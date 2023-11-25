using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace netlectureAPI.Migrations
{
    /// <inheritdoc />
    public partial class seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("265f013c-5290-443d-b7a5-9ed7e1df53d3"), "Miguel de Cervantes" },
                    { new Guid("37c40cbd-0930-4880-a877-d9d3b69b3d5d"), "J.K Rowling" },
                    { new Guid("8c6c2911-99fc-4421-8ce8-9c048974c0c1"), "Stephenie Meyer" },
                    { new Guid("cb292479-4e3b-4588-815e-85fb88ded193"), "Suzanne Collins" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("7b0b86f6-16b7-4402-b0e7-343707c32e0f"), "Novela" },
                    { new Guid("a4ac9933-799b-4825-96ae-0d92770b8166"), "Fantasía" },
                    { new Guid("b46833ff-bf55-4ef1-80de-cdc2f9885d5b"), "Terror" },
                    { new Guid("d43252a3-7314-4b35-aa05-d626ae7a7724"), "Aventura" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "GenreId", "Grade", "ImageURL", "Qualification", "Summary", "Title" },
                values: new object[,]
                {
                    { new Guid("4c926d7a-0bad-4287-9a0b-c7a7dbb9fc15"), new Guid("8c6c2911-99fc-4421-8ce8-9c048974c0c1"), new Guid("7b0b86f6-16b7-4402-b0e7-343707c32e0f"), "Segundo", null, 4L, "", "Crepusculo" },
                    { new Guid("722adda9-a965-4727-9fcc-5d1a39437934"), new Guid("cb292479-4e3b-4588-815e-85fb88ded193"), new Guid("d43252a3-7314-4b35-aa05-d626ae7a7724"), "Tercero", null, 5L, "", "Los Juegos del Hambre" },
                    { new Guid("86a7305b-b2b6-4e76-85b5-bbbf32317f6f"), new Guid("265f013c-5290-443d-b7a5-9ed7e1df53d3"), new Guid("7b0b86f6-16b7-4402-b0e7-343707c32e0f"), "Primero", null, 3L, "", "Don Quijote de la Mancha" },
                    { new Guid("d4edb466-9a02-42e0-a7c0-69d5b09d6d8c"), new Guid("37c40cbd-0930-4880-a877-d9d3b69b3d5d"), new Guid("a4ac9933-799b-4825-96ae-0d92770b8166"), "Primero", null, 5L, "", "Harry Potter y La Piedra Filosofal" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("4c926d7a-0bad-4287-9a0b-c7a7dbb9fc15"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("722adda9-a965-4727-9fcc-5d1a39437934"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("86a7305b-b2b6-4e76-85b5-bbbf32317f6f"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("d4edb466-9a02-42e0-a7c0-69d5b09d6d8c"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("b46833ff-bf55-4ef1-80de-cdc2f9885d5b"));

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("265f013c-5290-443d-b7a5-9ed7e1df53d3"));

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("37c40cbd-0930-4880-a877-d9d3b69b3d5d"));

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("8c6c2911-99fc-4421-8ce8-9c048974c0c1"));

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("cb292479-4e3b-4588-815e-85fb88ded193"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("7b0b86f6-16b7-4402-b0e7-343707c32e0f"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("a4ac9933-799b-4825-96ae-0d92770b8166"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("d43252a3-7314-4b35-aa05-d626ae7a7724"));
        }
    }
}
