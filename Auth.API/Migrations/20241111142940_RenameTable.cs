using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Auth.API.Migrations
{
    /// <inheritdoc />
    public partial class RenameTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_asp_net_user_claims_users_user_id",
                schema: "iden",
                table: "asp_net_user_claims");

            migrationBuilder.DropForeignKey(
                name: "FK_asp_net_user_logins_users_user_id",
                schema: "iden",
                table: "asp_net_user_logins");

            migrationBuilder.DropForeignKey(
                name: "FK_asp_net_user_roles_users_user_id",
                schema: "iden",
                table: "asp_net_user_roles");

            migrationBuilder.DropForeignKey(
                name: "FK_asp_net_user_tokens_users_user_id",
                schema: "iden",
                table: "asp_net_user_tokens");

            migrationBuilder.DropForeignKey(
                name: "FK_login_histories_users_user_id",
                schema: "iden",
                table: "login_histories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_users",
                schema: "iden",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_login_histories",
                schema: "iden",
                table: "login_histories");

            migrationBuilder.EnsureSchema(
                name: "asp_net_identity");

            migrationBuilder.RenameTable(
                name: "asp_net_user_tokens",
                schema: "iden",
                newName: "asp_net_user_tokens",
                newSchema: "asp_net_identity");

            migrationBuilder.RenameTable(
                name: "asp_net_user_roles",
                schema: "iden",
                newName: "asp_net_user_roles",
                newSchema: "asp_net_identity");

            migrationBuilder.RenameTable(
                name: "asp_net_user_logins",
                schema: "iden",
                newName: "asp_net_user_logins",
                newSchema: "asp_net_identity");

            migrationBuilder.RenameTable(
                name: "asp_net_user_claims",
                schema: "iden",
                newName: "asp_net_user_claims",
                newSchema: "asp_net_identity");

            migrationBuilder.RenameTable(
                name: "asp_net_roles",
                schema: "iden",
                newName: "asp_net_roles",
                newSchema: "asp_net_identity");

            migrationBuilder.RenameTable(
                name: "asp_net_role_claims",
                schema: "iden",
                newName: "asp_net_role_claims",
                newSchema: "asp_net_identity");

            migrationBuilder.RenameTable(
                name: "users",
                schema: "iden",
                newName: "asp_net_users",
                newSchema: "asp_net_identity");

            migrationBuilder.RenameTable(
                name: "login_histories",
                schema: "iden",
                newName: "asp_net_login_logs",
                newSchema: "asp_net_identity");

            migrationBuilder.RenameIndex(
                name: "IX_login_histories_user_id",
                schema: "asp_net_identity",
                table: "asp_net_login_logs",
                newName: "IX_asp_net_login_logs_user_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_asp_net_users",
                schema: "asp_net_identity",
                table: "asp_net_users",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_asp_net_login_logs",
                schema: "asp_net_identity",
                table: "asp_net_login_logs",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_asp_net_login_logs_asp_net_users_user_id",
                schema: "asp_net_identity",
                table: "asp_net_login_logs",
                column: "user_id",
                principalSchema: "asp_net_identity",
                principalTable: "asp_net_users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_asp_net_user_claims_asp_net_users_user_id",
                schema: "asp_net_identity",
                table: "asp_net_user_claims",
                column: "user_id",
                principalSchema: "asp_net_identity",
                principalTable: "asp_net_users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_asp_net_user_logins_asp_net_users_user_id",
                schema: "asp_net_identity",
                table: "asp_net_user_logins",
                column: "user_id",
                principalSchema: "asp_net_identity",
                principalTable: "asp_net_users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_asp_net_user_roles_asp_net_users_user_id",
                schema: "asp_net_identity",
                table: "asp_net_user_roles",
                column: "user_id",
                principalSchema: "asp_net_identity",
                principalTable: "asp_net_users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_asp_net_user_tokens_asp_net_users_user_id",
                schema: "asp_net_identity",
                table: "asp_net_user_tokens",
                column: "user_id",
                principalSchema: "asp_net_identity",
                principalTable: "asp_net_users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_asp_net_login_logs_asp_net_users_user_id",
                schema: "asp_net_identity",
                table: "asp_net_login_logs");

            migrationBuilder.DropForeignKey(
                name: "FK_asp_net_user_claims_asp_net_users_user_id",
                schema: "asp_net_identity",
                table: "asp_net_user_claims");

            migrationBuilder.DropForeignKey(
                name: "FK_asp_net_user_logins_asp_net_users_user_id",
                schema: "asp_net_identity",
                table: "asp_net_user_logins");

            migrationBuilder.DropForeignKey(
                name: "FK_asp_net_user_roles_asp_net_users_user_id",
                schema: "asp_net_identity",
                table: "asp_net_user_roles");

            migrationBuilder.DropForeignKey(
                name: "FK_asp_net_user_tokens_asp_net_users_user_id",
                schema: "asp_net_identity",
                table: "asp_net_user_tokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_asp_net_users",
                schema: "asp_net_identity",
                table: "asp_net_users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_asp_net_login_logs",
                schema: "asp_net_identity",
                table: "asp_net_login_logs");

            migrationBuilder.EnsureSchema(
                name: "iden");

            migrationBuilder.RenameTable(
                name: "asp_net_user_tokens",
                schema: "asp_net_identity",
                newName: "asp_net_user_tokens",
                newSchema: "iden");

            migrationBuilder.RenameTable(
                name: "asp_net_user_roles",
                schema: "asp_net_identity",
                newName: "asp_net_user_roles",
                newSchema: "iden");

            migrationBuilder.RenameTable(
                name: "asp_net_user_logins",
                schema: "asp_net_identity",
                newName: "asp_net_user_logins",
                newSchema: "iden");

            migrationBuilder.RenameTable(
                name: "asp_net_user_claims",
                schema: "asp_net_identity",
                newName: "asp_net_user_claims",
                newSchema: "iden");

            migrationBuilder.RenameTable(
                name: "asp_net_roles",
                schema: "asp_net_identity",
                newName: "asp_net_roles",
                newSchema: "iden");

            migrationBuilder.RenameTable(
                name: "asp_net_role_claims",
                schema: "asp_net_identity",
                newName: "asp_net_role_claims",
                newSchema: "iden");

            migrationBuilder.RenameTable(
                name: "asp_net_users",
                schema: "asp_net_identity",
                newName: "users",
                newSchema: "iden");

            migrationBuilder.RenameTable(
                name: "asp_net_login_logs",
                schema: "asp_net_identity",
                newName: "login_histories",
                newSchema: "iden");

            migrationBuilder.RenameIndex(
                name: "IX_asp_net_login_logs_user_id",
                schema: "iden",
                table: "login_histories",
                newName: "IX_login_histories_user_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_users",
                schema: "iden",
                table: "users",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_login_histories",
                schema: "iden",
                table: "login_histories",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_asp_net_user_claims_users_user_id",
                schema: "iden",
                table: "asp_net_user_claims",
                column: "user_id",
                principalSchema: "iden",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_asp_net_user_logins_users_user_id",
                schema: "iden",
                table: "asp_net_user_logins",
                column: "user_id",
                principalSchema: "iden",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_asp_net_user_roles_users_user_id",
                schema: "iden",
                table: "asp_net_user_roles",
                column: "user_id",
                principalSchema: "iden",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_asp_net_user_tokens_users_user_id",
                schema: "iden",
                table: "asp_net_user_tokens",
                column: "user_id",
                principalSchema: "iden",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_login_histories_users_user_id",
                schema: "iden",
                table: "login_histories",
                column: "user_id",
                principalSchema: "iden",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
