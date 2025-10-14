using App;

// creates Users.csv.
string path_userCsv = FileHandler.GetDataPath("Users.csv");
// creates Count.Txt.
string path_countTxt = FileHandler.GetDataPath("Count.txt");

// creates Events.csv.
string path_EventLog = FileHandler.GetDataPath("Events.csv");


// create hardcoded users.
// User testUser = new User(1, "Lukas", "1", User.Role.Admin, User.Location.Hospital, User.Region.Region);
// User testUser1 = new User(1, "Lukas", "1", User.Role.Admin, User.Location.Hospital, User.Region.Region);
// User testUser2 = new User(2, "Anna", "2", User.Role.User, User.Location.Hospital, User.Region.Region);
// User testUser3 = new User(3, "Erik", "3", User.Role.Staff, User.Location.Hospital, User.Region.Region);
// User testUser4 = new User(4, "Maria", "4", User.Role.Patient, User.Location.Hospital, User.Region.Region);
// User testUser5 = new User(5, "Oskar", "5", User.Role.User, User.Location.Hospital, User.Region.Region);
//

// two hardcoded user lists
// List<User> testUsers = new() { testUser1, testUser2, testUser3, testUser4, testUser5 };
List<User> users = new List<User>();
// users.Add(testUser);
//

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
        writer.WriteLine(user.ToCsv());
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

        if (active_user == null && input == "1")
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

                if (!String.IsNullOrWhiteSpace(u_input) && !String.IsNullOrWhiteSpace(p_input)) // BEK av MAX
                {
                    {
                        User user = new User(userID_count, u_input, p_input, User.Role.User, User.Location.Hospital, User.Region.Region);
                        users.Add(user);
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

        if (active_user == null && input == "2")
        {

            Console.Write("enter username: ");
            string? u_input = Console.ReadLine();
            Console.Write("enter password: ");
            string? p_input = Console.ReadLine();

            foreach (User user in users)
            {
                if (u_input == user.Username && p_input == user.Password)
                {
                    active_user = user;
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
    else if (active_user != null)
    {
        if (active_user.UserRole == User.Role.User)
        {
            // Features to DEV:
            // As a user, I need to be able to request registration as a patient.
            Console.WriteLine($"you are logged in as: {User.Role.User}");

            Console.WriteLine($"\"logout\"");
            if (Console.ReadLine() == "logout")
            {
                active_user = null;

            }


        }
        else if (active_user.UserRole == User.Role.Admin)
        {
            Console.WriteLine($"you are logged in as: {User.Role.Admin}");
            Console.WriteLine($"\"logout\"");
            if (Console.ReadLine() == "logout")
            {
                active_user = null;

            }


        }
        else if (active_user.UserRole == User.Role.Staff)
        {
            Console.WriteLine($"you are logged in as: {User.Role.Staff}");

            Console.WriteLine($"\"logout\"");
            if (Console.ReadLine() == "logout")
            {
                active_user = null;

            }
        }
        else if (active_user.UserRole == User.Role.Patient)
        {
            Console.WriteLine($"you are logged in as: {User.Role.Patient}");

            Console.WriteLine($"\"logout\"");
            if (Console.ReadLine() == "logout")
            {
                active_user = null;


            }
        }
    }
}
