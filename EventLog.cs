namespace App;

class EventLog
{

    public DateTime Timestamp;
    public int UserID;
    public User.Role Role;
    public EventType Category;
    public int Target;
    public string? Description;

    public EventLog(int userId, User.Role role, EventType category, int target, string? description)
    {
        Timestamp = DateTime.Now;
        UserID = userId;
        Role = role;
        Category = category;
        Target = target;
        Description = string.IsNullOrWhiteSpace(description) ? "No description" : description;
    }


    public enum EventType
    {
        UserLogin,
        UserLogout,
    }
    public string ToCsv()
    {
        string date = Timestamp.ToString("yyyy-MM-dd");
        return $"{date},{UserID},{Role},{Category},{Target},{Description}";
    }
}