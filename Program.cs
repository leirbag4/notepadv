namespace Notepadv;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        var args = Environment.GetCommandLineArgs();
        var filePath = args.Length > 1 ? args[1] : null;
        Application.Run(new Form1(filePath));
    }    
}