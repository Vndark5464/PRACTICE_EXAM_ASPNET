using System;

namespace PRACTICE_EXAM_ASPNET.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string ContactName { get; set; }
        public string ContactNumber { get; set; }
        public string GroupName { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime Birthday { get; set; }
    }
}
