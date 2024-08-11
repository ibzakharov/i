using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TreeNodeException.Api.Migrations
{
    /// <inheritdoc />
    public partial class UpdateNode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nodes_Nodes_ParentNodeID",
                table: "Nodes");

            migrationBuilder.RenameColumn(
                name: "NodeID",
                table: "Nodes",
                newName: "NodeId");

            migrationBuilder.RenameColumn(
                name: "ParentNodeID",
                table: "Nodes",
                newName: "ParentId");

            migrationBuilder.RenameColumn(
                name: "NodeName",
                table: "Nodes",
                newName: "Name");

            migrationBuilder.RenameIndex(
                name: "IX_Nodes_ParentNodeID",
                table: "Nodes",
                newName: "IX_Nodes_ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Nodes_Nodes_ParentId",
                table: "Nodes",
                column: "ParentId",
                principalTable: "Nodes",
                principalColumn: "NodeId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nodes_Nodes_ParentId",
                table: "Nodes");

            migrationBuilder.RenameColumn(
                name: "NodeId",
                table: "Nodes",
                newName: "NodeID");

            migrationBuilder.RenameColumn(
                name: "ParentId",
                table: "Nodes",
                newName: "ParentNodeID");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Nodes",
                newName: "NodeName");

            migrationBuilder.RenameIndex(
                name: "IX_Nodes_ParentId",
                table: "Nodes",
                newName: "IX_Nodes_ParentNodeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Nodes_Nodes_ParentNodeID",
                table: "Nodes",
                column: "ParentNodeID",
                principalTable: "Nodes",
                principalColumn: "NodeID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
