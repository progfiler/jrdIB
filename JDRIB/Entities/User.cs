using System;
using System.Collections.Generic;
using System.Text;

namespace JDRIB.Entities
{
    class User
    {
        public  Nullable<int> Id { get; set; } 
        public string Name { get; set; }
        public string Lastname { get; set; }
        public User() { }
        public User(string name, string lastname, Nullable<int> id = null)
        {
            this.Id = id;
            this.Name = name;
            this.Lastname = lastname;
        }
    }
}
