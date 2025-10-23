using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LMS.Migrations
{
    /// <inheritdoc />
    public partial class init23 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentsStudents_Courses_CourseId",
                table: "StudentsStudents");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentsStudents_Students_StudentSSN",
                table: "StudentsStudents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentsStudents",
                table: "StudentsStudents");

            migrationBuilder.RenameTable(
                name: "StudentsStudents",
                newName: "StudentsCourses");

            migrationBuilder.RenameIndex(
                name: "IX_StudentsStudents_StudentSSN",
                table: "StudentsCourses",
                newName: "IX_StudentsCourses_StudentSSN");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentsCourses",
                table: "StudentsCourses",
                columns: new[] { "CourseId", "StudentSSN" });

            migrationBuilder.AddForeignKey(
                name: "FK_StudentsCourses_Courses_CourseId",
                table: "StudentsCourses",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentsCourses_Students_StudentSSN",
                table: "StudentsCourses",
                column: "StudentSSN",
                principalTable: "Students",
                principalColumn: "SSN",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentsCourses_Courses_CourseId",
                table: "StudentsCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentsCourses_Students_StudentSSN",
                table: "StudentsCourses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentsCourses",
                table: "StudentsCourses");

            migrationBuilder.RenameTable(
                name: "StudentsCourses",
                newName: "StudentsStudents");

            migrationBuilder.RenameIndex(
                name: "IX_StudentsCourses_StudentSSN",
                table: "StudentsStudents",
                newName: "IX_StudentsStudents_StudentSSN");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentsStudents",
                table: "StudentsStudents",
                columns: new[] { "CourseId", "StudentSSN" });

            migrationBuilder.AddForeignKey(
                name: "FK_StudentsStudents_Courses_CourseId",
                table: "StudentsStudents",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentsStudents_Students_StudentSSN",
                table: "StudentsStudents",
                column: "StudentSSN",
                principalTable: "Students",
                principalColumn: "SSN",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
