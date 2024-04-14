using CrudOperationMVC.Models.DBEntities;
using Microsoft.EntityFrameworkCore;

namespace CrudOperationMVC.DAL
{
    public class StudentDBContext : DbContext
    {
        public StudentDBContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Student>Students { get; set; }
            
    }
}
