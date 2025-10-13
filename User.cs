namespace App;
// User class - A new user.
class User
{
    // All Users have: 
    // UserID. will be set dynamicly
    // Username. 
    // Password.
    // Role is defaulted to Role.User.
    // Location is defaulted to Hospital.
    // Region is defaulted to Region.
    public int UserID; // DEV: needs to be autoset via function GetUserID() (måste va en float())
    public string Username;
    public string Password;
    public Role UserRole;
    public Location AssignedLocation;
    public Region AssignedRegion;

    //  Constructor
    public User(string username, string password)
    // When a new User is created the variables taken in are UserID, Username, Password.
    {
        UserID = 1; // DEV hardcoded until function SetID() done
        Username = username;
        Password = password;
        UserRole = Role.User;                   // User default get role User.
        AssignedLocation = Location.Hospital;   // Hardcoded location to Hospital.
        AssignedRegion = Region.Region;         // Hardcode Region

    }

    public enum Location // Locations can be added
    {
        Hospital = 1,
    }
    public enum Region // Locations can be added
    {
        Region = 1,
    }

    public enum Role // Set list of Roles.
    {
        User,
        Admin,
        Staff,
        Patient,
    }
}