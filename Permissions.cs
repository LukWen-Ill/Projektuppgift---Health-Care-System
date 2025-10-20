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

    public static void HandleRegistrations(User activeUser)
    {
        Console.WriteLine("Handling registrations...");
        // TODO: implement logic¨
          public static void HandleRegistrations(User activeUser, List<User> users)
    {
        Console.WriteLine("Handling registrations...");
 
        // Loopar genom alla användare i listan och skriver ut de som har rollen "user
        foreach (User user in users)
        {
            if (user.UserRole == Role.User)
            {
                Console.WriteLine("You are a User" + user.Username + "and your id is: " + user.UserID);
                Console.WriteLine($"You are a User {user.Username} and your id is: {user.UserID}");
            }
        }
       
        // Frågar admin om ett id och sedan konverterar det till en int
        Console.WriteLine("Chose an id ");
        string input_userid = Console.ReadLine();
        int.TryParse(input_userid, out int userid);
 
 
       // Loopar igenom våra användare i vår list och matchar idt med det som admin skrev. Sedan frågar om admin om de vill acceptera eller deny request
        foreach (User user in users)
        {
            if (user.UserID == userid && user.UserRole == Role.User)
            {
                Console.WriteLine($"User: {user.Username}, ID: {user.UserID}");
                Console.WriteLine("Accept or Deny registration?");
                string input_userstatus = Console.ReadLine();
                switch (input_userstatus)
                {
                    case "Accept":
                        user.UserRole = Role.Patient;
                        break;
                    case "Deny":
                        user.UserRole = Role.Denied; 
                        break;
                    default:
                        break;
                }
            }
            else
            {
                Console.WriteLine("No matching user found");
            }
           
        }
        // EventLog.Eventlogger(activeUser, EventLog.EventType.HandleRegistrations);
    }
 
        // EventLog.Eventlogger(activeUser, EventLog.EventType.HandleRegistrations)

    public static void AddLocation(User activeUser)
    {
        Console.WriteLine("Adding new location...");
        // TODO: implement logic
        // EventLog.Eventlogger(activeUser, EventLog.EventType.LocationAdded);
    }

    public static void CreatePersonnel(User activeUser)
    {
        Console.WriteLine("Creating personnel account...");
        // TODO: implement logic
        // EventLog.Eventlogger(activeUser, EventLog.EventType.PersonnelAccountCreated);
    }

    public static void ViewPermissionOverview(User activeUser)
    {
        Console.WriteLine("Viewing permission overview...");
        // TODO: implement logic
        // EventLog.Eventlogger(activeUser, EventLog.EventType.PermissionViewed);
    }

    public static void AcceptRegistration(User activeUser)
    {
        Console.WriteLine("Accepting patient registration...");
        // TODO: implement logic
        // EventLog.Eventlogger(activeUser, EventLog.EventType.RegistrationAccepted);
    }

    public static void DenyRegistration(User activeUser)
    {
        Console.WriteLine("Denying patient registration...");
        // TODO: implement logic
        // EventLog.Eventlogger(activeUser, EventLog.EventType.RegistrationDenied);
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