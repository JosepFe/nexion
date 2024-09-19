namespace Devon4Net.Infrastructure.Persistence;

using Devon4Net.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using MongoDB.EntityFrameworkCore.Extensions;

public class NexionContext : DbContext
{
    public NexionContext(DbContextOptions options)
        : base(options)
    {
    }

    public virtual DbSet<Center>? Centers { get; init; }

    public virtual DbSet<Trainer>? Trainers { get; init; }

    public virtual DbSet<Athlete>? Athletes { get; init; }

    public virtual DbSet<PredefinedQuestion>? PredefinedQuestions { get; init; }

    public virtual DbSet<Exercise>? Exercises { get; init; }

    public virtual DbSet<Session>? Sessions { get; init; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Map Centers to MongoDB collection
        modelBuilder.Entity<Center>(entity =>
        {
            entity.ToCollection(Center.CollectionName);
            entity.HasKey(e => e.Id);
        });

        // Map Trainers to MongoDB collection
        modelBuilder.Entity<Trainer>(entity =>
        {
            entity.ToCollection(Trainer.CollectionName);
            entity.HasKey(e => e.Id);
            entity.HasOne<Center>()
                .WithMany()
                .HasForeignKey(e => e.CenterId);
        });

        // Map Athletes to MongoDB collection
        modelBuilder.Entity<Athlete>(entity =>
        {
            entity.ToCollection(Athlete.CollectionName);
            entity.HasKey(e => e.Id);
            entity.HasOne<Center>()
                .WithMany()
                .HasForeignKey(e => e.CenterId);
        });

        // Map Predefined Questions to MongoDB collection
        modelBuilder.Entity<PredefinedQuestion>(entity =>
        {
            entity.ToCollection("predefinedQuestion");
            entity.HasKey(e => e.Id);
        });

        // Map Exercises to MongoDB collection
        modelBuilder.Entity<Exercise>(entity =>
        {
            entity.ToCollection(Exercise.CollectionName);
            entity.HasKey(e => e.Id);
        });

        // Map Sessions to MongoDB collection
        modelBuilder.Entity<Session>(entity =>
        {
            entity.ToCollection(Session.CollectionName);
            entity.HasKey(e => e.Id);

            // Establish relations inside Session
            entity.HasOne<Trainer>()
                .WithMany()
                .HasForeignKey(e => e.TrainerId);

            entity.OwnsMany(e => e.Athletes);
            entity.OwnsMany(e => e.Exercises);
        });
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
    }
}
