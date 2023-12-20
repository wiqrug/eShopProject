using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project2.Migrations
{
    /// <inheritdoc />
    public partial class NewMigration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CandidateCertificates",
                columns: table => new
                {
                    RecordID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CandidateID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CertificateID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CandidateScore = table.Column<int>(type: "int", nullable: true),
                    PercentageScore = table.Column<float>(type: "real", nullable: true),
                    AssessmentResultLabel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TopicDescriptions = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TopicScores = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateCertificates", x => x.RecordID);
                    table.ForeignKey(
                        name: "FK_CandidateCertificates_Candidates_CandidateID",
                        column: x => x.CandidateID,
                        principalTable: "Candidates",
                        principalColumn: "CandidateID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CandidateCertificates_Certificates_CertificateID",
                        column: x => x.CertificateID,
                        principalTable: "Certificates",
                        principalColumn: "CertificateID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CandidateCertificates_CandidateID",
                table: "CandidateCertificates",
                column: "CandidateID");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateCertificates_CertificateID",
                table: "CandidateCertificates",
                column: "CertificateID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CandidateCertificates");
        }
    }
}
