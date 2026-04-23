using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LMS.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserType = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InstructorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Credits = table.Column<int>(type: "int", nullable: false),
                    MaxEnrollment = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InstructorId1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_AspNetUsers_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Courses_AspNetUsers_InstructorId1",
                        column: x => x.InstructorId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Assignments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    MaxPoints = table.Column<int>(type: "int", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assignments_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentCourses",
                columns: table => new
                {
                    StudentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    EnrollmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Grade = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCourses", x => new { x.StudentId, x.CourseId });
                    table.ForeignKey(
                        name: "FK_StudentCourses_AspNetUsers_StudentId",
                        column: x => x.StudentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentCourses_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentAssignments",
                columns: table => new
                {
                    StudentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AssignmentId = table.Column<int>(type: "int", nullable: false),
                    SubmissionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PointsEarned = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Feedback = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentAssignments", x => new { x.StudentId, x.AssignmentId });
                    table.ForeignKey(
                        name: "FK_StudentAssignments_AspNetUsers_StudentId",
                        column: x => x.StudentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentAssignments_Assignments_AssignmentId",
                        column: x => x.AssignmentId,
                        principalTable: "Assignments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedDate", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "ModifiedDate", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName", "UserType" },
                values: new object[,]
                {
                    { "I1", 0, "3e3ed75d-ef2a-4ab4-a3ef-6c17ae6a8b39", new DateTime(2026, 4, 23, 12, 7, 5, 983, DateTimeKind.Local).AddTicks(9042), "smith@uni.com", false, false, null, null, "Dr. Smith", "SMITH@UNI.COM", "SMITH@UNI.COM", "AQAAAAIAAYagAAAAEGmmZra/4lfuYoNmBDrqjzED1TOxPJnPuCaIQtZE2I83OdUjT/Nu8+96taT3kRoTaQ==", null, false, 0, "768fc6fb-4896-4e89-b031-f4538d7017b6", false, "smith@uni.com", "User" },
                    { "I2", 0, "f5968c9e-7c67-4cfb-84e9-87ab374b7145", new DateTime(2026, 4, 23, 12, 7, 6, 36, DateTimeKind.Local).AddTicks(211), "johnson@uni.com", false, false, null, null, "Dr. Johnson", "JOHNSON@UNI.COM", "JOHNSON@UNI.COM", "AQAAAAIAAYagAAAAEBqR4EYb7xIbkNAXd1fnUBxSe2CJ91gANeZUlM9QC/sNK9cSxxldTa4Pwunrb9emjQ==", null, false, 0, "9a0c99d0-d9b2-4d99-b47b-a803e581e27e", false, "johnson@uni.com", "User" },
                    { "I3", 0, "797031e4-30f6-4e22-b49a-452d0710267c", new DateTime(2026, 4, 23, 12, 7, 6, 92, DateTimeKind.Local).AddTicks(7590), "lee@uni.com", false, false, null, null, "Dr. Lee", "LEE@UNI.COM", "LEE@UNI.COM", "AQAAAAIAAYagAAAAEC3G+wMUB59RAwFd95rZmyMfs8RuyvE2dfEjW7QnfJz+FmiRvYaGa6OrXimNKlbyCw==", null, false, 0, "79ce6402-fc40-481f-aa34-6f320d7aee14", false, "lee@uni.com", "User" },
                    { "S1", 0, "2d75da69-7ead-480c-9914-92187e4d063c", new DateTime(2026, 4, 23, 12, 7, 6, 143, DateTimeKind.Local).AddTicks(5592), "student1@uni.com", false, false, null, null, "Student 1", "STUDENT1@UNI.COM", "STUDENT1@UNI.COM", "AQAAAAIAAYagAAAAEJlw9GMS9h/b4GwprgwEH6UvU57PEDHBgmnXv7d9FRHskUq/4ABWPKzgxVDpyfJygA==", null, false, 1, "29981f8d-0752-47c1-9958-64535091a5ae", false, "student1@uni.com", "User" },
                    { "S2", 0, "5d0d3bfd-a186-42a6-aaf2-5ce816dcc134", new DateTime(2026, 4, 23, 12, 7, 6, 195, DateTimeKind.Local).AddTicks(2866), "student2@uni.com", false, false, null, null, "Student 2", "STUDENT2@UNI.COM", "STUDENT2@UNI.COM", "AQAAAAIAAYagAAAAECEn4GFdD/KFEJhFAEdkB5fpg2X465WFkiNz97S0PCydozzm6fJOOUUr5Fp6i0jpQg==", null, false, 1, "26002a05-13a9-4a74-9c2a-674a87ac5bb6", false, "student2@uni.com", "User" },
                    { "S3", 0, "c6fef8fd-6787-449d-972c-be44bbb35678", new DateTime(2026, 4, 23, 12, 7, 6, 246, DateTimeKind.Local).AddTicks(6856), "student3@uni.com", false, false, null, null, "Student 3", "STUDENT3@UNI.COM", "STUDENT3@UNI.COM", "AQAAAAIAAYagAAAAEDLWorrj/l3VJ3d3VjL4viVAeECaFuqKy8UufVq7tJ2WkrDkOP7MpZjxyBvsXTCaYw==", null, false, 1, "0eab4826-4d95-426c-8e4b-57b7ab533bf4", false, "student3@uni.com", "User" },
                    { "S4", 0, "97ca0052-31f4-4912-83cc-fdd2590cdec2", new DateTime(2026, 4, 23, 12, 7, 6, 301, DateTimeKind.Local).AddTicks(671), "student4@uni.com", false, false, null, null, "Student 4", "STUDENT4@UNI.COM", "STUDENT4@UNI.COM", "AQAAAAIAAYagAAAAECtSurK+1I6iB1bxxsCueC3AN2f5bjSzRMurWq3J+eG7SRjtv+LyLb+70qVyWvxKqw==", null, false, 1, "c9924525-ee25-4bf7-9c48-faae44805956", false, "student4@uni.com", "User" },
                    { "S5", 0, "5bc90bc9-7d48-49a3-8395-73bf3971e494", new DateTime(2026, 4, 23, 12, 7, 6, 352, DateTimeKind.Local).AddTicks(5359), "student5@uni.com", false, false, null, null, "Student 5", "STUDENT5@UNI.COM", "STUDENT5@UNI.COM", "AQAAAAIAAYagAAAAEIaLowWn99gVpFg9DTAOAHhpayneu9utJoiWcCXkYAwvI4+o/lb+spAMq8FoybkXyQ==", null, false, 1, "db86736e-5c03-4a50-be26-46f407986b3b", false, "student5@uni.com", "User" },
                    { "S6", 0, "9aeb560a-9ac5-4b4e-9d99-6cb0686f3042", new DateTime(2026, 4, 23, 12, 7, 6, 410, DateTimeKind.Local).AddTicks(6346), "student6@uni.com", false, false, null, null, "Student 6", "STUDENT6@UNI.COM", "STUDENT6@UNI.COM", "AQAAAAIAAYagAAAAECZroKPvVqvtZowlUBNEz7aRsIpYLkM1V7oBRKcx9DhQjBi1looegEf/INDz6ngqhg==", null, false, 1, "c52b9f04-6da7-4b2d-af5d-a0b71c0f72aa", false, "student6@uni.com", "User" },
                    { "S7", 0, "09e04d4a-8f66-4120-baad-b1af6629c018", new DateTime(2026, 4, 23, 12, 7, 6, 488, DateTimeKind.Local).AddTicks(8979), "student7@uni.com", false, false, null, null, "Student 7", "STUDENT7@UNI.COM", "STUDENT7@UNI.COM", "AQAAAAIAAYagAAAAEIr0wJPFeyG96ZNHGEpOjqob03KJN9cYnBWQOVTZk2/Zgw1C2/IYQjtxrKBQfWzLKA==", null, false, 1, "780ac610-fafd-4549-85be-ed683542ffde", false, "student7@uni.com", "User" },
                    { "S8", 0, "e1648e1b-1f54-4804-8f5f-d871d4a3e335", new DateTime(2026, 4, 23, 12, 7, 6, 540, DateTimeKind.Local).AddTicks(2062), "student8@uni.com", false, false, null, null, "Student 8", "STUDENT8@UNI.COM", "STUDENT8@UNI.COM", "AQAAAAIAAYagAAAAEJJIIQnaDcg71vQIuGG0aBiDuLXS9yL7q8BcEvDn0RBt9eO7aZGX0Gymm/0JoRdshA==", null, false, 1, "9ea6652d-0498-47b2-989b-4d8e4ec6bcc9", false, "student8@uni.com", "User" }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CreatedDate", "Credits", "Description", "EndDate", "InstructorId", "InstructorId1", "MaxEnrollment", "StartDate", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 4, 23, 12, 7, 6, 590, DateTimeKind.Local).AddTicks(4050), 3, "Basics of coding", new DateTime(2026, 8, 23, 12, 7, 6, 590, DateTimeKind.Local).AddTicks(4007), "I1", null, 30, new DateTime(2026, 4, 23, 12, 7, 6, 590, DateTimeKind.Local).AddTicks(3991), "Introduction to Programming" },
                    { 2, new DateTime(2026, 4, 23, 12, 7, 6, 590, DateTimeKind.Local).AddTicks(4062), 3, "Advanced data handling", new DateTime(2026, 8, 23, 12, 7, 6, 590, DateTimeKind.Local).AddTicks(4061), "I2", null, 25, new DateTime(2026, 4, 23, 12, 7, 6, 590, DateTimeKind.Local).AddTicks(4060), "Data Structures" },
                    { 3, new DateTime(2026, 4, 23, 12, 7, 6, 590, DateTimeKind.Local).AddTicks(4064), 3, "ASP.NET Core", new DateTime(2026, 8, 23, 12, 7, 6, 590, DateTimeKind.Local).AddTicks(4064), "I3", null, 20, new DateTime(2026, 4, 23, 12, 7, 6, 590, DateTimeKind.Local).AddTicks(4063), "Web Development" }
                });

            migrationBuilder.InsertData(
                table: "Assignments",
                columns: new[] { "Id", "CourseId", "CreatedDate", "Deleted", "DueDate", "MaxPoints", "Title" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2026, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, "Variables Assignment" },
                    { 2, 2, new DateTime(2026, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2026, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 25, "Linked List" }
                });

            migrationBuilder.InsertData(
                table: "StudentCourses",
                columns: new[] { "CourseId", "StudentId", "EnrollmentDate", "Grade" },
                values: new object[,]
                {
                    { 1, "S1", new DateTime(2026, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1, "S2", new DateTime(2026, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2, "S3", new DateTime(2026, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2, "S4", new DateTime(2026, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 3, "S5", new DateTime(2026, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
                });

            migrationBuilder.InsertData(
                table: "StudentAssignments",
                columns: new[] { "AssignmentId", "StudentId", "Feedback", "PointsEarned", "Status", "SubmissionDate" },
                values: new object[,]
                {
                    { 1, "S1", "Good work", 8m, 1, null },
                    { 1, "S2", null, null, 0, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_CourseId",
                table: "Assignments",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_InstructorId",
                table: "Courses",
                column: "InstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_InstructorId1",
                table: "Courses",
                column: "InstructorId1");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAssignments_AssignmentId",
                table: "StudentAssignments",
                column: "AssignmentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourses_CourseId",
                table: "StudentCourses",
                column: "CourseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "StudentAssignments");

            migrationBuilder.DropTable(
                name: "StudentCourses");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Assignments");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
