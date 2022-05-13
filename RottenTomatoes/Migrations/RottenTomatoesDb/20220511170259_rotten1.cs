using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RottenTomatoes.Migrations.RottenTomatoesDb
{
    public partial class rotten1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Directors",
                columns: table => new
                {
                    DirectorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DirectorName = table.Column<string>(fixedLength: true, maxLength: 100, nullable: true),
                    DirectorSurname = table.Column<string>(fixedLength: true, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Directors", x => x.DirectorId);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    GenreId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenreName = table.Column<string>(fixedLength: true, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.GenreId);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    MovieId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieName = table.Column<string>(fixedLength: true, maxLength: 100, nullable: true),
                    Time = table.Column<TimeSpan>(type: "time", nullable: false),
                    BannerUrl = table.Column<string>(fixedLength: true, maxLength: 100, nullable: true),
                    Year = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.MovieId);
                });

            migrationBuilder.CreateTable(
                name: "Tomatoes",
                columns: table => new
                {
                    TomatoeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TomatoeName = table.Column<string>(fixedLength: true, maxLength: 100, nullable: true),
                    Password = table.Column<string>(fixedLength: true, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tomatoes", x => x.TomatoeId);
                });

            migrationBuilder.CreateTable(
                name: "DirectorsMovies",
                columns: table => new
                {
                    DMId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DirectorId = table.Column<int>(nullable: false),
                    MovieId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DirectorsMovies", x => x.DMId);
                    table.ForeignKey(
                        name: "FK_DirectorsMovies_Director",
                        column: x => x.DirectorId,
                        principalTable: "Directors",
                        principalColumn: "DirectorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DirectorsMovies_Movie",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GenresMovies",
                columns: table => new
                {
                    GMId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenreId = table.Column<int>(nullable: false),
                    MovieId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenresMovies", x => x.GMId);
                    table.ForeignKey(
                        name: "FK_GenresMovies_Genre",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "GenreId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenresMovies_Movie",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TomatoeId = table.Column<int>(nullable: false),
                    MovieId = table.Column<int>(nullable: false),
                    Text = table.Column<string>(fixedLength: true, maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_Comment_Movie",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comment_Tomatoe",
                        column: x => x.TomatoeId,
                        principalTable: "Tomatoes",
                        principalColumn: "TomatoeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_MovieId",
                table: "Comments",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_TomatoeId",
                table: "Comments",
                column: "TomatoeId");

            migrationBuilder.CreateIndex(
                name: "IX_DirectorsMovies_DirectorId",
                table: "DirectorsMovies",
                column: "DirectorId");

            migrationBuilder.CreateIndex(
                name: "IX_DirectorsMovies_MovieId",
                table: "DirectorsMovies",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_GenresMovies_GenreId",
                table: "GenresMovies",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_GenresMovies_MovieId",
                table: "GenresMovies",
                column: "MovieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "DirectorsMovies");

            migrationBuilder.DropTable(
                name: "GenresMovies");

            migrationBuilder.DropTable(
                name: "Tomatoes");

            migrationBuilder.DropTable(
                name: "Directors");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
