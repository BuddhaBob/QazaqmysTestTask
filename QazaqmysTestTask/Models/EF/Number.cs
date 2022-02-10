using System;
using System.Collections.Generic;

#nullable disable

namespace QazaqmysTestTask.Models.EF
{
    public partial class Number
    {
        public long Id { get; set; }
        public string Number1 { get; set; }
        public string Title { get; set; }
        public long UserId { get; set; }

        public virtual User User { get; set; }
    }
}
