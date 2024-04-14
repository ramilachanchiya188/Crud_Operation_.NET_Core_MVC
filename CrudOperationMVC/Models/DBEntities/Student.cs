using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudOperationMVC.Models.DBEntities
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudId { get; set; }
        [Column(TypeName ="varchar(50)")]
        public string FirstName { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string LastName { get; set; }
        public DateTime DateOfBirth{ get; set; }
        public string Email { get; set; }// if no define a database it is by default varchar(MAX)
        [Column(TypeName = "varchar(50)")]
        public string Stream { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Subjects { get; set; }
        public Double Marks { get; set; }

    }
}
