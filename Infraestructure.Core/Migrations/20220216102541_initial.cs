﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infraestructure.Core.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Library");

            migrationBuilder.EnsureSchema(
                name: "Master");

            migrationBuilder.EnsureSchema(
                name: "Security");

            migrationBuilder.CreateTable(
                name: "Editorial",
                schema: "Library",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    Direction = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Editorial", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeBook",
                schema: "Library",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeBook = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeBook", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeStateEntity",
                schema: "Master",
                columns: table => new
                {
                    IdTypeState = table.Column<int>(nullable: false),
                    TypeState = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeStateEntity", x => x.IdTypeState);
                });

            migrationBuilder.CreateTable(
                name: "Rol",
                schema: "Security",
                columns: table => new
                {
                    IdRol = table.Column<int>(nullable: false),
                    Rol = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol", x => x.IdRol);
                });

            migrationBuilder.CreateTable(
                name: "TypePermission",
                schema: "Security",
                columns: table => new
                {
                    IdTypePermission = table.Column<int>(nullable: false),
                    TypePermission = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypePermission", x => x.IdTypePermission);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "Security",
                columns: table => new
                {
                    IdUser = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    LastName = table.Column<string>(maxLength: 100, nullable: false),
                    Email = table.Column<string>(maxLength: 200, nullable: false),
                    Password = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.IdUser);
                });

            migrationBuilder.CreateTable(
                name: "State",
                schema: "Master",
                columns: table => new
                {
                    IdState = table.Column<int>(nullable: false),
                    State = table.Column<string>(nullable: true),
                    IdTypeState = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State", x => x.IdState);
                    table.ForeignKey(
                        name: "FK_State_TypeStateEntity_IdTypeState",
                        column: x => x.IdTypeState,
                        principalSchema: "Master",
                        principalTable: "TypeStateEntity",
                        principalColumn: "IdTypeState",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Permission",
                schema: "Security",
                columns: table => new
                {
                    IdPermission = table.Column<int>(nullable: false),
                    Permission = table.Column<string>(maxLength: 100, nullable: true),
                    Description = table.Column<string>(maxLength: 150, nullable: true),
                    IdTypePermission = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission", x => x.IdPermission);
                    table.ForeignKey(
                        name: "FK_Permission_TypePermission_IdTypePermission",
                        column: x => x.IdTypePermission,
                        principalSchema: "Security",
                        principalTable: "TypePermission",
                        principalColumn: "IdTypePermission",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RolUser",
                schema: "Security",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdRol = table.Column<int>(nullable: false),
                    IdUser = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RolUser_Rol_IdRol",
                        column: x => x.IdRol,
                        principalSchema: "Security",
                        principalTable: "Rol",
                        principalColumn: "IdRol",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolUser_User_IdUser",
                        column: x => x.IdUser,
                        principalSchema: "Security",
                        principalTable: "User",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Book",
                schema: "Library",
                columns: table => new
                {
                    IdBook = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatePreRealease = table.Column<DateTime>(nullable: false),
                    IdTypeBook = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    AuthorName = table.Column<string>(maxLength: 100, nullable: true),
                    DateRelease = table.Column<DateTime>(nullable: true),
                    Description = table.Column<string>(maxLength: 300, nullable: true),
                    IdState = table.Column<int>(nullable: false),
                    IdEditorial = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.IdBook);
                    table.ForeignKey(
                        name: "FK_Book_Editorial_IdEditorial",
                        column: x => x.IdEditorial,
                        principalSchema: "Library",
                        principalTable: "Editorial",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Book_State_IdState",
                        column: x => x.IdState,
                        principalSchema: "Master",
                        principalTable: "State",
                        principalColumn: "IdState",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Book_TypeBook_IdTypeBook",
                        column: x => x.IdTypeBook,
                        principalSchema: "Library",
                        principalTable: "TypeBook",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RolesPermissions",
                schema: "Security",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdRol = table.Column<int>(nullable: false),
                    IdPermission = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolesPermissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RolesPermissions_Permission_IdPermission",
                        column: x => x.IdPermission,
                        principalSchema: "Security",
                        principalTable: "Permission",
                        principalColumn: "IdPermission",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolesPermissions_Rol_IdRol",
                        column: x => x.IdRol,
                        principalSchema: "Security",
                        principalTable: "Rol",
                        principalColumn: "IdRol",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Book_IdEditorial",
                schema: "Library",
                table: "Book",
                column: "IdEditorial");

            migrationBuilder.CreateIndex(
                name: "IX_Book_IdState",
                schema: "Library",
                table: "Book",
                column: "IdState");

            migrationBuilder.CreateIndex(
                name: "IX_Book_IdTypeBook",
                schema: "Library",
                table: "Book",
                column: "IdTypeBook");

            migrationBuilder.CreateIndex(
                name: "IX_State_IdTypeState",
                schema: "Master",
                table: "State",
                column: "IdTypeState");

            migrationBuilder.CreateIndex(
                name: "IX_Permission_IdTypePermission",
                schema: "Security",
                table: "Permission",
                column: "IdTypePermission");

            migrationBuilder.CreateIndex(
                name: "IX_RolesPermissions_IdPermission",
                schema: "Security",
                table: "RolesPermissions",
                column: "IdPermission");

            migrationBuilder.CreateIndex(
                name: "IX_RolesPermissions_IdRol",
                schema: "Security",
                table: "RolesPermissions",
                column: "IdRol");

            migrationBuilder.CreateIndex(
                name: "IX_RolUser_IdRol",
                schema: "Security",
                table: "RolUser",
                column: "IdRol");

            migrationBuilder.CreateIndex(
                name: "IX_RolUser_IdUser",
                schema: "Security",
                table: "RolUser",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_User_Email",
                schema: "Security",
                table: "User",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Book",
                schema: "Library");

            migrationBuilder.DropTable(
                name: "RolesPermissions",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "RolUser",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "Editorial",
                schema: "Library");

            migrationBuilder.DropTable(
                name: "State",
                schema: "Master");

            migrationBuilder.DropTable(
                name: "TypeBook",
                schema: "Library");

            migrationBuilder.DropTable(
                name: "Permission",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "Rol",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "User",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "TypeStateEntity",
                schema: "Master");

            migrationBuilder.DropTable(
                name: "TypePermission",
                schema: "Security");
        }
    }
}
