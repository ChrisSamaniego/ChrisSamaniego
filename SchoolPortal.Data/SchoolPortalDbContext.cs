using Microsoft.EntityFrameworkCore;
using SchoolPortal.Data.Entities;

namespace SchoolPortal.Data;

public class SchoolPortalDbContext(DbContextOptions<SchoolPortalDbContext> options) : DbContext(options)
{
    public DbSet<UserEntity> Users => Set<UserEntity>();
    public DbSet<CourseEntity> Courses => Set<CourseEntity>();
    public DbSet<ClassScheduleEntity> ClassSchedules => Set<ClassScheduleEntity>();
    public DbSet<CourseFeeEntity> CourseFees => Set<CourseFeeEntity>();
    public DbSet<PortalDocumentEntity> Documents => Set<PortalDocumentEntity>();
    public DbSet<AdminMessageEntity> AdminMessages => Set<AdminMessageEntity>();
    public DbSet<StaffMessageEntity> StaffMessages => Set<StaffMessageEntity>();
    public DbSet<QuestionnaireEntity> Questionnaires => Set<QuestionnaireEntity>();
    public DbSet<QuestionEntity> Questions => Set<QuestionEntity>();
    public DbSet<QuestionnaireResponseEntity> QuestionnaireResponses => Set<QuestionnaireResponseEntity>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserEntity>(entity =>
        {
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Username).HasMaxLength(128);
            entity.Property(x => x.DisplayName).HasMaxLength(128);
            entity.Property(x => x.Email).HasMaxLength(256);
        });

        modelBuilder.Entity<CourseEntity>(entity =>
        {
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Code).HasMaxLength(32);
            entity.Property(x => x.Name).HasMaxLength(128);
        });

        modelBuilder.Entity<ClassScheduleEntity>(entity =>
        {
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Name).HasMaxLength(128);
            entity.Property(x => x.Instructor).HasMaxLength(128);
            entity.Property(x => x.Room).HasMaxLength(64);
        });

        modelBuilder.Entity<CourseFeeEntity>(entity =>
        {
            entity.HasKey(x => x.Id);
            entity.HasOne(x => x.Course)
                .WithMany(x => x.Fees)
                .HasForeignKey(x => x.CourseId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<PortalDocumentEntity>(entity =>
        {
            entity.HasKey(x => x.Id);
            entity.HasOne(x => x.UploadedByUser)
                .WithMany(x => x.Documents)
                .HasForeignKey(x => x.UploadedByUserId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<AdminMessageEntity>(entity =>
        {
            entity.HasKey(x => x.Id);
            entity.HasOne(x => x.StudentUser)
                .WithMany()
                .HasForeignKey(x => x.StudentUserId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<QuestionnaireEntity>(entity =>
        {
            entity.HasKey(x => x.Id);
            entity.HasOne(x => x.Course)
                .WithMany(x => x.TheoreticalExams)
                .HasForeignKey(x => x.CourseId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<QuestionEntity>(entity =>
        {
            entity.HasKey(x => x.Id);
            entity.HasOne(x => x.Questionnaire)
                .WithMany(x => x.Questions)
                .HasForeignKey(x => x.QuestionnaireId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<QuestionnaireResponseEntity>(entity =>
        {
            entity.HasKey(x => x.Id);
            entity.HasOne(x => x.Questionnaire)
                .WithMany(x => x.Responses)
                .HasForeignKey(x => x.QuestionnaireId)
                .OnDelete(DeleteBehavior.Cascade);
            entity.HasOne(x => x.StudentUser)
                .WithMany()
                .HasForeignKey(x => x.StudentUserId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<StaffMessageEntity>(entity =>
        {
            entity.HasKey(x => x.Id);
        });
    }
}
