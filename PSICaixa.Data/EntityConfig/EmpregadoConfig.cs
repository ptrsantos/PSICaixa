using PSICaixa.Domain.Entities.Empregados;
using System.Data.Entity.ModelConfiguration;

namespace PSICaixa.Data.EntityConfig
{
    public class EmpregadoConfig : EntityTypeConfiguration<Empregado>
    {
        public EmpregadoConfig()
        {

            ToTable("Empregados");

            HasKey(a => a.Id);

            Property(a => a.Nome)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnType("varchar");

            Property(a => a.Matricula)
                .IsRequired()
                .HasMaxLength(6)
                .HasColumnType("varchae");
        }
    }
}