using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class add_students : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
               name: "Stuednts",
               columns: table => new
               {
                   Id = table.Column<int>(type: "int", nullable: false)
                       .Annotation("SqlServer:Identity", "1, 1"),
                   Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                   Gender = table.Column<int>(type: "int", nullable: false),
                   Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                   Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                   Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                   PicturePath = table.Column<string>(type: "nvarchar(max)", nullable: false)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_Stuednts", x => x.Id);
               });

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
           
            migrationBuilder.DropTable(
                name: "Stuednts");
           
        }
    }
}
