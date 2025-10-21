using System.Security;
using App;

// creates Users.csv.
string path_userCsv = FileHandler.GetDataPath("Users.csv");

// creates Events.csv.
string path_EventLog = FileHandler.GetDataPath("Events.csv");


// create hardcoded users.
// User testUser = new User(1, "Lukas", "1", User.Role.Admin, User.Location.Hospital, User.Region.Region);
// User testUser1 = new User(1, "Lukas", "1", User.Role.Admin, User.Location.Hospital, User.Region.Region);
// User testUser2 = new User(2, "Anna", "2", User.Role.User, User.Location.Hospital, User.Region.Region);
// User testUser3 = new User(3, "Erik", "3", User.Role.Staff, User.Location.Hospital, User.Region.Region);
// User testUser4 = new User(4, "Maria", "4", User.Role.Patient, User.Location.Hospital, User.Region.Region);
// User testUser5 = new User(5, "Oskar", "5", User.Role.User, User.Location.Hospital, User.Region.Region);
//

// two hardcoded user lists
// List<User> testUsers = new() { testUser1, testUser2, testUser3, testUser4, testUser5 };
List<User> users = new List<User>();
// users.Add(testUser);
//

// reads from Users.csv and adds list.
<<<<<<< HEAD
using (StreamReader reader = new StreamReader(path_userCsv));
{
    string? line;

    while ((line = reader.ReadLine()) != null)
    {
        User? user = User.FromCsv(line);
        users.Add(user);
    }
}

// writes from list to Users.csv
using (StreamWriter writer = new StreamWriter(path_userCsv))
{
    foreach (User user in users)
    {
        writer.WriteLine(user.ToCsv());
    }
}
=======
FileHandler.Read(users, path_userCsv);

// writes from list to Users.csv
FileHandler.Write(users, path_userCsv);

>>>>>>> c4a33cd4ea31b0d96493012d90957d9b11401ca8

User? active_user = null;


