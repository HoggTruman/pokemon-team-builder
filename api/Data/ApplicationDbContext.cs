using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Data 
{
     public class ApplicationDbContext: DbContext 
     {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
       
        }

    
        public DbSet<Ability> Ability { get; set; }
        public DbSet<Pokemon> Pokemon { get; set; }
        public DbSet<PkmnType> PkmnType { get; set; }
        public DbSet<BaseStats> BaseStats { get; set; }
        public DbSet<Move> Move { get; set; }
        public DbSet<MoveEffect> MoveEffect { get; set; }
        public DbSet<DamageClass> DamageClass { get; set; }
        public DbSet<Gender> Gender { get; set; }

        public DbSet<PokemonPkmnType> PokemonPkmnType { get; set; }
        public DbSet<PokemonAbility> PokemonAbility { get; set; }
        public DbSet<PokemonMove> PokemonMove { get; set; }
        public DbSet<PokemonGender> PokemonGender { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            // Register Pokemon-BaseStats one-to-one relationship
            modelBuilder.Entity<Pokemon>()
                .HasOne(e => e.BaseStats)
                .WithOne(e => e.Pokemon)
                .HasForeignKey<BaseStats>();


            // Register Pokemon-PkmnType many-to-many relationship
            modelBuilder.Entity<Pokemon>()
                .HasMany(e => e.PkmnTypes)
                .WithMany(e => e.Pokemon)
                .UsingEntity<PokemonPkmnType>();


            // Register Pokemon-Ability many-to-many relationship
            modelBuilder.Entity<Pokemon>()
                .HasMany(e => e.Abilities)
                .WithMany(e => e.Pokemon)
                .UsingEntity<PokemonAbility>();


            // Register Pokemon-Gender many-to-many relationship
            modelBuilder.Entity<Pokemon>()
                .HasMany(e => e.Genders)
                .WithMany(e => e.Pokemon)
                .UsingEntity<PokemonGender>();


            // Register Pokemon-Move many-to-many relationship
            modelBuilder.Entity<Pokemon>()
                .HasMany(e => e.Moves)
                .WithMany(e => e.Pokemon)
                .UsingEntity<PokemonMove>();


        }
    }
}