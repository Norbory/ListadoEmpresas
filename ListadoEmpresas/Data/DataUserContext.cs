using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ListadoEmpresas.Data
{
    public class DataUserContext: IdentityDbContext
    {
        public DataUserContext(DbContextOptions<DataUserContext> options): base(options)
        {

        }
    }
}
