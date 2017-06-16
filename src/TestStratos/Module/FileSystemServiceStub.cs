using System.IO;
using System.Xml;
using Stratos.Service;
using TestStratos.TestData;

namespace TestStratos.Module
{
    public class FileSystemServiceStub : IFileSystemService
    {
        public bool DirectoryExists(string path)
        {
            return true;
        }

        public bool FileExists(string path)
        {
            return true;
        }

        public string[] GetDirectories(string path)
        {
            return new [] { "packageA", "packageB" };
        }

        public XmlDocument LoadXmlDocument(string path)
        {
            var xmlDocument = new XmlDocument();
            xmlDocument.Load(new MemoryStream(Files.testpackage));
            return xmlDocument;
        }
    }
}
