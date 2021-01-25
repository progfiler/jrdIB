using System;
using System.Collections.Generic;
using System.Text;

namespace JDRIB.Entities
{
    class User
    {
        private Nullable<int> Id { get; set; } 
        private string Name { get; set; }
        private string Lastname { get; set; }

        public User(string name, string lastname, Nullable<int> id = null)
        {
            this.Id = id;
            this.Name = name;
            this.Lastname = lastname;
        }
    }
}
