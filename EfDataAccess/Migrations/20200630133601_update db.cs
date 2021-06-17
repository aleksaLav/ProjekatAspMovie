using Microsoft.EntityFrameworkCore.Migrations;

namespace EfDataAccess.Migrations
{
    public partial class updatedb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movie_Director_DirectorId",
                table: "Movie");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieActor_Movie_MovieId",
                table: "MovieActor");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieGenre_Movie_MovieId",
                table: "MovieGenre");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieReservation_Movie_MovieId",
                table: "MovieReservation");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieReservation_Users_UserId",
                table: "MovieReservation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieReservation",
                table: "MovieReservation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Movie",
                table: "Movie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Director",
                table: "Director");

            migrationBuilder.RenameTable(
                name: "MovieReservation",
                newName: "MovieReservations");

            migrationBuilder.RenameTable(
                name: "Movie",
                newName: "Movies");

            migrationBuilder.RenameTable(
                name: "Director",
                newName: "Directors");

            migrationBuilder.RenameColumn(
                name: "isActive",
                table: "Users",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "isActive",
                table: "Genres",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "isActive",
                table: "Actors",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "isActive",
                table: "MovieReservations",
                newName: "IsActive");

            migrationBuilder.RenameIndex(
                name: "IX_MovieReservation_UserId",
                table: "MovieReservations",
                newName: "IX_MovieReservations_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_MovieReservation_MovieId",
                table: "MovieReservations",
                newName: "IX_MovieReservations_MovieId");

            migrationBuilder.RenameColumn(
                name: "isActive",
                table: "Movies",
                newName: "IsActive");

            migrationBuilder.RenameIndex(
                name: "IX_Movie_DirectorId",
                table: "Movies",
                newName: "IX_Movies_DirectorId");

            migrationBuilder.RenameColumn(
                name: "isActive",
                table: "Directors",
                newName: "IsActive");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Directors",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Directors",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieReservations",
                table: "MovieReservations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Movies",
                table: "Movies",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Directors",
                table: "Directors",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieActor_Movies_MovieId",
                table: "MovieActor",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieGenre_Movies_MovieId",
                table: "MovieGenre",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieReservations_Movies_MovieId",
                table: "MovieReservations",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieReservations_Users_UserId",
                table: "MovieReservations",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Directors_DirectorId",
                table: "Movies",
                column: "DirectorId",
                principalTable: "Directors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieActor_Movies_MovieId",
                table: "MovieActor");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieGenre_Movies_MovieId",
                table: "MovieGenre");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieReservations_Movies_MovieId",
                table: "MovieReservations");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieReservations_Users_UserId",
                table: "MovieReservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Directors_DirectorId",
                table: "Movies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Movies",
                table: "Movies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieReservations",
                table: "MovieReservations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Directors",
                table: "Directors");

            migrationBuilder.RenameTable(
                name: "Movies",
                newName: "Movie");

            migrationBuilder.RenameTable(
                name: "MovieReservations",
                newName: "MovieReservation");

            migrationBuilder.RenameTable(
                name: "Directors",
                newName: "Director");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Users",
                newName: "isActive");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Genres",
                newName: "isActive");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Actors",
                newName: "isActive");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Movie",
                newName: "isActive");

            migrationBuilder.RenameIndex(
                name: "IX_Movies_DirectorId",
                table: "Movie",
                newName: "IX_Movie_DirectorId");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "MovieReservation",
                newName: "isActive");

            migrationBuilder.RenameIndex(
                name: "IX_MovieReservations_UserId",
                table: "MovieReservation",
                newName: "IX_MovieReservation_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_MovieReservations_MovieId",
                table: "MovieReservation",
                newName: "IX_MovieReservation_MovieId");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Director",
                newName: "isActive");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Director",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Director",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Movie",
                table: "Movie",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieReservation",
                table: "MovieReservation",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Director",
                table: "Director",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_Director_DirectorId",
                table: "Movie",
                column: "DirectorId",
                principalTable: "Director",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieActor_Movie_MovieId",
                table: "MovieActor",
                column: "MovieId",
                principalTable: "Movie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieGenre_Movie_MovieId",
                table: "MovieGenre",
                column: "MovieId",
                principalTable: "Movie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieReservation_Movie_MovieId",
                table: "MovieReservation",
                column: "MovieId",
                principalTable: "Movie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieReservation_Users_UserId",
                table: "MovieReservation",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
