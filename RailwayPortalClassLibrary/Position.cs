using System;
using System.Collections.Generic;
using System.Text;

namespace RailwayPortalClassLibrary
{
    public class Position
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<User> Users { get; set; }

        public Position()
        {
            Users = new List<User>();
        }
    }
}
