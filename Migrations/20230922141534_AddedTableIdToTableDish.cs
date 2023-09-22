﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantManagement.Migrations
{
    /// <inheritdoc />
    public partial class AddedTableIdToTableDish : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TableDishes_Tables_TableId",
                table: "TableDishes");

            migrationBuilder.AlterColumn<int>(
                name: "TableId",
                table: "TableDishes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TableDishes_Tables_TableId",
                table: "TableDishes",
                column: "TableId",
                principalTable: "Tables",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TableDishes_Tables_TableId",
                table: "TableDishes");

            migrationBuilder.AlterColumn<int>(
                name: "TableId",
                table: "TableDishes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_TableDishes_Tables_TableId",
                table: "TableDishes",
                column: "TableId",
                principalTable: "Tables",
                principalColumn: "Id");
        }
    }
}
