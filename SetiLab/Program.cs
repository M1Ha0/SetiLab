using SetiLab.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Faker;
using System.Diagnostics.Metrics;
using SetiLab;

string[] posts =
{
    "Доцент",
    "Профессор",
    "Старший преподаватель",
    "Ассистент"
};
using (Iarmo26Context db = new Iarmo26Context())
{
    // Группы
    for (int i = 1; i <= 3; i++)
        db.Groups.Add(new Group
        {
            NameGroup = $"Гр-{i}",
            NumCourse = Number.RandomNumber(1, 4),
            NameSpeciality = Company.Industry()
        });
    db.SaveChanges();

    // Предметы
    for (int i = 0; i < 5; i++)
        db.Subjects.Add(new Subject
        {
            NameSubject = Education.Major(),
            CountHours = Number.RandomNumber(40, 120)
        });
    db.SaveChanges();

    // Преподаватели
    for (int i = 0; i < 3; i++)
        db.Lectors.Add(new Lector
        {
            NameLector = Name.FullName(),
            Science = Education.Major(),
            Post = posts[Number.RandomNumber(0, posts.Length - 1)],
            Date = DateOnly.FromDateTime(DateTime.Now.AddYears(-10))
        });
    db.SaveChanges();

    // Студенты
    var groups = db.Groups.ToList();
    for (int i = 0; i < 10; i++)
        db.Students.Add(new Student
        {
            Surname = Name.LastName(),
            Name = Name.FirstName(),
            Birthday = DateTime.Now.AddYears(-20),
            Phone = Phone.GetPhoneNumber(),
            CodeGroup = groups[Number.RandomNumber(0, groups.Count - 1)].CodeGroup
        });
    db.SaveChanges();

    // Успеваемость
    var studs = db.Students.ToList();
    var subs = db.Subjects.ToList();
    var lecs = db.Lectors.ToList();

    for (int i = 0; i < 20; i++)
        db.Progresses.Add(new Progress
        {
            CodeStud = studs[Number.RandomNumber(0, studs.Count - 1)].CodeStud,
            CodeSubject = subs[Number.RandomNumber(0, subs.Count - 1)].CodeSubject,
            CodeLector = lecs[Number.RandomNumber(0, lecs.Count - 1)].CodeLector,
            DateExam = DateOnly.FromDateTime(DateTime.Now),
            Estimate = Number.RandomNumber(2, 5)
        });

    db.SaveChanges();
}
//Задание 66
using (Iarmo26Context db = new Iarmo26Context())
{
    var students = db.Students.OrderBy(s => s.CodeStud).ToList();
    foreach (var s in students)
    {
        Console.WriteLine(
            $"{s.CodeStud} {s.Surname} {s.Name} {s.Lastname} {s.Birthday:d} {s.Phone} Group: {s.CodeGroup}"
        );
    }
}
//Задание 71
using (Iarmo26Context db = new Iarmo26Context())
{
    var list = db.Students.Join(
        db.Groups,
        s => s.CodeGroup,
        g => g.CodeGroup,
        (s, g) => new
        {
            s.Surname,
            s.Name,
            s.Lastname,
            NameGroup = g.NameGroup
        }).ToList();

    foreach (var item in list)
    {
        Console.WriteLine(
            item.Surname + " " +
            item.Name + " " +
            item.Lastname + " " +
            item.NameGroup
        );
    }
}
//Задание 76
using (Iarmo26Context db = new Iarmo26Context())
{
    var subjects = db.Subjects
        .Where(s => s.NameSubject.StartsWith("математ"))
        .Select(s => s.NameSubject)
        .ToList();

    foreach (var s in subjects)
    {
        Console.WriteLine(s);
    }
}
//Задание 81
using (Iarmo26Context db = new Iarmo26Context())
{
    DateOnly dateFrom = new DateOnly(2000, 3, 12);
    DateOnly dateTo = new DateOnly(2000, 6, 15);

    var lectors = db.Lectors
        .Where(l => l.Date >= dateFrom && l.Date <= dateTo)
        .Select(l => new
        {
            l.NameLector,
            l.Post
        })
        .ToList();

    foreach (var l in lectors)
    {
        Console.WriteLine(l.NameLector + " " + l.Post);
    }
}
//Задание 86
using (Iarmo26Context db = new Iarmo26Context())
{
    int[] subjects = { 5, 8, 12, 25 };

    var students = db.Students.Join(
        db.Progresses.Where(p => subjects.Contains(p.CodeSubject)),
        s => s.CodeStud,
        p => p.CodeStud,
        (s, p) => new
        {
            s.Surname,
            s.Name,
            s.Lastname
        })
        .Distinct()
        .ToList();

    foreach (var s in students)
    {
        Console.WriteLine(
            s.Surname + " " + s.Name + " " + s.Lastname
        );
    }
}
//Задание 91
using (Iarmo26Context db = new Iarmo26Context())
{
    DateOnly dateFrom = new DateOnly(2003, 1, 1);
    DateOnly dateTo = new DateOnly(2003, 2, 1);

    var lectors = db.Lectors.Join(
        db.Progresses.Where(p =>
            p.CodeSubject >= 5 &&
            p.CodeSubject <= 12 &&
            p.DateExam >= dateFrom &&
            p.DateExam <= dateTo),
        l => l.CodeLector,
        p => p.CodeLector,
        (l, p) => new
        {
            l.NameLector
        })
        .Distinct()
        .ToList();

    foreach (var l in lectors)
    {
        Console.WriteLine(l.NameLector);
    }
}
//Задание 99
using (Iarmo26Context db = new Iarmo26Context())
{
    var students = db.Students.Join(
        db.Groups,
        s => s.CodeGroup,
        g => g.CodeGroup,
        (s, g) => new
        {
            s.Surname,
            s.Name,
            s.Lastname,
            Course = g.NumCourse,
            YearsLeft = 4 - g.NumCourse
        })
        .ToList();

    foreach (var s in students)
    {
        Console.WriteLine(
            s.Surname + " " +
            s.Name + " " +
            s.Lastname + " | Курс: " +
            s.Course + " | Осталось лет: " +
            s.YearsLeft
        );
    }
}
//Задание 101
using (Iarmo26Context db = new Iarmo26Context())
{
    DateOnly dateFrom = new DateOnly(2003, 1, 5);
    DateOnly dateTo = new DateOnly(2003, 1, 25);

    var result = db.Students.Join(
        db.Progresses.Where(p =>
            p.DateExam >= dateFrom &&
            p.DateExam <= dateTo),
        s => s.CodeStud,
        p => p.CodeStud,
        (s, p) => new
        {
            s.Surname,
            s.Name,
            p.Estimate,
            s.CodeStud
        })
        .GroupBy(x => new { x.CodeStud, x.Surname, x.Name })
        .Select(g => new
        {
            g.Key.Surname,
            g.Key.Name,
            AvgEstimate = g.Average(x => x.Estimate)
        })
        .ToList();

    foreach (var r in result)
    {
        Console.WriteLine(
            r.Surname + " " + r.Name + " — средний балл: " + r.AvgEstimate
        );
    }
}
//Задание 106
using (Iarmo26Context db = new Iarmo26Context())
{
    var lectors = db.Lectors
        .Select(l => new
        {
            l.NameLector,
            l.Science,
            Old_years = DateTime.Now.Year - l.Date.ToDateTime(TimeOnly.MinValue).Year
        })
        .ToList();

    foreach (var l in lectors)
    {
        Console.WriteLine(
            l.NameLector + " " +
            l.Science + " " +
            l.Old_years
        );
    }
}
//Задание 111
using (Iarmo26Context db = new Iarmo26Context())
{
    var result =
        from A in db.Students
        join B in db.Progresses on A.CodeStud equals B.CodeStud
        join C in db.Subjects on B.CodeSubject equals C.CodeSubject
        select new
        {
            A.Surname,
            A.Name,
            C.NameSubject,
            C.CodeSubject,
            B.Estimate
        };

    foreach (var r in result)
    {
        Console.WriteLine(
            r.Surname + " " +
            r.Name + " | " +
            r.CodeSubject + " " +
            r.NameSubject + " | " +
            r.Estimate
        );
    }
}
//Задание 116
using (Iarmo26Context db = new Iarmo26Context())
{
    var avgDate = db.Lectors
        .Select(l => l.Date.ToDateTime(TimeOnly.MinValue))
        .Average(d => d.Ticks);

    DateOnly avgDateOnly = DateOnly.FromDateTime(new DateTime((long)avgDate));

    var lectors = db.Lectors
        .Where(l => l.Date < avgDateOnly)
        .ToList();

    foreach (var l in lectors)
    {
        Console.WriteLine(
            l.CodeLector + " " +
            l.NameLector + " " +
            l.Science + " " +
            l.Post + " " +
            l.Date
        );
    }
}
//Задание 121
using (Iarmo26Context db = new Iarmo26Context())
{
    var students = db.Students
        .Where(s =>
            db.Progresses
              .Where(p => p.CodeStud == s.CodeStud)
              .All(p => p.Estimate == 5)
        )
        .Select(s => new
        {
            s.Surname,
            s.Name,
            s.Lastname
        })
        .ToList();

    foreach (var s in students)
    {
        Console.WriteLine(
            s.Surname + " " +
            s.Name + " " +
            s.Lastname
        );
    }
}
//Задание 126
using (Iarmo26Context db = new Iarmo26Context())
{
    Progress progress = new Progress
    {
        CodeStud = 45,
        CodeSubject = 12,
        CodeLector = 11,
        DateExam = new DateOnly(2003, 3, 12),
        Estimate = 5   // оценку можно поставить любую или оставить нужную
    };

    db.Progresses.Add(progress);
    db.SaveChanges();
}