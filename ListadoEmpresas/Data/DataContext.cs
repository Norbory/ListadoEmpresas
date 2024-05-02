using ListadoEmpresas.Models;
using Microsoft.EntityFrameworkCore;

namespace ListadoEmpresas.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<Empresa> Empresas { get; set; }
    }
}
