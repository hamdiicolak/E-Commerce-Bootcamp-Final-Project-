using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductCatalog.Persistence.Migrations
{
    public partial class mig_01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Colors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColorName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UsingStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsingStatusDetail = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsingStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsOfferable = table.Column<bool>(type: "bit", nullable: false),
                    IsSold = table.Column<bool>(type: "bit", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    BrandId = table.Column<int>(type: "int", nullable: true),
                    UsingStatusId = table.Column<int>(type: "int", nullable: false),
                    ColorId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Colors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Colors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_UsingStatuses_UsingStatusId",
                        column: x => x.UsingStatusId,
                        principalTable: "UsingStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Offers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OfferPrice = table.Column<int>(type: "int", nullable: false),
                    OfferApproved = table.Column<bool>(type: "bit", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Offers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Offers_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, "b3a6bba3-b4f8-4f0e-9b1f-54f820bead4d", "aalvares0@npr.org", true, "Alidia", "Alvares", false, null, "AALVARES0@DRUPAL.ORG", "AALVARES0", "AQAAAAEAACcQAAAAEA17K3h57VX+EHCLWbiotMPp4i79Zrogfz1yX187F/JrsN+NStzeL4Hgw9jXf3WDvg==", null, false, "3dbf793e-5aee-4896-b1cf-6d8044c945e9", false, "aalvares0" },
                    { 2, 0, "51c53286-8dee-4474-83d4-05dc4dbb9c7e", "kfrankowski1@typepad.com", true, "Korry", "Frankowski", false, null, "KFRANKOWSKI1@PINTEREST.COM", "KFRANKOWSKI1", "AQAAAAEAACcQAAAAEOmS8f8sZFlIy+ySqwR7JiCKTBL1Dr5B4uMIUzQgt5gyd2TPdkj1ZhxCjdtHTcvbgA==", null, false, "86f5c0eb-90cf-46ad-9a0f-1fc52876191e", false, "kfrankowski1" },
                    { 3, 0, "43b2cf37-b32c-4252-8766-28efcee73d17", "wmathen2@shop-pro.jp", true, "Wayne", "Mathen", false, null, "WMATHEN2@MIIBEIAN.GOV.CN", "WMATHEN2", "AQAAAAEAACcQAAAAECdzhtm4ARxcgD6hQov/bnUCocvMOJZRrnn2K4hrKy7t7oatN2LSJ9HTCmwX4JzqEQ==", null, false, "ad114b41-f471-40e8-85aa-5076325a02a8", false, "wmathen2" },
                    { 4, 0, "cd64ac7e-e593-47ce-9e1f-64a1d0de1f6f", "galoshechkin3@harvard.edu", true, "Ginelle", "Aloshechkin", false, null, "GALOSHECHKIN3@SQUIDOO.COM", "GALOSHECHKIN3", "AQAAAAEAACcQAAAAEKEhJOhssBRvk8B1nePwYsXHau69bKstLE3KMdffzHRT8BiEHoBbDQeZYIfuB6nPTg==", null, false, "ef59c4fa-2733-489e-ac74-8e806b355ddc", false, "galoshechkin3" },
                    { 5, 0, "17f66134-c0ce-4379-b52f-8e7fdacb8ec2", "amcnutt4@lulu.com", true, "Andrei", "McNutt", false, null, "AMCNUTT4@INDEPENDENT.CO.UK", "AMCNUTT4", "AQAAAAEAACcQAAAAEHQd/hzKtJRy6SAAcUQTPC/ASRGd54BJuwyAQv4uFSPorZ98JjC4sZj3Ld4AJCFdKQ==", null, false, "40c62395-ff7d-4642-87be-d620a5a7399e", false, "amcnutt4" },
                    { 6, 0, "32ed6b24-d33b-47fe-bb11-99432a4add1b", "hollis5@instagram.com", true, "Harman", "Ollis", false, null, "HOLLIS5@TIMESONLINE.CO.UK", "HOLLIS5", "AQAAAAEAACcQAAAAEAzaPhRgqPjH5ixD732ZUf3X+K8FU2rQbd1s2dW36+ucIZaeAKUlq6lG9KJbrPsOoQ==", null, false, "ee7bceaa-f901-438e-afd6-af8cb1ccb5f5", false, "hollis5" },
                    { 7, 0, "be9e1d6b-5c66-449a-b5f5-8eb44f4a4a57", "isate6@nifty.com", true, "Ivar", "Sate", false, null, "ISATE6@GOOGLE.COM.HK", "ISATE6", "AQAAAAEAACcQAAAAEJLTZEDezwhgI4+iXTZZuXnep0uTycgVokdU1tMVBwcvHwU8GD4Fs/OyO9+vtKHhvQ==", null, false, "36a52ddc-e7f4-4dcf-9bca-cb309a7dbd01", false, "isate6" }
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "BrandName", "CreatedDate", "LastModifiedDate" },
                values: new object[,]
                {
                    { 1, "LCWaikiki", new DateTime(2022, 6, 17, 8, 15, 15, 440, DateTimeKind.Local).AddTicks(9928), null },
                    { 2, "Defacto", new DateTime(2022, 6, 17, 8, 15, 15, 440, DateTimeKind.Local).AddTicks(9931), null },
                    { 3, "Vakko", new DateTime(2022, 6, 17, 8, 15, 15, 440, DateTimeKind.Local).AddTicks(9932), null },
                    { 4, "Koton", new DateTime(2022, 6, 17, 8, 15, 15, 440, DateTimeKind.Local).AddTicks(9933), null },
                    { 5, "Mavi", new DateTime(2022, 6, 17, 8, 15, 15, 440, DateTimeKind.Local).AddTicks(9934), null },
                    { 6, "Kiğili", new DateTime(2022, 6, 17, 8, 15, 15, 440, DateTimeKind.Local).AddTicks(9935), null }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "Description", "LastModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 6, 17, 8, 15, 15, 440, DateTimeKind.Local).AddTicks(5905), "Kategorii Tanımı", null, "Ayakkabı" },
                    { 2, new DateTime(2022, 6, 17, 8, 15, 15, 440, DateTimeKind.Local).AddTicks(5914), "Kategorii Tanımı", null, "Tişört" },
                    { 3, new DateTime(2022, 6, 17, 8, 15, 15, 440, DateTimeKind.Local).AddTicks(5915), "Kategorii Tanımı", null, "Kot" },
                    { 4, new DateTime(2022, 6, 17, 8, 15, 15, 440, DateTimeKind.Local).AddTicks(5916), "Kategorii Tanımı", null, "Gömlek" },
                    { 5, new DateTime(2022, 6, 17, 8, 15, 15, 440, DateTimeKind.Local).AddTicks(5917), "Kategorii Tanımı", null, "Kazak" },
                    { 6, new DateTime(2022, 6, 17, 8, 15, 15, 440, DateTimeKind.Local).AddTicks(5917), "Kategorii Tanımı", null, "Pantolon" },
                    { 7, new DateTime(2022, 6, 17, 8, 15, 15, 440, DateTimeKind.Local).AddTicks(5918), "Kategorii Tanımı", null, "Ceket" },
                    { 8, new DateTime(2022, 6, 17, 8, 15, 15, 440, DateTimeKind.Local).AddTicks(5919), "Kategorii Tanımı", null, "Şort" }
                });

            migrationBuilder.InsertData(
                table: "Colors",
                columns: new[] { "Id", "ColorName", "CreatedDate", "LastModifiedDate" },
                values: new object[,]
                {
                    { 1, "Mavi", new DateTime(2022, 6, 17, 8, 15, 15, 441, DateTimeKind.Local).AddTicks(3590), null },
                    { 2, "Yeşil", new DateTime(2022, 6, 17, 8, 15, 15, 441, DateTimeKind.Local).AddTicks(3594), null },
                    { 3, "Kırmızı", new DateTime(2022, 6, 17, 8, 15, 15, 441, DateTimeKind.Local).AddTicks(3656), null },
                    { 4, "Sarı", new DateTime(2022, 6, 17, 8, 15, 15, 441, DateTimeKind.Local).AddTicks(3659), null },
                    { 5, "Kahverengi", new DateTime(2022, 6, 17, 8, 15, 15, 441, DateTimeKind.Local).AddTicks(3660), null },
                    { 6, "Mor", new DateTime(2022, 6, 17, 8, 15, 15, 441, DateTimeKind.Local).AddTicks(3661), null },
                    { 7, "Gri", new DateTime(2022, 6, 17, 8, 15, 15, 441, DateTimeKind.Local).AddTicks(3662), null },
                    { 8, "Siyah", new DateTime(2022, 6, 17, 8, 15, 15, 441, DateTimeKind.Local).AddTicks(3662), null },
                    { 9, "Beyaz", new DateTime(2022, 6, 17, 8, 15, 15, 441, DateTimeKind.Local).AddTicks(3663), null }
                });

            migrationBuilder.InsertData(
                table: "UsingStatuses",
                columns: new[] { "Id", "CreatedDate", "LastModifiedDate", "UsingStatusDetail" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Az kullanılmış defalu" },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Çok kullanılmış defalu" },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Yeni & Etiketli" },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Çok fazla kullanılmış defalu" },
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Çok Az kullanılmış defalu" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CategoryId", "ColorId", "CreatedDate", "Description", "ImageUrl", "IsOfferable", "IsSold", "LastModifiedDate", "Name", "Price", "Size", "UserId", "UsingStatusId" },
                values: new object[,]
                {
                    { 1, 1, 1, 1, new DateTime(2022, 6, 17, 8, 15, 15, 440, DateTimeKind.Local).AddTicks(7792), "Kullanıcının ürün e ait tanımı 1", "ayakkabi1.jpg", true, false, null, "Yazlık Ayakkabı", 199m, "S", 1, 1 },
                    { 2, 1, 2, 2, new DateTime(2022, 6, 17, 8, 15, 15, 440, DateTimeKind.Local).AddTicks(7797), "Kullanıcının ürün e ait tanımı 2", "Tisort1.jpg", true, false, null, "Kısa Tişört", 199m, "M", 2, 2 },
                    { 3, 1, 3, 3, new DateTime(2022, 6, 17, 8, 15, 15, 440, DateTimeKind.Local).AddTicks(7802), "Kullanıcının ürün e ait tanımı 3", "Kot1.jpg", true, false, null, "Dar Paça Kot", 199m, "L", 3, 3 },
                    { 4, 1, 4, 4, new DateTime(2022, 6, 17, 8, 15, 15, 440, DateTimeKind.Local).AddTicks(7803), "Kullanıcının ürün e ait tanımı 4", "Gomlek1.jpg", true, false, null, "Ferah Gömlek", 99m, "XL", 4, 4 },
                    { 5, 1, 5, 5, new DateTime(2022, 6, 17, 8, 15, 15, 440, DateTimeKind.Local).AddTicks(7805), "Kullanıcının ürün e ait tanımı 5", "Kazak1.jpg", true, false, null, "Yazlık Kazak ", 99m, "XXL", 5, 5 },
                    { 6, 1, 6, 6, new DateTime(2022, 6, 17, 8, 15, 15, 440, DateTimeKind.Local).AddTicks(7806), "Kullanıcının ürün e ait tanımı 6", "Pantolon1.jpg", true, false, null, "Kışlık Pantolon", 99m, "XS", 6, 1 },
                    { 7, 1, 7, 7, new DateTime(2022, 6, 17, 8, 15, 15, 440, DateTimeKind.Local).AddTicks(7808), "Kullanıcının ürün e ait tanım ı 7", "Ceket1.jpg", true, false, null, "Kışlık Ceket ", 150m, "S", 7, 2 },
                    { 8, 1, 8, 8, new DateTime(2022, 6, 17, 8, 15, 15, 440, DateTimeKind.Local).AddTicks(7809), "Kullanıcının ürün e ait tanım ı 8", "Sort1.jpg", true, false, null, "Deniz Şortu", 150m, "M", 1, 3 },
                    { 9, 1, 1, 9, new DateTime(2022, 6, 17, 8, 15, 15, 440, DateTimeKind.Local).AddTicks(7811), "Kullanıcının ürün e ait tanım ı 9", "ayakkabi2.jpg", true, false, null, "Kışlık Ayakkabı", 150m, "L", 2, 4 },
                    { 10, 1, 2, 1, new DateTime(2022, 6, 17, 8, 15, 15, 440, DateTimeKind.Local).AddTicks(7812), "Kullanıcının ürün e ait tanımı 10", "Tisort2.jpg", true, false, null, "Ferah Tişört", 150m, "XL", 3, 5 },
                    { 11, 1, 3, 2, new DateTime(2022, 6, 17, 8, 15, 15, 440, DateTimeKind.Local).AddTicks(7813), "Kullanıcının ürün e ait tanımı 11", "Kot2.jpg", true, false, null, "Kışlık Kot", 150m, "XXL", 4, 1 },
                    { 12, 1, 4, 3, new DateTime(2022, 6, 17, 8, 15, 15, 440, DateTimeKind.Local).AddTicks(7816), "Kullanıcının ürün e ait tanımı 12", "Gomlek2.jpg", true, false, null, "Uzun Kollu Gömlek", 150m, "XS", 5, 2 },
                    { 13, 1, 5, 4, new DateTime(2022, 6, 17, 8, 15, 15, 440, DateTimeKind.Local).AddTicks(7817), "Kullanıcının ürün e ait tanımı 13", "Kazak2.jpg", true, false, null, "Kışlık Kazak Boğazlı", 150m, "S", 6, 3 },
                    { 14, 1, 6, 5, new DateTime(2022, 6, 17, 8, 15, 15, 440, DateTimeKind.Local).AddTicks(7818), "Kullanıcının ürün e ait tanımı 14", "Pantolon2.jpg", true, false, null, "Yazlık Pantolon ", 150m, "M", 7, 4 },
                    { 15, 1, 7, 6, new DateTime(2022, 6, 17, 8, 15, 15, 440, DateTimeKind.Local).AddTicks(7820), "Kullanıcının ürün e ait tanımı 15", "Ceket2.jpg", true, false, null, "Basic Ceket", 150m, "L", 1, 5 },
                    { 16, 1, 8, 7, new DateTime(2022, 6, 17, 8, 15, 15, 440, DateTimeKind.Local).AddTicks(7821), "Kullanıcının ürün e ait tanımı 16", "Sort2.jpg", true, false, null, "Spor Şortu", 150m, "XL", 2, 1 },
                    { 17, 1, 1, 8, new DateTime(2022, 6, 17, 8, 15, 15, 440, DateTimeKind.Local).AddTicks(7822), "Kullanıcının ürün e ait tanımı 17", "ayakkabi3.jpg", true, false, null, "Koşu Ayakkabısı", 150m, "XXL", 3, 2 },
                    { 18, 1, 2, 9, new DateTime(2022, 6, 17, 8, 15, 15, 440, DateTimeKind.Local).AddTicks(7824), "Kullanıcının ürün e ait tanımı 18", "Tisort3.jpg", true, false, null, "Termal Tişört", 150m, "XS", 4, 3 },
                    { 19, 1, 3, 1, new DateTime(2022, 6, 17, 8, 15, 15, 440, DateTimeKind.Local).AddTicks(7825), "Kullanıcının ürün e ait tanımı 19", "Kot3.jpg", true, false, null, "Likralı Kot", 150m, "S", 5, 4 },
                    { 20, 1, 4, 2, new DateTime(2022, 6, 17, 8, 15, 15, 440, DateTimeKind.Local).AddTicks(7827), "Kullanıcının ürün e ait tanımı 20", "Gomlek3.jpg", true, false, null, "Takım Gömleği", 150m, "M", 6, 5 },
                    { 21, 1, 5, 3, new DateTime(2022, 6, 17, 8, 15, 15, 440, DateTimeKind.Local).AddTicks(7829), "Kullanıcının ürün e ait tanımı 21", "Kazak3.jpg", true, false, null, "V Yaka Kazak", 150m, "L", 7, 1 },
                    { 22, 1, 6, 4, new DateTime(2022, 6, 17, 8, 15, 15, 440, DateTimeKind.Local).AddTicks(7830), "Kullanıcının ürün e ait tanımı 22", "Pantolon3.jpg", true, false, null, "Kumaş Pantolon", 150m, "XL", 1, 2 },
                    { 23, 1, 7, 5, new DateTime(2022, 6, 17, 8, 15, 15, 440, DateTimeKind.Local).AddTicks(7832), "Kullanıcının ürün e ait tanımı 23", "Ceket3.jpg", true, false, null, "Blazer Ceket", 150m, "XXL", 2, 3 },
                    { 24, 1, 8, 6, new DateTime(2022, 6, 17, 8, 15, 15, 440, DateTimeKind.Local).AddTicks(7833), "Kullanıcının ürün e ait tanımı 24", "Sort3.jpg", true, false, null, "Koşu Şortu", 150m, "XS", 3, 4 },
                    { 25, 1, 1, 7, new DateTime(2022, 6, 17, 8, 15, 15, 440, DateTimeKind.Local).AddTicks(7834), "Kullanıcının ürün e ait tanımı 25", "ayakkabi4.jpg", true, false, null, "Sert Kış Botu", 150m, "S", 4, 5 },
                    { 26, 1, 2, 8, new DateTime(2022, 6, 17, 8, 15, 15, 440, DateTimeKind.Local).AddTicks(7836), "Kullanıcının ürün e ait tanımı 26", "Tisort4.jpg", true, false, null, "Polo Yaka Tişört", 150m, "M", 5, 1 },
                    { 27, 1, 3, 9, new DateTime(2022, 6, 17, 8, 15, 15, 440, DateTimeKind.Local).AddTicks(7837), "Kullanıcının ürün e ait tanımı 27", "Kot4.jpg", true, false, null, "İspanyol Paça Kot", 150m, "L", 6, 2 },
                    { 28, 1, 4, 1, new DateTime(2022, 6, 17, 8, 15, 15, 440, DateTimeKind.Local).AddTicks(7841), "Kullanıcının ürün e ait tanımı 28", "Gomlek4.jpg", true, false, null, "Kısa Kollu Gömlek", 150m, "XL", 7, 3 }
                });

            migrationBuilder.InsertData(
                table: "Offers",
                columns: new[] { "Id", "CreatedDate", "LastModifiedDate", "OfferApproved", "OfferPrice", "ProductId", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 6, 17, 8, 15, 15, 440, DateTimeKind.Local).AddTicks(7955), null, false, 150, 1, 2 },
                    { 2, new DateTime(2022, 6, 17, 8, 15, 15, 440, DateTimeKind.Local).AddTicks(7957), null, false, 155, 2, 1 },
                    { 3, new DateTime(2022, 6, 17, 8, 15, 15, 440, DateTimeKind.Local).AddTicks(7958), null, false, 160, 3, 4 },
                    { 4, new DateTime(2022, 6, 17, 8, 15, 15, 440, DateTimeKind.Local).AddTicks(7959), null, false, 165, 4, 3 },
                    { 5, new DateTime(2022, 6, 17, 8, 15, 15, 440, DateTimeKind.Local).AddTicks(7960), null, false, 170, 5, 7 },
                    { 6, new DateTime(2022, 6, 17, 8, 15, 15, 440, DateTimeKind.Local).AddTicks(7961), null, false, 175, 6, 5 },
                    { 7, new DateTime(2022, 6, 17, 8, 15, 15, 440, DateTimeKind.Local).AddTicks(7962), null, false, 180, 7, 6 },
                    { 8, new DateTime(2022, 6, 17, 8, 15, 15, 440, DateTimeKind.Local).AddTicks(7962), null, false, 185, 8, 2 },
                    { 9, new DateTime(2022, 6, 17, 8, 15, 15, 440, DateTimeKind.Local).AddTicks(7963), null, false, 190, 9, 1 },
                    { 10, new DateTime(2022, 6, 17, 8, 15, 15, 440, DateTimeKind.Local).AddTicks(7964), null, false, 150, 10, 4 },
                    { 11, new DateTime(2022, 6, 17, 8, 15, 15, 440, DateTimeKind.Local).AddTicks(7965), null, false, 155, 11, 3 },
                    { 12, new DateTime(2022, 6, 17, 8, 15, 15, 440, DateTimeKind.Local).AddTicks(8011), null, false, 160, 12, 7 },
                    { 13, new DateTime(2022, 6, 17, 8, 15, 15, 440, DateTimeKind.Local).AddTicks(8013), null, false, 165, 13, 5 },
                    { 14, new DateTime(2022, 6, 17, 8, 15, 15, 440, DateTimeKind.Local).AddTicks(8013), null, false, 170, 14, 6 },
                    { 15, new DateTime(2022, 6, 17, 8, 15, 15, 440, DateTimeKind.Local).AddTicks(8014), null, false, 175, 15, 2 },
                    { 16, new DateTime(2022, 6, 17, 8, 15, 15, 440, DateTimeKind.Local).AddTicks(8015), null, false, 180, 16, 1 },
                    { 17, new DateTime(2022, 6, 17, 8, 15, 15, 440, DateTimeKind.Local).AddTicks(8016), null, false, 185, 17, 4 },
                    { 18, new DateTime(2022, 6, 17, 8, 15, 15, 440, DateTimeKind.Local).AddTicks(8017), null, false, 190, 18, 3 },
                    { 19, new DateTime(2022, 6, 17, 8, 15, 15, 440, DateTimeKind.Local).AddTicks(8017), null, false, 130, 19, 7 },
                    { 20, new DateTime(2022, 6, 17, 8, 15, 15, 440, DateTimeKind.Local).AddTicks(8018), null, false, 120, 20, 5 },
                    { 21, new DateTime(2022, 6, 17, 8, 15, 15, 440, DateTimeKind.Local).AddTicks(8019), null, false, 150, 21, 6 },
                    { 22, new DateTime(2022, 6, 17, 8, 15, 15, 440, DateTimeKind.Local).AddTicks(8020), null, false, 155, 22, 2 },
                    { 23, new DateTime(2022, 6, 17, 8, 15, 15, 440, DateTimeKind.Local).AddTicks(8021), null, false, 160, 23, 1 },
                    { 24, new DateTime(2022, 6, 17, 8, 15, 15, 440, DateTimeKind.Local).AddTicks(8023), null, false, 165, 24, 4 },
                    { 25, new DateTime(2022, 6, 17, 8, 15, 15, 440, DateTimeKind.Local).AddTicks(8023), null, false, 170, 26, 3 },
                    { 26, new DateTime(2022, 6, 17, 8, 15, 15, 440, DateTimeKind.Local).AddTicks(8024), null, false, 175, 26, 7 },
                    { 27, new DateTime(2022, 6, 17, 8, 15, 15, 440, DateTimeKind.Local).AddTicks(8025), null, false, 180, 27, 5 },
                    { 28, new DateTime(2022, 6, 17, 8, 15, 15, 440, DateTimeKind.Local).AddTicks(8026), null, false, 185, 28, 6 },
                    { 29, new DateTime(2022, 6, 17, 8, 15, 15, 440, DateTimeKind.Local).AddTicks(8027), null, false, 190, 3, 2 },
                    { 30, new DateTime(2022, 6, 17, 8, 15, 15, 440, DateTimeKind.Local).AddTicks(8027), null, false, 170, 4, 1 },
                    { 31, new DateTime(2022, 6, 17, 8, 15, 15, 440, DateTimeKind.Local).AddTicks(8028), null, false, 150, 1, 4 },
                    { 32, new DateTime(2022, 6, 17, 8, 15, 15, 440, DateTimeKind.Local).AddTicks(8029), null, false, 155, 2, 3 },
                    { 33, new DateTime(2022, 6, 17, 8, 15, 15, 440, DateTimeKind.Local).AddTicks(8030), null, false, 160, 6, 7 },
                    { 34, new DateTime(2022, 6, 17, 8, 15, 15, 440, DateTimeKind.Local).AddTicks(8031), null, false, 165, 7, 5 },
                    { 35, new DateTime(2022, 6, 17, 8, 15, 15, 440, DateTimeKind.Local).AddTicks(8032), null, false, 170, 5, 6 },
                    { 36, new DateTime(2022, 6, 17, 8, 15, 15, 440, DateTimeKind.Local).AddTicks(8032), null, false, 175, 10, 2 },
                    { 37, new DateTime(2022, 6, 17, 8, 15, 15, 440, DateTimeKind.Local).AddTicks(8033), null, false, 180, 11, 1 },
                    { 38, new DateTime(2022, 6, 17, 8, 15, 15, 440, DateTimeKind.Local).AddTicks(8034), null, false, 185, 8, 4 },
                    { 39, new DateTime(2022, 6, 17, 8, 15, 15, 440, DateTimeKind.Local).AddTicks(8035), null, false, 190, 9, 3 },
                    { 40, new DateTime(2022, 6, 17, 8, 15, 15, 440, DateTimeKind.Local).AddTicks(8036), null, false, 150, 13, 7 },
                    { 41, new DateTime(2022, 6, 17, 8, 15, 15, 440, DateTimeKind.Local).AddTicks(8036), null, false, 155, 14, 5 },
                    { 42, new DateTime(2022, 6, 17, 8, 15, 15, 440, DateTimeKind.Local).AddTicks(8037), null, false, 160, 12, 6 }
                });

            migrationBuilder.InsertData(
                table: "Offers",
                columns: new[] { "Id", "CreatedDate", "LastModifiedDate", "OfferApproved", "OfferPrice", "ProductId", "UserId" },
                values: new object[,]
                {
                    { 43, new DateTime(2022, 6, 17, 8, 15, 15, 440, DateTimeKind.Local).AddTicks(8038), null, false, 165, 17, 2 },
                    { 44, new DateTime(2022, 6, 17, 8, 15, 15, 440, DateTimeKind.Local).AddTicks(8039), null, false, 170, 18, 1 },
                    { 45, new DateTime(2022, 6, 17, 8, 15, 15, 440, DateTimeKind.Local).AddTicks(8041), null, false, 175, 15, 4 },
                    { 46, new DateTime(2022, 6, 17, 8, 15, 15, 440, DateTimeKind.Local).AddTicks(8042), null, false, 180, 16, 3 },
                    { 47, new DateTime(2022, 6, 17, 8, 15, 15, 440, DateTimeKind.Local).AddTicks(8043), null, false, 185, 20, 7 },
                    { 48, new DateTime(2022, 6, 17, 8, 15, 15, 440, DateTimeKind.Local).AddTicks(8044), null, false, 190, 21, 5 },
                    { 49, new DateTime(2022, 6, 17, 8, 15, 15, 440, DateTimeKind.Local).AddTicks(8044), null, false, 150, 19, 6 },
                    { 50, new DateTime(2022, 6, 17, 8, 15, 15, 440, DateTimeKind.Local).AddTicks(8045), null, false, 155, 24, 1 },
                    { 51, new DateTime(2022, 6, 17, 8, 15, 15, 440, DateTimeKind.Local).AddTicks(8046), null, false, 160, 26, 2 },
                    { 52, new DateTime(2022, 6, 17, 8, 15, 15, 440, DateTimeKind.Local).AddTicks(8047), null, false, 165, 22, 4 },
                    { 53, new DateTime(2022, 6, 17, 8, 15, 15, 440, DateTimeKind.Local).AddTicks(8048), null, false, 170, 23, 3 },
                    { 54, new DateTime(2022, 6, 17, 8, 15, 15, 440, DateTimeKind.Local).AddTicks(8049), null, false, 175, 27, 7 },
                    { 55, new DateTime(2022, 6, 17, 8, 15, 15, 440, DateTimeKind.Local).AddTicks(8049), null, false, 180, 28, 5 },
                    { 56, new DateTime(2022, 6, 17, 8, 15, 15, 440, DateTimeKind.Local).AddTicks(8050), null, false, 185, 26, 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_ProductId",
                table: "Offers",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_UserId",
                table: "Offers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandId",
                table: "Products",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ColorId",
                table: "Products",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_UserId",
                table: "Products",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_UsingStatusId",
                table: "Products",
                column: "UsingStatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Offers");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Colors");

            migrationBuilder.DropTable(
                name: "UsingStatuses");
        }
    }
}
