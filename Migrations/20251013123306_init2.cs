using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LMS.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Departments_DepartmentdeptId",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Instructors_Departments_DepartmentdeptId",
                table: "Instructors");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Departments_DepartmentdeptId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Departments_DepartmentdeptId",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "DepartmentdeptId",
                table: "Departments");

            migrationBuilder.RenameColumn(
                name: "DepartmentdeptId",
                table: "Students",
                newName: "DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Students_DepartmentdeptId",
                table: "Students",
                newName: "IX_Students_DepartmentId");

            migrationBuilder.RenameColumn(
                name: "DepartmentdeptId",
                table: "Instructors",
                newName: "DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Instructors_DepartmentdeptId",
                table: "Instructors",
                newName: "IX_Instructors_DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Instructors_Departments_DepartmentId",
                table: "Instructors",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "deptId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Departments_DepartmentId",
                table: "Students",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "deptId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instructors_Departments_DepartmentId",
                table: "Instructors");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Departments_DepartmentId",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "DepartmentId",
                table: "Students",
                newName: "DepartmentdeptId");

            migrationBuilder.RenameIndex(
                name: "IX_Students_DepartmentId",
                table: "Students",
                newName: "IX_Students_DepartmentdeptId");

            migrationBuilder.RenameColumn(
                name: "DepartmentId",
                table: "Instructors",
                newName: "DepartmentdeptId");

            migrationBuilder.RenameIndex(
                name: "IX_Instructors_DepartmentId",
                table: "Instructors",
                newName: "IX_Instructors_DepartmentdeptId");

            migrationBuilder.AddColumn<int>(
                name: "DepartmentdeptId",
                table: "Departments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Departments_DepartmentdeptId",
                table: "Departments",
                column: "DepartmentdeptId");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Departments_DepartmentdeptId",
                table: "Departments",
                column: "DepartmentdeptId",
                principalTable: "Departments",
                principalColumn: "deptId");

            migrationBuilder.AddForeignKey(
                name: "FK_Instructors_Departments_DepartmentdeptId",
                table: "Instructors",
                column: "DepartmentdeptId",
                principalTable: "Departments",
                principalColumn: "deptId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Departments_DepartmentdeptId",
                table: "Students",
                column: "DepartmentdeptId",
                principalTable: "Departments",
                principalColumn: "deptId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
