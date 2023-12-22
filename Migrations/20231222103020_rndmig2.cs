using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project2.Migrations
{
    /// <inheritdoc />
    public partial class rndmig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CandidateUserID",
                table: "CandidateCertificates",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_CandidateCertificates_CandidateUserID",
                table: "CandidateCertificates",
                column: "CandidateUserID");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateCertificates_CertificateID",
                table: "CandidateCertificates",
                column: "CertificateID");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateCertificates_Candidates_CandidateUserID",
                table: "CandidateCertificates",
                column: "CandidateUserID",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CandidateCertificates_Candidates_CandidateUserID",
                table: "CandidateCertificates");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidateCertificates_Certificates_CertificateID",
                table: "CandidateCertificates");

            migrationBuilder.DropIndex(
                name: "IX_CandidateCertificates_CandidateUserID",
                table: "CandidateCertificates");

            migrationBuilder.DropIndex(
                name: "IX_CandidateCertificates_CertificateID",
                table: "CandidateCertificates");

            migrationBuilder.DropColumn(
                name: "CandidateUserID",
                table: "CandidateCertificates");
        }
    }
}
