namespace App;
// User class - A new user.
class User
// All Users have: 
// UserID.
// Username. 
// Password.
// Role is defaulted to Role.User.
// Location is defaulted to Location.Hospital.
{
    public int UserID;
    public string Username;
    public string Password;
    public Role UserRole;
    public Location AssignedLocation;


    //  Constructor
    public User(int userID, string username, string password)
    // When a new User is created the variables taken in are UserID, Username, Password.
    {
        UserID = userID;
        Username = username;
        Password = password;
        UserRole = Role.User                    // User default get role User.
        AssignedLocation = Location.Hospital;   // Hardcoded location to Hospital.

    }

    public enum Location // Locations can be added
    {
        Hospital = 1,
    }

    public enum Role // Set list of Roles.
    {
        User,
        Admin,
        Staff,
        Patient,
    }
}