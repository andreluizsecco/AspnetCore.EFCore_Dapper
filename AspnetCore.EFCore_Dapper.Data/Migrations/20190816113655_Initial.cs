using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AspnetCore.EFCore_Dapper.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Autor",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autor", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Livro",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AutorID = table.Column<int>(nullable: false),
                    Titulo = table.Column<string>(type: "varchar(100)", nullable: false),
                    AnoPublicacao = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livro", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Livro_Autor_AutorID",
                        column: x => x.AutorID,
                        principalTable: "Autor",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Autor",
                columns: new[] { "ID", "Nome" },
                values: new object[,]
                {
                    { 1, "Eric Evans" },
                    { 2, "Robert C. Martin" },
                    { 3, "Vaughn Vernon" },
                    { 4, "Scott Millet" },
                    { 5, "Martin Fowler" }
                });

            migrationBuilder.InsertData(
                table: "Livro",
                columns: new[] { "ID", "AnoPublicacao", "AutorID", "Titulo" },
                values: new object[,]
                {
                    { 1, 2003, 1, "Domain-Driven Design: Tackling Complexity in the Heart of Software" },
                    { 2, 2006, 2, "Agile Principles, Patterns, and Practices in C#" },
                    { 3, 2008, 2, "Clean Code: A Handbook of Agile Software Craftsmanship" },
                    { 4, 2013, 3, "Implementing Domain-Driven Design" },
                    { 5, 2015, 4, "Patterns, Principles, and Practices of Domain-Driven Design" },
                    { 6, 2012, 5, "Refactoring: Improving the Design of Existing Code " }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Livro_AutorID",
                table: "Livro",
                column: "AutorID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Livro");

            migrationBuilder.DropTable(
                name: "Autor");
        }
    }
}
