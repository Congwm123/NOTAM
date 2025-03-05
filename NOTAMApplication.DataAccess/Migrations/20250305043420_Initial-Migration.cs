using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace NOTAMApplication.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CrawlJobs",
                columns: table => new
                {
                    JobId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    JobName = table.Column<string>(type: "text", nullable: false),
                    RunTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    DataCount = table.Column<int>(type: "integer", nullable: false),
                    ErrorMessage = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateOnly>(type: "date", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrawlJobs", x => x.JobId);
                });

            migrationBuilder.CreateTable(
                name: "NOTAMs",
                columns: table => new
                {
                    NOTAMId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    JobId = table.Column<int>(type: "integer", nullable: false),
                    FacilityDesignator = table.Column<string>(type: "text", nullable: false),
                    NotamNumber = table.Column<string>(type: "text", nullable: false),
                    FeatureName = table.Column<string>(type: "text", nullable: false),
                    IssueDate = table.Column<string>(type: "text", nullable: false),
                    StartDate = table.Column<string>(type: "text", nullable: false),
                    EndDate = table.Column<string>(type: "text", nullable: false),
                    Source = table.Column<string>(type: "text", nullable: false),
                    SourceType = table.Column<string>(type: "text", nullable: false),
                    IcaoMessage = table.Column<string>(type: "text", nullable: false),
                    TraditionalMessage = table.Column<string>(type: "text", nullable: false),
                    PlainLanguageMessage = table.Column<string>(type: "text", nullable: false),
                    TraditionalMessageFrom4thWord = table.Column<string>(type: "text", nullable: false),
                    IcaoId = table.Column<string>(type: "text", nullable: false),
                    AccountId = table.Column<string>(type: "text", nullable: false),
                    AirportName = table.Column<string>(type: "text", nullable: false),
                    Procedure = table.Column<bool>(type: "boolean", nullable: false),
                    UserID = table.Column<int>(type: "integer", nullable: false),
                    TransactionID = table.Column<long>(type: "bigint", nullable: false),
                    CancelledOrExpired = table.Column<bool>(type: "boolean", nullable: false),
                    DigitalTppLink = table.Column<bool>(type: "boolean", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    ContractionsExpandedForPlainLanguage = table.Column<bool>(type: "boolean", nullable: false),
                    Keyword = table.Column<string>(type: "text", nullable: false),
                    Snowtam = table.Column<bool>(type: "boolean", nullable: false),
                    Geometry = table.Column<string>(type: "text", nullable: false),
                    DigitallyTransformed = table.Column<bool>(type: "boolean", nullable: false),
                    MessageDisplayed = table.Column<string>(type: "text", nullable: false),
                    HasHistory = table.Column<bool>(type: "boolean", nullable: false),
                    MoreThan300Chars = table.Column<bool>(type: "boolean", nullable: false),
                    ShowingFullText = table.Column<bool>(type: "boolean", nullable: false),
                    LocID = table.Column<int>(type: "integer", nullable: false),
                    DefaultIcao = table.Column<bool>(type: "boolean", nullable: false),
                    CrossoverTransactionID = table.Column<long>(type: "bigint", nullable: false),
                    CrossoverAccountID = table.Column<string>(type: "text", nullable: false),
                    MapPointer = table.Column<string>(type: "text", nullable: false),
                    RequestID = table.Column<int>(type: "integer", nullable: false),
                    CollectDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NOTAMs", x => x.NOTAMId);
                    table.ForeignKey(
                        name: "FK_NOTAMs_CrawlJobs_JobId",
                        column: x => x.JobId,
                        principalTable: "CrawlJobs",
                        principalColumn: "JobId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NOTAMs_JobId",
                table: "NOTAMs",
                column: "JobId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NOTAMs");

            migrationBuilder.DropTable(
                name: "CrawlJobs");
        }
    }
}
