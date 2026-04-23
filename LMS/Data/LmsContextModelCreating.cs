using LMS.Models;
using LMS.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace LMS.Data
{
    public static class LmsContextModelCreating
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            // =========================
            //  IDENTITY PASSWORD HASHER
            // =========================
            var hasher = new PasswordHasher<User>();

            // =========================
            //  INSTRUCTORS
            // =========================
            var instructor1 = new User
            {
                Id = "I1",
                UserName = "smith@uni.com",
                NormalizedUserName = "SMITH@UNI.COM",
                Email = "smith@uni.com",
                NormalizedEmail = "SMITH@UNI.COM",
                Name = "Dr. Smith",
                Role = UserRole.Instructor,
                CreatedDate = DateTime.Now,
                SecurityStamp = Guid.NewGuid().ToString()
            };
            instructor1.PasswordHash = hasher.HashPassword(instructor1, "Password123!");

            var instructor2 = new User
            {
                Id = "I2",
                UserName = "johnson@uni.com",
                NormalizedUserName = "JOHNSON@UNI.COM",
                Email = "johnson@uni.com",
                NormalizedEmail = "JOHNSON@UNI.COM",
                Name = "Dr. Johnson",
                Role = UserRole.Instructor,
                CreatedDate = DateTime.Now,
                SecurityStamp = Guid.NewGuid().ToString()
            };
            instructor2.PasswordHash = hasher.HashPassword(instructor2, "Password123!");

            var instructor3 = new User
            {
                Id = "I3",
                UserName = "lee@uni.com",
                NormalizedUserName = "LEE@UNI.COM",
                Email = "lee@uni.com",
                NormalizedEmail = "LEE@UNI.COM",
                Name = "Dr. Lee",
                Role = UserRole.Instructor,
                CreatedDate = DateTime.Now,
                SecurityStamp = Guid.NewGuid().ToString()
            };
            instructor3.PasswordHash = hasher.HashPassword(instructor3, "Password123!");

            // =========================
            //  STUDENTS
            // =========================
            var students = new List<User>();

            for (int i = 1; i <= 8; i++)
            {
                var student = new User
                {
                    Id = $"S{i}",
                    UserName = $"student{i}@uni.com",
                    NormalizedUserName = $"STUDENT{i}@UNI.COM",
                    Email = $"student{i}@uni.com",
                    NormalizedEmail = $"STUDENT{i}@UNI.COM",
                    Name = $"Student {i}",
                    Role = UserRole.Student,
                    CreatedDate = DateTime.Now,
                    SecurityStamp = Guid.NewGuid().ToString()
                };

                student.PasswordHash = hasher.HashPassword(student, "Password123!");
                students.Add(student);
            }

            modelBuilder.Entity<User>().HasData(
                instructor1, instructor2, instructor3
            );

            modelBuilder.Entity<User>().HasData(students.ToArray());
            // =========================
            //  COURSES
            // =========================
            modelBuilder.Entity<Course>().HasData(
                new Course
                {
                    Id = 1,
                    Title = "Introduction to Programming",
                    Description = "Basics of coding",
                    InstructorId = "I1",
                    Credits = 3,
                    MaxEnrollment = 30,
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddMonths(4),
                    CreatedDate = DateTime.Now
                },
                new Course
                {
                    Id = 2,
                    Title = "Data Structures",
                    Description = "Advanced data handling",
                    InstructorId = "I2",
                    Credits = 3,
                    MaxEnrollment = 25,
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddMonths(4),
                    CreatedDate = DateTime.Now
                },
                new Course
                {
                    Id = 3,
                    Title = "Web Development",
                    Description = "ASP.NET Core",
                    InstructorId = "I3",
                    Credits = 3,
                    MaxEnrollment = 20,
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddMonths(4),
                    CreatedDate = DateTime.Now
                }
            );

            // =========================
            //  ASSIGNMENTS
            // =========================
            modelBuilder.Entity<Assignment>().HasData(
                new Assignment
                {
                    Id = 1,
                    CourseId = 1,
                    Title = "Variables Assignment",
                    MaxPoints = 10,
                    DueDate = new DateTime(2026, 05, 01),
                    CreatedDate = new DateTime(2026, 04, 01),
                    Deleted = false
                },
                new Assignment
                {
                    Id = 2,
                    CourseId = 2,
                    Title = "Linked List",
                    MaxPoints = 25,
                    DueDate = new DateTime(2026, 05, 05),
                    CreatedDate = new DateTime(2026, 04, 01),
                    Deleted = false
                }
            );

            // =========================
            //  STUDENT COURSE ENROLLMENT
            // =========================
            modelBuilder.Entity<StudentCourse>().HasData(
              new StudentCourse { StudentId = "S1", CourseId = 1, EnrollmentDate = new DateTime(2026, 04, 01) },
              new StudentCourse { StudentId = "S2", CourseId = 1, EnrollmentDate = new DateTime(2026, 04, 01) },
              new StudentCourse { StudentId = "S3", CourseId = 2, EnrollmentDate = new DateTime(2026, 04, 01) },
              new StudentCourse { StudentId = "S4", CourseId = 2, EnrollmentDate = new DateTime(2026, 04, 01) },
              new StudentCourse { StudentId = "S5", CourseId = 3, EnrollmentDate = new DateTime(2026, 04, 01) }
          );

            // =========================
            //  STUDENT ASSIGNMENTS
            // =========================
            modelBuilder.Entity<StudentAssignment>().HasData
            (
               new StudentAssignment
               {
                   StudentId = "S1",
                   AssignmentId = 1,
                   Status = AssignmentStatus.Submitted,
                   PointsEarned = 8,
                   Feedback = "Good work"   
               },
                new StudentAssignment
                {
                    StudentId = "S2",
                    AssignmentId = 1,
                    Status = AssignmentStatus.Pending,
                    PointsEarned = null,
                    Feedback = null  
                }
            );
        }
    }
}