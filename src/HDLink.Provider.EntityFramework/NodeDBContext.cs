using HDLink.Core;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HDLink.Provider.EntityFramework
{
    public class NodeDbContext : DbContext
    {
        const string DefinitionId = "DefinitionId";

        public DbSet<Link> Links { get; set; }
        public DbSet<Node> Nodes { get; set; }
        public DbSet<Attribute> Attributes { get; set; }
        public DbSet<AttributeDefinition> AttributeDefinitions { get; set; }
        public DbSet<NodeAttribute> NodeAttribute { get; set; }

        public NodeDbContext() : base() { }
        public NodeDbContext(DbContextOptions options) : base(options) { }
        public NodeDbContext(System.IServiceProvider serviceProvider) : base(serviceProvider) { }
        public NodeDbContext(System.IServiceProvider serviceProvider,DbContextOptions options) : base(serviceProvider,options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AttributeDefinition>().ToTable(nameof(AttributeDefinitions));
            modelBuilder.Entity<AttributeDefinition>().HasKey(r => r.Id);
            modelBuilder.Entity<AttributeDefinition>().Property(r => r.Definition).HasMaxLength(255);
            modelBuilder.Entity<AttributeDefinition>().HasIndex(r => r.Definition).IsUnique();
            modelBuilder.Entity<AttributeDefinition>().Property(r => r.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<Attribute>().ToTable(nameof(Attributes));
            modelBuilder.Entity<Attribute>().HasKey(r => r.Id);
            modelBuilder.Entity<Attribute>().Property(r => r.Value).HasMaxLength(255);
            modelBuilder.Entity<Attribute>().Property(r => r.Id).ValueGeneratedOnAdd();
            //modelBuilder.Entity<Attribute>().Property<int>(DefinitionId);

            modelBuilder.Entity<Attribute>().HasOne(r => r.Definition).WithMany()
                .HasForeignKey(DefinitionId)
                .IsRequired();
            modelBuilder.Entity<Attribute>().HasIndex(DefinitionId, nameof(Attribute.Value)).IsUnique();

            
            

            modelBuilder.Entity<Node>().ToTable(nameof(Nodes));
            modelBuilder.Entity<Node>().HasKey(r => r.Id);
            modelBuilder.Entity<Node>().Property(r => r.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Node>().HasMany(r => r.Attributes).WithOne()
                .IsRequired().OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Link>().ToTable(nameof(Links));
            modelBuilder.Entity<Link>().HasKey(r => r.Id);
            modelBuilder.Entity<Link>().Property(r => r.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Link>().HasOne(r => r.NodeA).WithOne()
                .IsRequired(false);
            modelBuilder.Entity<Link>().HasOne(r => r.NodeB).WithOne()
                .IsRequired(false);

            modelBuilder.Entity<NodeAttribute>().ToTable(nameof(NodeAttribute));
            modelBuilder.Entity<NodeAttribute>().HasKey(r => r.Id);
            modelBuilder.Entity<NodeAttribute>().Property(r => r.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<NodeAttribute>().HasOne(r=> r.Attribute).WithOne()
                .IsRequired().OnDelete(DeleteBehavior.Cascade);
        }

    }
}
