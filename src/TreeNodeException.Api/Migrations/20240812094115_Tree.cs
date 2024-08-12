using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TreeNodeException.Api.Migrations
{
    /// <inheritdoc />
    public partial class Tree : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Nodes",
                type: "character varying(5)",
                maxLength: 5,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "TreeId",
                table: "Nodes",
                type: "integer",
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "TreeId",
                table: "Nodes");

            migrationBuilder.DropColumn(
                name: "TreeName",
                table: "Nodes");

            migrationBuilder.DropColumn(
                name: "TreeNodeId",
                table: "Nodes");
        }
    }
}
