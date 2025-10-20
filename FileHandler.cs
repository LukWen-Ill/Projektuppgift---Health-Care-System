namespace App;

class FileHandler
{
    public static string GetDataPath(string csv_filename)
    // returns program root + file name. 
    {
        // navigates from three levels up from bin/Debug/net8.0/ where program is executed.
        string programFolder = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "Data"));

        // checks if the folder exists otherwise creates it.
        Directory.CreateDirectory(programFolder);

        return Path.Combine(programFolder, csv_filename);
    }
    public static int Read_count()
    {
        string path_countTxt = GetDataPath("Count.txt");
        string s_userID_count = File.ReadAllText(path_countTxt);
        int.TryParse(s_userID_count, out int userID_count);
        return userID_count;
    }
    public static void Write_count(int userID_count)
    {
        string path_countTxt = GetDataPath("Count.txt");
        File.WriteAllText(path_countTxt, userID_count.ToString());
    }



    public static void LogEvent(EventLog log)
    {
        string path_EventLog = FileHandler.GetDataPath("EventLog.csv");
        string csv = log.ToCsv() + Environment.NewLine;
        File.AppendAllText(path_EventLog, csv);
    }

    public static string PermissionsToString(List<Permission> list)
    {
        string permission_list = "";
        for (int i = 0; i < list.Count; ++i)
        {
            permission_list += list[i].ToString();
            if (i < list.Count - 1)
                permission_list += ", ";
        }
        return permission_list;
    }
    public static void Write(List<User> users, string path)
    {
        using (StreamWriter writer = new StreamWriter(path))
        {
            foreach (User user in users)
            {
                writer.WriteLine($"{user.ToCsv()}");
            }
        }
    }
    public static void Read(List<User> users, string path)
    {
        using (StreamReader reader = new StreamReader(path))
        {
            string? line;

            while ((line = reader.ReadLine()) != null)
            {
                User? user = User.FromCsv(line);
                users.Add(user);
            }
        }
    }
}