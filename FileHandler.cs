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
}