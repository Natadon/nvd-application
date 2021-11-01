using Microsoft.EntityFrameworkCore.Migrations;

namespace Nvd.DataAccess.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Configurations",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CVE_data_version = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Configurations", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CVE_Data_Metas",
                columns: table => new
                {
                    PrimaryKey = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ASSIGNER = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CVE_Data_Metas", x => x.PrimaryKey);
                });

            migrationBuilder.CreateTable(
                name: "Cvssv2s",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    version = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    vectorString = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    accessVector = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    accessComplexity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    authentication = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    confidentialityImpact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    integrityImpact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    availabilityImpact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    baseScore = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cvssv2s", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Cvssv3s",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    version = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    vectorString = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    attackVector = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    attackComplexity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    privilegesRequired = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userInteraction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    scope = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    confidentialityImpact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    integrityImpact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    availabilityImpact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    baseScore = table.Column<float>(type: "real", nullable: false),
                    baseSeverity = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cvssv3s", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Description1",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Description1", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ProblemTypes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProblemTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "RawDownloads",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    resultsPerPage = table.Column<int>(type: "int", nullable: false),
                    startIndex = table.Column<int>(type: "int", nullable: false),
                    totalResults = table.Column<int>(type: "int", nullable: false),
                    result = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RawDownloads", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "References",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_References", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Results",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CVE_data_type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CVE_data_format = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CVE_data_version = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CVE_data_timestamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Results", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Nodes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    _operator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConfigurationsID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nodes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Nodes_Configurations_ConfigurationsID",
                        column: x => x.ConfigurationsID,
                        principalTable: "Configurations",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BaseMetricsV2",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cvssV2ID = table.Column<int>(type: "int", nullable: true),
                    severity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    exploitabilityScore = table.Column<float>(type: "real", nullable: false),
                    impactScore = table.Column<float>(type: "real", nullable: false),
                    acInsufInfo = table.Column<bool>(type: "bit", nullable: false),
                    obtainAllPrivilege = table.Column<bool>(type: "bit", nullable: false),
                    obtainUserPrivilege = table.Column<bool>(type: "bit", nullable: false),
                    obtainOtherPrivilege = table.Column<bool>(type: "bit", nullable: false),
                    userInteractionRequired = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseMetricsV2", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BaseMetricsV2_Cvssv2s_cvssV2ID",
                        column: x => x.cvssV2ID,
                        principalTable: "Cvssv2s",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BaseMetricsV3",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cvssV3ID = table.Column<int>(type: "int", nullable: true),
                    exploitabilityScore = table.Column<float>(type: "real", nullable: false),
                    impactScore = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseMetricsV3", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BaseMetricsV3_Cvssv3s_cvssV3ID",
                        column: x => x.cvssV3ID,
                        principalTable: "Cvssv3s",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Description_Data",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    lang = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description1ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Description_Data", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Description_Data_Description1_Description1ID",
                        column: x => x.Description1ID,
                        principalTable: "Description1",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Problemtype_Data",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProblemtypeID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Problemtype_Data", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Problemtype_Data_ProblemTypes_ProblemtypeID",
                        column: x => x.ProblemtypeID,
                        principalTable: "ProblemTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cves",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    data_type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    data_format = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    data_version = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CVE_data_metaPrimaryKey = table.Column<int>(type: "int", nullable: true),
                    problemtypeID = table.Column<int>(type: "int", nullable: true),
                    referencesID = table.Column<int>(type: "int", nullable: true),
                    descriptionID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cves", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Cves_CVE_Data_Metas_CVE_data_metaPrimaryKey",
                        column: x => x.CVE_data_metaPrimaryKey,
                        principalTable: "CVE_Data_Metas",
                        principalColumn: "PrimaryKey",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cves_Description1_descriptionID",
                        column: x => x.descriptionID,
                        principalTable: "Description1",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cves_ProblemTypes_problemtypeID",
                        column: x => x.problemtypeID,
                        principalTable: "ProblemTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cves_References_referencesID",
                        column: x => x.referencesID,
                        principalTable: "References",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reference_Data",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    refsource = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReferencesID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reference_Data", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Reference_Data_References_ReferencesID",
                        column: x => x.ReferencesID,
                        principalTable: "References",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NvdSearchResults",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    resultsPerPage = table.Column<int>(type: "int", nullable: false),
                    startIndex = table.Column<int>(type: "int", nullable: false),
                    totalResults = table.Column<int>(type: "int", nullable: false),
                    resultID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NvdSearchResults", x => x.ID);
                    table.ForeignKey(
                        name: "FK_NvdSearchResults_Results_resultID",
                        column: x => x.resultID,
                        principalTable: "Results",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cpe_Matches",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    vulnerable = table.Column<bool>(type: "bit", nullable: false),
                    cpe23Uri = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    versionEndIncluding = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    versionStartIncluding = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NodeID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cpe_Matches", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Cpe_Matches_Nodes_NodeID",
                        column: x => x.NodeID,
                        principalTable: "Nodes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Impacts",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    baseMetricV3ID = table.Column<int>(type: "int", nullable: true),
                    baseMetricV2ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Impacts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Impacts_BaseMetricsV2_baseMetricV2ID",
                        column: x => x.baseMetricV2ID,
                        principalTable: "BaseMetricsV2",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Impacts_BaseMetricsV3_baseMetricV3ID",
                        column: x => x.baseMetricV3ID,
                        principalTable: "BaseMetricsV3",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Descriptions",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    lang = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Problemtype_DataID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Descriptions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Descriptions_Problemtype_Data_Problemtype_DataID",
                        column: x => x.Problemtype_DataID,
                        principalTable: "Problemtype_Data",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CVE_Items",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cveID = table.Column<int>(type: "int", nullable: true),
                    configurationsID = table.Column<int>(type: "int", nullable: true),
                    impactID = table.Column<int>(type: "int", nullable: true),
                    publishedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastModifiedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResultID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CVE_Items", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CVE_Items_Configurations_configurationsID",
                        column: x => x.configurationsID,
                        principalTable: "Configurations",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CVE_Items_Cves_cveID",
                        column: x => x.cveID,
                        principalTable: "Cves",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CVE_Items_Impacts_impactID",
                        column: x => x.impactID,
                        principalTable: "Impacts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CVE_Items_Results_ResultID",
                        column: x => x.ResultID,
                        principalTable: "Results",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BaseMetricsV2_cvssV2ID",
                table: "BaseMetricsV2",
                column: "cvssV2ID");

            migrationBuilder.CreateIndex(
                name: "IX_BaseMetricsV3_cvssV3ID",
                table: "BaseMetricsV3",
                column: "cvssV3ID");

            migrationBuilder.CreateIndex(
                name: "IX_Cpe_Matches_NodeID",
                table: "Cpe_Matches",
                column: "NodeID");

            migrationBuilder.CreateIndex(
                name: "IX_CVE_Items_configurationsID",
                table: "CVE_Items",
                column: "configurationsID");

            migrationBuilder.CreateIndex(
                name: "IX_CVE_Items_cveID",
                table: "CVE_Items",
                column: "cveID");

            migrationBuilder.CreateIndex(
                name: "IX_CVE_Items_impactID",
                table: "CVE_Items",
                column: "impactID");

            migrationBuilder.CreateIndex(
                name: "IX_CVE_Items_ResultID",
                table: "CVE_Items",
                column: "ResultID");

            migrationBuilder.CreateIndex(
                name: "IX_Cves_CVE_data_metaPrimaryKey",
                table: "Cves",
                column: "CVE_data_metaPrimaryKey");

            migrationBuilder.CreateIndex(
                name: "IX_Cves_descriptionID",
                table: "Cves",
                column: "descriptionID");

            migrationBuilder.CreateIndex(
                name: "IX_Cves_problemtypeID",
                table: "Cves",
                column: "problemtypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Cves_referencesID",
                table: "Cves",
                column: "referencesID");

            migrationBuilder.CreateIndex(
                name: "IX_Description_Data_Description1ID",
                table: "Description_Data",
                column: "Description1ID");

            migrationBuilder.CreateIndex(
                name: "IX_Descriptions_Problemtype_DataID",
                table: "Descriptions",
                column: "Problemtype_DataID");

            migrationBuilder.CreateIndex(
                name: "IX_Impacts_baseMetricV2ID",
                table: "Impacts",
                column: "baseMetricV2ID");

            migrationBuilder.CreateIndex(
                name: "IX_Impacts_baseMetricV3ID",
                table: "Impacts",
                column: "baseMetricV3ID");

            migrationBuilder.CreateIndex(
                name: "IX_Nodes_ConfigurationsID",
                table: "Nodes",
                column: "ConfigurationsID");

            migrationBuilder.CreateIndex(
                name: "IX_NvdSearchResults_resultID",
                table: "NvdSearchResults",
                column: "resultID");

            migrationBuilder.CreateIndex(
                name: "IX_Problemtype_Data_ProblemtypeID",
                table: "Problemtype_Data",
                column: "ProblemtypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Reference_Data_ReferencesID",
                table: "Reference_Data",
                column: "ReferencesID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cpe_Matches");

            migrationBuilder.DropTable(
                name: "CVE_Items");

            migrationBuilder.DropTable(
                name: "Description_Data");

            migrationBuilder.DropTable(
                name: "Descriptions");

            migrationBuilder.DropTable(
                name: "NvdSearchResults");

            migrationBuilder.DropTable(
                name: "RawDownloads");

            migrationBuilder.DropTable(
                name: "Reference_Data");

            migrationBuilder.DropTable(
                name: "Nodes");

            migrationBuilder.DropTable(
                name: "Cves");

            migrationBuilder.DropTable(
                name: "Impacts");

            migrationBuilder.DropTable(
                name: "Problemtype_Data");

            migrationBuilder.DropTable(
                name: "Results");

            migrationBuilder.DropTable(
                name: "Configurations");

            migrationBuilder.DropTable(
                name: "CVE_Data_Metas");

            migrationBuilder.DropTable(
                name: "Description1");

            migrationBuilder.DropTable(
                name: "References");

            migrationBuilder.DropTable(
                name: "BaseMetricsV2");

            migrationBuilder.DropTable(
                name: "BaseMetricsV3");

            migrationBuilder.DropTable(
                name: "ProblemTypes");

            migrationBuilder.DropTable(
                name: "Cvssv2s");

            migrationBuilder.DropTable(
                name: "Cvssv3s");
        }
    }
}
