using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseManagementApi.Migrations
{
    public partial class Addeddefault : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "36d08894-0141-4472-bc0d-4d34660b5435", "1d3f9e9b-f137-4774-882c-b4eeddd53e5e", "Student", "STUDENT" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5e3b6143-0ff3-4974-ad5b-389853b194b0", "dcde9a15-5c0c-4ae2-a22c-a872f16fb3f8", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5fd13dd4-a3a6-4d5b-8900-98542c8f3697", "4bb4f161-4ccd-45ce-99a2-7806858ec24b", "Teacher", "TEACHER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "36d08894-0141-4472-bc0d-4d34660b5435");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5e3b6143-0ff3-4974-ad5b-389853b194b0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5fd13dd4-a3a6-4d5b-8900-98542c8f3697");

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
    }
}
