using System.Security;
using App;

// creates Users.csv.
string path_userCsv = FileHandler.GetDataPath("Users.csv");
// creates Count.Txt.
string path_countTxt = FileHandler.GetDataPath("Count.txt");

List<User> users = new List<User>();

// gets count from Count.txt and converts to int.
string s_userID_count = File.ReadAllText(path_countTxt);
int.TryParse(s_userID_count, out int userID_count);


// reads from Users.csv and adds list.
using StreamReader reader = new StreamReader(path_userCsv);
{
    string line;

    while ((line = reader.ReadLine()) != null)
    {
        User? user = User.FromCsv(line);
        users.Add(user);
    }
}

// writes from list to Users.csv
using (StreamWriter writer = new StreamWriter(path_userCsv))
{
    foreach (User user in users)
    {
        writer.WriteLine($"{user.ToCsv()}");
    }
}



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
            bool is_viable = true;
            Console.Write("enter username: ");
            string? u_input = Console.ReadLine();

            foreach (User user in users)
            {
                if (user.Username == u_input)
                {
                    Console.WriteLine($"Username: {u_input} is already in use.");

                    Console.WriteLine("press enter to continue..");
                    Console.ReadLine();

                    is_viable = false;
                    break;
                }
            }
            if (is_viable)
            {
                Console.Write("enter password: ");
                string? p_input = Console.ReadLine();

                if (!String.IsNullOrWhiteSpace(u_input) && !String.IsNullOrWhiteSpace(p_input)) // Godkänd av MAX
                {
                    {

                        User user = new User(userID_count, u_input, p_input, Role.User, Location.Hospital, Region.Region);
                        users.Add(user);
                        EventLog.Eventlogger(user, EventType.RegistrationRequested);
                        Console.WriteLine("user added, ID: " + userID_count);
                    }
                    // counter for UserID
                    userID_count++;
                    File.WriteAllText(path_countTxt, userID_count.ToString());

                    // writes from list to Users.csv
                    using (StreamWriter writer = new StreamWriter(path_userCsv))
                    {
                        foreach (User user in users)
                        {
                            writer.WriteLine(user.ToCsv());
                        }
                    }
                }
                else
                {
                    Console.WriteLine("invalid input");
                }
            }
        }

        // Login
        if (input == "2")
        {

            Console.Write("enter username: ");
            string? u_input = Console.ReadLine();
            Console.Write("enter password: ");
            string? p_input = Console.ReadLine();

            foreach (User user in users)
            {
                if (u_input == user.Username && p_input == user.Password && user.TryPermission(Permission.UserLogin))
                {

                    active_user = user;
                    EventLog.Eventlogger(active_user, EventType.UserLogin);
                    Console.WriteLine("login sucessful");

                    break;

                }
            }
            if (active_user == null)
            {
                Console.WriteLine("login failed. Press Enter to continue");
                Console.ReadLine();
            }
        }
    }

    // Logged in
    else if (active_user != null)
    {
        switch (active_user.UserRole)
        {
            case Role.Admin:
                RoleMenuService.ShowPermissionMenu(active_user);
                break;

            case Role.Staff:
                RoleMenuService.ShowPermissionMenu(active_user);
                break;

            case Role.Patient:
                RoleMenuService.ShowPermissionMenu(active_user);
                break;
        }
    }
}
