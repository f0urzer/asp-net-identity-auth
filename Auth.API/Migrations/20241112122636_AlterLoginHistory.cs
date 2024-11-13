using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Auth.API.Migrations
{
    /// <inheritdoc />
    public partial class AlterLoginHistory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_asp_net_login_histories_asp_net_users_user_id1",
                schema: "asp_net_identity",
                table: "asp_net_login_histories");

            migrationBuilder.DropIndex(
                name: "IX_asp_net_login_histories_user_id1",
                schema: "asp_net_identity",
                table: "asp_net_login_histories");

            migrationBuilder.DropColumn(
                name: "user_id1",
                schema: "asp_net_identity",
                table: "asp_net_login_histories");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "user_id1",
                schema: "asp_net_identity",
                table: "asp_net_login_histories",
                type: "character varying(36)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_asp_net_login_histories_user_id1",
                schema: "asp_net_identity",
                table: "asp_net_login_histories",
                column: "user_id1");

            migrationBuilder.AddForeignKey(
                name: "FK_asp_net_login_histories_asp_net_users_user_id1",
                schema: "asp_net_identity",
                table: "asp_net_login_histories",
                column: "user_id1",
                principalSchema: "asp_net_identity",
                principalTable: "asp_net_users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
