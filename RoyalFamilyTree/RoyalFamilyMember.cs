using System;
using System.Collections.Generic;
using System.Drawing;

namespace RoyalFamilyTree
{
    public class RoyalFamilyMember
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool IsAlive { get; set; }
        public string Title { get; set; }

        public RoyalFamilyMember(string name, DateTime dateOfBirth, bool isAlive, string title = "")
        {
            Name = name;
            DateOfBirth = dateOfBirth;
            IsAlive = isAlive;
            Title = title;
        }

        public override string ToString()
        {
            string status = IsAlive ? "Alive" : "Dead";
            return $"{Title} {Name} ({DateOfBirth:yyyy}) - {status}";
        }
    }
}