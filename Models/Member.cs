using System.ComponentModel.DataAnnotations;

namespace Moldoveanu_Alex_Laborator2.Models
{
    public class Member
    {
        public int ID { get; set; }
        public string? FirstName { get; set; }    
        public string? LastName { get; set; }
        public string? Adress { get; set; }
        public string Email { get; set; }
        public string? Phone { get; set; }
        
        [Display(Name = "FullName")]
        public string? FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
        public ICollection<Borrowing>? Borrowings { get; set; }
    }
}