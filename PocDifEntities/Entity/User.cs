using PocDifEntities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocDifEntities.Entity
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime Birthday { get; set; }

        public string Telephone { get; set; }

        public Address Address { get; set; }

        public string Email { get; set; }

        public string Nickname { get; set; }

        public string Twitter { get; set; }
    }
}
