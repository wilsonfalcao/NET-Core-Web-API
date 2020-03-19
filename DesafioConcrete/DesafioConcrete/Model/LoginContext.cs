using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioConcrete.Model
{
    public class LoginContext : DbContext
    {
        public DbSet<CreateLogin> CreateLogins { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=tcp:wilsonfalcapdb.database.windows.net,1433;Initial Catalog=cadastrouser;"+
                                        "Persist Security Info=False;User ID=wilsonfalcao;Password=Gpoz33@@;"+
                                        "MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }
    }
}
