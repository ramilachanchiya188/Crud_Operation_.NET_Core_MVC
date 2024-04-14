using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudOperationMVC.Models
{
    public class StudentViewModel
    {
        /// <summary>
        /// this model is used to a only display perpose
        /// </summary>
        public int StudId { get; set; }
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("Date Of Birth")]
        public DateTime DateOfBirth { get; set; }

        [DisplayName("E-mail")]
        public string Email { get; set; }// if no define a database it is by default varchar(MAX)

        public string Stream { get; set; }
        
        public string Subjects { get; set; }
        public Double Marks { get; set; }
        [DisplayName("Name")]
        public string FullName 
        {
            get { return FirstName + " " + LastName; }
         }
    }
}
