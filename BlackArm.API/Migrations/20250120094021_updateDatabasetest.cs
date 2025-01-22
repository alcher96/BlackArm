using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlackArm.API.Migrations
{
    /// <inheritdoc />
    public partial class updateDatabasetest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArmWrestler",
                columns: table => new
                {
                    ArmWrestlerId = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    NickName = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    Country = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    BirthDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Weight = table.Column<int>(type: "integer", nullable: false),
                    Height = table.Column<int>(type: "integer", nullable: false),
                    Bicep = table.Column<int>(type: "integer", nullable: false),
                    Forearm = table.Column<int>(type: "integer", nullable: false),
                    Wins = table.Column<int>(type: "integer", nullable: false),
                    Losses = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArmWrestler", x => x.ArmWrestlerId);
                });

            migrationBuilder.CreateTable(
                name: "Competition",
                columns: table => new
                {
                    CompetitionId = table.Column<Guid>(type: "uuid", nullable: false),
                    CompetitionName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    CompetitionDate = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competition", x => x.CompetitionId);
                });

            migrationBuilder.CreateTable(
                name: "WrestlingStyle",
                columns: table => new
                {
                    StyleId = table.Column<Guid>(type: "uuid", nullable: false),
                    StyleName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WrestlingStyle", x => x.StyleId);
                });

            migrationBuilder.CreateTable(
                name: "RadarGraph",
                columns: table => new
                {
                    GraphId = table.Column<Guid>(type: "uuid", nullable: false),
                    WrestlerId = table.Column<Guid>(type: "uuid", nullable: false),
                    PronatorStrength = table.Column<int>(type: "integer", nullable: false),
                    WristStrength = table.Column<int>(type: "integer", nullable: false),
                    SidePressure = table.Column<int>(type: "integer", nullable: false),
                    Stamina = table.Column<int>(type: "integer", nullable: false),
                    AngleStrenght = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RadarGraph", x => x.GraphId);
                    table.ForeignKey(
                        name: "FK_RadarGraph_ArmWrestler_WrestlerId",
                        column: x => x.WrestlerId,
                        principalTable: "ArmWrestler",
                        principalColumn: "ArmWrestlerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Fight",
                columns: table => new
                {
                    FightId = table.Column<Guid>(type: "uuid", nullable: false),
                    CompetitionId = table.Column<Guid>(type: "uuid", nullable: false),
                    Wrestler1Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Wrestler2Id = table.Column<Guid>(type: "uuid", nullable: false),
                    WinnerId = table.Column<Guid>(type: "uuid", nullable: false),
                    StyleUsedId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fight", x => x.FightId);
                    table.ForeignKey(
                        name: "FK_Fight_ArmWrestler_WinnerId",
                        column: x => x.WinnerId,
                        principalTable: "ArmWrestler",
                        principalColumn: "ArmWrestlerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Fight_ArmWrestler_Wrestler1Id",
                        column: x => x.Wrestler1Id,
                        principalTable: "ArmWrestler",
                        principalColumn: "ArmWrestlerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Fight_ArmWrestler_Wrestler2Id",
                        column: x => x.Wrestler2Id,
                        principalTable: "ArmWrestler",
                        principalColumn: "ArmWrestlerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Fight_Competition_CompetitionId",
                        column: x => x.CompetitionId,
                        principalTable: "Competition",
                        principalColumn: "CompetitionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Fight_WrestlingStyle_StyleUsedId",
                        column: x => x.StyleUsedId,
                        principalTable: "WrestlingStyle",
                        principalColumn: "StyleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Round",
                columns: table => new
                {
                    RoundId = table.Column<Guid>(type: "uuid", nullable: false),
                    FightId = table.Column<Guid>(type: "uuid", nullable: false),
                    RoundNumber = table.Column<int>(type: "integer", nullable: false),
                    WinnerId = table.Column<Guid>(type: "uuid", nullable: false),
                    StyleUsedId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Round", x => x.RoundId);
                    table.ForeignKey(
                        name: "FK_Round_ArmWrestler_WinnerId",
                        column: x => x.WinnerId,
                        principalTable: "ArmWrestler",
                        principalColumn: "ArmWrestlerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Round_Fight_FightId",
                        column: x => x.FightId,
                        principalTable: "Fight",
                        principalColumn: "FightId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Round_WrestlingStyle_StyleUsedId",
                        column: x => x.StyleUsedId,
                        principalTable: "WrestlingStyle",
                        principalColumn: "StyleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ArmWrestler",
                columns: new[] { "ArmWrestlerId", "Bicep", "BirthDate", "Country", "FirstName", "Forearm", "Height", "LastName", "Losses", "NickName", "Weight", "Wins" },
                values: new object[,]
                {
                    { new Guid("2d1b391c-92c9-416e-93f8-74ab4fd2a818"), 40, new DateTimeOffset(new DateTime(2022, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), "US", "john", 30, 120, "doe", 2, "poop", 150, 15 },
                    { new Guid("7bb4f59c-dadc-4918-a215-730dd34f03d4"), 40, new DateTimeOffset(new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), "US", "nick", 30, 120, "piterson", 2, "qwerty", 150, 15 }
                });

            migrationBuilder.InsertData(
                table: "Competition",
                columns: new[] { "CompetitionId", "CompetitionDate", "CompetitionName" },
                values: new object[,]
                {
                    { new Guid("dfc6e35c-6057-4fa6-8c55-5332bb19d357"), new DateTime(2019, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "East vs West 1" },
                    { new Guid("e85a1433-87bc-42b5-85c4-1c9bc2ac66fc"), new DateTime(2018, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "King of the table 1" }
                });

            migrationBuilder.InsertData(
                table: "WrestlingStyle",
                columns: new[] { "StyleId", "StyleName" },
                values: new object[,]
                {
                    { new Guid("71d60165-142c-47a5-aeba-265d771cfbea"), "Kings move" },
                    { new Guid("8e66d889-7055-4024-b9d6-58732c3bddd0"), "Top roll" },
                    { new Guid("ad870477-c1c7-4310-b512-944e68b4a894"), "Hook" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fight_CompetitionId",
                table: "Fight",
                column: "CompetitionId");

            migrationBuilder.CreateIndex(
                name: "IX_Fight_StyleUsedId",
                table: "Fight",
                column: "StyleUsedId");

            migrationBuilder.CreateIndex(
                name: "IX_Fight_WinnerId",
                table: "Fight",
                column: "WinnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Fight_Wrestler1Id",
                table: "Fight",
                column: "Wrestler1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Fight_Wrestler2Id",
                table: "Fight",
                column: "Wrestler2Id");

            migrationBuilder.CreateIndex(
                name: "IX_RadarGraph_WrestlerId",
                table: "RadarGraph",
                column: "WrestlerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Round_FightId",
                table: "Round",
                column: "FightId");

            migrationBuilder.CreateIndex(
                name: "IX_Round_StyleUsedId",
                table: "Round",
                column: "StyleUsedId");

            migrationBuilder.CreateIndex(
                name: "IX_Round_WinnerId",
                table: "Round",
                column: "WinnerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RadarGraph");

            migrationBuilder.DropTable(
                name: "Round");

            migrationBuilder.DropTable(
                name: "Fight");

            migrationBuilder.DropTable(
                name: "ArmWrestler");

            migrationBuilder.DropTable(
                name: "Competition");

            migrationBuilder.DropTable(
                name: "WrestlingStyle");
        }
    }
}
