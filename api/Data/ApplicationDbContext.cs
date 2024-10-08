using api.Models.Static;
using api.Models.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace api.Data 
{
     public class ApplicationDbContext: IdentityDbContext<AppUser>
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
        public DbSet<Item> Item { get; set; }
        public DbSet<Nature> Nature { get; set; }

        public DbSet<Team> Team { get; set; }
        public DbSet<UserPokemon> UserPokemon { get; set; }

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
                .HasForeignKey<BaseStats>(e => e.PokemonId);


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



            // Add Identity Roles
            List<IdentityRole> roles = new List<IdentityRole>()
            {
                new IdentityRole()
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole()
                {
                    Name = "User",
                    NormalizedName = "USER"
                }
            };

            modelBuilder.Entity<IdentityRole>().HasData(roles);


            // Add Test Users
            List<AppUser> appUsers = new()
            {
                new AppUser()
                {
                    Id = "test1",
                    UserName = "TestUser1"
                },
                new AppUser()
                {
                    Id = "test2",
                    UserName = "TestUser2"
                }
            };

            modelBuilder.Entity<AppUser>().HasData(appUsers);
        }
    }
}