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
            HasIndex(x => x.IdProcesso).IsUnique();

            // Configurations
            Property(x => x.IdProcesso).IsRequired().HasColumnName("idprocesso");
            Property(x => x.DataSolicitacao).IsRequired().HasColumnName("data_solicitacao");
            Property(x => x.SetorSolicitante).HasMaxLength(50).IsRequired().HasColumnName("setor_solicitante");
            Property(x => x.Responsavel).IsRequired().HasColumnName("responsavel");
            Property(x => x.QuantidadeDeFalhas).IsRequired().HasColumnName("quantidade_falhas");
            Property(x => x.Motivo).HasMaxLength(1000).IsRequired().HasColumnName("motivo");
            Property(x => x.FalhaGrave).IsRequired().HasColumnName("falha_grave");
            Property(x => x.PessoaCurriculoId).HasColumnName("pessoaId");

            // Relationships
            HasRequired(x => x.PessoaCurriculo).WithMany(x => x.Demissoes).HasForeignKey(x => x.PessoaCurriculoId);
        }
    }
}
