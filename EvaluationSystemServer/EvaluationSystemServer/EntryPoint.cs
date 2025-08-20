using Bogus;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EvaluationSystemServer
{
    public class EntryPoint
    {
        //public async static Task Main()
        //{
        //    await SetUpAsync();

        //    var thread = new Thread(() =>
        //    {
        //    });

        //    // Set the thread department to STA
        //    thread.SetApartmentState(ApartmentState.STA);

        //    // Start the application
        //    thread.Start();
        //}

        //private static async Task SetUpAsync()
        //{
        //    // Get the database context
        //    var dbContext = DI.GetDbContext;

        //    var result = dbContext.Database.EnsureCreatedAsync();

        public static void Init()
        {
            var context = DI.GetDbContext;

            var faker = new Faker();

            Random rand = new Random();

            #region Company

            var companies = new List<CompanyEntity>();
                var company = new CompanyEntity
                {
                    Id = 1,
                    AFM = 123456789,
                    DOY = "A' Athens",
                    Name = "RandomCompany",
                    Phone = "(+30) 2101234567",
                    Website = new Uri("https://www.example.com/path/to/resource?query=string"),
                    Address = "somewhere 20",
                    City = "Athens",
                    Country = "Greece",
                    DateCreated = DateTimeOffset.Now,
                    DateUpdated = DateTimeOffset.Now

                };
                companies.Add(company);

            context.Companies.AddRange(companies);
            context.SaveChanges();

            #endregion

            #region Certificates

            string[] universities = { "Harvard University", "Stanford University", "Massachusetts Institute of Technology", "University of Cambridge", "University of Oxford", "California Institute of Technology", "University of Chicago", "Princeton University", "Columbia University", "Yale University" };

            string[] certificateNames = { "Bachelor of Science", "Master of Arts", "Doctor of Philosophy", "Associate of Applied Science", "Certificate in Management", "Certificate in Marketing", "Certificate in Human Resources", "Certificate in Data Science", "Certificate in Artificial Intelligence", "Certificate in Cybersecurity" };

            var certificates = new List<CertificateEntity>();
            for (int i = 1; i < 20; i++)
            {
                var certificate = new CertificateEntity
                {
                    Id = i,
                    Name = certificateNames[rand.Next(certificateNames.Length)],
                    Department = universities[rand.Next(universities.Length)],
                    GraduationYear = faker.Random.Int(2000, 2023),
                    Grade = faker.Random.Double(0.0, 10.0),
                    DateCreated = DateTimeOffset.Now,
                    DateUpdated = DateTimeOffset.Now

                };
                certificates.Add(certificate);
            }
            context.Certificates.AddRange(certificates);
            context.SaveChanges();

            #endregion

            #region Skills

            string[] skillNames = { "C#", "Java", "Python", "JavaScript", "HTML", "CSS", "SQL", "React", "Angular", "Node.js", "MongoDB", "Unity", "Photoshop", "Illustrator", "Adobe Premiere" };

            string[] companyNames = { "Microsoft", "Amazon", "Google", "Facebook", "Apple", "Netflix", "Tesla", "Intel", "Oracle", "IBM", "Cisco", "HP", "Dell", "Samsung", "LG" };

            var skills = new List<SkillEntity>();
            for (int i = 1; i < 20; i++)
            {
                var skill = new SkillEntity
                {
                    Id = i,
                    Name = skillNames[rand.Next(skillNames.Length)],
                    Experience = companyNames[rand.Next(companyNames.Length)],
                    DateCreated = DateTimeOffset.Now,
                    DateUpdated = DateTimeOffset.Now
                };
                skills.Add(skill);
            }
            context.Skills.AddRange(skills);
            context.SaveChanges();

            #endregion

            #region Categories

            string[] categoryNames = { "Web Development", "Mobile App Development", "Data Analysis", "Machine Learning", "Artificial Intelligence", "Internet of Things", "Cloud Computing", "Game Development", "Virtual Reality", "Augmented Reality" };

            var categories = new List<CategoryEntity>();
            for (int i = 1; i < 9; i++)
            {
                var category = new CategoryEntity
                {
                    Id = i,
                    Name = categoryNames[rand.Next(categoryNames.Length)],
                    Description = faker.Lorem.Sentence(8),
                    DateCreated = DateTimeOffset.Now,
                    DateUpdated = DateTimeOffset.Now
                };
                categories.Add(category);
            }
            context.Categories.AddRange(categories);
            context.SaveChanges();

            #endregion

            #region Jobs

            string[] jobTitles = { "Software Engineer", "Product Manager", "Data Analyst", "Marketing Manager", "Sales Representative", "User Experience Designer", "Network Administrator", "Database Administrator", "Technical Writer", "Graphic Designer" };

            var jobs = new List<JobEntity>();
            for (int i = 1; i < 9; i++)
            {
                var job = new JobEntity
                {
                    Id = i,
                    Name = jobTitles[rand.Next(jobTitles.Length)],
                    Description = faker.Lorem.Sentence(8),
                    Salary = faker.Random.Decimal(1000.0m, 2500.0m),
                    DateCreated = DateTimeOffset.Now,
                    DateUpdated = DateTimeOffset.Now
                };
                jobs.Add(job);
            }
            context.Jobs.AddRange(jobs);
            context.SaveChanges();

            #endregion

            #region Job Positions

            var jobPositions = new List<JobPositionEntity>();
            for (int i = 1; i < 9; i++)
            {
                var jobPosition = new JobPositionEntity
                {
                    Id = i,
                    JobId = faker.Random.Int(1, 9),
                    IsOpen = faker.Random.Bool(),
                    DateCreated = DateTimeOffset.Now,
                    DateUpdated = DateTimeOffset.Now,
                    CompanyId = 1
                };
                jobPositions.Add(jobPosition);
            }
            context.JobPositions.AddRange(jobPositions);
            context.SaveChanges();

            #endregion

            #region Users

            var users = new List<UserEntity>();
            for (int i = 1; i < 30; i++)
            {
                var user = new UserEntity
                {
                    Id = i,
                    Username = $"rand{i}",
                    Password = $"rand{i}@1234",
                    Email = $"rand{i}@random.com",
                    FirstName = faker.Name.FirstName(),
                    LastName = faker.Name.LastName(),
                    Bio = faker.Lorem.Sentence(20),
                    Recommendations = faker.Lorem.Sentence(20),
                    Rating = faker.Random.Double(0.0, 5.0),
                    DateCreated = DateTimeOffset.Now,
                    DateUpdated = DateTimeOffset.Now,
                    CompanyId = 1,
                    JobPositionId = faker.Random.Int(1, 9)
                };
                users.Add(user);
            }
            context.Users.AddRange(users);
            context.SaveChanges();

            #endregion

            #region Projects

            string[] projectNames = { "Project A", "Project B", "Project C", "Project D", "Project E", "Project F", "Project G", "Project H", "Project I", "Project J, Design new product\", \"Implement new feature\", \"Test software\", \"Create marketing campaign\", \"Analyze user data\", \"Develop software architecture\", \"Manage project team\", \"Deploy software updates\", \"Maintain IT infrastructure\", \"Provide technical support" };

            var projects = new List<ProjectEntity>();
            for (int i = 1; i < 19; i++)
            {
                var project = new ProjectEntity
                {
                    Id = i,
                    Name = projectNames[rand.Next(projectNames.Length)],
                    Description = faker.Lorem.Sentence(20),
                    UserId = faker.Random.Int(1, 29),
                    Grade = faker.Random.Double(0.0, 10.0),
                    //isSubmitted = faker.Random.Bool(),
                    SubmissionStart = faker.Date.RecentOffset(10, DateTimeOffset.Now),
                    SubmissionEnd = faker.Date.SoonOffset(20, DateTimeOffset.Now.AddDays(11)),
                    DateCreated = DateTimeOffset.Now,
                    DateUpdated = DateTimeOffset.Now
                };
                projects.Add(project);
            }
            context.Projects.AddRange(projects);
            context.SaveChanges();

            #endregion

            #region Project Categories

            var projectCategories = new List<ProjectCategoryEntity>();
            for (int i = 1; i < 19; i++)
            {
                var projectCategory = new ProjectCategoryEntity
                {
                    Id = i,
                    CategoryId = faker.Random.Int(1, 9),
                    ProjectId = faker.Random.Int(1, 19),
                    DateCreated = DateTimeOffset.Now,
                    DateUpdated = DateTimeOffset.Now
                };
                projectCategories.Add(projectCategory);
            }
            context.ProjectCategories.AddRange(projectCategories);
            context.SaveChanges();

            #endregion

            #region User Skills

            var userSkills = new List<UserSkillEntity>();
            for (int i = 1; i < 50; i++)
            {
                var userSkill = new UserSkillEntity
                {
                    Id = i,
                    UserId = faker.Random.Int(1, 29),
                    SkillId = faker.Random.Int(1, 19),
                    DateCreated = DateTimeOffset.Now,
                    DateUpdated = DateTimeOffset.Now
                };
                userSkills.Add(userSkill);
            }
            context.UserSkills.AddRange(userSkills);
            context.SaveChanges();

            #endregion

            #region User Certificates

            var userCertificates = new List<UserCertificateEntity>();
            for (int i = 1; i < 50; i++)
            {
                var userCertificate = new UserCertificateEntity
                {
                    Id = i,
                    UserId = faker.Random.Int(1, 29),
                    CertificateId = faker.Random.Int(1, 19),
                    DateCreated = DateTimeOffset.Now,
                    DateUpdated = DateTimeOffset.Now
                };
                userCertificates.Add(userCertificate);
            }
            context.UserCertificates.AddRange(userCertificates);
            context.SaveChanges();

            #endregion

            #region Meetings

            var meetings = new List<MeetingEntity>();
            for (int i = 1; i < 40; i++)
            {
                var meeting = new MeetingEntity
                {
                    Id = i,
                    MeetingDate = faker.Date.RecentOffset(15, DateTimeOffset.Now),
                    Duration = faker.Date.Timespan(new TimeSpan(1, 0, 0)),
                    Link = new Uri(faker.Internet.Url()),
                    DateCreated = DateTimeOffset.Now,
                    DateUpdated = DateTimeOffset.Now,
                    Description = faker.Lorem.Sentence(10),
                    Location = faker.Address.StreetAddress(),
                    OrganizerId = faker.Random.Int(1,5)
                };
                meetings.Add(meeting);
            }
            context.Meetings.AddRange(meetings);
            context.SaveChanges();

            #endregion

            #region Participant Meetings

            var participantMeetings = new List<ParticipantMeetingEntity>();
            for (int i = 1; i < 50; i++)
            {
                var participantMeeting = new ParticipantMeetingEntity
                {
                    Id = i,
                    ParticipantId = faker.Random.Int(6, 29),
                    MeetingId = faker.Random.Int(1, 39),
                    DateCreated = DateTimeOffset.Now,
                    DateUpdated = DateTimeOffset.Now,

                };
                participantMeetings.Add(participantMeeting);
            }
            context.ParticipantMeetings.AddRange(participantMeetings);
            context.SaveChanges();

            #endregion

            #region Job Applications

            var jobApplications = new List<JobApplicationEntity>();
            for (int i = 1; i < 15; i++)
            {
                var jobApplication = new JobApplicationEntity
                {
                    Id = i,
                    Grade = faker.Random.Double(0.0, 10.0),
                    Comments = faker.Lorem.Sentence(10),
                    ManagerId = faker.Random.Int(1, 3),
                    EvaluatorId = faker.Random.Int(4, 6),
                    EmployeeId = faker.Random.Int(7, 29),
                    JobPositionId = faker.Random.Int(4, 7),
                    SubmissionStart = faker.Date.RecentOffset(10, DateTimeOffset.Now),
                    SubmissionEnd = faker.Date.SoonOffset(20, DateTimeOffset.Now.AddDays(11)),
                    DateCreated = DateTimeOffset.Now,
                    DateUpdated = DateTimeOffset.Now,

                };
                jobApplications.Add(jobApplication);
            }
            context.JobApplications.AddRange(jobApplications);
            context.SaveChanges();

            #endregion
        }




        //    #region Certificates

        //    var certificates = new Faker<CertificateEntity>()
        //        .RuleFor(x => x.Name, faker => faker.Lorem.Sentence(2))
        //        .RuleFor(x => x.Department, faker => faker.Lorem.Sentence(3))
        //        .RuleFor(x => x.GraduationYear, faker => faker.Random.Int(2000,2023))
        //        .RuleFor(x => x.Grade, faker => faker.Random.Double(5.0,10.0))
        //        .Generate(20);

        //    dbContext.Certificates.AddRange(certificates);

        //    await dbContext.SaveChangesAsync();

        //    #endregion

        //#region Skills

        //var skills = new Faker<SkillEntity>()
        //    .RuleFor(x => x.Name, faker => faker.Lorem.Sentence(2))
        //    .RuleFor(x => x.Experience, faker => faker.Lorem.Sentence(3))
        //    .Generate(20);

        //dbContext.Certificates.AddRange(certificates);

        //await dbContext.SaveChangesAsync();

        //#endregion

        //#region Categories

        //var categories = new Faker<CategoryEntity>()
        //    .RuleFor(x => x.Name, faker => faker.Lorem.Sentence(1))
        //    .RuleFor(x => x.Description, faker => faker.Lorem.Sentence(5))
        //    .Generate(10);

        //dbContext.Categories.AddRange(categories);

        //await dbContext.SaveChangesAsync();

        //#endregion

        //#region Companies

        //var companies = new Faker<CompanyEntity>()
        //    .RuleFor(x => x.AFM, faker => faker.Random.Int(1000, 9999))
        //    .RuleFor(x => x.DOY, faker => faker.Lorem.Sentence(1))
        //    .RuleFor(x => x.Name, faker => faker.Lorem.Sentence(1))
        //    .RuleFor(x => x.Phone, faker => faker.Random.Int(1000000, 9999999).ToString())
        //    //.RuleFor(x => x.Website, faker => faker.Images.DataUri)
        //    .Generate(20);

        //dbContext.Companies.AddRange(companies);

        //await dbContext.SaveChangesAsync();

        //#endregion

        //#region Jobs

        //var jobs = new Faker<JobEntity>()
        //    .RuleFor(x => x.Name, faker => faker.Lorem.Sentence(3))
        //    .RuleFor(x => x.Description, faker => faker.Lorem.Sentence(5))
        //    .RuleFor(x => x.Salary, faker => faker.Random.Decimal(1000.0m, 3000.0m))
        //    .Generate(10);

        //dbContext.Jobs.AddRange(jobs);

        //await dbContext.SaveChangesAsync();

        //#endregion

        //#region JobPositions

        //var jobPostions = new Faker<JobPositionEntity>()
        //    .RuleFor(x => x.IsOpen, faker => faker.Random.Bool())
        //    .Generate(10);

        //dbContext.JobPositions.AddRange(jobPostions);

        //await dbContext.SaveChangesAsync();

        //#endregion

        //#region Users

        //var users = new Faker<UserEntity>()
        //    .RuleFor(x => x.Username, faker => faker.Person.UserName)
        //    .RuleFor(x => x.Password, faker => faker.Random.String(5, 10))
        //    .RuleFor(x => x.Email, (faker, x) => faker.Internet.Email(x.Username, ".com"))
        //    .RuleFor(x => x.FirstName, faker => faker.Person.FirstName)
        //    .RuleFor(x => x.LastName, faker => faker.Person.LastName)
        //    .RuleFor(x => x.Bio, faker => faker.Lorem.Sentence(10))
        //    .RuleFor(x => x.Recommendations, faker => faker.Lorem.Sentence(10))
        //    .RuleFor(x => x.Rating, faker => faker.Random.Double(0.0, 5.0))
        //    .RuleFor(x => x.UserType, faker => faker.Random.Enum<StaffType>())
        //    .Generate(50);

        //dbContext.Users.AddRange(users);

        //dbContext.SaveChanges();

        //#endregion

        //#region JobApplications

        //var jobApplications = new Faker<JobApplicationEntity>()
        //    .RuleFor(x => x.Grade, faker => faker.Random.Double(0.0, 5.0))
        //    .RuleFor(x => x.Comments, faker => faker.Lorem.Sentence(10))
        //    .RuleFor(x => x.SubmissionStart, faker => faker.Date.RecentOffset(1, DateTimeOffset.Now))
        //    .RuleFor(x => x.SubmissionEnd, faker => faker.Date.SoonOffset(15, DateTimeOffset.Now))
        //    .Generate(50);

        //#endregion

        //#region Projects

        //var projects = new Faker<ProjectEntity>()
        //    .RuleFor(x => x.Name, faker => faker.Lorem.Sentence(2))
        //    .RuleFor(x => x.Description, faker => faker.Lorem.Sentence(10))
        //    .RuleFor(x => x.SubmissionStart, faker => faker.Date.RecentOffset(1, DateTimeOffset.Now ))
        //    .RuleFor(x => x.SubmissionEnd, faker => faker.Date.SoonOffset(15, DateTimeOffset.Now ))
        //    .RuleFor(x => x.Grade, faker => faker.Random.Double(0.0, 10.0))
        //    .RuleFor(x => x.isSubmitted, faker => faker.Random.Bool())
        //    .Generate(50);

        //dbContext.Projects.AddRange(projects);

        //dbContext.SaveChanges();

        //#endregion

        //#region Meetings

        //var meetings = new Faker<MeetingEntity>()
        //    .RuleFor(x => x.MeetingDate, faker => faker.Date.SoonOffset(10, DateTimeOffset.Now ))
        //    .RuleFor(x => x.Duration, faker => faker.Date.Timespan(new TimeSpan(1, 0, 0)))
        //    //.RuleFor(x => x.Link)
        //    .RuleFor(x => x.Title, faker => faker.Lorem.Sentence(2))
        //    .RuleFor(x => x.Description, faker => faker.Lorem.Sentence(10))
        //    .RuleFor(x => x.Location, faker => faker.Lorem.Sentence(1))
        //    .Generate(50);

        //dbContext.Meetings.AddRange(meetings);

        //await dbContext.SaveChangesAsync();

        //#endregion
    }
    }

