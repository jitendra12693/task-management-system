using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TaskManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedDataAndDbChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("007b470b-3f6a-45d2-803e-61d20f227977"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("24b50946-8da5-49a6-8299-13c40fa69e11"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("526981c8-33f2-4f4e-8693-42c40b5b9f52"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("56a3c0ce-fb67-4463-809d-864df4bfa825"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("5e99f847-c577-45b2-80c4-8845772f6af8"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("c508fd54-9648-4a0f-b1f4-6515800f5908"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("c6d9e093-abd2-4e83-9ab6-9699667781b0"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("e7ec0db2-4c41-473f-9195-055af97aa543"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("4315bea9-26b4-4e81-a627-fd76c9a0b539"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c5a48572-e460-42c8-bc99-fe610187860c"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "PasswordHash", "Role", "Username" },
                values: new object[,]
                {
                    { new Guid("7f8250de-1646-4a70-b675-fc13d7bfa94d"), new DateTime(2025, 9, 27, 8, 1, 5, 647, DateTimeKind.Utc).AddTicks(9196), "user@example.com", "$2a$11$SVnSHDmSzZLXDiV0..YCDuzTkEd8Sd4LsCizF9uhDoQ7QSoMr1c0i", 0, "user" },
                    { new Guid("8ab106de-325b-48d8-9fe5-08099049fe89"), new DateTime(2025, 9, 27, 8, 1, 5, 468, DateTimeKind.Utc).AddTicks(484), "admin@example.com", "$2a$11$3B94RS298Kp/oez//VGz7.9aM1F75l2f8EdUiii.0DbXiJSCNpe8W", 1, "admin" }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "AssigneeId", "CreatedAt", "CreatorId", "Description", "Priority", "Status", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("44848876-29d2-4496-8e09-94e346406f39"), new Guid("7f8250de-1646-4a70-b675-fc13d7bfa94d"), new DateTime(2025, 9, 27, 8, 1, 5, 812, DateTimeKind.Utc).AddTicks(2160), new Guid("8ab106de-325b-48d8-9fe5-08099049fe89"), "JWT authentication", "HIGH", 2, "Implement login API", new DateTime(2025, 9, 27, 8, 1, 5, 812, DateTimeKind.Utc).AddTicks(2160) },
                    { new Guid("4ccd9459-ffa9-48a8-be2c-fb01db8d47d5"), new Guid("7f8250de-1646-4a70-b675-fc13d7bfa94d"), new DateTime(2025, 9, 27, 8, 1, 5, 812, DateTimeKind.Utc).AddTicks(2174), new Guid("8ab106de-325b-48d8-9fe5-08099049fe89"), "Update CI/CD pipeline", "HIGH", 0, "Update CI/CD", new DateTime(2025, 9, 27, 8, 1, 5, 812, DateTimeKind.Utc).AddTicks(2174) },
                    { new Guid("6112daa4-efb5-4a44-8e80-060404e85edc"), new Guid("7f8250de-1646-4a70-b675-fc13d7bfa94d"), new DateTime(2025, 9, 27, 8, 1, 5, 812, DateTimeKind.Utc).AddTicks(2190), new Guid("7f8250de-1646-4a70-b675-fc13d7bfa94d"), "Task board columns", "LOW", 0, "Task Board", new DateTime(2025, 9, 27, 8, 1, 5, 812, DateTimeKind.Utc).AddTicks(2190) },
                    { new Guid("763b1f75-aac3-448b-91c9-522d0331cc7b"), new Guid("7f8250de-1646-4a70-b675-fc13d7bfa94d"), new DateTime(2025, 9, 27, 8, 1, 5, 812, DateTimeKind.Utc).AddTicks(878), new Guid("8ab106de-325b-48d8-9fe5-08099049fe89"), "Initialize git and CI pipeline", "HIGH", 0, "Setup project repo", new DateTime(2025, 9, 27, 8, 1, 5, 812, DateTimeKind.Utc).AddTicks(884) },
                    { new Guid("7f0978e8-c3bf-4865-9155-378e6513b2da"), new Guid("7f8250de-1646-4a70-b675-fc13d7bfa94d"), new DateTime(2025, 9, 27, 8, 1, 5, 812, DateTimeKind.Utc).AddTicks(2187), new Guid("8ab106de-325b-48d8-9fe5-08099049fe89"), "JWT authentication validation", "HIGH", 2, "Auth Validation", new DateTime(2025, 9, 27, 8, 1, 5, 812, DateTimeKind.Utc).AddTicks(2188) },
                    { new Guid("7f621b5d-abed-420a-b02d-554f8f96fce5"), new Guid("8ab106de-325b-48d8-9fe5-08099049fe89"), new DateTime(2025, 9, 27, 8, 1, 5, 812, DateTimeKind.Utc).AddTicks(2155), new Guid("8ab106de-325b-48d8-9fe5-08099049fe89"), "ER diagram for tasks & users", "MEDIUM", 1, "Design DB schema", new DateTime(2025, 9, 27, 8, 1, 5, 812, DateTimeKind.Utc).AddTicks(2156) },
                    { new Guid("a36d73ab-49b1-41f8-8cec-611f03957765"), new Guid("8ab106de-325b-48d8-9fe5-08099049fe89"), new DateTime(2025, 9, 27, 8, 1, 5, 812, DateTimeKind.Utc).AddTicks(2185), new Guid("8ab106de-325b-48d8-9fe5-08099049fe89"), "Validate all user Data", "MEDIUM", 1, "DB Validation", new DateTime(2025, 9, 27, 8, 1, 5, 812, DateTimeKind.Utc).AddTicks(2185) },
                    { new Guid("c7f07bde-448f-4901-8dd8-79264b60ddc9"), new Guid("7f8250de-1646-4a70-b675-fc13d7bfa94d"), new DateTime(2025, 9, 27, 8, 1, 5, 812, DateTimeKind.Utc).AddTicks(2171), new Guid("7f8250de-1646-4a70-b675-fc13d7bfa94d"), "Task board columns", "LOW", 0, "Frontend dashboard", new DateTime(2025, 9, 27, 8, 1, 5, 812, DateTimeKind.Utc).AddTicks(2171) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("44848876-29d2-4496-8e09-94e346406f39"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("4ccd9459-ffa9-48a8-be2c-fb01db8d47d5"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("6112daa4-efb5-4a44-8e80-060404e85edc"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("763b1f75-aac3-448b-91c9-522d0331cc7b"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("7f0978e8-c3bf-4865-9155-378e6513b2da"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("7f621b5d-abed-420a-b02d-554f8f96fce5"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("a36d73ab-49b1-41f8-8cec-611f03957765"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("c7f07bde-448f-4901-8dd8-79264b60ddc9"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("7f8250de-1646-4a70-b675-fc13d7bfa94d"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8ab106de-325b-48d8-9fe5-08099049fe89"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "PasswordHash", "Role", "Username" },
                values: new object[,]
                {
                    { new Guid("4315bea9-26b4-4e81-a627-fd76c9a0b539"), new DateTime(2025, 9, 27, 7, 55, 44, 653, DateTimeKind.Utc).AddTicks(4760), "admin@example.com", "$2a$11$htj6fGbknvRj2Zx6p/mSuOAb4pEFE2tF8RjrJeePqlX1EX59h/sOS", 1, "admin" },
                    { new Guid("c5a48572-e460-42c8-bc99-fe610187860c"), new DateTime(2025, 9, 27, 7, 55, 44, 967, DateTimeKind.Utc).AddTicks(4595), "user@example.com", "$2a$11$SIYDn2ABuY4Se4nsmzqzLuMjjUqPVSli0ZCW3w0jNGWzbMgJsvTHG", 0, "user" }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "AssigneeId", "CreatedAt", "CreatorId", "Description", "Priority", "Status", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("007b470b-3f6a-45d2-803e-61d20f227977"), new Guid("4315bea9-26b4-4e81-a627-fd76c9a0b539"), new DateTime(2025, 9, 27, 7, 55, 45, 303, DateTimeKind.Utc).AddTicks(9301), new Guid("4315bea9-26b4-4e81-a627-fd76c9a0b539"), "Validate all user Data", "MEDIUM", 1, "DB Validation", new DateTime(2025, 9, 27, 7, 55, 45, 303, DateTimeKind.Utc).AddTicks(9301) },
                    { new Guid("24b50946-8da5-49a6-8299-13c40fa69e11"), new Guid("c5a48572-e460-42c8-bc99-fe610187860c"), new DateTime(2025, 9, 27, 7, 55, 45, 303, DateTimeKind.Utc).AddTicks(9268), new Guid("4315bea9-26b4-4e81-a627-fd76c9a0b539"), "JWT authentication", "HIGH", 2, "Implement login API", new DateTime(2025, 9, 27, 7, 55, 45, 303, DateTimeKind.Utc).AddTicks(9268) },
                    { new Guid("526981c8-33f2-4f4e-8693-42c40b5b9f52"), new Guid("c5a48572-e460-42c8-bc99-fe610187860c"), new DateTime(2025, 9, 27, 7, 55, 45, 303, DateTimeKind.Utc).AddTicks(9289), new Guid("4315bea9-26b4-4e81-a627-fd76c9a0b539"), "Update CI/CD pipeline", "HIGH", 0, "Update CI/CD", new DateTime(2025, 9, 27, 7, 55, 45, 303, DateTimeKind.Utc).AddTicks(9290) },
                    { new Guid("56a3c0ce-fb67-4463-809d-864df4bfa825"), new Guid("c5a48572-e460-42c8-bc99-fe610187860c"), new DateTime(2025, 9, 27, 7, 55, 45, 303, DateTimeKind.Utc).AddTicks(9305), new Guid("4315bea9-26b4-4e81-a627-fd76c9a0b539"), "JWT authentication validation", "HIGH", 2, "Auth Validation", new DateTime(2025, 9, 27, 7, 55, 45, 303, DateTimeKind.Utc).AddTicks(9305) },
                    { new Guid("5e99f847-c577-45b2-80c4-8845772f6af8"), new Guid("c5a48572-e460-42c8-bc99-fe610187860c"), new DateTime(2025, 9, 27, 7, 55, 45, 303, DateTimeKind.Utc).AddTicks(7419), new Guid("4315bea9-26b4-4e81-a627-fd76c9a0b539"), "Initialize git and CI pipeline", "HIGH", 0, "Setup project repo", new DateTime(2025, 9, 27, 7, 55, 45, 303, DateTimeKind.Utc).AddTicks(7425) },
                    { new Guid("c508fd54-9648-4a0f-b1f4-6515800f5908"), new Guid("c5a48572-e460-42c8-bc99-fe610187860c"), new DateTime(2025, 9, 27, 7, 55, 45, 303, DateTimeKind.Utc).AddTicks(9272), new Guid("c5a48572-e460-42c8-bc99-fe610187860c"), "Task board columns", "LOW", 0, "Frontend dashboard", new DateTime(2025, 9, 27, 7, 55, 45, 303, DateTimeKind.Utc).AddTicks(9272) },
                    { new Guid("c6d9e093-abd2-4e83-9ab6-9699667781b0"), new Guid("c5a48572-e460-42c8-bc99-fe610187860c"), new DateTime(2025, 9, 27, 7, 55, 45, 303, DateTimeKind.Utc).AddTicks(9308), new Guid("c5a48572-e460-42c8-bc99-fe610187860c"), "Task board columns", "LOW", 0, "Task Board", new DateTime(2025, 9, 27, 7, 55, 45, 303, DateTimeKind.Utc).AddTicks(9309) },
                    { new Guid("e7ec0db2-4c41-473f-9195-055af97aa543"), new Guid("4315bea9-26b4-4e81-a627-fd76c9a0b539"), new DateTime(2025, 9, 27, 7, 55, 45, 303, DateTimeKind.Utc).AddTicks(9262), new Guid("4315bea9-26b4-4e81-a627-fd76c9a0b539"), "ER diagram for tasks & users", "MEDIUM", 1, "Design DB schema", new DateTime(2025, 9, 27, 7, 55, 45, 303, DateTimeKind.Utc).AddTicks(9262) }
                });
        }
    }
}
