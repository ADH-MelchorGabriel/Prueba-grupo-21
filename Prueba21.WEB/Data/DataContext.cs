using Microsoft.EntityFrameworkCore;
using Prueba21.WEB.Models;

namespace Prueba21.WEB.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<TareaEntity> Tareas { get; set; }
    }
}
