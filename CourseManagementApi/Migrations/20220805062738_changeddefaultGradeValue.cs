using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseManagementApi.Migrations
{
    public partial class changeddefaultGradeValue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "45554017-e3ae-4ce0-b527-08c20e42f833", "24dada36-4def-4318-8ad4-a67493072a86", "Student", "STUDENT" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5ef6b1b3-a71f-4261-8beb-6d806e61fd7d", "99e18a43-f7dd-4ee0-9bcc-33a5e49b0868", "Teacher", "TEACHER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b087bb18-fae5-4017-b27e-874ac9ebf3ca", "3688c7c9-aca6-4787-bc7c-2e760e9f3dd2", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "45554017-e3ae-4ce0-b527-08c20e42f833");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5ef6b1b3-a71f-4261-8beb-6d806e61fd7d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b087bb18-fae5-4017-b27e-874ac9ebf3ca");

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
    }
}
