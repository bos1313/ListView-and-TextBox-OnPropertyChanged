using System;

namespace TabStudents.Models
{
    public class StudentsModel
    {
        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;        
     
    }    
}
