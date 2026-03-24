using Microsoft.EntityFrameworkCore;
using SchoolPortal.Data;
using SchoolPortal.Data.Entities;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<SchoolPortalDbContext>(options =>
    options.UseInMemoryDatabase("SchoolPortalApiDb"));

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/api/users", async (SchoolPortalDbContext db) => await db.Users.ToListAsync());
app.MapPost("/api/users", async (UserEntity entity, SchoolPortalDbContext db) =>
{
    db.Users.Add(entity);
    await db.SaveChangesAsync();
    return Results.Created($"/api/users/{entity.Id}", entity);
});

app.MapGet("/api/class-schedules", async (SchoolPortalDbContext db) => await db.ClassSchedules.ToListAsync());
app.MapPost("/api/class-schedules", async (ClassScheduleEntity entity, SchoolPortalDbContext db) =>
{
    db.ClassSchedules.Add(entity);
    await db.SaveChangesAsync();
    return Results.Created($"/api/class-schedules/{entity.Id}", entity);
});

app.MapGet("/api/courses", async (SchoolPortalDbContext db) => await db.Courses.ToListAsync());
app.MapPost("/api/courses", async (CourseEntity entity, SchoolPortalDbContext db) =>
{
    db.Courses.Add(entity);
    await db.SaveChangesAsync();
    return Results.Created($"/api/courses/{entity.Id}", entity);
});

app.MapGet("/api/course-fees", async (SchoolPortalDbContext db) => await db.CourseFees.ToListAsync());
app.MapPost("/api/course-fees", async (CourseFeeEntity entity, SchoolPortalDbContext db) =>
{
    db.CourseFees.Add(entity);
    await db.SaveChangesAsync();
    return Results.Created($"/api/course-fees/{entity.Id}", entity);
});

app.MapGet("/api/documents", async (SchoolPortalDbContext db) => await db.Documents.ToListAsync());
app.MapPost("/api/documents", async (PortalDocumentEntity entity, SchoolPortalDbContext db) =>
{
    db.Documents.Add(entity);
    await db.SaveChangesAsync();
    return Results.Created($"/api/documents/{entity.Id}", entity);
});

app.MapGet("/api/admin-messages", async (SchoolPortalDbContext db) => await db.AdminMessages.ToListAsync());
app.MapPost("/api/admin-messages", async (AdminMessageEntity entity, SchoolPortalDbContext db) =>
{
    db.AdminMessages.Add(entity);
    await db.SaveChangesAsync();
    return Results.Created($"/api/admin-messages/{entity.Id}", entity);
});

app.MapGet("/api/staff-messages", async (SchoolPortalDbContext db) => await db.StaffMessages.ToListAsync());
app.MapPost("/api/staff-messages", async (StaffMessageEntity entity, SchoolPortalDbContext db) =>
{
    db.StaffMessages.Add(entity);
    await db.SaveChangesAsync();
    return Results.Created($"/api/staff-messages/{entity.Id}", entity);
});

app.MapGet("/api/questionnaires", async (SchoolPortalDbContext db) => await db.Questionnaires.ToListAsync());
app.MapPost("/api/questionnaires", async (QuestionnaireEntity entity, SchoolPortalDbContext db) =>
{
    db.Questionnaires.Add(entity);
    await db.SaveChangesAsync();
    return Results.Created($"/api/questionnaires/{entity.Id}", entity);
});

app.MapGet("/api/questions", async (SchoolPortalDbContext db) => await db.Questions.ToListAsync());
app.MapPost("/api/questions", async (QuestionEntity entity, SchoolPortalDbContext db) =>
{
    db.Questions.Add(entity);
    await db.SaveChangesAsync();
    return Results.Created($"/api/questions/{entity.Id}", entity);
});

app.MapGet("/api/questionnaire-responses", async (SchoolPortalDbContext db) => await db.QuestionnaireResponses.ToListAsync());
app.MapPost("/api/questionnaire-responses", async (QuestionnaireResponseEntity entity, SchoolPortalDbContext db) =>
{
    db.QuestionnaireResponses.Add(entity);
    await db.SaveChangesAsync();
    return Results.Created($"/api/questionnaire-responses/{entity.Id}", entity);
});

app.Run();
