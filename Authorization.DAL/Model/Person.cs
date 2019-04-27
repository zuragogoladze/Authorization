using System;
using System.Collections.Generic;
using System.Text;

namespace Authorization.DAL.Model
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

    }
}
