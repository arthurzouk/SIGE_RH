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
            Property(x => x.IdProcesso).IsRequired().HasColumnName("idprocesso");
            Property(x => x.DataAbertura).IsRequired().HasColumnName("data_abertura");
            Property(x => x.DataFechamento).IsRequired().HasColumnName("data_fechamento");
            Property(x => x.SetorSolicitante).HasMaxLength(50).IsRequired().HasColumnName("setor_solicitante");
            Property(x => x.Responsavel).IsRequired().HasColumnName("responsavel");
            Property(x => x.Situacao).IsRequired().HasColumnName("situacao");
            Property(x => x.PerfilVaga).HasMaxLength(1000).IsRequired().HasColumnName("perfil_vaga");
            Property(x => x.TestesAAplicar).HasMaxLength(500).IsRequired().HasColumnName("testes_aplicar");
            Property(x => x.Entrevistador).HasMaxLength(150).IsRequired().HasColumnName("entrevistador");
            Property(x => x.Aprovado).IsRequired().HasColumnName("aprovado");
            Property(x => x.Observacoes).HasMaxLength(1000).IsOptional().HasColumnName("observacoes");
            Property(x => x.PessoaCurriculoId).HasColumnName("pessoa_id");

            // Relationships
            HasRequired(x => x.PessoaCurriculo).WithMany(x => x.Recrutamentos).HasForeignKey(x => x.PessoaCurriculoId);
        }
    }
}
