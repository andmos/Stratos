using System.IO;
using System.Xml;

namespace Stratos.Service
{
    public class FileSystemService : IFileSystemService
    {
        public bool DirectoryExists(string path)
        {
            return Directory.Exists(path);
        }

        public bool FileExists(string path)
        {
            return File.Exists(path);
        }

        public string[] GetDirectories(string path)
        {
            return Directory.GetDirectories(path);
        }

        public XmlDocument LoadXmlDocument(string path)
        {
            var xmlDocument = new XmlDocument();
            xmlDocument.Load(path);
            return xmlDocument;
        }
    }
}