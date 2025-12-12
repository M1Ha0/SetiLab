using SetiLab.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Faker;
using System.Diagnostics.Metrics;
using SetiLab;
using (Iarmo26Context db = new Iarmo26Context())
{
    Subject s1 = new Subject { NameSubject = "Математика",CountHours =24 };
    Subject s2 = new Subject { NameSubject = "Русский", CountHours = 30 };
    Subject s3 = new Subject { NameSubject = "Биология", CountHours = 12 };
    db.Subjects.Add(s1);
    db.Subjects.Add(s2);
    db.Subjects.Add(s3);
    Lector l1 = new Lector { NameLector = "Андрей", Science = "Кандидат наук", Post="Учитель"};
    Lector l2 = new Lector { NameLector = "Владимир", Science = "Кандидат наук", Post = "Зауч" };
    Lector l3 = new Lector { NameLector = "Александр", Science = "Кандидат наук", Post = "Декан" };
    db.Lectors.Add(l1);
    db.Lectors.Add(l2);
    db.Lectors.Add(l3);
    Group g1 = new Group { NameGroup = "Исп", NumCourse = 3, NameSpeciality = "Програмирование" };
    Group g2 = new Group { NameGroup = "Са", NumCourse = 4, NameSpeciality = "Системное" };
    db.Groups.Add(g1);
    db.Groups.Add(g2);
    db.SaveChanges();
    for (int i = 1; i < 6; i++)
    {
        SetiLab.Models.Student stu1 = new SetiLab.Models.Student();
        stu1.Name = Faker.Name.FirstName();
        stu1.Surname = Faker.Name.LastName();
        stu1.Phone = Faker.Phone.GetShortPhoneNumber();
        stu1.Birthday = Faker.Date.Birthday();
        stu1.CodeGroup = db.Groups.FirstOrDefault(p => p.NameGroup == "Са")!.CodeGroup;
        db.Students.Add(stu1);

        SetiLab.Models.Student stu2 = new SetiLab.Models.Student();
        stu2.Name = Faker.Name.FirstName();
        stu2.Surname = Faker.Name.LastName();
        stu2.Phone = Faker.Phone.GetShortPhoneNumber();
        stu2.Birthday = Faker.Date.Birthday();
        stu2.CodeGroup = db.Groups.FirstOrDefault(p => p.NameGroup == "Исп")!.CodeGroup;
        db.Students.Add(stu2);
    }
    db.SaveChanges();
}
using (Iarmo26Context db = new Iarmo26Context())
{
    var student1 = db.Students.OrderBy(p => p.CodeStud);
    foreach (Student u in student1)
    {
        Console.WriteLine(u.CodeStud + " " + u.Name + " " + u.Surname + " " + u.Lastname + " " + u.Birthday + " " + u.Phone + " " + u.CodeGroup);
    }
}
