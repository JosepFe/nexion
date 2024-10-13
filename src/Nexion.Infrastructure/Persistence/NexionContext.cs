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

    public virtual DbSet<Athlete>? Athletes { get; init; }

    public virtual DbSet<Center>? Centers { get; init; }

    public virtual DbSet<Exercise>? Exercises { get; init; }

    public virtual DbSet<Session>? Sessions { get; init; }

    public virtual DbSet<Survey>? Surveys { get; init; }

    public virtual DbSet<SurveyAnswer>? SurveysAnswers { get; init; }

    public virtual DbSet<Trainer>? Trainers { get; init; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Map Athletes to MongoDB collection
        modelBuilder.Entity<Athlete>(entity =>
        {
            entity.ToCollection(Athlete.CollectionName);
            entity.HasKey(e => e.Id);
        });

        // Map Centers to MongoDB collection
        modelBuilder.Entity<Center>(entity =>
        {
            entity.ToCollection(Center.CollectionName);
            entity.HasKey(e => e.Id);
        });

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
        });

        // Map Trainers to MongoDB collection
        modelBuilder.Entity<Survey>(entity =>
        {
            entity.ToCollection(Survey.CollectionName);
            entity.HasKey(e => e.Id);
        });

        // Map Trainers to MongoDB collection
        modelBuilder.Entity<SurveyAnswer>(entity =>
        {
            entity.ToCollection(SurveyAnswer.CollectionName);
            entity.HasKey(e => e.Id);

            // Establish relations inside Survey
            entity.HasOne<Survey>()
                .WithMany()
                .HasForeignKey(e => e.SurveyId);

            // Establish relations inside Survey
            entity.HasOne<Athlete>()
                .WithMany()
                .HasForeignKey(e => e.AthelteId);
        });

        // Map Trainers to MongoDB collection
        modelBuilder.Entity<Trainer>(entity =>
        {
            entity.ToCollection(Trainer.CollectionName);
            entity.HasKey(e => e.Id);
        });
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
    }
}
