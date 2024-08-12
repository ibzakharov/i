using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TreeNodeException.Api.Migrations
{
    /// <inheritdoc />
    public partial class ChangeExceptionLog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EventID",
                table: "ExceptionLogs",
                newName: "EventId");

            migrationBuilder.RenameColumn(
                name: "RequestParameters",
                table: "ExceptionLogs",
                newName: "RequestQueryParams");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EventId",
                table: "ExceptionLogs",
                newName: "EventID");

            migrationBuilder.RenameColumn(
                name: "RequestQueryParams",
                table: "ExceptionLogs",
                newName: "RequestParameters");
        }
    }
}
