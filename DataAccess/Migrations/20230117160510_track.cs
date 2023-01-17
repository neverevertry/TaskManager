using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class track : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "_status",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__status", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "_user",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__user", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "_userTask",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    createTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    close = table.Column<DateTime>(type: "datetime2", nullable: false),
                    approximateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    actualTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    statusId = table.Column<int>(type: "int", nullable: false),
                    userId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__userTask", x => x.id);
                    table.ForeignKey(
                        name: "FK__userTask__user_userId",
                        column: x => x.userId,
                        principalTable: "_user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "_comment",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaskId = table.Column<int>(type: "int", nullable: false),
                    UserTaskid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__comment", x => x.id);
                    table.ForeignKey(
                        name: "FK__comment__userTask_UserTaskid",
                        column: x => x.UserTaskid,
                        principalTable: "_userTask",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX__comment_UserTaskid",
                table: "_comment",
                column: "UserTaskid");

            migrationBuilder.CreateIndex(
                name: "IX__userTask_userId",
                table: "_userTask",
                column: "userId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "_comment");

            migrationBuilder.DropTable(
                name: "_status");

            migrationBuilder.DropTable(
                name: "_userTask");

            migrationBuilder.DropTable(
                name: "_user");
        }
    }
}
