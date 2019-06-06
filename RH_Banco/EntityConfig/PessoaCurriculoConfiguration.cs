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
            ToTable("Pessoa");
            HasIndex(x => x.CPF).IsUnique();

            // Configurations
            Property(x => x.CPF).HasMaxLength(11).IsRequired().HasColumnName("cpf");
            Property(x => x.Nome).HasMaxLength(150).IsRequired().HasColumnName("nome");
            Property(x => x.DataNascimento).IsRequired().HasColumnName("data_nascimento");
            Property(x => x.Endereco).HasMaxLength(200).IsRequired().HasColumnName("endereco");
            Property(x => x.Escolaridade).IsRequired().HasColumnName("escolaridade");
            Property(x => x.Curso).IsRequired().HasColumnName("curso");
            Property(x => x.Salario).IsRequired().HasColumnName("salario");
            Property(x => x.HorasAbsenteismo).IsOptional().HasColumnName("horas_absenteismo");

            // Relationships
            
        }
    }
}
