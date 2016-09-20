using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DataContractSerializerDemo
{
    [DataContract]
    class Friend
    {
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
    }

    [DataContract]
    class ProgramData
    {
        [DataMember]
        public List<Friend> Friends { get; set; } = new List<Friend>();
    }

    class Program
    {
        static void Main(string[] args)
        {
            DataContractSerializer ser = new DataContractSerializer(typeof(ProgramData));

            using (XmlWriter s = XmlWriter.Create("file.xml", new XmlWriterSettings() {Indent = true}))
            {
                Console.WriteLine("Writing to file.");
                ser.WriteObject(s, new ProgramData()
                {
                    Friends = new List<Friend>()
                    {
                        new Friend()
                        {
                            FirstName = "John",
                            LastName = "Doe"
                        }
                    }
                });
                s.Close();   
            }
        }
    }
}
