using PSICaixa.Data.EntityConfig;
using PSICaixa.Domain.Entities.Empregados;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace PSICaixa.Data.Context
{
    public class PSICaixaContext : DbContext
    {
        //const string stringConnection = @"Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\ProjetoEmpregadoDB.mdf;Initial Catalog=ProjetoEmpregadoDB;Integrated Security=True";
        const string stringConnection = @"Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\ProjetoEmpregadoDB.mdf;Integrated Security=True";

        public PSICaixaContext() : base(stringConnection)
        {

        }

        public DbSet<Empregado> Empregados { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.Add(new EmpregadoConfig());

            base.OnModelCreating(modelBuilder);
        }
    }
}