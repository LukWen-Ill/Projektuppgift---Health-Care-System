using System.Security;
using App;

// creates Users.csv.
string path_userCsv = FileHandler.GetDataPath("Users.csv");

List<User> users = new List<User>();

// reads from Users.csv and adds list.
FileHandler.Read(users, path_userCsv);

// writes from list to Users.csv
FileHandler.Write(users, path_userCsv);


User? active_user = null;


while (true)
{
    if (active_user == null)
    {
        Console.WriteLine("1. register");
        Console.WriteLine("2. login");

        string? input = Console.ReadLine();

        // Register
        if (input == "1")
        {
            User.RegisterNewUser(users, path_userCsv);
        }

        // Login
        if (input == "2")
        {
            Console.Write("enter username: ");
            string? u_input = Console.ReadLine();
            Console.Write("enter password: ");
            string? p_input = Console.ReadLine();

            active_user = User.TryLogin(active_user, u_input, p_input, users);       
        }
    }

    // Logged in
    else if (active_user != null)
    {
        switch (active_user.UserRole)
        {
            case Role.Admin:
                RoleMenuService.ShowPermissionMenu_Admin(active_user, users, path_userCsv);
                break;

            case Role.Staff:
                RoleMenuService.ShowPermissionMenu_Staff(active_user);
                break;

            case Role.Patient:
                RoleMenuService.ShowPermissionMenu_Patient(active_user);
                break;
        }
    }
}
