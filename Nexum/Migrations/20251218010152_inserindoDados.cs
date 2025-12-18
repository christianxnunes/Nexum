using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Nexum.Migrations
{
    /// <inheritdoc />
    public partial class inserindoDados : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Disciplines_Teachers_TeacherId",
                table: "Disciplines");

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "LastName", "Name", "Phone" },
                values: new object[,]
                {
                    { new Guid("21dea7e0-0cff-46dd-83e5-6a57acf5b4fc"), "Smith", "Jane", "987-654-3210" },
                    { new Guid("631b3317-55c6-44fc-af6f-8e78d2102333"), "Doe", "John", "123-456-7890" },
                    { new Guid("c5fd24da-ce49-4c49-bde8-3918ebb84ab5"), "Nunes", "Alice", "555-555-5555" }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("6b77e151-c571-49eb-b5c7-73e5f0e13bea"), "Paulo" },
                    { new Guid("804e59ba-e3fc-483e-81a6-75ec5e4181b8"), "Luiz" },
                    { new Guid("f6ebe851-04d7-49cb-9ac1-e750b256da66"), "Marcos" }
                });

            migrationBuilder.InsertData(
                table: "Disciplines",
                columns: new[] { "Id", "Name", "TeacherId" },
                values: new object[,]
                {
                    { new Guid("914fb3f8-a293-452e-a660-f179693ae440"), "Libras", new Guid("6b77e151-c571-49eb-b5c7-73e5f0e13bea") },
                    { new Guid("bb65dac5-8c25-4dff-bd62-0e11cad12f92"), "Portugues", new Guid("6b77e151-c571-49eb-b5c7-73e5f0e13bea") },
                    { new Guid("de92fb63-f588-462c-90f3-92dc8e637f2e"), "Matemática", new Guid("f6ebe851-04d7-49cb-9ac1-e750b256da66") },
                    { new Guid("e237da4d-73eb-4e02-a633-956447bd3783"), "Ingles", new Guid("804e59ba-e3fc-483e-81a6-75ec5e4181b8") },
                    { new Guid("fe847335-286f-4a36-8516-6c0bb79551fb"), "Ciencias", new Guid("804e59ba-e3fc-483e-81a6-75ec5e4181b8") }
                });

            migrationBuilder.InsertData(
                table: "StudentsDisciplines",
                columns: new[] { "DisciplineId", "StudentId" },
                values: new object[,]
                {
                    { new Guid("de92fb63-f588-462c-90f3-92dc8e637f2e"), new Guid("21dea7e0-0cff-46dd-83e5-6a57acf5b4fc") },
                    { new Guid("bb65dac5-8c25-4dff-bd62-0e11cad12f92"), new Guid("631b3317-55c6-44fc-af6f-8e78d2102333") },
                    { new Guid("914fb3f8-a293-452e-a660-f179693ae440"), new Guid("c5fd24da-ce49-4c49-bde8-3918ebb84ab5") },
                    { new Guid("e237da4d-73eb-4e02-a633-956447bd3783"), new Guid("c5fd24da-ce49-4c49-bde8-3918ebb84ab5") },
                    { new Guid("fe847335-286f-4a36-8516-6c0bb79551fb"), new Guid("c5fd24da-ce49-4c49-bde8-3918ebb84ab5") }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Disciplines_Teachers_TeacherId",
                table: "Disciplines",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Disciplines_Teachers_TeacherId",
                table: "Disciplines");

            migrationBuilder.DeleteData(
                table: "StudentsDisciplines",
                keyColumns: new[] { "DisciplineId", "StudentId" },
                keyValues: new object[] { new Guid("de92fb63-f588-462c-90f3-92dc8e637f2e"), new Guid("21dea7e0-0cff-46dd-83e5-6a57acf5b4fc") });

            migrationBuilder.DeleteData(
                table: "StudentsDisciplines",
                keyColumns: new[] { "DisciplineId", "StudentId" },
                keyValues: new object[] { new Guid("bb65dac5-8c25-4dff-bd62-0e11cad12f92"), new Guid("631b3317-55c6-44fc-af6f-8e78d2102333") });

            migrationBuilder.DeleteData(
                table: "StudentsDisciplines",
                keyColumns: new[] { "DisciplineId", "StudentId" },
                keyValues: new object[] { new Guid("914fb3f8-a293-452e-a660-f179693ae440"), new Guid("c5fd24da-ce49-4c49-bde8-3918ebb84ab5") });

            migrationBuilder.DeleteData(
                table: "StudentsDisciplines",
                keyColumns: new[] { "DisciplineId", "StudentId" },
                keyValues: new object[] { new Guid("e237da4d-73eb-4e02-a633-956447bd3783"), new Guid("c5fd24da-ce49-4c49-bde8-3918ebb84ab5") });

            migrationBuilder.DeleteData(
                table: "StudentsDisciplines",
                keyColumns: new[] { "DisciplineId", "StudentId" },
                keyValues: new object[] { new Guid("fe847335-286f-4a36-8516-6c0bb79551fb"), new Guid("c5fd24da-ce49-4c49-bde8-3918ebb84ab5") });

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("914fb3f8-a293-452e-a660-f179693ae440"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("bb65dac5-8c25-4dff-bd62-0e11cad12f92"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("de92fb63-f588-462c-90f3-92dc8e637f2e"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("e237da4d-73eb-4e02-a633-956447bd3783"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("fe847335-286f-4a36-8516-6c0bb79551fb"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("21dea7e0-0cff-46dd-83e5-6a57acf5b4fc"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("631b3317-55c6-44fc-af6f-8e78d2102333"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("c5fd24da-ce49-4c49-bde8-3918ebb84ab5"));

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: new Guid("6b77e151-c571-49eb-b5c7-73e5f0e13bea"));

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: new Guid("804e59ba-e3fc-483e-81a6-75ec5e4181b8"));

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: new Guid("f6ebe851-04d7-49cb-9ac1-e750b256da66"));

            migrationBuilder.AddForeignKey(
                name: "FK_Disciplines_Teachers_TeacherId",
                table: "Disciplines",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
