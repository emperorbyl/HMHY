using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HMHY
{
    class MainUser
    {
        [XmlElement("userId")]
        public int userId { get; set; }
        [XmlElement("userName")]
        public string userName { get; set; }
        [XmlElement("userPassword")]
        public string password { get; set; }
        public MainUser() { }
    }

    [XmlRoot("ArrayOfMainUser")]
    class MainUserList
    {
        public MainUserList() { Items = new List<MainUserList>(); }
        [XmlElement("MainUser")]
        public List<MainUserList> Items { get; set; }
    }
}
