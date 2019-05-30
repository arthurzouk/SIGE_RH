using RH_Dominio.Models;
using System.Data.Entity.ModelConfiguration;

namespace RH_Banco.EntityConfig
{
    public class RecrutamentoConfiguration : EntityTypeConfiguration<Recrutamento>
    {
        public RecrutamentoConfiguration()
        {
            // Primary Keys
            HasKey(x => x.Id);

            // Table & Column Mappings
            ToTable("Recrutamento");
            HasIndex(x => x.IdProcesso).IsUnique();

            // Configurations
            Property(x => x.DataAbertura).IsRequired();
            Property(x => x.DataFechamento).IsRequired();
            Property(x => x.SetorSolicitante).HasMaxLength(50).IsRequired();
            Property(x => x.Responsavel).IsRequired();
            Property(x => x.Situacao).IsRequired();
            Property(x => x.PerfilVaga).HasMaxLength(1000).IsRequired();
            Property(x => x.TestesAAplicar).HasMaxLength(500).IsRequired();
            Property(x => x.Entrevistador).HasMaxLength(150).IsRequired();
            Property(x => x.Observacoes).HasMaxLength(1000).IsOptional();
        }
    }
}
