using PSICaixa.Domain.Entities.Empregados;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace PSICaixa.Data.Context
{
    public class PSICaixaContext : DbContext
    {
        //"Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\PsiFcvs.mdf;Initial Catalog=PsiFcvsDB;Integrated Security=True" providerName="System.Data.SqlClient"
        const string stringConnection = @"Data Source = (LocalDb)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\PsiCaixa.mdf;Initial Catalog = PsiCaixaDB; Integrated Security = True";

        public PSICaixaContext() : base(stringConnection)
        {

        }

        public DbSet<Empregado> Empregados { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

        }
    }
}