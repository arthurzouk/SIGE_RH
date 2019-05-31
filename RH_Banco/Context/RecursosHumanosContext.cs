using RH_Banco.EntityConfig;
using RH_Dominio.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace RH_Banco.Context
{
    public class RecursosHumanosContext : DbContext
    {
        public RecursosHumanosContext() : base("RecursosHumanos")
        {

        }

        public DbSet<PessoaCurriculo> PessoasCurriculo { get; set; }
        public DbSet<Recrutamento> Recrutamento { get; set; }
        public DbSet<Demissao> Demissoes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Configurações básicas
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties()
                .Where(p => p.Name == "Id" + p.ReflectedType.Name)
                .Configure(p => p.IsKey());

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

            // Adicionar configurações de tabelas
            modelBuilder.Configurations.Add(new PessoaCurriculoConfiguration());
            modelBuilder.Configurations.Add(new RecrutamentoConfiguration());
            modelBuilder.Configurations.Add(new DemissaoConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
