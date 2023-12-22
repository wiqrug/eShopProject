using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project2.Migrations
{
    /// <inheritdoc />
    public partial class newmgri3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Exams_CertificateID",
                table: "Exams",
                column: "CertificateID");

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_Certificates_CertificateID",
                table: "Exams",
                column: "CertificateID",
                principalTable: "Certificates",
                principalColumn: "CertificateID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exams_Certificates_CertificateID",
                table: "Exams");

            migrationBuilder.DropIndex(
                name: "IX_Exams_CertificateID",
                table: "Exams");
        }
    }
}
