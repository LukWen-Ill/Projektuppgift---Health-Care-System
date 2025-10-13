using App;

User testUser = new User("Lukas", "1");

List<User> users = new List<User>();

users.Add(testUser);

User? active_user = null;

Console.WriteLine("1. register");
Console.WriteLine("2. login");

string? input = Console.ReadLine();
