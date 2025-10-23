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
    {   // funktionen tar in parametrar: inloggad användare, en lista på alla users och var i filhanteringen som listan är sparad

        // Visar en lista på alla requested registrations
        // skriver ut en lista med alla som har rollen User
        Console.WriteLine("List of registration requests");
        foreach (User user in users)
        {
            if (user.UserRole == Role.User)
            {
                Console.WriteLine($"UserID: {user.UserID}, Username: {user.Username}\n");
            }
        }
        //

        // Kollar om user får lov att accept eller deny registration requests
        if (activeUser.TryPermission(Permission.AcceptPatientRegistrations) || activeUser.TryPermission(Permission.DenyPatientRegistrations))
        {
            // Frågar admin om ett id på den personen som du vill acceptera eller deny
            Console.Write("Chose an id: ");

            // Läser in vad användaren skrev in.
            string input_userid = Console.ReadLine();

            // Sedan gör om från string till en int
            int.TryParse(input_userid, out int userid);

            bool user_found = false;
            // Loopar igenom våra användare i vår list och matchar ID med det som admin skrev (siffran). 
            foreach (User user in users)
            {
                if (user.UserID == userid && user.UserRole == Role.User)
                {
                    user_found = true;

                    // Menu based on Permissions
                    // Sedan frågar om admin om de vill acceptera eller deny request
                    if (activeUser.TryPermission(Permission.AcceptPatientRegistrations)) { Console.Write("Accept registration? (A)"); }

                    else if (activeUser.TryPermission(Permission.AcceptPatientRegistrations) && activeUser.TryPermission(Permission.DenyPatientRegistrations)) { Console.Write("Accept/Deny registration? (A/D)"); }

                    else if (activeUser.TryPermission(Permission.DenyPatientRegistrations)) { Console.Write("Deny registration? (D)"); }
                
                    // skriver ut den valda personens ID och användarnamn
                    Console.WriteLine($"User ID: {user.UserID}, Name: {user.Username}");

                    // läser in A/D
                    string input_accept_deny = Console.ReadLine();

                    // Om du skriver in "A"
                    if (input_accept_deny == "A" && activeUser.TryPermission(Permission.AcceptPatientRegistrations))
                    {
                        user.UserRole = Role.Patient; // ändrar rollen på den som frågar om registration till Patient
                        user.Permissions.Add(Permission.UserLogin); // lägger till permissions som en patient ska ha. Nu kan dem logga in.
                        FileHandler.Write(users, path); // updaterar CSV filen med Users Så att rollen är patient
                        EventLog.Eventlogger(activeUser, EventType.RegistrationAccepted, user); // log event

                        Console.WriteLine($"\nUser ID: {user.UserID}, Name: {user.Username} Registration Complete");
                        break;
                    }

                    // Om du skriver in "D"
                    else if (input_accept_deny == "D" && activeUser.TryPermission(Permission.DenyPatientRegistrations))
                    {
                        user.UserRole = Role.Denied; // ändrar rollen på den som frågar om registration till Denied
                        FileHandler.Write(users, path); // update CSV filen
                        EventLog.Eventlogger(activeUser, EventType.RegistrationDenied, user); // log event

                        Console.WriteLine($"\nUser ID: {user.UserID}, Name: {user.Username} Registration Denied");
                        break;
                    }
                    // Om du skriver in vad som helst annat
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