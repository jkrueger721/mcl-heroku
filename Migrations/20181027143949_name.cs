using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MusiCoLab2.Migrations
{
    public partial class name : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectContributor_Projects_ProjectId",
                table: "ProjectContributor");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectContributor_Users_UserId",
                table: "ProjectContributor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectContributor",
                table: "ProjectContributor");

            migrationBuilder.RenameTable(
                name: "ProjectContributor",
                newName: "ProjectContributors");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectContributor_UserId",
                table: "ProjectContributors",
                newName: "IX_ProjectContributors_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectContributors",
                table: "ProjectContributors",
                columns: new[] { "ProjectId", "UserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectContributors_Projects_ProjectId",
                table: "ProjectContributors",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectContributors_Users_UserId",
                table: "ProjectContributors",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectContributors_Projects_ProjectId",
                table: "ProjectContributors");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectContributors_Users_UserId",
                table: "ProjectContributors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectContributors",
                table: "ProjectContributors");

            migrationBuilder.RenameTable(
                name: "ProjectContributors",
                newName: "ProjectContributor");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectContributors_UserId",
                table: "ProjectContributor",
                newName: "IX_ProjectContributor_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectContributor",
                table: "ProjectContributor",
                columns: new[] { "ProjectId", "UserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectContributor_Projects_ProjectId",
                table: "ProjectContributor",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectContributor_Users_UserId",
                table: "ProjectContributor",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
