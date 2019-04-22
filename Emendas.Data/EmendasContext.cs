using EmendasModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;


namespace Emendas.Data
{
    public class EmendasContext : DbContext
    {

        //    public static readonly LoggerFactory MyLoggerFactory
        //= new LoggerFactory(new[] { new ConsoleLoggerProvider((category, level)
        //        => category == DbLoggerCategory.Database.Command.Name
        //           && level == LogLevel.Information, true) });


       

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.
                UseNpgsql("User ID=postgres;Password=sapostgres;Server=localhost;Port=5432;Database=Emendas;Integrated Security=false;Pooling=true;")
               ;
             
            //optionsBuilder.UseSqlite( "Data Source = Emendas.sqlite");
            base.OnConfiguring(optionsBuilder);

            //optionsBuilder.UseSqlServer("Server = DESKTOP-GI6KUR4; Database = Emendas; User Id = sa; Password = saninatobiassimba123; ");
            //base.OnConfiguring(optionsBuilder);
        }

        public EmendasContext() : base()
        {

        }
        public EmendasContext(DbContextOptions<EmendasContext> options) : base(options) 
        {

        }  
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)

        {


            modelBuilder.ForNpgsqlUseIdentityColumns();
            modelBuilder.Entity<EmendaEmpenho>()
           
          .HasKey(e => new { e.EmendaId, e.EmpenhoId,e.BeneficiarioId });
            modelBuilder.Entity<EmendaEmpenho>()
                .HasOne(e => e.Emenda)
                .WithMany(b => b.EmendaEmpenho)
                .HasForeignKey(e => e.EmendaId);
            modelBuilder.Entity<EmendaEmpenho>()
                .HasOne(bc => bc.Empenho)
                .WithMany(c => c.EmendaEmpenhos)
                .HasForeignKey(bc => bc.EmpenhoId);
            modelBuilder.Entity<EmendaEmpenho>()
               .HasOne(bc => bc.Beneficiario)
               .WithMany(c => c.EmendaEmpenho)
               .HasForeignKey(bc => bc.BeneficiarioId);


            modelBuilder.Entity<Emenda>()
                .Property(e => e.Valor)
                .HasColumnType("decimal(18,2)");
            modelBuilder.Entity<EmendaEmpenho>()
               .Property(e => e.ValorEmpenhado)
               .HasColumnType("decimal(18,2)");
            modelBuilder.Entity<EmendaEmpenho>()
               .Property(e => e.ValorPago)
               .HasColumnType("decimal(18,2)");





        }

        public DbSet<Parlamentar> Parlamentars { get; set; }
        public DbSet<Emenda> Emendas { get; set; }
        public DbSet<PlanoTrabalho> PlanoTrabalhos { get; set; }
        public DbSet<Partido> Partidos { get; set; }
        public DbSet<Beneficiario> Beneficiarios { get; set; }
        public DbSet<Empenho> Empenhos { get; set; }
        public DbSet<EmendaEmpenho> EmendaEmpenhos { get; set; }






        //public DbSet<P> StudentCourses { get; set; }
    }
}
