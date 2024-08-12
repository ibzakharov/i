using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TreeNodeException.Api.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTreeAndNode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nodes_Nodes_TreeNodeId",
                table: "Nodes");

            migrationBuilder.DropIndex(
                name: "IX_Nodes_TreeNodeId",
                table: "Nodes");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Nodes");

            migrationBuilder.DropColumn(
                name: "TreeName",
                table: "Nodes");

            migrationBuilder.DropColumn(
                name: "TreeNodeId",
                table: "Nodes");

            migrationBuilder.AlterColumn<int>(
                name: "TreeId",
                table: "Nodes",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nodes_Trees_TreeId",
                table: "Nodes");

            migrationBuilder.DropTable(
                name: "Trees");

            migrationBuilder.DropIndex(
                name: "IX_Nodes_TreeId",
                table: "Nodes");

            migrationBuilder.AlterColumn<int>(
                name: "TreeId",
                table: "Nodes",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Nodes",
                type: "character varying(5)",
                maxLength: 5,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TreeName",
                table: "Nodes",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TreeNodeId",
                table: "Nodes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Nodes_TreeNodeId",
                table: "Nodes",
                column: "TreeNodeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Nodes_Nodes_TreeNodeId",
                table: "Nodes",
                column: "TreeNodeId",
                principalTable: "Nodes",
                principalColumn: "NodeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