while (true)
{
    if (active_user == null)
    {
        Console.WriteLine("1. register");
        Console.WriteLine("2. login");

        string? input = Console.ReadLine();

        // Register
        if (input == "1")
        {
<<<<<<< HEAD
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
                    {

                        User user = new User(userID_count, u_input, p_input, Role.User, Location.Hospital, Region.Region);
                        users.Add(user);
                        EventLog.Eventlogger(active_user, EventType.RegistrationRequested);
                        Console.WriteLine("user added, ID: " + userID_count);
                    }
                    // counter for UserID
                    userID_count++;
                    File.WriteAllText(path_countTxt, userID_count.ToString());

                    // writes from list to Users.csv
                    using (StreamWriter writer = new StreamWriter(path_userCsv))
                    {
                        foreach (User user in users)
                        {
                            writer.WriteLine(user.ToCsv());
                        }
                    }
                }
                else
                {
                    Console.WriteLine("invalid input");
                }
            }
=======
            User.RegisterNewUser(active_user, users, path_userCsv, Role.User);
>>>>>>> c4a33cd4ea31b0d96493012d90957d9b11401ca8
        }

        // Login
        if (input == "2")
        {
            Console.Write("enter username: ");
            string? u_input = Console.ReadLine();
            Console.Write("enter password: ");
            string? p_input = Console.ReadLine();

            active_user = User.TryLogin(active_user, u_input, p_input, users);
        }
    }

    // Logged in
    else if (active_user != null)
    {
        if (active_user.UserRole == Role.User)
        {
<<<<<<< HEAD
            // Features to DEV:
            // As a user, I need to be able to request registration as a patient.


        }
        else if (active_user.UserRole == Role.Admin)
        {
            Console.WriteLine($"you are logged in as: {Role.Admin}");

            Console.WriteLine("Handle the permission system, in fine granularity");


            // Assign admins to certain regions
            // Handle registrations
            // Add locations
            // Create accounts for personnel
            // View a list of who has permission to what
            // Accept user registration as patients
            // Deny user registration as patients


        }
        else if (active_user.UserRole == Role.Staff)
        {
            Console.WriteLine($"you are logged in as: {Role.Staff}");

            // View a patient's journal entries
            // Mark journal entries with levels of read permissions(Each journal entry has a simple boolean — for example IsSensitive = true / false.
            // Personnel either have CanViewSensitive = true / false)
            // Register appointments
            // Modify appointments
            // Approve appointment requests
            // View the schedule of a location

            Console.WriteLine($"\"logout\"");
            if (Console.ReadLine() == "logout")
            {
                active_user = null;

            }
        }

        
        else if (active_user.UserRole == Role.Patient)
        {
            Console.WriteLine($"you are logged in as: {Role.Patient}");

            Console.WriteLine($"\"logout\"");
            if (Console.ReadLine() == "logout")
            {
                active_user = null;
            }
=======
            case Role.Admin:
                RoleMenuService.ShowPermissionMenu_Admin(active_user, users, path_userCsv);
                break;

            case Role.Staff:
                RoleMenuService.ShowPermissionMenu_Staff(active_user);
                break;

            case Role.Patient:
                RoleMenuService.ShowPermissionMenu_Patient(active_user);
                break;
>>>>>>> c4a33cd4ea31b0d96493012d90957d9b11401ca8
        }
        active_user = null;
    }


    

     


}
/*Console.WriteLine("1. ViewPatientJournalEntries");
        Console.WriteLine("2. MarkSensitiveEntries");
        Console.WriteLine("3. ViewSensitiveEntrie");
        Console.WriteLine("4. RegisterAppointments");
        Console.WriteLine("5. ModifyAppointments");
        Console.WriteLine("6. ApproveAppointmentRequests");
        Console.WriteLine("7. ViewLocationSchedule");
        Console.WriteLine("7. AcceptPatientRegistrations");
        Console.WriteLine("7. DenyPatientRegistrations");
        Console.WriteLine("7. HandleRegistrations");
        Console.WriteLine("7. CreatePersonnelAccounts");
        Console.WriteLine("7. AddLocations");
        Console.WriteLine("7. AssignAdminsToRegions");
        Console.WriteLine("7. ViewPermissionOverview");
        Console.WriteLine("7. HandlePermissionSystem");
        string? input = Console.ReadLine() ?? "";
        switch (input) // Switchen matchar numret och kollar rätt permission via ActiveUserHasPermission().
        //Funktionen returnerar true/false baserat på active_user.Permissions.
        {
            case "1": 
            if (ActiveUserHasPermission(StaffPermission.ViewPatientJournalEntries))
                Console.WriteLine("You CAN view patient journals!");
            else
                Console.WriteLine("You CANNOT view patient journals!");
                break;
            case "2":
            if (ActiveUserHasPermission(StaffPermission.MarkSensitiveEntries))
                Console.WriteLine("You CAN mark sensitive entries!");
            else
                Console.WriteLine("You CANNOT mark sensitive entries!");
            break;

        case "3":
            if (ActiveUserHasPermission(StaffPermission.ViewSensitiveEntries))
                Console.WriteLine("You CAN view sensitive entries!");
            else
                Console.WriteLine("You CANNOT view sensitive entries!");
            break;

        case "4":
            if (ActiveUserHasPermission(StaffPermission.RegisterAppointments))
                Console.WriteLine("You CAN register appointments!");
            else
                Console.WriteLine("You CANNOT register appointments!");
            break;

        case "5":
            if (ActiveUserHasPermission(StaffPermission.ModifyAppointments))
                Console.WriteLine("You CAN modify appointments!");
            else
                Console.WriteLine("You CANNOT modify appointments!");
            break;

        case "6":
            if (ActiveUserHasPermission(StaffPermission.ApproveAppointmentRequests))
                Console.WriteLine("You CAN approve appointment requests!");
            else
                Console.WriteLine("You CANNOT approve appointment requests!");
            break;

        case "7":
            if (ActiveUserHasPermission(StaffPermission.ViewLocationSchedule))
                Console.WriteLine("You CAN view location schedule!");
            else
                Console.WriteLine("You CANNOT view location schedule!");
            break;

        // Admin-permissions
        case "8":
            if (ActiveUserHasPermission(AdminPermission.AcceptPatientRegistrations))
                Console.WriteLine("You CAN accept patient registrations!");
            else
                Console.WriteLine("You CANNOT accept patient registrations!");
            break;

        case "9":
            if (ActiveUserHasPermission(AdminPermission.DenyPatientRegistrations))
                Console.WriteLine("You CAN deny patient registrations!");
            else
                Console.WriteLine("You CANNOT deny patient registrations!");
            break;

        case "10":
            if (ActiveUserHasPermission(AdminPermission.HandleRegistrations))
                Console.WriteLine("You CAN handle registrations!");
            else
                Console.WriteLine("You CANNOT handle registrations!");
            break;

        case "11":
            if (ActiveUserHasPermission(AdminPermission.CreatePersonnelAccounts))
                Console.WriteLine("You CAN create personnel accounts!");
            else
                Console.WriteLine("You CANNOT create personnel accounts!");
            break;

        case "12":
            if (ActiveUserHasPermission(AdminPermission.AddLocations))
                Console.WriteLine("You CAN add locations!");
            else
                Console.WriteLine("You CANNOT add locations!");
            break;

        case "13":
            if (ActiveUserHasPermission(AdminPermission.AssignAdminsToRegions))
                Console.WriteLine("You CAN assign admins to regions!");
            else
                Console.WriteLine("You CANNOT assign admins to regions!");
            break;

        case "14":
            if (ActiveUserHasPermission(AdminPermission.ViewPermissionOverview))
                Console.WriteLine("You CAN view permission overview!");
            else
                Console.WriteLine("You CANNOT view permission overview!");
            break;

        case "15":
            if (ActiveUserHasPermission(AdminPermission.HandlePermissionSystem))
                Console.WriteLine("You CAN handle permission system!");
            else
                Console.WriteLine("You CANNOT handle permission system!");
            break;

        default:
            Console.WriteLine("Invalid input.");
            break;
        }*/
