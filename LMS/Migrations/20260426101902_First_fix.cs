using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LMS.Migrations
{
    /// <inheritdoc />
    public partial class First_fix : Migration
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
                    Role = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserType = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
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
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "R1", null, "Instructor", "INSTRUCTOR" },
                    { "R2", null, "Student", "STUDENT" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedDate", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "ModifiedDate", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName", "UserType" },
                values: new object[,]
                {
                    { "I1", 0, "6e8ad6c3-37a8-4ea3-863f-a5b88a5b4616", new DateTime(2026, 4, 26, 16, 19, 0, 964, DateTimeKind.Local).AddTicks(4488), "smith@uni.com", false, false, null, null, "Dr. Smith", "SMITH@UNI.COM", "SMITH@UNI.COM", "AQAAAAIAAYagAAAAEJ976yXXLwjMpuQQrHB8vDtBOPSSCwvyxvDJLmj9ank5CFxxs+zlycyeiSIDQ41tnw==", null, false, 0, "3d66c328-b03b-4421-9546-44b2b7a361e7", false, "smith@uni.com", "User" },
                    { "I2", 0, "872b9afa-1bbc-4002-9dc8-6b3186985bfc", new DateTime(2026, 4, 26, 16, 19, 1, 15, DateTimeKind.Local).AddTicks(6066), "johnson@uni.com", false, false, null, null, "Dr. Johnson", "JOHNSON@UNI.COM", "JOHNSON@UNI.COM", "AQAAAAIAAYagAAAAEEOsydHJAjikwXVQFrC0gfh9S4/RcwPRAZyvcyO3oGlV1NLFbBZ3RFWaOGjxbJSLiw==", null, false, 0, "9b0cf5d8-7a23-4d98-aafb-089f75db6d58", false, "johnson@uni.com", "User" },
                    { "I3", 0, "438f078e-7255-4047-8997-ad63fa8eeeaa", new DateTime(2026, 4, 26, 16, 19, 1, 66, DateTimeKind.Local).AddTicks(1139), "lee@uni.com", false, false, null, null, "Dr. Lee", "LEE@UNI.COM", "LEE@UNI.COM", "AQAAAAIAAYagAAAAENbz2Q3W4oDH7jfVHfNrWQc7r6NLfS8cKfwrnpZLDZ1DiBzbCXM0/is+Cjpj97TfHw==", null, false, 0, "e502365a-4a8b-42bd-85d9-05f01f424984", false, "lee@uni.com", "User" },
                    { "S1", 0, "1cfbb3ca-f6d3-48ac-ba79-1d3a15e5bee0", new DateTime(2026, 4, 26, 16, 19, 1, 116, DateTimeKind.Local).AddTicks(2527), "student1@uni.com", false, false, null, null, "Student 1", "STUDENT1@UNI.COM", "STUDENT1@UNI.COM", "AQAAAAIAAYagAAAAENyzeaaQPCCziiwsWgecbXZ+2ZZBQ4YN3Q6VGIikucHYWIAcRelJ8vRH3T4Rm4Ur7Q==", null, false, 1, "a0a2d1d7-a4b1-486e-88f0-dde774fcde6b", false, "student1@uni.com", "User" },
                    { "S2", 0, "cc40595d-44c3-41d9-b5fc-f609e95f82a6", new DateTime(2026, 4, 26, 16, 19, 1, 179, DateTimeKind.Local).AddTicks(4981), "student2@uni.com", false, false, null, null, "Student 2", "STUDENT2@UNI.COM", "STUDENT2@UNI.COM", "AQAAAAIAAYagAAAAEDgHkFJJXXuinNbcFTXzU8FaJOxojf0PxK8SyiNLzj0mBqlGOocAmVep2TQtoSN8fA==", null, false, 1, "748688c2-0a79-46dd-a319-997a38263018", false, "student2@uni.com", "User" },
                    { "S3", 0, "479aa6ea-6bbc-4daf-a98f-aa456f1a771c", new DateTime(2026, 4, 26, 16, 19, 1, 233, DateTimeKind.Local).AddTicks(8322), "student3@uni.com", false, false, null, null, "Student 3", "STUDENT3@UNI.COM", "STUDENT3@UNI.COM", "AQAAAAIAAYagAAAAEJaK80c58E8r9xqZwHBni0KKWrD37zboQxfREkTM2jwmW0EoJeDpFJIG2hmFeXE/dA==", null, false, 1, "b9596b8a-12d2-4db0-92de-c241b66e49fd", false, "student3@uni.com", "User" },
                    { "S4", 0, "38e39728-fff4-4fe0-8501-f53348ddcf4f", new DateTime(2026, 4, 26, 16, 19, 1, 285, DateTimeKind.Local).AddTicks(9560), "student4@uni.com", false, false, null, null, "Student 4", "STUDENT4@UNI.COM", "STUDENT4@UNI.COM", "AQAAAAIAAYagAAAAEClENe/fWisHABxF51+y743/YTL0UzePZ7MHiwX79KCu+nwFY7Ybci48KE4wbunH/Q==", null, false, 1, "a6d8914b-5add-48ff-87b9-3ecce5c23e43", false, "student4@uni.com", "User" },
                    { "S5", 0, "1df3e09f-f19c-4a32-99e9-032611158210", new DateTime(2026, 4, 26, 16, 19, 1, 336, DateTimeKind.Local).AddTicks(3046), "student5@uni.com", false, false, null, null, "Student 5", "STUDENT5@UNI.COM", "STUDENT5@UNI.COM", "AQAAAAIAAYagAAAAEMYb1nlPy91xVVE7+9yIBdzVnC0oKKGbmOvtjD9yY6GGEPKaxYSSrgfiaSwD7jh44w==", null, false, 1, "292237d1-18a2-4259-9c90-13a02d70c170", false, "student5@uni.com", "User" },
                    { "S6", 0, "fac3aea8-a19c-4d6b-a1ad-081fe8de12a7", new DateTime(2026, 4, 26, 16, 19, 1, 389, DateTimeKind.Local).AddTicks(7153), "student6@uni.com", false, false, null, null, "Student 6", "STUDENT6@UNI.COM", "STUDENT6@UNI.COM", "AQAAAAIAAYagAAAAENbholLHqZ51EAt/nlyO5NTc4sRLwdmxfdA2xoFdZbO8GpdjIVf9fo3bZpSTqnWM1Q==", null, false, 1, "4084a422-4d8c-47a1-91e9-fce12a04e760", false, "student6@uni.com", "User" },
                    { "S7", 0, "47c87be2-93fc-48dd-8c5c-40c68188266b", new DateTime(2026, 4, 26, 16, 19, 1, 439, DateTimeKind.Local).AddTicks(9450), "student7@uni.com", false, false, null, null, "Student 7", "STUDENT7@UNI.COM", "STUDENT7@UNI.COM", "AQAAAAIAAYagAAAAEEAVWCE0FdpJq07MdQpR9v3nKaokfB4NTvyLoW+7j1deOJbR+3HpVcpJ5Xv3AAqiiQ==", null, false, 1, "2f981060-b233-4b39-a053-beecce0d7515", false, "student7@uni.com", "User" },
                    { "S8", 0, "ceace6cc-f514-4666-b48e-20bc666bd80e", new DateTime(2026, 4, 26, 16, 19, 1, 498, DateTimeKind.Local).AddTicks(6927), "student8@uni.com", false, false, null, null, "Student 8", "STUDENT8@UNI.COM", "STUDENT8@UNI.COM", "AQAAAAIAAYagAAAAEDh15mK3yhXSZ+oAsH2S8Su/TG86LDw1ZbrOlqE4eMirK0ReD4tJEhL0S64x+23xTQ==", null, false, 1, "f3db2bb6-a7b9-47af-b99f-e5186149530b", false, "student8@uni.com", "User" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "R1", "I1" },
                    { "R1", "I2" },
                    { "R1", "I3" },
                    { "R2", "S1" },
                    { "R2", "S2" }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CreatedDate", "Credits", "Description", "EndDate", "InstructorId", "InstructorId1", "MaxEnrollment", "StartDate", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 4, 26, 16, 19, 1, 548, DateTimeKind.Local).AddTicks(6259), 3, "Basics of coding", new DateTime(2026, 8, 26, 16, 19, 1, 548, DateTimeKind.Local).AddTicks(6235), "I1", null, 30, new DateTime(2026, 4, 26, 16, 19, 1, 548, DateTimeKind.Local).AddTicks(6222), "Introduction to Programming" },
                    { 2, new DateTime(2026, 4, 26, 16, 19, 1, 548, DateTimeKind.Local).AddTicks(6278), 3, "Advanced data handling", new DateTime(2026, 8, 26, 16, 19, 1, 548, DateTimeKind.Local).AddTicks(6277), "I2", null, 25, new DateTime(2026, 4, 26, 16, 19, 1, 548, DateTimeKind.Local).AddTicks(6277), "Data Structures" },
                    { 3, new DateTime(2026, 4, 26, 16, 19, 1, 548, DateTimeKind.Local).AddTicks(6280), 3, "ASP.NET Core", new DateTime(2026, 8, 26, 16, 19, 1, 548, DateTimeKind.Local).AddTicks(6280), "I3", null, 20, new DateTime(2026, 4, 26, 16, 19, 1, 548, DateTimeKind.Local).AddTicks(6279), "Web Development" }
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
