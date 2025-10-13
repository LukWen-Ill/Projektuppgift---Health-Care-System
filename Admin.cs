using System.Dynamic;

namespace App;

class Admin : User
{
    public Permission AdminPermission;
    public Region AssignedRegion;
    public Location AssignedLocation;

    public Admin(int userID, string username, string password, Permission permissions)
    : base(userID, username, password)
    {
        AdminPermission = permissions;
        UserRole = Role.Admin;                  // Hardcoded    role       - Admin
        AssignedRegion = Region.Region;         // Hardcoded    region     - Region
        AssignedLocation = Location.Hospital;   // Hardcoded    location   - Hospital


    }
    public enum Region
    {
        Region = 1,
    }
}