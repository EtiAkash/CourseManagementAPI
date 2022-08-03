using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseManagementApi.Migrations
{
    public partial class AddedRequiredTag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0840186f-db46-4d7c-8dad-ea2d34cf94e3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2ed272ca-be58-4a2f-8ca4-60d53cc59209");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "594c6ba8-7a0b-4ce7-bb25-fde50e900c38");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "67a258f9-c0fc-46a8-9eda-696e676208ac", "4cb9d703-26f3-47f0-b480-b56437da215d", "Student", "STUDENT" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b7f7f040-85cb-46c5-9a4c-e5a1ec140c3a", "b1516657-a195-4b22-815a-c3514b7adad9", "Teacher", "TEACHER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e11dd939-dc03-4e57-a0b4-fa6b8b0c2861", "c83b82cb-e717-4206-8c01-6d3602e0c92e", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "67a258f9-c0fc-46a8-9eda-696e676208ac");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b7f7f040-85cb-46c5-9a4c-e5a1ec140c3a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e11dd939-dc03-4e57-a0b4-fa6b8b0c2861");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0840186f-db46-4d7c-8dad-ea2d34cf94e3", "cf08f0ee-cf16-4213-a3cc-79875e3e14bb", "Student", "STUDENT" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2ed272ca-be58-4a2f-8ca4-60d53cc59209", "c0d8beac-7739-4543-8374-5ae3f4368cc1", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "594c6ba8-7a0b-4ce7-bb25-fde50e900c38", "6d84b9af-90a6-496d-9d64-9eab923ab55a", "Teacher", "TEACHER" });
        }
    }
}
