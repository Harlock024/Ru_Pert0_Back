using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ru_pert0_back.Migrations
{
    /// <inheritdoc />
    public partial class initial_Migration_models_v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nodes_Nodes_ParentId",
                table: "Nodes");

            migrationBuilder.DropForeignKey(
                name: "FK_Nodes_Projects_ProjectId",
                table: "Nodes");

            migrationBuilder.DropForeignKey(
                name: "FK_Nodes_Tasks_TaskId",
                table: "Nodes");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Users_UserId",
                table: "Projects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Projects",
                table: "Projects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Nodes",
                table: "Nodes");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "Projects",
                newName: "Project");

            migrationBuilder.RenameTable(
                name: "Nodes",
                newName: "Node");

            migrationBuilder.RenameIndex(
                name: "IX_Projects_UserId",
                table: "Project",
                newName: "IX_Project_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Nodes_TaskId",
                table: "Node",
                newName: "IX_Node_TaskId");

            migrationBuilder.RenameIndex(
                name: "IX_Nodes_ProjectId",
                table: "Node",
                newName: "IX_Node_ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_Nodes_ParentId",
                table: "Node",
                newName: "IX_Node_ParentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Project",
                table: "Project",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Node",
                table: "Node",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Node_Node_ParentId",
                table: "Node",
                column: "ParentId",
                principalTable: "Node",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Node_Project_ProjectId",
                table: "Node",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Node_Tasks_TaskId",
                table: "Node",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Project_User_UserId",
                table: "Project",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Node_Node_ParentId",
                table: "Node");

            migrationBuilder.DropForeignKey(
                name: "FK_Node_Project_ProjectId",
                table: "Node");

            migrationBuilder.DropForeignKey(
                name: "FK_Node_Tasks_TaskId",
                table: "Node");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_User_UserId",
                table: "Project");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Project",
                table: "Project");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Node",
                table: "Node");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "Project",
                newName: "Projects");

            migrationBuilder.RenameTable(
                name: "Node",
                newName: "Nodes");

            migrationBuilder.RenameIndex(
                name: "IX_Project_UserId",
                table: "Projects",
                newName: "IX_Projects_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Node_TaskId",
                table: "Nodes",
                newName: "IX_Nodes_TaskId");

            migrationBuilder.RenameIndex(
                name: "IX_Node_ProjectId",
                table: "Nodes",
                newName: "IX_Nodes_ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_Node_ParentId",
                table: "Nodes",
                newName: "IX_Nodes_ParentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Projects",
                table: "Projects",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Nodes",
                table: "Nodes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Nodes_Nodes_ParentId",
                table: "Nodes",
                column: "ParentId",
                principalTable: "Nodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Nodes_Projects_ProjectId",
                table: "Nodes",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Nodes_Tasks_TaskId",
                table: "Nodes",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Users_UserId",
                table: "Projects",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
