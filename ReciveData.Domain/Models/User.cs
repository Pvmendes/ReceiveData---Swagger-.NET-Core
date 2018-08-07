using System;
using System.Collections.Generic;
using System.Text;

namespace ReciveData.Domain.Models
{
    public class User
    {
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public bool IsDone { get; set; }

        public string name { get; set; }
        public string Email { get; set; }

        public string IdDevice { get; set; }
        public string Model { get; set; }
        public string Platform { get; set; }
        public string Version { get; set; }
    }
}
