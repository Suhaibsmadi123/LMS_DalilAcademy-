using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dalilacademy.infra.Migrations
{
    /// <inheritdoc />
    public partial class intiallCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Coures_Instructors_InstructorId",
                table: "Coures");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Coures_CourseId",
                table: "Enrollments");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Students_StudentId",
                table: "Enrollments");

            migrationBuilder.RenameColumn(
                name: "Fullname",
                table: "Students",
                newName: "fullname");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Students",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Students",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Instructors",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "Fullname",
                table: "Instructors",
                newName: "fullname");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Instructors",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "Enrollments",
                newName: "studentId");

            migrationBuilder.RenameColumn(
                name: "EnrollmentAt",
                table: "Enrollments",
                newName: "enrollmentAt");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "Enrollments",
                newName: "courseId");

            migrationBuilder.RenameIndex(
                name: "IX_Enrollments_StudentId_CourseId",
                table: "Enrollments",
                newName: "IX_Enrollments_studentId_courseId");

            migrationBuilder.RenameIndex(
                name: "IX_Enrollments_CourseId",
                table: "Enrollments",
                newName: "IX_Enrollments_courseId");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Coures",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Coures",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "InstructorId",
                table: "Coures",
                newName: "instructorId");

            migrationBuilder.RenameIndex(
                name: "IX_Coures_Title",
                table: "Coures",
                newName: "IX_Coures_title");

            migrationBuilder.RenameIndex(
                name: "IX_Coures_InstructorId",
                table: "Coures",
                newName: "IX_Coures_instructorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Coures_Instructors_instructorId",
                table: "Coures",
                column: "instructorId",
                principalTable: "Instructors",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Coures_courseId",
                table: "Enrollments",
                column: "courseId",
                principalTable: "Coures",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Students_studentId",
                table: "Enrollments",
                column: "studentId",
                principalTable: "Students",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Coures_Instructors_instructorId",
                table: "Coures");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Coures_courseId",
                table: "Enrollments");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Students_studentId",
                table: "Enrollments");

            migrationBuilder.RenameColumn(
                name: "fullname",
                table: "Students",
                newName: "Fullname");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Students",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Students",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "Instructors",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "fullname",
                table: "Instructors",
                newName: "Fullname");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Instructors",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "studentId",
                table: "Enrollments",
                newName: "StudentId");

            migrationBuilder.RenameColumn(
                name: "enrollmentAt",
                table: "Enrollments",
                newName: "EnrollmentAt");

            migrationBuilder.RenameColumn(
                name: "courseId",
                table: "Enrollments",
                newName: "CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_Enrollments_studentId_courseId",
                table: "Enrollments",
                newName: "IX_Enrollments_StudentId_CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_Enrollments_courseId",
                table: "Enrollments",
                newName: "IX_Enrollments_CourseId");

            migrationBuilder.RenameColumn(
                name: "title",
                table: "Coures",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "Coures",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "instructorId",
                table: "Coures",
                newName: "InstructorId");

            migrationBuilder.RenameIndex(
                name: "IX_Coures_title",
                table: "Coures",
                newName: "IX_Coures_Title");

            migrationBuilder.RenameIndex(
                name: "IX_Coures_instructorId",
                table: "Coures",
                newName: "IX_Coures_InstructorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Coures_Instructors_InstructorId",
                table: "Coures",
                column: "InstructorId",
                principalTable: "Instructors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Coures_CourseId",
                table: "Enrollments",
                column: "CourseId",
                principalTable: "Coures",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Students_StudentId",
                table: "Enrollments",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
