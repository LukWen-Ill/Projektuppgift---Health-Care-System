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
    public User(int userID, string username, string password, Role userRole, Location assignedLocation, Region assignedRegion)
    // When a new User is created the variables taken in are UserID, Username, Password.
    {
        UserID = userID;
        Username = username;
        Password = password;
        UserRole = userRole;
        AssignedLocation = assignedLocation;
        AssignedRegion = assignedRegion;
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
    public string ToCsv()
    {
        return $"{UserID},{Username},{Password},{UserRole},{AssignedLocation},{AssignedRegion}";
    }
    public static User FromCsv(string line)
    {
        string[] var = line.Split(','); // saves each varible in string array

        if (var.Length < 6)
            return null;

        Role role = (Role)Enum.Parse(typeof(Role), var[3]);
        Location location = (Location)Enum.Parse(typeof(Location), var[4]);
        Region region = (Region)Enum.Parse(typeof(Region), var[5]);

        return new User(id, var[1], var[2], role, location, region);


    }
}