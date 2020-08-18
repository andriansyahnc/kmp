using System;
using System.Collections.Generic;

namespace KMP.Models
{
    public partial class Todo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public byte Percentage { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset? Updated { get; set; }
        public DateTimeOffset? Expiry { get; set; }
    }
}
