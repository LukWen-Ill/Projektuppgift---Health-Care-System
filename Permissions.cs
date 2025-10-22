namespace App;

class Permissions
{
    public static void ManagePermissions(User activeUser)
    {
        Console.WriteLine("Managing permission system...");
        // TODO: implement logic
        // EventLog.Eventlogger(activeUser, EventLog.EventType.PermissionModified);
    }

    public static void AssignAdminToRegion(User activeUser)
    {
        Console.WriteLine("Assigning admin to region...");
        // TODO: implement logic
        // EventLog.Eventlogger(activeUser, EventLog.EventType.AdminAssignedToRegion);
    }
    public static void HandleRegistrations(User activeUser, List<User> users, string path)
    {
        // Visar en lista på alla requested registrations
        Console.WriteLine("List of registration requests");
        foreach (User user in users)
        {
            if (user.UserRole == Role.User)
            {
                Console.WriteLine($"UserID: {user.UserID}, Username: {user.Username}\n");
            }
        }

        // Kollar om user får accept eller deny registration requests
        if (activeUser.TryPermission(Permission.AcceptPatientRegistrations) || activeUser.TryPermission(Permission.DenyPatientRegistrations))
        {
            // Frågar admin om ett id och sedan konverterar det till en int
            Console.Write("Chose an id: ");
            string input_userid = Console.ReadLine();
            int.TryParse(input_userid, out int userid);

            // Loopar igenom våra användare i vår list och matchar idt med det som admin skrev. Sedan frågar om admin om de vill acceptera eller deny request
            bool user_found = false;
            foreach (User user in users)
            {
                if (user.UserID == userid && user.UserRole == Role.User)
                {
                    user_found = true;
                    // Menu based on Permissions
                    if (activeUser.TryPermission(Permission.AcceptPatientRegistrations)) { Console.Write("Accept"); }
                    if (activeUser.TryPermission(Permission.AcceptPatientRegistrations) && activeUser.TryPermission(Permission.DenyPatientRegistrations)) { Console.Write(" or "); }
                    if (activeUser.TryPermission(Permission.DenyPatientRegistrations)) { Console.Write("Deny"); }
                    Console.Write(" registration? (");
                    if (activeUser.TryPermission(Permission.AcceptPatientRegistrations)) { Console.Write("A"); }
                    if (activeUser.TryPermission(Permission.AcceptPatientRegistrations) && activeUser.TryPermission(Permission.DenyPatientRegistrations)) { Console.Write("/"); }
                    if (activeUser.TryPermission(Permission.DenyPatientRegistrations)) { Console.Write("D"); }
                    Console.WriteLine(")");
                    Console.WriteLine($"User ID: {user.UserID}, Name: {user.Username}");

                    string input_accept_deny = Console.ReadLine();

                    if (input_accept_deny == "A" && activeUser.TryPermission(Permission.AcceptPatientRegistrations))
                    {
                        user.UserRole = Role.Patient;
                        user.Permissions.Add(Permission.UserLogin);
                        FileHandler.Write(users, path); // update userlist
                        EventLog.Eventlogger(activeUser, EventType.RegistrationAccepted, user); // log event
                        Console.WriteLine($"\nUser ID: {user.UserID}, Name: {user.Username} Registration Complete");
                        break;
                    }
                    else if (input_accept_deny == "D" && activeUser.TryPermission(Permission.DenyPatientRegistrations))
                    {
                        user.UserRole = Role.Denied;
                        FileHandler.Write(users, path); // update userlist
                        EventLog.Eventlogger(activeUser, EventType.RegistrationDenied, user); // log event
                        Console.WriteLine($"\nUser ID: {user.UserID}, Name: {user.Username} Registration Denied");
                        break;
                    }
                    else
                        Console.WriteLine("cancelled");

                    break;
                }
            }
            if (!user_found)
            {
                Console.WriteLine("No matching user found");
            }
        }
        else
        {
            Console.WriteLine("Permission to accept or deny not found");

        }

    }

    public static void AddLocation(User activeUser)
    {
        Console.WriteLine("Adding new location...");
        // TODO: implement logic
        // EventLog.Eventlogger(activeUser, EventLog.EventType.LocationAdded);
    }

    public static void CreatePersonnel(User activeUser, List<User> users, string path, Role role)
    {
        if (activeUser.TryPermission(Permission.CreatePersonnelAccounts))
        {
            User.RegisterNewUser(activeUser, users, path, role);
        }
    }

    public static void ViewPermissionOverview(User activeUser)
    {
        Console.WriteLine("Viewing permission overview...");
        // TODO: implement logic
        // EventLog.Eventlogger(activeUser, EventLog.EventType.PermissionViewed);
    }

    public static void ViewPatientJournalEntries(User activeUser)
    {
        Console.WriteLine("Viewing patient journals...");
        // TODO: implement logic
        // EventLog.Eventlogger(activeUser, EventLog.EventType.JournalViewed);
    }

    public static void MarkJournalEntrySensitivity(User activeUser)
    {
        Console.WriteLine("Marking journal entry sensitivity...");
        // TODO: implement logic
        // EventLog.Eventlogger(activeUser, EventLog.EventType.JournalMarkedSensitive);
    }

    public static void RegisterAppointments(User activeUser)
    {
        Console.WriteLine("Registering new appointment...");
        // TODO: implement logic
        // EventLog.Eventlogger(activeUser, EventLog.EventType.AppointmentRegistered);
    }

    public static void ModifyAppointments(User activeUser)
    {
        Console.WriteLine("Modifying appointment...");
        // TODO: implement logic
        // EventLog.Eventlogger(activeUser, EventLog.EventType.AppointmentModified);
    }

    public static void ApproveAppointmentRequests(User activeUser)
    {
        Console.WriteLine("Approving appointment request...");
        // TODO: implement logic
        // EventLog.Eventlogger(activeUser, EventLog.EventType.AppointmentApproved);
    }

    public static void ViewLocationSchedule(User activeUser)
    {
        Console.WriteLine("Viewing location schedule...");
        // TODO: implement logic
        // EventLog.Eventlogger(activeUser, EventLog.EventType.ScheduleViewed);
    }
}