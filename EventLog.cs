namespace App;

class EventLog
{

    public DateTime Timestamp;
    public int UserID;
    public Role Role;
    public EventType Category;
    public int Target;
    public string? Description;

    public EventLog(DateTime timestamp, int userId, Role role, EventType category, int target, string? description)
    {
        Timestamp = timestamp;
        UserID = userId;
        Role = role;
        Category = category;
        Target = target;
        Description = string.IsNullOrWhiteSpace(description) ? "No description" : description; // no description is set, this will set defaulted
    }




    public string ToCsv()
    {
        string date = Timestamp.ToString("G");
        return $"{date},{UserID},{Role},{Category},{Target},{Description}";
    }
    public static EventLog FromCsv(string string_of_events)
    {
        string[] col = string_of_events.Split(','); // saves each varible in string array.

        if (col.Length != 6) // check for correct data handling.
        {
            return null;
        }
        // parse string to datetime
        DateTime timestamp = DateTime.Parse(col[0]);

        // parse to int.
        int.TryParse(col[1], out int userID);
        int.TryParse(col[4], out int targetID);


        // parsing to enum
        Role role = (Role)Enum.Parse(typeof(Role), col[3]);
        EventType eventType = (EventType)Enum.Parse(typeof(EventType), col[4]);


        return new EventLog(timestamp, userID, role, eventType, targetID, col[5]);
    }
    // DateTime.Now

    public static void Eventlogger(User user, EventType type) // DEV: how do we log target?
    {
        if (type == EventType.UserLogin)
            FileHandler.LogEvent(new EventLog(DateTime.Now, user.UserID, user.UserRole, type, user.UserID, $"{user.Username} logged in"));

        else if (type == EventType.UserLogout)
            FileHandler.LogEvent(new EventLog(DateTime.Now, user.UserID, user.UserRole, type, user.UserID, $"{user.Username} logged out"));

        else if (type == EventType.PermissionModified)
            FileHandler.LogEvent(new EventLog(DateTime.Now, user.UserID, user.UserRole, type, 0, $"{user.Username} modified permissions"));

        else if (type == EventType.PermissionViewed)
            FileHandler.LogEvent(new EventLog(DateTime.Now, user.UserID, user.UserRole, type, 0, $"{user.Username} viewed permissions"));

        else if (type == EventType.AdminAssignedToRegion)
            FileHandler.LogEvent(new EventLog(DateTime.Now, user.UserID, user.UserRole, type, 0, $"{user.Username} assigned admin to region"));

        else if (type == EventType.RegistrationRequested)
            FileHandler.LogEvent(new EventLog(DateTime.Now, user.UserID, user.UserRole, type, user.UserID, $"{user.Username} requested registration"));

        else if (type == EventType.RegistrationAccepted)
            FileHandler.LogEvent(new EventLog(DateTime.Now, user.UserID, user.UserRole, type, 0, $"{user.Username} accepted registration"));

        else if (type == EventType.RegistrationDenied)
            FileHandler.LogEvent(new EventLog(DateTime.Now, user.UserID, user.UserRole, type, 0, $"{user.Username} denied registration"));

        else if (type == EventType.PersonnelAccountCreated)
            FileHandler.LogEvent(new EventLog(DateTime.Now, user.UserID, user.UserRole, type, 0, $"{user.Username} created a personnel account"));

        else if (type == EventType.LocationAdded)
            FileHandler.LogEvent(new EventLog(DateTime.Now, user.UserID, user.UserRole, type, 0, $"{user.Username} added a location"));

        else if (type == EventType.RegionAssigned)
            FileHandler.LogEvent(new EventLog(DateTime.Now, user.UserID, user.UserRole, type, 0, $"{user.Username} assigned a region"));

        else if (type == EventType.JournalViewed)
            FileHandler.LogEvent(new EventLog(DateTime.Now, user.UserID, user.UserRole, type, user.UserID, $"{user.Username} viewed a journal"));

        else if (type == EventType.JournalMarkedSensitive)
            FileHandler.LogEvent(new EventLog(DateTime.Now, user.UserID, user.UserRole, type, 0, $"{user.Username} marked a journal sensitive"));

        else if (type == EventType.JournalEntryCreated)
            FileHandler.LogEvent(new EventLog(DateTime.Now, user.UserID, user.UserRole, type, 0, $"{user.Username} created a journal entry"));

        else if (type == EventType.AppointmentRegistered)
            FileHandler.LogEvent(new EventLog(DateTime.Now, user.UserID, user.UserRole, type, 0, $"{user.Username} registered an appointment"));

        else if (type == EventType.AppointmentModified)
            FileHandler.LogEvent(new EventLog(DateTime.Now, user.UserID, user.UserRole, type, 0, $"{user.Username} modified an appointment"));

        else if (type == EventType.AppointmentApproved)
            FileHandler.LogEvent(new EventLog(DateTime.Now, user.UserID, user.UserRole, type, 0, $"{user.Username} approved an appointment"));

        else if (type == EventType.ScheduleViewed)
            FileHandler.LogEvent(new EventLog(DateTime.Now, user.UserID, user.UserRole, type, 0, $"{user.Username} viewed a schedule"));
    }


}
public enum EventType
{
    // authentication
    UserLogin,
    UserLogout,

    // permissions 
    PermissionModified,
    PermissionViewed,
    AdminAssignedToRegion,

    // registration
    RegistrationRequested,
    RegistrationAccepted,
    RegistrationDenied,
    PersonnelAccountCreated,

    // location 
    LocationAdded,
    RegionAssigned,

    // journal
    JournalViewed,
    JournalMarkedSensitive,
    JournalEntryCreated,

    // appointment & schedule
    AppointmentRegistered,
    AppointmentModified,
    AppointmentApproved,
    ScheduleViewed
}