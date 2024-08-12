using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TreeNodeException.Api.Migrations
{
    /// <inheritdoc />
    public partial class RemoveTreeAgain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nodes_Trees_TreeId",
                table: "Nodes");

            migrationBuilder.DropTable(
                name: "Trees");

            migrationBuilder.DropIndex(
                name: "IX_Nodes_TreeId",
                table: "Nodes");

            migrationBuilder.DropColumn(
                name: "TreeId",
                table: "Nodes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TreeId",
                table: "Nodes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Trees",
                columns: table => new
                {
                    TreeId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TreeName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trees", x => x.TreeId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Nodes_TreeId",
                table: "Nodes",
                column: "TreeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Nodes_Trees_TreeId",
                table: "Nodes",
                column: "TreeId",
                principalTable: "Trees",
                principalColumn: "TreeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
