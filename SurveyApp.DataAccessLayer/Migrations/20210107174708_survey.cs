using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SurveyApp.DataAccessLayer.Migrations
{
    public partial class survey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    RoleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RolesDtos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolesDtos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionText = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    QuestionExpiresOnDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PublishedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SurveyAnswerId = table.Column<int>(type: "int", nullable: true),
                    SurveyQuestionsAnswerId = table.Column<int>(type: "int", nullable: true),
                    SurveyQuestionsId = table.Column<int>(type: "int", nullable: true),
                    UsersId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SurveyAnswers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SurveyId = table.Column<int>(type: "int", nullable: true),
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
                    table.ForeignKey(
                        name: "FK_SurveyAnswers_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SurveyQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SurveyId = table.Column<int>(type: "int", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SurveyQuestions_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SurveyCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NameCategory = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SubNameCategory = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SurveyQuestionsId = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SurveyCategories_SurveyQuestions_SurveyQuestionsId",
                        column: x => x.SurveyQuestionsId,
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
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SurveyId = table.Column<int>(type: "int", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    OfferedAnswerId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyQuestionsAnswers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SurveyQuestionsAnswers_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    EmailUser = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserPasswordHash = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    LastLoginDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    SurveyAnswerId = table.Column<int>(type: "int", nullable: true),
                    SurveyQuestionsAnswerId = table.Column<int>(type: "int", nullable: true),
                    SurveyQuestionsId = table.Column<int>(type: "int", nullable: true),
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
                        name: "FK_AspNetUsers_SurveyQuestions_SurveyQuestionsId",
                        column: x => x.SurveyQuestionsId,
                        principalTable: "SurveyQuestions",
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
                    SurveyAnswerId = table.Column<int>(type: "int", nullable: true),
                    SurveyQuestionsAnswerId = table.Column<int>(type: "int", nullable: true),
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
                name: "Surveys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsOpen = table.Column<bool>(type: "bit", nullable: false),
                    SurveyAnswerId = table.Column<int>(type: "int", nullable: true),
                    SurveyQuestionsAnswerId = table.Column<int>(type: "int", nullable: true),
                    SurveyQuestionsId = table.Column<int>(type: "int", nullable: true),
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
                        name: "FK_Surveys_SurveyQuestions_SurveyQuestionsId",
                        column: x => x.SurveyQuestionsId,
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

            migrationBuilder.CreateTable(
                name: "SurveyAnswerDtos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SurveyId = table.Column<int>(type: "int", nullable: true),
                    QuestionId = table.Column<int>(type: "int", nullable: true),
                    OfferedAnswerId = table.Column<int>(type: "int", nullable: true),
                    OtherText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsersId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    QuestionsId = table.Column<int>(type: "int", nullable: true),
                    OfferedAnswersId = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyAnswerDtos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SurveyQuestionsAnswerDtos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SurveyId = table.Column<int>(type: "int", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    OfferedAnswerId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    QuestionsId = table.Column<int>(type: "int", nullable: true),
                    OfferedAnswersId = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyQuestionsAnswerDtos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SurveyQuestionsDtos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SurveyId = table.Column<int>(type: "int", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    QuestionsId = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyQuestionsDtos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SurveyCategoryDtos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NameCategory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubNameCategory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SurveyQuestionsDtoId = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyCategoryDtos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SurveyCategoryDtos_SurveyQuestionsDtos_SurveyQuestionsDtoId",
                        column: x => x.SurveyQuestionsDtoId,
                        principalTable: "SurveyQuestionsDtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SurveyDtos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsOpen = table.Column<bool>(type: "bit", nullable: false),
                    SurveyAnswerDtoId = table.Column<int>(type: "int", nullable: true),
                    SurveyQuestionsAnswerDtoId = table.Column<int>(type: "int", nullable: true),
                    SurveyQuestionsDtoId = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyDtos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SurveyDtos_SurveyAnswerDtos_SurveyAnswerDtoId",
                        column: x => x.SurveyAnswerDtoId,
                        principalTable: "SurveyAnswerDtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SurveyDtos_SurveyQuestionsAnswerDtos_SurveyQuestionsAnswerDtoId",
                        column: x => x.SurveyQuestionsAnswerDtoId,
                        principalTable: "SurveyQuestionsAnswerDtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SurveyDtos_SurveyQuestionsDtos_SurveyQuestionsDtoId",
                        column: x => x.SurveyQuestionsDtoId,
                        principalTable: "SurveyQuestionsDtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UsersDtos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    EmailUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserPasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastLoginDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    RolesId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SurveyAnswerDtoId = table.Column<int>(type: "int", nullable: true),
                    SurveyQuestionsAnswerDtoId = table.Column<int>(type: "int", nullable: true),
                    SurveyQuestionsDtoId = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersDtos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsersDtos_RolesDtos_RolesId",
                        column: x => x.RolesId,
                        principalTable: "RolesDtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsersDtos_SurveyAnswerDtos_SurveyAnswerDtoId",
                        column: x => x.SurveyAnswerDtoId,
                        principalTable: "SurveyAnswerDtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsersDtos_SurveyQuestionsAnswerDtos_SurveyQuestionsAnswerDtoId",
                        column: x => x.SurveyQuestionsAnswerDtoId,
                        principalTable: "SurveyQuestionsAnswerDtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsersDtos_SurveyQuestionsDtos_SurveyQuestionsDtoId",
                        column: x => x.SurveyQuestionsDtoId,
                        principalTable: "SurveyQuestionsDtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OfferedAnswersDtos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OfferedAnswerText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SurveyAnswerDtoId = table.Column<int>(type: "int", nullable: true),
                    SurveyQuestionsAnswerDtoId = table.Column<int>(type: "int", nullable: true),
                    UsersDtoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfferedAnswersDtos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OfferedAnswersDtos_SurveyAnswerDtos_SurveyAnswerDtoId",
                        column: x => x.SurveyAnswerDtoId,
                        principalTable: "SurveyAnswerDtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OfferedAnswersDtos_SurveyQuestionsAnswerDtos_SurveyQuestionsAnswerDtoId",
                        column: x => x.SurveyQuestionsAnswerDtoId,
                        principalTable: "SurveyQuestionsAnswerDtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OfferedAnswersDtos_UsersDtos_UsersDtoId",
                        column: x => x.UsersDtoId,
                        principalTable: "UsersDtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QuestionsDtos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuestionExpiresOnDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PublishedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SurveyAnswerDtoId = table.Column<int>(type: "int", nullable: true),
                    SurveyQuestionsAnswerDtoId = table.Column<int>(type: "int", nullable: true),
                    SurveyQuestionsDtoId = table.Column<int>(type: "int", nullable: true),
                    UsersDtoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionsDtos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionsDtos_SurveyAnswerDtos_SurveyAnswerDtoId",
                        column: x => x.SurveyAnswerDtoId,
                        principalTable: "SurveyAnswerDtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QuestionsDtos_SurveyQuestionsAnswerDtos_SurveyQuestionsAnswerDtoId",
                        column: x => x.SurveyQuestionsAnswerDtoId,
                        principalTable: "SurveyQuestionsAnswerDtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QuestionsDtos_SurveyQuestionsDtos_SurveyQuestionsDtoId",
                        column: x => x.SurveyQuestionsDtoId,
                        principalTable: "SurveyQuestionsDtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QuestionsDtos_UsersDtos_UsersDtoId",
                        column: x => x.UsersDtoId,
                        principalTable: "UsersDtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
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
                name: "IX_AspNetUsers_SurveyQuestionsId",
                table: "AspNetUsers",
                column: "SurveyQuestionsId");

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
                name: "IX_OfferedAnswersDtos_SurveyAnswerDtoId",
                table: "OfferedAnswersDtos",
                column: "SurveyAnswerDtoId");

            migrationBuilder.CreateIndex(
                name: "IX_OfferedAnswersDtos_SurveyQuestionsAnswerDtoId",
                table: "OfferedAnswersDtos",
                column: "SurveyQuestionsAnswerDtoId");

            migrationBuilder.CreateIndex(
                name: "IX_OfferedAnswersDtos_UsersDtoId",
                table: "OfferedAnswersDtos",
                column: "UsersDtoId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_SurveyAnswerId",
                table: "Questions",
                column: "SurveyAnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_SurveyQuestionsAnswerId",
                table: "Questions",
                column: "SurveyQuestionsAnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_SurveyQuestionsId",
                table: "Questions",
                column: "SurveyQuestionsId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_UsersId",
                table: "Questions",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionsDtos_SurveyAnswerDtoId",
                table: "QuestionsDtos",
                column: "SurveyAnswerDtoId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionsDtos_SurveyQuestionsAnswerDtoId",
                table: "QuestionsDtos",
                column: "SurveyQuestionsAnswerDtoId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionsDtos_SurveyQuestionsDtoId",
                table: "QuestionsDtos",
                column: "SurveyQuestionsDtoId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionsDtos_UsersDtoId",
                table: "QuestionsDtos",
                column: "UsersDtoId");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyAnswerDtos_OfferedAnswersId",
                table: "SurveyAnswerDtos",
                column: "OfferedAnswersId");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyAnswerDtos_QuestionsId",
                table: "SurveyAnswerDtos",
                column: "QuestionsId");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyAnswerDtos_SurveyId",
                table: "SurveyAnswerDtos",
                column: "SurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyAnswerDtos_UsersId",
                table: "SurveyAnswerDtos",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyAnswers_OfferedAnswerId",
                table: "SurveyAnswers",
                column: "OfferedAnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyAnswers_QuestionId",
                table: "SurveyAnswers",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyAnswers_SurveyId",
                table: "SurveyAnswers",
                column: "SurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyAnswers_UserId",
                table: "SurveyAnswers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyCategories_SurveyQuestionsId",
                table: "SurveyCategories",
                column: "SurveyQuestionsId");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyCategoryDtos_SurveyQuestionsDtoId",
                table: "SurveyCategoryDtos",
                column: "SurveyQuestionsDtoId");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyDtos_SurveyAnswerDtoId",
                table: "SurveyDtos",
                column: "SurveyAnswerDtoId");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyDtos_SurveyQuestionsAnswerDtoId",
                table: "SurveyDtos",
                column: "SurveyQuestionsAnswerDtoId");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyDtos_SurveyQuestionsDtoId",
                table: "SurveyDtos",
                column: "SurveyQuestionsDtoId");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyQuestions_CategoryId",
                table: "SurveyQuestions",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyQuestions_QuestionId",
                table: "SurveyQuestions",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyQuestions_SurveyId",
                table: "SurveyQuestions",
                column: "SurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyQuestions_UserId",
                table: "SurveyQuestions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyQuestionsAnswerDtos_OfferedAnswersId",
                table: "SurveyQuestionsAnswerDtos",
                column: "OfferedAnswersId");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyQuestionsAnswerDtos_QuestionsId",
                table: "SurveyQuestionsAnswerDtos",
                column: "QuestionsId");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyQuestionsAnswerDtos_SurveyId",
                table: "SurveyQuestionsAnswerDtos",
                column: "SurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyQuestionsAnswerDtos_UsersId",
                table: "SurveyQuestionsAnswerDtos",
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
                name: "IX_SurveyQuestionsDtos_CategoryId",
                table: "SurveyQuestionsDtos",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyQuestionsDtos_QuestionsId",
                table: "SurveyQuestionsDtos",
                column: "QuestionsId");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyQuestionsDtos_SurveyId",
                table: "SurveyQuestionsDtos",
                column: "SurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyQuestionsDtos_UsersId",
                table: "SurveyQuestionsDtos",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Surveys_SurveyAnswerId",
                table: "Surveys",
                column: "SurveyAnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_Surveys_SurveyQuestionsAnswerId",
                table: "Surveys",
                column: "SurveyQuestionsAnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_Surveys_SurveyQuestionsId",
                table: "Surveys",
                column: "SurveyQuestionsId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersDtos_RolesId",
                table: "UsersDtos",
                column: "RolesId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersDtos_SurveyAnswerDtoId",
                table: "UsersDtos",
                column: "SurveyAnswerDtoId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersDtos_SurveyQuestionsAnswerDtoId",
                table: "UsersDtos",
                column: "SurveyQuestionsAnswerDtoId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersDtos_SurveyQuestionsDtoId",
                table: "UsersDtos",
                column: "SurveyQuestionsDtoId");

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
                name: "FK_Questions_AspNetUsers_UsersId",
                table: "Questions",
                column: "UsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_SurveyAnswers_SurveyAnswerId",
                table: "Questions",
                column: "SurveyAnswerId",
                principalTable: "SurveyAnswers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_SurveyQuestions_SurveyQuestionsId",
                table: "Questions",
                column: "SurveyQuestionsId",
                principalTable: "SurveyQuestions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_SurveyQuestionsAnswers_SurveyQuestionsAnswerId",
                table: "Questions",
                column: "SurveyQuestionsAnswerId",
                principalTable: "SurveyQuestionsAnswers",
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
                name: "FK_SurveyAnswers_Surveys_SurveyId",
                table: "SurveyAnswers",
                column: "SurveyId",
                principalTable: "Surveys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SurveyQuestions_AspNetUsers_UserId",
                table: "SurveyQuestions",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SurveyQuestions_SurveyCategories_CategoryId",
                table: "SurveyQuestions",
                column: "CategoryId",
                principalTable: "SurveyCategories",
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

            migrationBuilder.AddForeignKey(
                name: "FK_SurveyAnswerDtos_OfferedAnswersDtos_OfferedAnswersId",
                table: "SurveyAnswerDtos",
                column: "OfferedAnswersId",
                principalTable: "OfferedAnswersDtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SurveyAnswerDtos_QuestionsDtos_QuestionsId",
                table: "SurveyAnswerDtos",
                column: "QuestionsId",
                principalTable: "QuestionsDtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SurveyAnswerDtos_SurveyDtos_SurveyId",
                table: "SurveyAnswerDtos",
                column: "SurveyId",
                principalTable: "SurveyDtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SurveyAnswerDtos_UsersDtos_UsersId",
                table: "SurveyAnswerDtos",
                column: "UsersId",
                principalTable: "UsersDtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SurveyQuestionsAnswerDtos_OfferedAnswersDtos_OfferedAnswersId",
                table: "SurveyQuestionsAnswerDtos",
                column: "OfferedAnswersId",
                principalTable: "OfferedAnswersDtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SurveyQuestionsAnswerDtos_QuestionsDtos_QuestionsId",
                table: "SurveyQuestionsAnswerDtos",
                column: "QuestionsId",
                principalTable: "QuestionsDtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SurveyQuestionsAnswerDtos_SurveyDtos_SurveyId",
                table: "SurveyQuestionsAnswerDtos",
                column: "SurveyId",
                principalTable: "SurveyDtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SurveyQuestionsAnswerDtos_UsersDtos_UsersId",
                table: "SurveyQuestionsAnswerDtos",
                column: "UsersId",
                principalTable: "UsersDtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SurveyQuestionsDtos_QuestionsDtos_QuestionsId",
                table: "SurveyQuestionsDtos",
                column: "QuestionsId",
                principalTable: "QuestionsDtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SurveyQuestionsDtos_SurveyCategoryDtos_CategoryId",
                table: "SurveyQuestionsDtos",
                column: "CategoryId",
                principalTable: "SurveyCategoryDtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SurveyQuestionsDtos_SurveyDtos_SurveyId",
                table: "SurveyQuestionsDtos",
                column: "SurveyId",
                principalTable: "SurveyDtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SurveyQuestionsDtos_UsersDtos_UsersId",
                table: "SurveyQuestionsDtos",
                column: "UsersId",
                principalTable: "UsersDtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_AspNetUsers_UsersId",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_SurveyAnswers_AspNetUsers_UserId",
                table: "SurveyAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_SurveyQuestions_AspNetUsers_UserId",
                table: "SurveyQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_SurveyQuestionsAnswers_AspNetUsers_UserId",
                table: "SurveyQuestionsAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_OfferedAnswers_SurveyAnswers_SurveyAnswerId",
                table: "OfferedAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_SurveyAnswers_SurveyAnswerId",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_Surveys_SurveyAnswers_SurveyAnswerId",
                table: "Surveys");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_SurveyQuestions_SurveyQuestionsId",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_SurveyCategories_SurveyQuestions_SurveyQuestionsId",
                table: "SurveyCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_Surveys_SurveyQuestions_SurveyQuestionsId",
                table: "Surveys");

            migrationBuilder.DropForeignKey(
                name: "FK_OfferedAnswers_SurveyQuestionsAnswers_SurveyQuestionsAnswerId",
                table: "OfferedAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_SurveyQuestionsAnswers_SurveyQuestionsAnswerId",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_Surveys_SurveyQuestionsAnswers_SurveyQuestionsAnswerId",
                table: "Surveys");

            migrationBuilder.DropForeignKey(
                name: "FK_OfferedAnswersDtos_SurveyAnswerDtos_SurveyAnswerDtoId",
                table: "OfferedAnswersDtos");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionsDtos_SurveyAnswerDtos_SurveyAnswerDtoId",
                table: "QuestionsDtos");

            migrationBuilder.DropForeignKey(
                name: "FK_SurveyDtos_SurveyAnswerDtos_SurveyAnswerDtoId",
                table: "SurveyDtos");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersDtos_SurveyAnswerDtos_SurveyAnswerDtoId",
                table: "UsersDtos");

            migrationBuilder.DropForeignKey(
                name: "FK_OfferedAnswersDtos_SurveyQuestionsAnswerDtos_SurveyQuestionsAnswerDtoId",
                table: "OfferedAnswersDtos");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionsDtos_SurveyQuestionsAnswerDtos_SurveyQuestionsAnswerDtoId",
                table: "QuestionsDtos");

            migrationBuilder.DropForeignKey(
                name: "FK_SurveyDtos_SurveyQuestionsAnswerDtos_SurveyQuestionsAnswerDtoId",
                table: "SurveyDtos");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersDtos_SurveyQuestionsAnswerDtos_SurveyQuestionsAnswerDtoId",
                table: "UsersDtos");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionsDtos_UsersDtos_UsersDtoId",
                table: "QuestionsDtos");

            migrationBuilder.DropForeignKey(
                name: "FK_SurveyQuestionsDtos_UsersDtos_UsersId",
                table: "SurveyQuestionsDtos");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionsDtos_SurveyQuestionsDtos_SurveyQuestionsDtoId",
                table: "QuestionsDtos");

            migrationBuilder.DropForeignKey(
                name: "FK_SurveyCategoryDtos_SurveyQuestionsDtos_SurveyQuestionsDtoId",
                table: "SurveyCategoryDtos");

            migrationBuilder.DropForeignKey(
                name: "FK_SurveyDtos_SurveyQuestionsDtos_SurveyQuestionsDtoId",
                table: "SurveyDtos");

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
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "SurveyAnswers");

            migrationBuilder.DropTable(
                name: "SurveyQuestions");

            migrationBuilder.DropTable(
                name: "SurveyCategories");

            migrationBuilder.DropTable(
                name: "SurveyQuestionsAnswers");

            migrationBuilder.DropTable(
                name: "OfferedAnswers");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Surveys");

            migrationBuilder.DropTable(
                name: "SurveyAnswerDtos");

            migrationBuilder.DropTable(
                name: "SurveyQuestionsAnswerDtos");

            migrationBuilder.DropTable(
                name: "OfferedAnswersDtos");

            migrationBuilder.DropTable(
                name: "UsersDtos");

            migrationBuilder.DropTable(
                name: "RolesDtos");

            migrationBuilder.DropTable(
                name: "SurveyQuestionsDtos");

            migrationBuilder.DropTable(
                name: "QuestionsDtos");

            migrationBuilder.DropTable(
                name: "SurveyCategoryDtos");

            migrationBuilder.DropTable(
                name: "SurveyDtos");
        }
    }
}
