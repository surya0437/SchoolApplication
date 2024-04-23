using Microsoft.EntityFrameworkCore;
using SchoolApplication.Models;
using static System.Net.Mime.MediaTypeNames;

namespace SchoolApplication.Data
{
    
    public class ApplicationDbContext:DbContext
    {
        /*Type ctor and then 2 times tab  it will create a constructor of the class */
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>
            dbContextOptions):base(dbContextOptions)
        {

        }
       public DbSet<Student> Students { get; set; }

        
    }
}
