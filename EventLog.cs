namespace App;

class EventLog
{

    public DateTime Timestamp;
    public int UserID;
    public User.Role Role;
    public EventType Category;
    public int Target;
    public string? Description;

    public EventLog(DateTime timestamp, int userId, User.Role role, EventType category, int target, string? description)
    {
        Timestamp = timestamp;
        UserID = userId;
        Role = role;
        Category = category;
        Target = target;
        Description = string.IsNullOrWhiteSpace(description) ? "No description" : description; // no description is set, this will set defaulted
    }

    public enum EventType
    {
        UserLogin,
        UserLogout,
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
        User.Role role = (User.Role)Enum.Parse(typeof(User.Role), col[3]);
        EventType eventType = (EventType)Enum.Parse(typeof(EventType), col[4]);


        return new EventLog(timestamp, userID, role, eventType, targetID, col[5]);
    }
    // DateTime.Now

}