using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RoshanApi.Migrations
{
    /// <inheritdoc />
    public partial class bill : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Accounts_AccountId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_AccountId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Transactions");

            migrationBuilder.RenameColumn(
                name: "Side",
                table: "Transactions",
                newName: "PaymentType");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "Transactions",
                newName: "ProductId");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Transactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Transactions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Discount",
                table: "Transactions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "Transactions",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Quantity",
                table: "Transactions",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Rate",
                table: "Transactions",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "SupplierId",
                table: "Transactions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TotalLaga",
                table: "Transactions",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "Discount",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "Rate",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "TotalLaga",
                table: "Transactions");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Transactions",
                newName: "AccountId");

            migrationBuilder.RenameColumn(
                name: "PaymentType",
                table: "Transactions",
                newName: "Side");

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_AccountId",
                table: "Transactions",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Accounts_AccountId",
                table: "Transactions",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
