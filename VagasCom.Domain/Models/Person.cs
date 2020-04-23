using System;
using System.Collections.Generic;
using System.Text;

namespace VagasCom.Domain.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Profession { get; set; }
        public string Location { get; set; }
        public int Level { get; set; }
    }
}
