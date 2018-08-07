using System;
using System.Collections.Generic;
using System.Text;

namespace ReciveData.Domain.Models
{
    public class Item
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsDone { get; set; }

        public string Text { get; set; }
        public string Description { get; set; }
    }
}
