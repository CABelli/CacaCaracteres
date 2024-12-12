using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CacaCaracteres.Migrations
{
    /// <inheritdoc />
    public partial class CreateAtributAutorIdTableLivroTexto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AutorId",
                table: "LivroTexto",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LivroTexto_AutorId",
                table: "LivroTexto",
                column: "AutorId");

            migrationBuilder.AddForeignKey(
                name: "FK_LivroTexto_Autors_AutorId",
                table: "LivroTexto",
                column: "AutorId",
                principalTable: "Autors",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LivroTexto_Autors_AutorId",
                table: "LivroTexto");

            migrationBuilder.DropIndex(
                name: "IX_LivroTexto_AutorId",
                table: "LivroTexto");

            migrationBuilder.DropColumn(
                name: "AutorId",
                table: "LivroTexto");
        }
    }
}
