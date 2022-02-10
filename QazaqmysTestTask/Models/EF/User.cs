using System;
using System.Collections.Generic;

#nullable disable

namespace QazaqmysTestTask.Models.EF
{
    public partial class User
    {
        public User()
        {
            Numbers = new HashSet<Number>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }

        public virtual ICollection<Number> Numbers { get; set; }
    }
}
