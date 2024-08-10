using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TreeNodeException.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "Nodes",
                columns: table => new
                {
                    NodeID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NodeName = table.Column<string>(type: "text", nullable: false),
                    ParentNodeID = table.Column<int>(type: "integer", nullable: true),
                    TreeID = table.Column<int>(type: "integer", nullable: false),
                    OtherAttributes = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nodes", x => x.NodeID);
                    table.ForeignKey(
                        name: "FK_Nodes_Nodes_ParentNodeID",
                        column: x => x.ParentNodeID,
                        principalTable: "Nodes",
                        principalColumn: "NodeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Nodes_Trees_TreeID",
                        column: x => x.TreeID,
                        principalTable: "Trees",
                        principalColumn: "TreeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Nodes_ParentNodeID",
                table: "Nodes",
                column: "ParentNodeID");

            migrationBuilder.CreateIndex(
                name: "IX_Nodes_TreeID",
                table: "Nodes",
                column: "TreeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Nodes");

            migrationBuilder.DropTable(
                name: "Trees");
        }
    }
}
