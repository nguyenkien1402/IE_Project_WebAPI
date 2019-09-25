using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace XBrain.Migrations
{
    public partial class LiberzyDBInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "XBrainUser",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(maxLength: 100, nullable: true),
                    LastName = table.Column<string>(maxLength: 100, nullable: true),
                    UserName = table.Column<string>(maxLength: 100, nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: true),
                    HashPassword = table.Column<string>(maxLength: 250, nullable: true),
                    DeviceId = table.Column<string>(maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_XBrainUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DailyActivity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    ActivityTitle = table.Column<string>(maxLength: 100, nullable: false),
                    ActivityContent = table.Column<string>(maxLength: 250, nullable: true),
                    DateAchieve = table.Column<DateTime>(type: "date", nullable: false),
                    NumberOfHour = table.Column<double>(nullable: false),
                    TargetHour = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyActivity", x => x.Id);
                    table.ForeignKey(
                        name: "FK__DailyActi__UserI__403A8C7D",
                        column: x => x.UserId,
                        principalTable: "XBrainUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DailyRoutine",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    RoutineTitle = table.Column<string>(maxLength: 100, nullable: false),
                    RoutineContent = table.Column<string>(nullable: true),
                    DayOperation = table.Column<string>(maxLength: 100, nullable: true),
                    DateAchieve = table.Column<DateTime>(type: "date", nullable: false),
                    PlanStartTime = table.Column<TimeSpan>(nullable: false),
                    PlanEndTime = table.Column<TimeSpan>(nullable: false),
                    ActualStartTime = table.Column<TimeSpan>(nullable: true),
                    ActualEndTime = table.Column<TimeSpan>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyRoutine", x => x.Id);
                    table.ForeignKey(
                        name: "FK__DailyRout__Actua__3B75D760",
                        column: x => x.UserId,
                        principalTable: "XBrainUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SleepingTime",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    DateAchieve = table.Column<DateTime>(type: "date", nullable: true),
                    SleepTime = table.Column<TimeSpan>(nullable: true),
                    WakingupTime = table.Column<TimeSpan>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SleepingTime", x => x.Id);
                    table.ForeignKey(
                        name: "FK__SleepingT__UserI__49C3F6B7",
                        column: x => x.UserId,
                        principalTable: "XBrainUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DailyActivity_UserId",
                table: "DailyActivity",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyRoutine_UserId",
                table: "DailyRoutine",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SleepingTime_UserId",
                table: "SleepingTime",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DailyActivity");

            migrationBuilder.DropTable(
                name: "DailyRoutine");

            migrationBuilder.DropTable(
                name: "SleepingTime");

            migrationBuilder.DropTable(
                name: "XBrainUser");
        }
    }
}
