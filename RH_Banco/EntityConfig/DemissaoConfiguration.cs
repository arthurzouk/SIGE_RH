using RH_Dominio.Models;
using System.Data.Entity.ModelConfiguration;

namespace RH_Banco.EntityConfig
{
    public class DemissaoConfiguration : EntityTypeConfiguration<Demissao>
    {
        public DemissaoConfiguration()
        {
            // Primary Keys
            HasKey(x => x.Id);

            // Table & Column Mappings
            ToTable("Demissao");
            HasIndex(x => x.IdProcesso);

            // Configurations
            Property(x => x.DataSolicitacao).IsRequired();
            Property(x => x.SetorSolicitante).HasMaxLength(50).IsRequired();
            Property(x => x.Responsavel).IsRequired();
            Property(x => x.QuantidadeDeFalhas).IsRequired();
            Property(x => x.Motivo).HasMaxLength(1000).IsRequired();
            Property(x => x.FalhaGrave).IsRequired();

            // Relationships
            HasRequired(x => x.Funcionario).WithMany(x => x.Demissoes).HasForeignKey(x => x.IdFuncionario);
        }
    }
}
