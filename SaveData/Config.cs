using System.Text.Json;
using System.Text.Json.Serialization;

namespace Notepadv.SaveData;

public sealed class Config
{
    public static string Version => "1.0.0";

    private static readonly string ConfigDir = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "notepadv");

    private static readonly string ConfigPath = Path.Combine(ConfigDir, "config.json");

    private static Config _instance = new();

    [JsonInclude] private int _width = 1000;
    [JsonInclude] private int _height = 700;
    [JsonInclude] private int _zoomSize;

    public static int Width
    {
        get => _instance._width;
        set => _instance._width = value;
    }

    public static int Height
    {
        get => _instance._height;
        set => _instance._height = value;
    }

    public static int ZoomSize
    {
        get => _instance._zoomSize;
        set => _instance._zoomSize = value;
    }

    public static void Load()
    {
        try
        {
            if (File.Exists(ConfigPath))
            {
                var json = File.ReadAllText(ConfigPath);
                var options = new JsonSerializerOptions { IncludeFields = true };
                var loaded = JsonSerializer.Deserialize<Config>(json, options);
                if (loaded != null)
                    _instance = loaded;
            }
        }
        catch
        {
            _instance = new Config();
        }
    }

    public static void Save()
    {
        try
        {
            Directory.CreateDirectory(ConfigDir);
            var options = new JsonSerializerOptions { WriteIndented = true, IncludeFields = true };
            var json = JsonSerializer.Serialize(_instance, options);
            File.WriteAllText(ConfigPath, json);
        }
        catch
        {
        }
    }
}
