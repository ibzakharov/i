using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TreeNodeException.Api.Migrations
{
    /// <inheritdoc />
    public partial class RemoveTree : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nodes_Trees_TreeID",
                table: "Nodes");

            migrationBuilder.DropTable(
                name: "Trees");

            migrationBuilder.DropIndex(
                name: "IX_Nodes_TreeID",
                table: "Nodes");

            migrationBuilder.DropColumn(
                name: "TreeID",
                table: "Nodes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TreeID",
                table: "Nodes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Trees",
                columns: table => new
                {
                    TreeID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TreeName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trees", x => x.TreeID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Nodes_TreeID",
                table: "Nodes",
                column: "TreeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Nodes_Trees_TreeID",
                table: "Nodes",
                column: "TreeID",
                principalTable: "Trees",
                principalColumn: "TreeID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
