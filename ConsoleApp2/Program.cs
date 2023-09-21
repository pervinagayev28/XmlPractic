using System.Text;
using System.Xml;

namespace ConsoleApp2
{
    internal class Program
    {

        static void Main(string[] args)
        {
            string path = "C:\\Users\\user\\Desktop\\xmls.xml";
            var data = ConvertClass(path);
            foreach (var item in data)
            {
                Console.WriteLine(item);
            }

        }
        static void ConvertXml(List<Student> students)
        {
            using var newStream = new FileStream("C:\\Users\\user\\Desktop\\xmls.xml", FileMode.Open, FileAccess.Write);
            using XmlTextWriter writer = new XmlTextWriter(newStream, Encoding.Default);
            writer.Formatting = Formatting.Indented;
            writer.WriteStartDocument();
            writer.WriteStartElement("students");

            foreach (var item in students)
            {
                writer.WriteStartElement("student");
                writer.WriteElementString(nameof(item.Id), item.Id.ToString());
                writer.WriteElementString(nameof(item.name), item.name.ToString());
                writer.WriteEndElement();
            }
            writer.WriteEndElement();

            writer.WriteEndDocument();

        }
        static List<Student>ConvertClass(string path)
        {
            List<Student> ss = new();
            XmlDocument reader = new XmlDocument();
            reader.Load(path);
            XmlElement xe = reader.DocumentElement;
            foreach (var item in xe.ChildNodes)
            {
                
            }

            return ss;
        }
    }


    class Student
    {
        public int Id { get; set; }
        public string name { get; set; }
        public override string ToString()
        {
            return $"Id: {name}\nname: {name}";
        }
    }
}