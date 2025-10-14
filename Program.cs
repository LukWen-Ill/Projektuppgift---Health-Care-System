using App;

// creates a path from where this program is running
string basePath = AppContext.BaseDirectory;

// creates file
string dataFolder = Path.Combine(basePath, "Data");

// checks if file was created
Directory.CreateDirectory(dataFolder);

// creates filepath to Users.csv
string filePath = Path.Combine(dataFolder, "Users.csv");
// BUG:
// Ny fil skapad: / Users / lukaswennstrom / repos / Projektuppgift-- - Health - Care - System / bin / Debug / net8.0 / Data / Users.csv

if (!File.Exists(filePath))
{
    File.WriteAllText(filePath, "");
    Console.WriteLine($"Ny fil skapad: {filePath}");
}
else
{
    Console.WriteLine($"Filen finns redan: {filePath}");
}

using StreamReader reader = new StreamReader("Users.csv");
{
    string innehall = reader.ReadToEnd();
}

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