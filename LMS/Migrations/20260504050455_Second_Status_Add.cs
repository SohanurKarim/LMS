using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LMS.Migrations
{
    /// <inheritdoc />
    public partial class Second_Status_Add : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "StudentCourses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CourseFee",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "I1",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f5643581-fea0-412d-8d90-911f38795051", new DateTime(2026, 5, 4, 11, 4, 52, 180, DateTimeKind.Local).AddTicks(441), "AQAAAAIAAYagAAAAECtzquudIwisefPVzlupR1EjoYqqQdOw+UmUYuzdo/G/w3bSmdiSCahX22KmNlOPDQ==", "6eceef2d-63da-405f-9920-27c7500b1713" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "I2",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e09558c6-0465-4794-ba0a-84b602d9aff0", new DateTime(2026, 5, 4, 11, 4, 52, 230, DateTimeKind.Local).AddTicks(8074), "AQAAAAIAAYagAAAAEO8MSGnOiclCGN12+PI3IkkP3kYATIUn0i2jEttK8HnUaP8d6+77n2j/nUALfAuE5w==", "d5c6a22c-8f47-4630-81e4-d8519836de6c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "I3",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e8e37f67-d264-489b-af51-fb6418e79420", new DateTime(2026, 5, 4, 11, 4, 52, 280, DateTimeKind.Local).AddTicks(9289), "AQAAAAIAAYagAAAAEDOMhzTQAmaHe27l7E4Ws7StWvosjc7p5qvQ1pMdD93MLkDIGFf2HA9kzVosmf2FdQ==", "5c6d3349-e175-4ec3-961a-bcdf4c8500ed" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "S1",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cdeb8816-2af9-40c9-90b1-b2ddc524c024", new DateTime(2026, 5, 4, 11, 4, 52, 333, DateTimeKind.Local).AddTicks(1674), "AQAAAAIAAYagAAAAEBc54ywryxsGW+QssKcC/MdI7EFgcFgKuMZ6rVU8j3j3AIEB5VkOEtuCFyCxP4hkXg==", "a1d69efd-77b2-4c58-9197-e7f190336d47" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "S2",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b0a7dd97-576b-4873-bcad-f097723b599a", new DateTime(2026, 5, 4, 11, 4, 52, 386, DateTimeKind.Local).AddTicks(2851), "AQAAAAIAAYagAAAAED4f1jZxMtVaAvWbLHY55MsFzoQT7gLlQxo6uQ7zaE23A3z4mroPVMMZTINdWm69ug==", "428f770b-02cf-444a-a92e-0bfe462fe5a6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "S3",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "82070186-d596-4fac-8390-464f8f70347a", new DateTime(2026, 5, 4, 11, 4, 52, 446, DateTimeKind.Local).AddTicks(5388), "AQAAAAIAAYagAAAAEIjwJdNsB9CqQOnp25ZMg20W6rjVTJXmxnxC53e4FN58UKvrLP7xHaNMSbB2oHuLTg==", "a24f5064-6fe1-44b5-9d4e-b899df04dcd6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "S4",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8221ba6f-40d1-4a4d-95fe-06b1db709ff4", new DateTime(2026, 5, 4, 11, 4, 52, 511, DateTimeKind.Local).AddTicks(7607), "AQAAAAIAAYagAAAAEFpOp2G+gHmU9he0HKlKd81+Sl0o1MNjapqKOnGzcL43E0dIaO+ybfF4G281Pdug5w==", "07ef86c5-fad9-461b-84d9-3f0f48144551" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "S5",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e2f3ed0a-c87e-4b6a-877b-9886272805ba", new DateTime(2026, 5, 4, 11, 4, 52, 570, DateTimeKind.Local).AddTicks(244), "AQAAAAIAAYagAAAAEF56maLk75VfEGtWcBHUcKhJFt6jmUtMIDanyyFSBvWxJWR/GiIktgEhn4cemoVZaA==", "f3a4f006-5026-4fb7-a230-37094604902e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "S6",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "61a5e0af-3e06-4b42-bb69-ee1c509c3177", new DateTime(2026, 5, 4, 11, 4, 52, 626, DateTimeKind.Local).AddTicks(5165), "AQAAAAIAAYagAAAAEIVx2zsFG8+dcMpSlyyXyRy4PrfvDd63HekSd47iHZNF+RFQqKzQg4sdGOIyzjwuTw==", "37e7736e-1cf0-45f6-a7eb-48c5399b225f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "S7",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a1384f83-c2af-4778-bfe2-bba8b6c8c288", new DateTime(2026, 5, 4, 11, 4, 52, 680, DateTimeKind.Local).AddTicks(8227), "AQAAAAIAAYagAAAAEFb3RYxkiEcdzYvfQZd2o5/8lvStqEfkk/auc23AyzVe30G6fxjK8TOhaxQ4CxzevA==", "badff740-2c7f-4301-9b55-87a5bb4a5375" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "S8",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "eeb1c2f5-f8f0-4ee7-83be-c72c99f2f34d", new DateTime(2026, 5, 4, 11, 4, 52, 731, DateTimeKind.Local).AddTicks(7580), "AQAAAAIAAYagAAAAEDCMk4HlQfodztiV2lrTcbFmQKDUB2eIzJSObh/Wgcw3XtA1Ql7Z4do0PIVnsiCflQ==", "1770f408-dfcb-4ba1-87d3-ef09395e0233" });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CourseFee", "CreatedDate", "EndDate", "StartDate" },
                values: new object[] { 0, new DateTime(2026, 5, 4, 11, 4, 52, 783, DateTimeKind.Local).AddTicks(3917), new DateTime(2026, 9, 4, 11, 4, 52, 783, DateTimeKind.Local).AddTicks(3908), new DateTime(2026, 5, 4, 11, 4, 52, 783, DateTimeKind.Local).AddTicks(3894) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CourseFee", "CreatedDate", "EndDate", "StartDate" },
                values: new object[] { 0, new DateTime(2026, 5, 4, 11, 4, 52, 783, DateTimeKind.Local).AddTicks(3926), new DateTime(2026, 9, 4, 11, 4, 52, 783, DateTimeKind.Local).AddTicks(3926), new DateTime(2026, 5, 4, 11, 4, 52, 783, DateTimeKind.Local).AddTicks(3925) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CourseFee", "CreatedDate", "EndDate", "StartDate" },
                values: new object[] { 0, new DateTime(2026, 5, 4, 11, 4, 52, 783, DateTimeKind.Local).AddTicks(3952), new DateTime(2026, 9, 4, 11, 4, 52, 783, DateTimeKind.Local).AddTicks(3951), new DateTime(2026, 5, 4, 11, 4, 52, 783, DateTimeKind.Local).AddTicks(3942) });

            migrationBuilder.UpdateData(
                table: "StudentAssignments",
                keyColumns: new[] { "AssignmentId", "StudentId" },
                keyValues: new object[] { 1, "S1" },
                column: "Status",
                value: 3);

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 1, "S1" },
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 1, "S2" },
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 2, "S3" },
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 2, "S4" },
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 3, "S5" },
                column: "Status",
                value: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "StudentCourses");

            migrationBuilder.DropColumn(
                name: "CourseFee",
                table: "Courses");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "I1",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6e8ad6c3-37a8-4ea3-863f-a5b88a5b4616", new DateTime(2026, 4, 26, 16, 19, 0, 964, DateTimeKind.Local).AddTicks(4488), "AQAAAAIAAYagAAAAEJ976yXXLwjMpuQQrHB8vDtBOPSSCwvyxvDJLmj9ank5CFxxs+zlycyeiSIDQ41tnw==", "3d66c328-b03b-4421-9546-44b2b7a361e7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "I2",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "872b9afa-1bbc-4002-9dc8-6b3186985bfc", new DateTime(2026, 4, 26, 16, 19, 1, 15, DateTimeKind.Local).AddTicks(6066), "AQAAAAIAAYagAAAAEEOsydHJAjikwXVQFrC0gfh9S4/RcwPRAZyvcyO3oGlV1NLFbBZ3RFWaOGjxbJSLiw==", "9b0cf5d8-7a23-4d98-aafb-089f75db6d58" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "I3",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "438f078e-7255-4047-8997-ad63fa8eeeaa", new DateTime(2026, 4, 26, 16, 19, 1, 66, DateTimeKind.Local).AddTicks(1139), "AQAAAAIAAYagAAAAENbz2Q3W4oDH7jfVHfNrWQc7r6NLfS8cKfwrnpZLDZ1DiBzbCXM0/is+Cjpj97TfHw==", "e502365a-4a8b-42bd-85d9-05f01f424984" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "S1",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1cfbb3ca-f6d3-48ac-ba79-1d3a15e5bee0", new DateTime(2026, 4, 26, 16, 19, 1, 116, DateTimeKind.Local).AddTicks(2527), "AQAAAAIAAYagAAAAENyzeaaQPCCziiwsWgecbXZ+2ZZBQ4YN3Q6VGIikucHYWIAcRelJ8vRH3T4Rm4Ur7Q==", "a0a2d1d7-a4b1-486e-88f0-dde774fcde6b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "S2",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cc40595d-44c3-41d9-b5fc-f609e95f82a6", new DateTime(2026, 4, 26, 16, 19, 1, 179, DateTimeKind.Local).AddTicks(4981), "AQAAAAIAAYagAAAAEDgHkFJJXXuinNbcFTXzU8FaJOxojf0PxK8SyiNLzj0mBqlGOocAmVep2TQtoSN8fA==", "748688c2-0a79-46dd-a319-997a38263018" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "S3",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "479aa6ea-6bbc-4daf-a98f-aa456f1a771c", new DateTime(2026, 4, 26, 16, 19, 1, 233, DateTimeKind.Local).AddTicks(8322), "AQAAAAIAAYagAAAAEJaK80c58E8r9xqZwHBni0KKWrD37zboQxfREkTM2jwmW0EoJeDpFJIG2hmFeXE/dA==", "b9596b8a-12d2-4db0-92de-c241b66e49fd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "S4",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "38e39728-fff4-4fe0-8501-f53348ddcf4f", new DateTime(2026, 4, 26, 16, 19, 1, 285, DateTimeKind.Local).AddTicks(9560), "AQAAAAIAAYagAAAAEClENe/fWisHABxF51+y743/YTL0UzePZ7MHiwX79KCu+nwFY7Ybci48KE4wbunH/Q==", "a6d8914b-5add-48ff-87b9-3ecce5c23e43" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "S5",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1df3e09f-f19c-4a32-99e9-032611158210", new DateTime(2026, 4, 26, 16, 19, 1, 336, DateTimeKind.Local).AddTicks(3046), "AQAAAAIAAYagAAAAEMYb1nlPy91xVVE7+9yIBdzVnC0oKKGbmOvtjD9yY6GGEPKaxYSSrgfiaSwD7jh44w==", "292237d1-18a2-4259-9c90-13a02d70c170" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "S6",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fac3aea8-a19c-4d6b-a1ad-081fe8de12a7", new DateTime(2026, 4, 26, 16, 19, 1, 389, DateTimeKind.Local).AddTicks(7153), "AQAAAAIAAYagAAAAENbholLHqZ51EAt/nlyO5NTc4sRLwdmxfdA2xoFdZbO8GpdjIVf9fo3bZpSTqnWM1Q==", "4084a422-4d8c-47a1-91e9-fce12a04e760" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "S7",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "47c87be2-93fc-48dd-8c5c-40c68188266b", new DateTime(2026, 4, 26, 16, 19, 1, 439, DateTimeKind.Local).AddTicks(9450), "AQAAAAIAAYagAAAAEEAVWCE0FdpJq07MdQpR9v3nKaokfB4NTvyLoW+7j1deOJbR+3HpVcpJ5Xv3AAqiiQ==", "2f981060-b233-4b39-a053-beecce0d7515" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "S8",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ceace6cc-f514-4666-b48e-20bc666bd80e", new DateTime(2026, 4, 26, 16, 19, 1, 498, DateTimeKind.Local).AddTicks(6927), "AQAAAAIAAYagAAAAEDh15mK3yhXSZ+oAsH2S8Su/TG86LDw1ZbrOlqE4eMirK0ReD4tJEhL0S64x+23xTQ==", "f3db2bb6-a7b9-47af-b99f-e5186149530b" });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "EndDate", "StartDate" },
                values: new object[] { new DateTime(2026, 4, 26, 16, 19, 1, 548, DateTimeKind.Local).AddTicks(6259), new DateTime(2026, 8, 26, 16, 19, 1, 548, DateTimeKind.Local).AddTicks(6235), new DateTime(2026, 4, 26, 16, 19, 1, 548, DateTimeKind.Local).AddTicks(6222) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "EndDate", "StartDate" },
                values: new object[] { new DateTime(2026, 4, 26, 16, 19, 1, 548, DateTimeKind.Local).AddTicks(6278), new DateTime(2026, 8, 26, 16, 19, 1, 548, DateTimeKind.Local).AddTicks(6277), new DateTime(2026, 4, 26, 16, 19, 1, 548, DateTimeKind.Local).AddTicks(6277) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "EndDate", "StartDate" },
                values: new object[] { new DateTime(2026, 4, 26, 16, 19, 1, 548, DateTimeKind.Local).AddTicks(6280), new DateTime(2026, 8, 26, 16, 19, 1, 548, DateTimeKind.Local).AddTicks(6280), new DateTime(2026, 4, 26, 16, 19, 1, 548, DateTimeKind.Local).AddTicks(6279) });

            migrationBuilder.UpdateData(
                table: "StudentAssignments",
                keyColumns: new[] { "AssignmentId", "StudentId" },
                keyValues: new object[] { 1, "S1" },
                column: "Status",
                value: 1);
        }
    }
}
