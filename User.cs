using System.Security;

namespace App;
// User class - A new user.
class User
{
    // All Users have: 
    // UserID. will be set dynamicly
    // Username. 
    // Password.
    // Role is defaulted to Role.User.
    // Location is defaulted to Hospital.
    // Region is defaulted to Region.
    public int UserID; // DEV: needs to be autoset via function GetUserID() (måste va en float())
    public string Username;
    public string Password;
    public Role UserRole;
    public Location AssignedLocation;
    public Region AssignedRegion;
    public List<Permission> Permissions = new List<Permission>(); // creates a empty list of permissions when user is created.

    //  Constructor
    public User(int userID, string username, string password, Role userRole, Location assignedLocation, Region assignedRegion)
    // When a new User is created the variables taken in are UserID, Username, Password
    {
        UserID = userID;
        Username = username;
        Password = password;
        UserRole = userRole;
        AssignedLocation = assignedLocation;
        AssignedRegion = assignedRegion;
    }

    public string ToCsv()
    {//     Interpolation transform any datatype to string.
     //     
        return $"{UserID},{Username},{Password},{UserRole},{AssignedLocation},{AssignedRegion};{FileHandler.PermissionsToString(Permissions)}";
    }

    public static User FromCsv(string string_of_users)
    {
        string[] data = string_of_users.Split(';');
        string[] data_user = data[0].Split(','); // saves each varible in string array.
        string[] data_permission = data[1].Split(','); // saves each varible in string array.

        // check for correct data handling.
        if (data_user.Length != 6)
        {
            return null;
        }

        // parse string to int.
        int.TryParse(data_user[0], out int userID);

        // parse string to enum
        Role role = (Role)Enum.Parse(typeof(Role), data_user[3]);
        Location location = (Location)Enum.Parse(typeof(Location), data_user[4]);
        Region region = (Region)Enum.Parse(typeof(Region), data_user[5]);

        User user = new User(userID, data_user[1], data_user[2], role, location, region);

        {
            for (int i = 0; i < data_permission.Length; ++i)
            {
                if (!String.IsNullOrWhiteSpace(data_permission[i]))
                    user.Permissions.Add((Permission)Enum.Parse(typeof(Permission), data_permission[i]));
            }
        }

        return user;
    }
    public bool TryPermission(Permission permission)
    {
        bool result = false;
        foreach (Permission p in Permissions)
        {
            if (p == permission)
            {
                result = true;
                break;
            }
        }
        return result;
    }
    public void ShowPermission()
    {
        for (int i = 0; i < Permissions.Count; ++i)
        {
            Console.Write($"{Permissions[i]}, ");
        }
    }
    public static User TryLogin(User active_user, string username, string password, List<User> users)
    {
        foreach (User user in users)
        {
            if (username == user.Username && password == user.Password && user.TryPermission(Permission.UserLogin))
            {
                active_user = user;
                EventLog.Eventlogger(active_user, EventType.UserLogin, active_user);
                Console.WriteLine("login sucessful. Press Enter to continue");
                Console.ReadLine();
                return active_user;
            }
        }
        Console.WriteLine("login failed. Press Enter to continue");
        Console.ReadLine();
        return active_user;
    }

    public static void RegisterNewUser(User? active_user, List<User> users, string path, Role role)
    {
        bool is_viable = true;
        Console.Write("enter username: ");
        string? u_input = Console.ReadLine();

        foreach (User user in users)
        {
            if (user.Username == u_input)
            {
                Console.WriteLine($"Username: {u_input} is already in use.");

                Console.WriteLine("press enter to continue..");
                Console.ReadLine();

                is_viable = false;
                break;
            }
        }
        if (is_viable)
        {
            Console.Write("enter password: ");
            string? p_input = Console.ReadLine();

            if (!String.IsNullOrWhiteSpace(u_input) && !String.IsNullOrWhiteSpace(p_input)) // Godkänd av MAX
            {
                int userID_count = FileHandler.Read_count();
                {

                    User user = new User(userID_count, u_input, p_input, role, Location.Hospital, Region.Region);
                    users.Add(user);
                    if (user.UserRole == Role.User)
                    {
                        EventLog.Eventlogger(user, EventType.RegistrationRequested, user);
                        Console.WriteLine("User added, ID: " + userID_count);
                    }
                    else if (user.UserRole == Role.Admin || user.UserRole == Role.Staff)
                    {
                        user.Permissions.Add(Permission.UserLogin);
                        EventLog.Eventlogger(active_user, EventType.PersonnelAccountCreated, user);
                        Console.WriteLine("Personnel account added, ID: " + userID_count);
                    }
                }
                // counter for UserID
                userID_count++;
                FileHandler.Write_count(userID_count);

                // writes from list to Users.csv
                FileHandler.Write(users, path);
            }
            else
            {
                Console.WriteLine("invalid input");
            }
        }
    }
}

enum Permission
{
    // UserPermissions
    UserLogin,
    ViewSchedule,

    // PatientPermissions
    ViewJournal,
    RequestAppointment,

    // StaffPermissions
    ViewPatientJournalEntries,      // View a patient's journal entries
    SetHiddenEntries,               // Mark journal entries with IsSensitive = true/false
    ViewHiddenEntries,              // Can view entries marked as sensitive
    RegisterAppointments,           // Register appointments
    ModifyAppointments,             // Modify appointments
    ApproveAppointmentRequests,     // Approve appointment requests
    ViewLocationSchedule,           // View the schedule of a location

    // AdminPermissions
    AcceptPatientRegistrations,     // Accept user registration as patients
    DenyPatientRegistrations,       // Deny user registration as patients
    HandleRegistrations,            // Handle registrations
    CreatePersonnelAccounts,        // Create accounts for personnel
    AddLocations,                   // Add locations
    AssignAdminsToRegions,          // Assign admins to certain regions
    ViewPermissionOverview,         // View a list of who has permission to what
    HandlePermissionSystem,         // Handle the permission system, in fine granularity
}
enum Location // Locations can be added // will be list in future
{
    Hospital,
}
enum Region
{
    Region,
}

enum Role // Set list of Roles.
{
    User,
    Admin,
    Staff,
    Patient,
    Denied,
}