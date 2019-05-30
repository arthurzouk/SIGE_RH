using RH_Dominio.Models;
using System.Data.Entity.ModelConfiguration;

namespace RH_Banco.EntityConfig
{
    public class PessoaCurriculoConfiguration : EntityTypeConfiguration<PessoaCurriculo>
    {
        public PessoaCurriculoConfiguration()
        {
            // Primary Keys
            HasKey(x => x.Id);

            // Table & Column Mappings
            ToTable("PessoaCurriculo");
            HasIndex(x => x.CPF).IsUnique();

            // Configurations
            Property(x => x.Nome).HasMaxLength(150).IsRequired();
            Property(x => x.DataNascimento).IsRequired();
            Property(x => x.Endereco).HasMaxLength(200).IsRequired();
            Property(x => x.Escolaridade).IsRequired();
            Property(x => x.Curso).IsRequired();

            // Relationships
            HasMany(x => x.Recrutamentos).WithMany(x => x.Candidatos)
                .Map(um =>
                {
                    um.MapLeftKey("pessoaCurriculoId");
                    um.MapRightKey("recrutamentoId");
                    um.ToTable("CandidatosRecrutamentos");
                });

            HasMany(x => x.RecrutamentosAprovados).WithMany(m => m.Aprovados)
                .Map(um =>
                {
                    um.MapLeftKey("pessoaCurriculoId");
                    um.MapRightKey("recrutamentoId");
                    um.ToTable("AprovadosRecrutamentos");
                });
        }
    }
}
