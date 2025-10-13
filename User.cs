namespace App;
// User class - A created user
class User
{
    public int UserID;
    public string Username;
    public string Password;


    //  Constructor
    public User(int userID, string username, string password)
    {
        UserID = userID;
        Username = username;
        Password = password;
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