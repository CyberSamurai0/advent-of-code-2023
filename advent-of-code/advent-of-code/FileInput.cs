using System.IO;

namespace advent_of_code;

public class FileInput
{
    public string Path { get; set; }

    public FileInput(string path)
    {
        this.Path = path;
        if (File.Exists(this.Path))
        {
            
        }
    }
}