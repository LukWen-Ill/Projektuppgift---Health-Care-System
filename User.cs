using System.Security;

namespace App;
// User - A created user
class User
{
    public int UserId;

    public string Username;

    public string Password;

    public Permission permission;

    public User(int userId, string username, string password, Permission permissions)
    {
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