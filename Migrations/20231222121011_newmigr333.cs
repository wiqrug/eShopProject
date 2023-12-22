using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project2.Migrations
{
    /// <inheritdoc />
    public partial class newmigr333 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "AssessmentTestCode",
            //    table: "Certificates");

            migrationBuilder.AddColumn<string>(
                name: "AssessmentTestCode",
                table: "CandidateCertificates",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Exams",
                columns: table => new
                {
                    ExamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExamDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AwardedMarks = table.Column<int>(type: "int", nullable: false),
                    PossibleMarks = table.Column<int>(type: "int", nullable: false),
                    CertificateID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exams", x => x.ExamId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Exams");

            migrationBuilder.DropColumn(
                name: "AssessmentTestCode",
                table: "CandidateCertificates");

            migrationBuilder.AddColumn<string>(
                name: "AssessmentTestCode",
                table: "Certificates",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}
