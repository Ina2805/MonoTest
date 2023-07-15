using Microsoft.EntityFrameworkCore.Migrations;
using Service.DataAccess;

#nullable disable

namespace Service.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VehicleMake",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    Abrv = table.Column<string>(type: "VARCHAR(255)", nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_VehicleMake", x => x.Id); });

            migrationBuilder.CreateTable(
                name: "VehicleModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    Abrv = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    VehicleMakeId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehicleModel_VehicleMake_VehicleMakeId",
                        column: x => x.VehicleMakeId,
                        principalTable: "VehicleMake",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_VehicleModel_VehicleMakeId",
                table: "VehicleModel",
                column: "VehicleMakeId");


            // seeding basic data
            migrationBuilder.InsertData(
                table: "VehicleMake",
                columns: new[] { "Id", "Abrv", "Name" },
                values: new object[,]
                {
                    { 1, "BMW", "Bayerische Motoren Werke AG" },
                    { 2, "Toyota", "Toyota Motor Corporation" },
                    { 3, "Ford", "Ford Motor Company" },
                    { 4, "Honda", "Honda Motor Co., Ltd." },
                    { 5, "Chevrolet", "Chevrolet" },
                    { 6, "Mercedes-Benz", "Mercedes-Benz" },
                    { 7, "Nissan", "Nissan Motor Co., Ltd." },
                    { 8, "Audi", "Audi AG" },
                    { 9, "Volkswagen", "Volkswagen AG" },
                    { 10, "Hyundai", "Hyundai Motor Company" },
                    { 11, "Kia", "Kia Corporation" },
                    { 12, "Subaru", "Subaru Corporation" },
                    { 13, "Mazda", "Mazda Motor Corporation" },
                    { 14, "Volvo", "Volvo Cars" },
                    { 15, "Jeep", "Jeep" },
                    { 16, "Porsche", "Porsche AG" },
                    { 17, "Lexus", "Lexus" },
                    { 18, "Land Rover", "Land Rover" },
                    { 19, "Tesla", "Tesla, Inc." },
                    { 20, "Ferrari", "Ferrari N.V." },
                    { 21, "Jaguar", "Jaguar Land Rover Limited" },
                    { 22, "Aston Martin", "Aston Martin Lagonda Global Holdings plc" },
                    { 23, "Maserati", "Maserati S.p.A." },
                    { 24, "Bentley", "Bentley Motors Limited" },
                    { 25, "Rolls-Royce", "Rolls-Royce Motor Cars Limited" }
                });


            migrationBuilder.InsertData(
    table: "VehicleModel",
    columns: new[] { "Id", "Name", "Abrv", "VehicleMakeId" },
    values: new object[,]
    {
        // BMW Models
        { 1, "X5", "X5", 1 },
        { 2, "3 Series", "3 Series", 1 },
        { 3, "5 Series", "5 Series", 1 },
        { 4, "X3", "X3", 1 },

        // Toyota Models
        { 5, "Camry", "Camry", 2 },
        { 6, "Corolla", "Corolla", 2 },
        { 7, "RAV4", "RAV4", 2 },
        { 8, "Highlander", "Highlander", 2 },

        // Ford Models
        { 9, "Mustang", "Mustang", 3 },
        { 10, "F-150", "F-150", 3 },
        { 11, "Explorer", "Explorer", 3 },
        { 12, "Escape", "Escape", 3 },

        // Honda Models
        { 13, "Civic", "Civic", 4 },
        { 14, "Accord", "Accord", 4 },
        { 15, "CR-V", "CR-V", 4 },
        { 16, "Pilot", "Pilot", 4 },

        // Chevrolet Models
        { 17, "Silverado", "Silverado", 5 },
        { 18, "Cruze", "Cruze", 5 },
        { 19, "Malibu", "Malibu", 5 },
        { 20, "Equinox", "Equinox", 5 },

        // Mercedes-Benz Models
        { 21, "C-Class", "C-Class", 6 },
        { 22, "E-Class", "E-Class", 6 },
        { 23, "GLC", "GLC", 6 },
        { 24, "S-Class", "S-Class", 6 },

        // Nissan Models
        { 25, "Altima", "Altima", 7 },
        { 26, "Maxima", "Maxima", 7 },
        { 27, "Rogue", "Rogue", 7 },
        { 28, "Sentra", "Sentra", 7 },

        // Audi Models
        { 29, "A4", "A4", 8 },
        { 30, "Q5", "Q5", 8 },
        { 31, "A6", "A6", 8 },
        { 32, "Q7", "Q7", 8 },

        // Volkswagen Models
        { 33, "Jetta", "Jetta", 9 },
        { 34, "Passat", "Passat", 9 },
        { 35, "Golf", "Golf", 9 },
        { 36, "Tiguan", "Tiguan", 9 },

        // Hyundai Models
        { 37, "Elantra", "Elantra", 10 },
        { 38, "Tucson", "Tucson", 10 },
        { 39, "Sonata", "Sonata", 10 },
        { 40, "Santa Fe", "Santa Fe", 10 },

        // Kia Models
        { 41, "Optima", "Optima", 11 },
        { 42, "Soul", "Soul", 11 },
        { 43, "Sportage", "Sportage", 11 },
        { 44, "Sorento", "Sorento", 11 },

        // Subaru Models
        { 45, "Impreza", "Impreza", 12 },
        { 46, "Outback", "Outback", 12 },
        { 47, "Crosstrek", "Crosstrek", 12 },
        { 48, "Forester", "Forester", 12 },

        // Mazda Models
        { 49, "Mazda3", "Mazda3", 13 },
        { 50, "CX-5", "CX-5", 13 },
        { 51, "Mazda6", "Mazda6", 13 },
        { 52, "CX-9", "CX-9", 13 },

        // Volvo Models
        { 53, "XC90", "XC90", 14 },
        { 54, "XC60", "XC60", 14 },
        { 55, "S60", "S60", 14 },
        { 56, "XC40", "XC40", 14 },

        // Jeep Models
        { 57, "Wrangler", "Wrangler", 15 },
        { 58, "Grand Cherokee", "Grand Cherokee", 15 },
        { 59, "Cherokee", "Cherokee", 15 },
        { 60, "Compass", "Compass", 15 },

        // Porsche Models
        { 61, "911", "911", 16 },
        { 62, "Cayenne", "Cayenne", 16 },
        { 63, "Panamera", "Panamera", 16 },
        { 64, "Macan", "Macan", 16 },

        // Lexus Models
        { 65, "RX", "RX", 17 },
        { 66, "ES", "ES", 17 },
        { 67, "NX", "NX", 17 },
        { 68, "UX", "UX", 17 },

        // Land Rover Models
        { 69, "Range Rover", "Range Rover", 18 },
        { 70, "Range Rover Sport", "Range Rover Sport", 18 },
        { 71, "Discovery", "Discovery", 18 },
        { 72, "Range Rover Velar", "Range Rover Velar", 18 },

        // Tesla Models
        { 73, "Model S", "Model S", 19 },
        { 74, "Model 3", "Model 3", 19 },
        { 75, "Model X", "Model X", 19 },
        { 76, "Model Y", "Model Y", 19 },

        // Ferrari Models
        { 77, "F8 Tributo", "F8 Tributo", 20 },
        { 78, "488 GTB", "488 GTB", 20 },
        { 79, "Portofino", "Portofino", 20 },
        { 80, "812 Superfast", "812 Superfast", 20 },

        // Jaguar Models
        { 81, "F-PACE", "F-PACE", 21 },
        { 82, "XE", "XE", 21 },
        { 83, "XF", "XF", 21 },
        { 84, "E-PACE", "E-PACE", 21 },

        // Aston Martin Models
        { 85, "DB11", "DB11", 22 },
        { 86, "Vantage", "Vantage", 22 },
        { 87, "DBS Superleggera", "DBS Superleggera", 22 },
        { 88, "DBX", "DBX", 22 },

        // Maserati Models
        { 89, "Ghibli", "Ghibli", 23 },
        { 90, "Levante", "Levante", 23 },
        { 91, "Quattroporte", "Quattroporte", 23 },
        { 92, "MC20", "MC20", 23 },

        // Bentley Models
        { 93, "Continental GT", "Continental GT", 24 },
        { 94, "Bentayga", "Bentayga", 24 },
        { 95, "Flying Spur", "Flying Spur", 24 },
        { 96, "Mulsanne", "Mulsanne", 24 },

        // Rolls-Royce Models
        { 97, "Phantom", "Phantom", 25 },
        { 98, "Cullinan", "Cullinan", 25 },
        { 99, "Ghost", "Ghost", 25 },
        { 100, "Wraith", "Wraith", 25 },
    }
);

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VehicleModel");

            migrationBuilder.DropTable(
                name: "VehicleMake");
        }
    }
}
