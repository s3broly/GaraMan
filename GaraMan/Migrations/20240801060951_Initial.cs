using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaraMan.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Nhacungcaps",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nhacungcaps", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Phutungyeucaus",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    note = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phutungyeucaus", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Thanhviens",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    chucvu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Thanhviens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dichvuyeucaus",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nhanvienKTId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dichvuyeucaus", x => x.id);
                    table.ForeignKey(
                        name: "FK_Dichvuyeucaus_Thanhviens_nhanvienKTId",
                        column: x => x.nhanvienKTId,
                        principalTable: "Thanhviens",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Hoadonnhaps",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    total = table.Column<float>(type: "real", nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NhacungcapId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    NhanvienkhoId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hoadonnhaps", x => x.id);
                    table.ForeignKey(
                        name: "FK_Hoadonnhaps_Nhacungcaps_NhacungcapId",
                        column: x => x.NhacungcapId,
                        principalTable: "Nhacungcaps",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Hoadonnhaps_Thanhviens_NhanvienkhoId",
                        column: x => x.NhanvienkhoId,
                        principalTable: "Thanhviens",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Lichhens",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KhachhangId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lichhens", x => x.id);
                    table.ForeignKey(
                        name: "FK_Lichhens_Thanhviens_KhachhangId",
                        column: x => x.KhachhangId,
                        principalTable: "Thanhviens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Dichvus",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cost = table.Column<float>(type: "real", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dichvuyeucau385id = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Phutungyeucau385id = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dichvus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dichvus_Dichvuyeucaus_Dichvuyeucau385id",
                        column: x => x.Dichvuyeucau385id,
                        principalTable: "Dichvuyeucaus",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Dichvus_Phutungyeucaus_Phutungyeucau385id",
                        column: x => x.Phutungyeucau385id,
                        principalTable: "Phutungyeucaus",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Hoadons",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    total = table.Column<float>(type: "real", nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    khId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    nvbhId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    dichvuyeucauid = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    phutungyeucauid = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hoadons", x => x.id);
                    table.ForeignKey(
                        name: "FK_Hoadons_Dichvuyeucaus_dichvuyeucauid",
                        column: x => x.dichvuyeucauid,
                        principalTable: "Dichvuyeucaus",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Hoadons_Phutungyeucaus_phutungyeucauid",
                        column: x => x.phutungyeucauid,
                        principalTable: "Phutungyeucaus",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Hoadons_Thanhviens_khId",
                        column: x => x.khId,
                        principalTable: "Thanhviens",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Hoadons_Thanhviens_nvbhId",
                        column: x => x.nvbhId,
                        principalTable: "Thanhviens",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Phutungs",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cost = table.Column<float>(type: "real", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HoadonnhapId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phutungs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Phutungs_Hoadonnhaps_HoadonnhapId",
                        column: x => x.HoadonnhapId,
                        principalTable: "Hoadonnhaps",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dichvus_Dichvuyeucau385id",
                table: "Dichvus",
                column: "Dichvuyeucau385id");

            migrationBuilder.CreateIndex(
                name: "IX_Dichvus_Phutungyeucau385id",
                table: "Dichvus",
                column: "Phutungyeucau385id");

            migrationBuilder.CreateIndex(
                name: "IX_Dichvuyeucaus_nhanvienKTId",
                table: "Dichvuyeucaus",
                column: "nhanvienKTId");

            migrationBuilder.CreateIndex(
                name: "IX_Hoadonnhaps_NhacungcapId",
                table: "Hoadonnhaps",
                column: "NhacungcapId");

            migrationBuilder.CreateIndex(
                name: "IX_Hoadonnhaps_NhanvienkhoId",
                table: "Hoadonnhaps",
                column: "NhanvienkhoId");

            migrationBuilder.CreateIndex(
                name: "IX_Hoadons_dichvuyeucauid",
                table: "Hoadons",
                column: "dichvuyeucauid");

            migrationBuilder.CreateIndex(
                name: "IX_Hoadons_khId",
                table: "Hoadons",
                column: "khId");

            migrationBuilder.CreateIndex(
                name: "IX_Hoadons_nvbhId",
                table: "Hoadons",
                column: "nvbhId");

            migrationBuilder.CreateIndex(
                name: "IX_Hoadons_phutungyeucauid",
                table: "Hoadons",
                column: "phutungyeucauid");

            migrationBuilder.CreateIndex(
                name: "IX_Lichhens_KhachhangId",
                table: "Lichhens",
                column: "KhachhangId");

            migrationBuilder.CreateIndex(
                name: "IX_Phutungs_HoadonnhapId",
                table: "Phutungs",
                column: "HoadonnhapId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dichvus");

            migrationBuilder.DropTable(
                name: "Hoadons");

            migrationBuilder.DropTable(
                name: "Lichhens");

            migrationBuilder.DropTable(
                name: "Phutungs");

            migrationBuilder.DropTable(
                name: "Dichvuyeucaus");

            migrationBuilder.DropTable(
                name: "Phutungyeucaus");

            migrationBuilder.DropTable(
                name: "Hoadonnhaps");

            migrationBuilder.DropTable(
                name: "Nhacungcaps");

            migrationBuilder.DropTable(
                name: "Thanhviens");
        }
    }
}
