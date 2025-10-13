namespace App;
// User class - A created user
class User
{
    public int UserID;
    public string Username;
    public string Password;
    public Permission permission;

    //  Constructor
    public User(int userID, string username, string password, Permission permissions)
    {
        UserID = userID;
        Username = username;
        Password = password;
        permission = permissions;
    }

    public enum Location
    {
        Hospital = 1,
    }

    public enum Role
    {
        User,
        Admin,
        Staff,
        Patient,
    }
}