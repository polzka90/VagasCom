using System;
using System.Collections.Generic;
using System.Text;

namespace VagasCom.Domain.Models
{
    public class Vacancy
    {
        public int Id { get; set; }
        public string Company { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Location { get; set; }

        public int Level { get; set; }
    }
}
