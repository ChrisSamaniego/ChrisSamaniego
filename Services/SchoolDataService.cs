using SchoolPortal.Models;

namespace SchoolPortal.Services;

public class SchoolDataService
{
    public List<ClassSchedule> Schedules { get; } =
    [
        new()
        {
            Name = "Mathematics 101",
            Instructor = "Ms. Rivera",
            Room = "A-12",
            Start = DateTime.Today.AddHours(9),
            End = DateTime.Today.AddHours(10),
            AssignedStudents = ["Student One"]
        },
        new()
        {
            Name = "World History",
            Instructor = "Mr. Carter",
            Room = "B-03",
            Start = DateTime.Today.AddDays(1).AddHours(11),
            End = DateTime.Today.AddDays(1).AddHours(12),
            AssignedStudents = ["Student One"]
        },
        new()
        {
            Name = "Physics Lab",
            Instructor = "Dr. Stone",
            Room = "C-11",
            Start = DateTime.Today.AddDays(3).AddHours(14),
            End = DateTime.Today.AddDays(3).AddHours(15)
        }
    ];

    public List<Questionnaire> Questionnaires { get; } =
    [
        new()
        {
            Title = "Science Test",
            Questions =
            [
                "What is Newton's second law?",
                "Name one renewable energy source.",
                "Explain the difference between mass and weight."
            ]
        }
    ];


    public List<PortalDocument> Documents { get; } =
    [
        new()
        {
            FileName = "School-Rules.pdf",
            ContentType = "application/pdf",
            Base64Content = "VGhpcyBpcyBhIHNhbXBsZSBkb2N1bWVudCBmaWxlLg==",
            UploadedBy = "Student One",
            UploadedAt = DateTime.UtcNow.AddDays(-1)
        }
    ];


    public List<CourseFee> CourseFees { get; } =
    [
        new() { CourseName = "Mathematics 101", Amount = 240m, Currency = "USD", BillingPeriod = "Monthly" },
        new() { CourseName = "World History", Amount = 180m, Currency = "USD", BillingPeriod = "Monthly" },
        new() { CourseName = "Physics Lab", Amount = 210m, Currency = "USD", BillingPeriod = "Monthly" }
    ];


    public List<CourseCatalogItem> Courses { get; } =
    [
        new() { Code = "MATH101", Name = "Mathematics 101", Credits = 3 },
        new() { Code = "HIST201", Name = "World History", Credits = 2 },
        new() { Code = "PHYS110", Name = "Physics Lab", Credits = 3 }
    ];



    public List<StaffMessage> StaffMessages { get; } =
    [
        new()
        {
            FromRole = UserRole.Teacher,
            ToRole = UserRole.Administrator,
            Subject = "Attendance summary",
            Content = "Please review attendance report for Grade 9.",
            SentAt = DateTime.UtcNow.AddHours(-4)
        },
        new()
        {
            FromRole = UserRole.Administrator,
            ToRole = UserRole.Teacher,
            Subject = "Re: Attendance summary",
            Content = "Reviewed. Thanks for sharing the report.",
            SentAt = DateTime.UtcNow.AddHours(-2)
        }
    ];

    public List<AdminMessage> AdminMessages { get; } =
    [
        new()
        {
            StudentName = "Student One",
            Subject = "Question about Physics lab",
            Content = "Can I submit the lab report on Friday instead of Thursday?",
            SentAt = DateTime.UtcNow.AddHours(-8),
            AdminReply = "Yes, Friday 5:00 PM is acceptable. Please upload it to the portal.",
            RepliedAt = DateTime.UtcNow.AddHours(-5)
        },
        new()
        {
            StudentName = "Student One",
            Subject = "Need support with schedule",
            Content = "Can you help me move to the morning math section?",
            SentAt = DateTime.UtcNow.AddHours(-2)
        }
    ];

    public void CreateSchedule(ClassSchedule schedule)
    {
        schedule.Id = Guid.NewGuid();
        Schedules.Add(schedule);
    }

    public void AssignStudentToSchedule(Guid scheduleId, string studentName)
    {
        var schedule = Schedules.FirstOrDefault(x => x.Id == scheduleId);
        if (schedule is null)
        {
            return;
        }

        if (!schedule.AssignedStudents.Contains(studentName, StringComparer.OrdinalIgnoreCase))
        {
            schedule.AssignedStudents.Add(studentName);
        }
    }

    public void CreateQuestionnaire(Questionnaire questionnaire)
    {
        questionnaire.Id = Guid.NewGuid();
        questionnaire.Questions = questionnaire.Questions
            .Where(q => !string.IsNullOrWhiteSpace(q))
            .Select(q => q.Trim())
            .ToList();

        Questionnaires.Add(questionnaire);
    }

    public void SubmitResponse(Guid questionnaireId, QuestionnaireResponse response)
    {
        var questionnaire = Questionnaires.FirstOrDefault(q => q.Id == questionnaireId);
        if (questionnaire is null)
        {
            return;
        }

        questionnaire.Responses.Add(response);
    }


    public void CreateCourse(CourseCatalogItem course)
    {
        course.Id = Guid.NewGuid();
        Courses.Insert(0, course);
    }

    public void AddCourseFee(CourseFee courseFee)
    {
        CourseFees.Insert(0, courseFee);
    }



    public void SendStaffMessage(UserRole fromRole, UserRole toRole, string subject, string content)
    {
        if (string.IsNullOrWhiteSpace(subject) || string.IsNullOrWhiteSpace(content))
        {
            return;
        }

        StaffMessages.Insert(0, new StaffMessage
        {
            FromRole = fromRole,
            ToRole = toRole,
            Subject = subject.Trim(),
            Content = content.Trim(),
            SentAt = DateTime.UtcNow
        });
    }

    public void SendMessageToAdmin(string studentName, string subject, string content)
    {
        AdminMessages.Insert(0, new AdminMessage
        {
            StudentName = studentName,
            Subject = subject.Trim(),
            Content = content.Trim(),
            SentAt = DateTime.UtcNow
        });
    }

    public void ReplyToMessage(Guid messageId, string reply)
    {
        var message = AdminMessages.FirstOrDefault(m => m.Id == messageId);
        if (message is null || string.IsNullOrWhiteSpace(reply))
        {
            return;
        }

        message.AdminReply = reply.Trim();
        message.RepliedAt = DateTime.UtcNow;
    }


    public void UploadDocument(string fileName, string contentType, string base64Content, string uploadedBy)
    {
        Documents.Insert(0, new PortalDocument
        {
            FileName = fileName,
            ContentType = string.IsNullOrWhiteSpace(contentType) ? "application/octet-stream" : contentType,
            Base64Content = base64Content,
            UploadedBy = uploadedBy,
            UploadedAt = DateTime.UtcNow
        });
    }

}
