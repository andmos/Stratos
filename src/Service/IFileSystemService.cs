using System.Xml;

namespace Stratos.Service
{
    public interface IFileSystemService
    {
        bool DirectoryExists(string path);
        bool FileExists(string path);
        string[] GetDirectories(string path);
        XmlDocument LoadXmlDocument(string path);
    }
}