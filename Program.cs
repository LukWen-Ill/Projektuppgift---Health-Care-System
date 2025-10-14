using App;

// creates Users.csv.
string path_userCsv = FileHandler.GetDataPath("Users.csv");

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

using (StreamWriter writer = new StreamWriter(path_userCsv, true))
{
    foreach (User user in users)
    {
        writer.WriteLine(user.ToCsv());
    }
}

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
foreach (User user in users)
{
    Console.WriteLine(user.Username);
}


int userID_count = 1; // DEV: should call on filereader for Count.csv

User? active_user = null;

while (true)
{
    Console.WriteLine("1. register");
    Console.WriteLine("2. login");

    string? input = Console.ReadLine();

    if (active_user == null && input == "1")
    {
        Console.Write("enter username: ");
        string? u_input = Console.ReadLine();
        Console.Write("enter password: ");
        string? p_input = Console.ReadLine();

        if (!String.IsNullOrWhiteSpace(u_input) && !String.IsNullOrWhiteSpace(p_input)) // BEK av MAX
        {
            // User user = new User(Count.RegisterUser(userID_count), u_input, p_input, )User.Role.User;
            // users.Add(user);
            Console.WriteLine("user added");
        }
        else
        {
            Console.WriteLine("invalid input");
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
            }
        }
    }
}