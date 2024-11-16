using Social.Shared.FileShared;

public class ImageFiles : Files
{
    public string Name { get; set; }
    public string Path { get; set; }
    public ImageFiles()
    {

    }

    public ImageFiles(int id, string name, string path, string storage) : this()
    {
        Id = id;
        Name = name;
        Path = path;
        Storage = storage;
    }
}