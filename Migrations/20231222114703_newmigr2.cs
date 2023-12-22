using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project2.Migrations
{
    /// <inheritdoc />
    public partial class newmigr2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CandidateCertificates_Candidates_CandidateUserID",
                table: "CandidateCertificates");

            migrationBuilder.DropColumn(
                name: "CandidateNumber",
                table: "CandidateCertificates");

            migrationBuilder.RenameColumn(
                name: "CandidateUserID",
                table: "CandidateCertificates",
                newName: "CandidateId");

            migrationBuilder.RenameIndex(
                name: "IX_CandidateCertificates_CandidateUserID",
                table: "CandidateCertificates",
                newName: "IX_CandidateCertificates_CandidateId");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateCertificates_Candidates_CandidateId",
                table: "CandidateCertificates",
                column: "CandidateId",
                principalTable: "Candidates",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CandidateCertificates_Candidates_CandidateId",
                table: "CandidateCertificates");

            migrationBuilder.RenameColumn(
                name: "CandidateId",
                table: "CandidateCertificates",
                newName: "CandidateUserID");

            migrationBuilder.RenameIndex(
                name: "IX_CandidateCertificates_CandidateId",
                table: "CandidateCertificates",
                newName: "IX_CandidateCertificates_CandidateUserID");

            migrationBuilder.AddColumn<int>(
                name: "CandidateNumber",
                table: "CandidateCertificates",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateCertificates_Candidates_CandidateUserID",
                table: "CandidateCertificates",
                column: "CandidateUserID",
                principalTable: "Candidates",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
