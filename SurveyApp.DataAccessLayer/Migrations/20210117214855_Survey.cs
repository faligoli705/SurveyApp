using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SurveyApp.DataAccessLayer.Migrations
{
    public partial class Survey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                });

            migrationBuilder.CreateTable(
                name: "SurveyAnswers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: true),
                    OfferedAnswerId = table.Column<int>(type: "int", nullable: true),
                    OtherText = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyAnswers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SurveyQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SurveyId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: true),
                    UsersId = table.Column<int>(type: "int", nullable: true),
                    QuestionText = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    QuestionExpiresOnDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PublishedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SurveyAnswerId = table.Column<int>(type: "int", nullable: true),
                    SurveyQuestionsAnswerId = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SurveyQuestions_SurveyAnswers_SurveyAnswerId",
                        column: x => x.SurveyAnswerId,
                        principalTable: "SurveyAnswers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoles_SurveyQuestions_RoleId",
                        column: x => x.RoleId,
                        principalTable: "SurveyQuestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SurveyQuestionsAnswers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: true),
                    OfferedAnswerId = table.Column<int>(type: "int", nullable: true),
                    SurveyId = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyQuestionsAnswers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SurveyQuestionsAnswers_SurveyQuestions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "SurveyQuestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    FName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    LastLoginDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    SurveyAnswerId = table.Column<int>(type: "int", nullable: true),
                    SurveyQuestionsAnswerId = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_SurveyAnswers_SurveyAnswerId",
                        column: x => x.SurveyAnswerId,
                        principalTable: "SurveyAnswers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_SurveyQuestionsAnswers_SurveyQuestionsAnswerId",
                        column: x => x.SurveyQuestionsAnswerId,
                        principalTable: "SurveyQuestionsAnswers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OfferedAnswers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OfferedAnswerText = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    SurveyQuestionsAnswerId = table.Column<int>(type: "int", nullable: false),
                    SurveyAnswerId = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfferedAnswers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OfferedAnswers_SurveyAnswers_SurveyAnswerId",
                        column: x => x.SurveyAnswerId,
                        principalTable: "SurveyAnswers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OfferedAnswers_SurveyQuestionsAnswers_SurveyQuestionsAnswerId",
                        column: x => x.SurveyQuestionsAnswerId,
                        principalTable: "SurveyQuestionsAnswers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SurveyCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Pid = table.Column<int>(type: "int", nullable: true),
                    NameCategory = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SubNameCategory = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SurveyQuestionsAnswerId = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SurveyCategories_SurveyQuestionsAnswers_SurveyQuestionsAnswerId",
                        column: x => x.SurveyQuestionsAnswerId,
                        principalTable: "SurveyQuestionsAnswers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Surveys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsOpen = table.Column<bool>(type: "bit", nullable: false),
                    SurveyAnswerId = table.Column<int>(type: "int", nullable: true),
                    SurveyId = table.Column<int>(type: "int", nullable: true),
                    SurveyQuestionsAnswerId = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Surveys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Surveys_SurveyAnswers_SurveyAnswerId",
                        column: x => x.SurveyAnswerId,
                        principalTable: "SurveyAnswers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Surveys_SurveyQuestions_SurveyId",
                        column: x => x.SurveyId,
                        principalTable: "SurveyQuestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Surveys_SurveyQuestionsAnswers_SurveyQuestionsAnswerId",
                        column: x => x.SurveyQuestionsAnswerId,
                        principalTable: "SurveyQuestionsAnswers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoles_RoleId",
                table: "AspNetRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_SurveyAnswerId",
                table: "AspNetUsers",
                column: "SurveyAnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_SurveyQuestionsAnswerId",
                table: "AspNetUsers",
                column: "SurveyQuestionsAnswerId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_OfferedAnswers_SurveyAnswerId",
                table: "OfferedAnswers",
                column: "SurveyAnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_OfferedAnswers_SurveyQuestionsAnswerId",
                table: "OfferedAnswers",
                column: "SurveyQuestionsAnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyAnswers_OfferedAnswerId",
                table: "SurveyAnswers",
                column: "OfferedAnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyAnswers_QuestionId",
                table: "SurveyAnswers",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyAnswers_UserId",
                table: "SurveyAnswers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyCategories_SurveyQuestionsAnswerId",
                table: "SurveyCategories",
                column: "SurveyQuestionsAnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyQuestions_SurveyAnswerId",
                table: "SurveyQuestions",
                column: "SurveyAnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyQuestions_SurveyId",
                table: "SurveyQuestions",
                column: "SurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyQuestions_SurveyQuestionsAnswerId",
                table: "SurveyQuestions",
                column: "SurveyQuestionsAnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyQuestions_UsersId",
                table: "SurveyQuestions",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyQuestionsAnswers_OfferedAnswerId",
                table: "SurveyQuestionsAnswers",
                column: "OfferedAnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyQuestionsAnswers_QuestionId",
                table: "SurveyQuestionsAnswers",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyQuestionsAnswers_SurveyId",
                table: "SurveyQuestionsAnswers",
                column: "SurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyQuestionsAnswers_UserId",
                table: "SurveyQuestionsAnswers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Surveys_SurveyAnswerId",
                table: "Surveys",
                column: "SurveyAnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_Surveys_SurveyId",
                table: "Surveys",
                column: "SurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_Surveys_SurveyQuestionsAnswerId",
                table: "Surveys",
                column: "SurveyQuestionsAnswerId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SurveyAnswers_AspNetUsers_UserId",
                table: "SurveyAnswers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SurveyAnswers_OfferedAnswers_OfferedAnswerId",
                table: "SurveyAnswers",
                column: "OfferedAnswerId",
                principalTable: "OfferedAnswers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SurveyAnswers_SurveyQuestions_QuestionId",
                table: "SurveyAnswers",
                column: "QuestionId",
                principalTable: "SurveyQuestions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SurveyQuestions_AspNetUsers_UsersId",
                table: "SurveyQuestions",
                column: "UsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SurveyQuestions_SurveyQuestionsAnswers_SurveyQuestionsAnswerId",
                table: "SurveyQuestions",
                column: "SurveyQuestionsAnswerId",
                principalTable: "SurveyQuestionsAnswers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SurveyQuestions_Surveys_SurveyId",
                table: "SurveyQuestions",
                column: "SurveyId",
                principalTable: "Surveys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SurveyQuestionsAnswers_AspNetUsers_UserId",
                table: "SurveyQuestionsAnswers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SurveyQuestionsAnswers_OfferedAnswers_OfferedAnswerId",
                table: "SurveyQuestionsAnswers",
                column: "OfferedAnswerId",
                principalTable: "OfferedAnswers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SurveyQuestionsAnswers_Surveys_SurveyId",
                table: "SurveyQuestionsAnswers",
                column: "SurveyId",
                principalTable: "Surveys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SurveyAnswers_SurveyQuestions_QuestionId",
                table: "SurveyAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_SurveyQuestionsAnswers_SurveyQuestions_QuestionId",
                table: "SurveyQuestionsAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_Surveys_SurveyQuestions_SurveyId",
                table: "Surveys");

            migrationBuilder.DropForeignKey(
                name: "FK_SurveyAnswers_AspNetUsers_UserId",
                table: "SurveyAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_SurveyQuestionsAnswers_AspNetUsers_UserId",
                table: "SurveyQuestionsAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_OfferedAnswers_SurveyAnswers_SurveyAnswerId",
                table: "OfferedAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_Surveys_SurveyAnswers_SurveyAnswerId",
                table: "Surveys");

            migrationBuilder.DropForeignKey(
                name: "FK_OfferedAnswers_SurveyQuestionsAnswers_SurveyQuestionsAnswerId",
                table: "OfferedAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_Surveys_SurveyQuestionsAnswers_SurveyQuestionsAnswerId",
                table: "Surveys");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "SurveyCategories");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "SurveyQuestions");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "SurveyAnswers");

            migrationBuilder.DropTable(
                name: "SurveyQuestionsAnswers");

            migrationBuilder.DropTable(
                name: "OfferedAnswers");

            migrationBuilder.DropTable(
                name: "Surveys");
        }
    }
}
