using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PT_SalasDario.Data.Migrations
{
    /// <inheritdoc />
    public partial class M1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_domicilio_usuario_UsuarioID",
                table: "domicilio");

            migrationBuilder.DropIndex(
                name: "IX_domicilio_UsuarioID",
                table: "domicilio");

            migrationBuilder.DropColumn(
                name: "UsuarioID",
                table: "domicilio");

            migrationBuilder.AddColumn<int>(
                name: "DomicilioID",
                table: "usuario",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_usuario_DomicilioID",
                table: "usuario",
                column: "DomicilioID");

            migrationBuilder.AddForeignKey(
                name: "FK_usuario_domicilio_DomicilioID",
                table: "usuario",
                column: "DomicilioID",
                principalTable: "domicilio",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_usuario_domicilio_DomicilioID",
                table: "usuario");

            migrationBuilder.DropIndex(
                name: "IX_usuario_DomicilioID",
                table: "usuario");

            migrationBuilder.DropColumn(
                name: "DomicilioID",
                table: "usuario");

            migrationBuilder.AddColumn<int>(
                name: "UsuarioID",
                table: "domicilio",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_domicilio_UsuarioID",
                table: "domicilio",
                column: "UsuarioID");

            migrationBuilder.AddForeignKey(
                name: "FK_domicilio_usuario_UsuarioID",
                table: "domicilio",
                column: "UsuarioID",
                principalTable: "usuario",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
