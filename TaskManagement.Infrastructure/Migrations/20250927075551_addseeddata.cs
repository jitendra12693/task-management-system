using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TaskManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addseeddata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Users_UserId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_UserId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Tasks");

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

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_AssigneeId",
                table: "Tasks",
                column: "AssigneeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Users_AssigneeId",
                table: "Tasks",
                column: "AssigneeId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Users_AssigneeId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_AssigneeId",
                table: "Tasks");

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

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Tasks",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_UserId",
                table: "Tasks",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Users_UserId",
                table: "Tasks",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
