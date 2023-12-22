using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project2.Migrations
{
    /// <inheritdoc />
    public partial class nmgr2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CandidateCertificates_Candidates_CandidateID",
                table: "CandidateCertificates");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidateCertificates_Certificates_CertificateID",
                table: "CandidateCertificates");

            migrationBuilder.DropIndex(
                name: "IX_CandidateCertificates_CandidateID",
                table: "CandidateCertificates");

            migrationBuilder.DropIndex(
                name: "IX_CandidateCertificates_CertificateID",
                table: "CandidateCertificates");

            migrationBuilder.DropColumn(
                name: "AssessmentTestCode",
                table: "Certificates");

            migrationBuilder.DropColumn(
                name: "CandidateID",
                table: "CandidateCertificates");

            migrationBuilder.AddColumn<int>(
                name: "CandidateNumber",
                table: "CandidateCertificates",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CandidateNumber",
                table: "CandidateCertificates");

            migrationBuilder.AddColumn<string>(
                name: "AssessmentTestCode",
                table: "Certificates",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "CandidateID",
                table: "CandidateCertificates",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_CandidateCertificates_CandidateID",
                table: "CandidateCertificates",
                column: "CandidateID");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateCertificates_CertificateID",
                table: "CandidateCertificates",
                column: "CertificateID");

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
        }
    }
}
