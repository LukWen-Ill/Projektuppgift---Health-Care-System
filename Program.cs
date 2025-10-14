using App;

User testUser = new User(1, "Lukas", "1", User.Role.Admin, User.Location.Hospital, User.Region.Region);

List<User> users = new List<User>();
users.Add(testUser);

int userID_count = 1; // should call on filereader for Count.csv

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
            User user = new User(Count.RegisterUser(userID_count), u_input, p_input, )User.Role.User;
            users.Add(user);
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