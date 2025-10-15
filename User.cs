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
    {//       Interpolation transform any datatype to string.
        return $"{UserID},{Username},{Password},{UserRole},{AssignedLocation},{AssignedRegion}";
    }
    public static User FromCsv(string string_of_users)
    {
        string[] col = string_of_users.Split(','); // saves each varible in string array.

        // check for correct data handling.
        if (col.Length != 6)
        {
            return null;
        }

        // parse string to int.
        int.TryParse(col[0], out int userID);

        // parse string to enum
        Role role = (Role)Enum.Parse(typeof(Role), col[3]);
        Location location = (Location)Enum.Parse(typeof(Location), col[4]);
        Region region = (Region)Enum.Parse(typeof(Region), col[5]);

        return new User(userID, col[1], col[2], role, location, region);
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
}