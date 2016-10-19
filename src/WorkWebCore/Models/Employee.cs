using System.ComponentModel.DataAnnotations;

namespace WorkWebCore.Models
{
    public class Employee
    {
        public Employee()
        {
        } 
        public int Id { get; set; }

        [MaxLength(30)]
        public string Name { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }
    }
}
