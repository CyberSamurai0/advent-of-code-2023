using System.IO;

namespace advent_of_code;

public class FileInput {
    public string Path { get; }
    public string Text { get; }
    public String[] Lines { get; }

    public FileInput(string path) {
        this.Path = path;
        if (File.Exists(this.Path)) {
            
        } else {
            Console.WriteLine($"File {this.Path} not found");
        }
        this.Text = File.Exists(this.Path) ? File.ReadAllText(this.Path) : "";
        this.Lines = File.Exists(this.Path) ? File.ReadAllLines(this.Path) : Array.Empty<string>();
    }
}