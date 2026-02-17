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
            End = DateTime.Today.AddHours(10)
        },
        new()
        {
            Name = "World History",
            Instructor = "Mr. Carter",
            Room = "B-03",
            Start = DateTime.Today.AddDays(1).AddHours(11),
            End = DateTime.Today.AddDays(1).AddHours(12)
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
}
