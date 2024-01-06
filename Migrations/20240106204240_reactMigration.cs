using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project2.Migrations
{
    /// <inheritdoc />
    public partial class reactMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admins_Users_UserID",
                table: "Admins");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidateCertificates_Candidates_CandidateID",
                table: "CandidateCertificates");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidateCertificates_Certificates_CertificateID",
                table: "CandidateCertificates");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidateExams_Candidates_CandidateID",
                table: "CandidateExams");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidateExams_Exams_ExamID",
                table: "CandidateExams");

            migrationBuilder.DropForeignKey(
                name: "FK_Candidates_Users_UserID",
                table: "Candidates");

            migrationBuilder.DropForeignKey(
                name: "FK_Exams_Certificates_CertificateID",
                table: "Exams");

            migrationBuilder.DropForeignKey(
                name: "FK_Markers_Users_UserID",
                table: "Markers");

            migrationBuilder.DropForeignKey(
                name: "FK_QualityControls_Users_UserID",
                table: "QualityControls");

            migrationBuilder.DropColumn(
                name: "questions",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "AwardedMarks",
                table: "Exams");

            migrationBuilder.DropColumn(
                name: "ExamDescription",
                table: "Exams");

            migrationBuilder.DropColumn(
                name: "PossibleMarks",
                table: "Exams");

            migrationBuilder.DropColumn(
                name: "ExaminationDate",
                table: "Certificates");

            migrationBuilder.DropColumn(
                name: "MaximumScore",
                table: "Certificates");

            migrationBuilder.DropColumn(
                name: "ScoreReportDate",
                table: "Certificates");

            migrationBuilder.DropColumn(
                name: "AssessmentResultLabel",
                table: "CandidateCertificates");

            migrationBuilder.DropColumn(
                name: "AssessmentTestCode",
                table: "CandidateCertificates");

            migrationBuilder.DropColumn(
                name: "PercentageScore",
                table: "CandidateCertificates");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Users",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "questionsID",
                table: "Questions",
                newName: "QuestionId");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "QualityControls",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Markers",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "CertificateID",
                table: "Exams",
                newName: "CertificateId");

            migrationBuilder.RenameIndex(
                name: "IX_Exams_CertificateID",
                table: "Exams",
                newName: "IX_Exams_CertificateId");

            migrationBuilder.RenameColumn(
                name: "CertificateID",
                table: "Certificates",
                newName: "CertificateId");

            migrationBuilder.RenameColumn(
                name: "TitleOfCertificate",
                table: "Certificates",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Candidates",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "ExamID",
                table: "CandidateExams",
                newName: "ExamId");

            migrationBuilder.RenameColumn(
                name: "CandidateID",
                table: "CandidateExams",
                newName: "CandidateId");

            migrationBuilder.RenameColumn(
                name: "CandidateExamID",
                table: "CandidateExams",
                newName: "CandidateExamId");

            migrationBuilder.RenameColumn(
                name: "Mark",
                table: "CandidateExams",
                newName: "ExamMark");

            migrationBuilder.RenameIndex(
                name: "IX_CandidateExams_ExamID",
                table: "CandidateExams",
                newName: "IX_CandidateExams_ExamId");

            migrationBuilder.RenameIndex(
                name: "IX_CandidateExams_CandidateID",
                table: "CandidateExams",
                newName: "IX_CandidateExams_CandidateId");

            migrationBuilder.RenameColumn(
                name: "CertificateID",
                table: "CandidateCertificates",
                newName: "CertificateId");

            migrationBuilder.RenameColumn(
                name: "CandidateID",
                table: "CandidateCertificates",
                newName: "CandidateId");

            migrationBuilder.RenameColumn(
                name: "RecordID",
                table: "CandidateCertificates",
                newName: "RecordId");

            migrationBuilder.RenameColumn(
                name: "CandidateScore",
                table: "CandidateCertificates",
                newName: "Mark");

            migrationBuilder.RenameIndex(
                name: "IX_CandidateCertificates_CertificateID",
                table: "CandidateCertificates",
                newName: "IX_CandidateCertificates_CertificateId");

            migrationBuilder.RenameIndex(
                name: "IX_CandidateCertificates_CandidateID",
                table: "CandidateCertificates",
                newName: "IX_CandidateCertificates_CandidateId");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Admins",
                newName: "UserId");

            migrationBuilder.AlterColumn<string>(
                name: "CorrectAnswer",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AnswerD",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AnswerC",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AnswerB",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AnswerA",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Question",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Exams",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Exams",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "TownOrCity",
                table: "Candidates",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "StateOrTerritoryOrProvince",
                table: "Candidates",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "PostalCode",
                table: "Candidates",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "PhotoIDType",
                table: "Candidates",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "PhotoIDNumber",
                table: "Candidates",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "NativeLanguage",
                table: "Candidates",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "MobileNumber",
                table: "Candidates",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "MiddleName",
                table: "Candidates",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "LandlineNumber",
                table: "Candidates",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "Candidates",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "AddressLine2",
                table: "Candidates",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Candidates",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "CompletedAt",
                table: "CandidateCertificates",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Admins_Users_UserId",
                table: "Admins",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateCertificates_Candidates_CandidateId",
                table: "CandidateCertificates",
                column: "CandidateId",
                principalTable: "Candidates",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateCertificates_Certificates_CertificateId",
                table: "CandidateCertificates",
                column: "CertificateId",
                principalTable: "Certificates",
                principalColumn: "CertificateId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateExams_Candidates_CandidateId",
                table: "CandidateExams",
                column: "CandidateId",
                principalTable: "Candidates",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateExams_Exams_ExamId",
                table: "CandidateExams",
                column: "ExamId",
                principalTable: "Exams",
                principalColumn: "ExamId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Candidates_Users_UserId",
                table: "Candidates",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_Certificates_CertificateId",
                table: "Exams",
                column: "CertificateId",
                principalTable: "Certificates",
                principalColumn: "CertificateId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Markers_Users_UserId",
                table: "Markers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QualityControls_Users_UserId",
                table: "QualityControls",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admins_Users_UserId",
                table: "Admins");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidateCertificates_Candidates_CandidateId",
                table: "CandidateCertificates");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidateCertificates_Certificates_CertificateId",
                table: "CandidateCertificates");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidateExams_Candidates_CandidateId",
                table: "CandidateExams");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidateExams_Exams_ExamId",
                table: "CandidateExams");

            migrationBuilder.DropForeignKey(
                name: "FK_Candidates_Users_UserId",
                table: "Candidates");

            migrationBuilder.DropForeignKey(
                name: "FK_Exams_Certificates_CertificateId",
                table: "Exams");

            migrationBuilder.DropForeignKey(
                name: "FK_Markers_Users_UserId",
                table: "Markers");

            migrationBuilder.DropForeignKey(
                name: "FK_QualityControls_Users_UserId",
                table: "QualityControls");

            migrationBuilder.DropColumn(
                name: "Question",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Exams");

            migrationBuilder.DropColumn(
                name: "CompletedAt",
                table: "CandidateCertificates");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Users",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "QuestionId",
                table: "Questions",
                newName: "questionsID");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "QualityControls",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Markers",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "CertificateId",
                table: "Exams",
                newName: "CertificateID");

            migrationBuilder.RenameIndex(
                name: "IX_Exams_CertificateId",
                table: "Exams",
                newName: "IX_Exams_CertificateID");

            migrationBuilder.RenameColumn(
                name: "CertificateId",
                table: "Certificates",
                newName: "CertificateID");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Certificates",
                newName: "TitleOfCertificate");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Candidates",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "ExamId",
                table: "CandidateExams",
                newName: "ExamID");

            migrationBuilder.RenameColumn(
                name: "CandidateId",
                table: "CandidateExams",
                newName: "CandidateID");

            migrationBuilder.RenameColumn(
                name: "CandidateExamId",
                table: "CandidateExams",
                newName: "CandidateExamID");

            migrationBuilder.RenameColumn(
                name: "ExamMark",
                table: "CandidateExams",
                newName: "Mark");

            migrationBuilder.RenameIndex(
                name: "IX_CandidateExams_ExamId",
                table: "CandidateExams",
                newName: "IX_CandidateExams_ExamID");

            migrationBuilder.RenameIndex(
                name: "IX_CandidateExams_CandidateId",
                table: "CandidateExams",
                newName: "IX_CandidateExams_CandidateID");

            migrationBuilder.RenameColumn(
                name: "CertificateId",
                table: "CandidateCertificates",
                newName: "CertificateID");

            migrationBuilder.RenameColumn(
                name: "CandidateId",
                table: "CandidateCertificates",
                newName: "CandidateID");

            migrationBuilder.RenameColumn(
                name: "RecordId",
                table: "CandidateCertificates",
                newName: "RecordID");

            migrationBuilder.RenameColumn(
                name: "Mark",
                table: "CandidateCertificates",
                newName: "CandidateScore");

            migrationBuilder.RenameIndex(
                name: "IX_CandidateCertificates_CertificateId",
                table: "CandidateCertificates",
                newName: "IX_CandidateCertificates_CertificateID");

            migrationBuilder.RenameIndex(
                name: "IX_CandidateCertificates_CandidateId",
                table: "CandidateCertificates",
                newName: "IX_CandidateCertificates_CandidateID");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Admins",
                newName: "UserID");

            migrationBuilder.AlterColumn<string>(
                name: "CorrectAnswer",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "AnswerD",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "AnswerC",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "AnswerB",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "AnswerA",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "questions",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Exams",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<int>(
                name: "AwardedMarks",
                table: "Exams",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExamDescription",
                table: "Exams",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PossibleMarks",
                table: "Exams",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ExaminationDate",
                table: "Certificates",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "MaximumScore",
                table: "Certificates",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ScoreReportDate",
                table: "Certificates",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "TownOrCity",
                table: "Candidates",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "StateOrTerritoryOrProvince",
                table: "Candidates",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PostalCode",
                table: "Candidates",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhotoIDType",
                table: "Candidates",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhotoIDNumber",
                table: "Candidates",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NativeLanguage",
                table: "Candidates",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MobileNumber",
                table: "Candidates",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MiddleName",
                table: "Candidates",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LandlineNumber",
                table: "Candidates",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "Candidates",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AddressLine2",
                table: "Candidates",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Candidates",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AssessmentResultLabel",
                table: "CandidateCertificates",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AssessmentTestCode",
                table: "CandidateCertificates",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<float>(
                name: "PercentageScore",
                table: "CandidateCertificates",
                type: "real",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Admins_Users_UserID",
                table: "Admins",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateCertificates_Candidates_CandidateID",
                table: "CandidateCertificates",
                column: "CandidateID",
                principalTable: "Candidates",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateCertificates_Certificates_CertificateID",
                table: "CandidateCertificates",
                column: "CertificateID",
                principalTable: "Certificates",
                principalColumn: "CertificateID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateExams_Candidates_CandidateID",
                table: "CandidateExams",
                column: "CandidateID",
                principalTable: "Candidates",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateExams_Exams_ExamID",
                table: "CandidateExams",
                column: "ExamID",
                principalTable: "Exams",
                principalColumn: "ExamId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Candidates_Users_UserID",
                table: "Candidates",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_Certificates_CertificateID",
                table: "Exams",
                column: "CertificateID",
                principalTable: "Certificates",
                principalColumn: "CertificateID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Markers_Users_UserID",
                table: "Markers",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QualityControls_Users_UserID",
                table: "QualityControls",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
