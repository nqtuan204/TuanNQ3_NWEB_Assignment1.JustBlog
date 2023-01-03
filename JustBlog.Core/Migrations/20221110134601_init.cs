using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JustBlog.Core.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    UrlSlug = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    UrlSlug = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    AboutMe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
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
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortDescription = table.Column<string>(name: "Short Description", type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    PostContent = table.Column<string>(name: "Post Content", type: "nvarchar(max)", nullable: false),
                    UrlSlug = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Published = table.Column<bool>(type: "bit", nullable: false),
                    ViewCount = table.Column<int>(type: "int", nullable: false),
                    RateCount = table.Column<int>(type: "int", nullable: false),
                    TotalRate = table.Column<int>(type: "int", nullable: false),
                    PostedOn = table.Column<DateTime>(name: "Posted On", type: "datetime2", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostId = table.Column<int>(type: "int", nullable: false),
                    CommentHeader = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommentText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommentTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PostTagMaps",
                columns: table => new
                {
                    PostId = table.Column<int>(type: "int", nullable: false),
                    TagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostTagMaps", x => new { x.TagId, x.PostId });
                    table.ForeignKey(
                        name: "FK_PostTagMaps_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostTagMaps_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name", "UrlSlug" },
                values: new object[,]
                {
                    { 1, "Funny story about friends", "Friends", "friends" },
                    { 2, "Funny story about family", "Family", "family" },
                    { 3, "Other funny story", "Others", "others" },
                    { 4, "Funny story about daily life", "Daily life", "daily-life" },
                    { 5, "Funny story about animal", "Animal", "animal" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("913f9729-54ad-496e-bf74-029be9537909"), "19873209-d250-4b98-bf6a-53dae23a954d", "Blog Owner", "BLOG OWNER" },
                    { new Guid("d7bc1c00-3eb2-4db9-bb17-c18c1cde4443"), "5106789a-fffd-4439-957d-c2fde2aaeaf1", "Contributor", "CONTRIBUTOR" },
                    { new Guid("f8853c24-2395-40b2-a7a9-47e46190fc4c"), "5b509e35-c271-4751-934d-45863ab8a398", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Count", "Description", "Name", "UrlSlug" },
                values: new object[,]
                {
                    { 1, 1, "Funny story about money", "Money", "money" },
                    { 2, 2, "Funny story about friends", "Friends", "friends" },
                    { 3, 3, "Funny story about father", "Father", "father" },
                    { 4, 4, "Funny story about family", "Family", "family" },
                    { 5, 5, "Funny story about natural", "Natural", "natural" },
                    { 6, 6, "Funny story about music", "Music", "music" },
                    { 7, 7, "Funny story about human", "Human", "human" },
                    { 8, 8, "Funny story about policeman", "Policeman", "policeman" },
                    { 9, 9, "Funny story about animal", "Animal", "animal" },
                    { 10, 10, "Funny story about office", "Office", "office" },
                    { 11, 11, "Funny story about mistery", "Mistery", "mistery" },
                    { 12, 12, "Funny story about French", "French", "mistery" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AboutMe", "AccessFailedCount", "Age", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("1eee39a2-ab38-456a-b8e3-4145b5ecb52e"), "Nothing to say", 0, 26, "b59f9e92-3f77-448c-b54d-75384b5854d1", "nqtuan206@gmail.com", true, false, null, "NQTUAN206@GMAIL.COM", "NQTUAN206@GMAIL.COM", "AQAAAAEAACcQAAAAEB7b5G0oCrhOOSPvUJme7CyQk2J9Y55aYGEuoubDbzF+I88meP+tT+crYTNWH1W9CA==", null, false, "47d09324-54e3-4b9a-a6e6-d42ebef5c360", false, "nqtuan206@gmail.com" },
                    { new Guid("513e04fc-760a-48c5-aef3-8bd3b2db2733"), "Nothing to say", 0, 26, "5d87dfc2-275c-4ef8-9a8a-e3fa1b2883d8", "nqtuan205@gmail.com", true, false, null, "NQTUAN205@GMAIL.COM", "NQTUAN205@GMAIL.COM", "AQAAAAEAACcQAAAAEEqJYNz7waG8MIRh9jEySWPQca/zMHQP8cz1haEef1YhH6NwWo36IZTDS0pWlDaQuQ==", null, false, "95fef7f7-f26d-4ae8-8e3d-6f0e325a0eb0", false, "nqtuan205@gmail.com" },
                    { new Guid("52c378ff-b013-4311-901f-ed2484895c41"), "Nothing to say", 0, 26, "c0ebe7be-3704-4798-9d64-759572ffda92", "nqtuan204@gmail.com", true, false, null, "NQTUAN204@GMAIL.COM", "NQTUAN204@GMAIL.COM", "AQAAAAEAACcQAAAAEMSmK+f+0s9pKrxuhaTUhzpF6/XGoBbVGnY57u3XpzwP8lxoz8E50tU9JCpo728ZAw==", null, false, "1ceaceaf-71ef-471b-ac3e-c5eeaafc77b8", false, "nqtuan204@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "CategoryId", "Modified", "Post Content", "Posted On", "Published", "RateCount", "Short Description", "Title", "TotalRate", "UrlSlug", "ViewCount" },
                values: new object[,]
                {
                    { 1, 1, null, "\"Since he lost his money, half his friends don't know him any more\"\r\n\r\n\"And the other half ?\"\r\n\r\n\"They don't know yet that has lost it\"", new DateTime(2022, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 23, "Funny story about friends", "Money And Friends", 100, "money-and-friends", 150 },
                    { 2, 2, null, "Next-door Neighbor's Little Boy :\r\n\r\n\"Father say could you lend him your cassette player for tonight ?\"\r\n\r\nHeavy - Metal Enthusiast :\r\n\r\n\"Have you a party on ?\"\r\n\r\nLittle Boy : \"Oh, no. Father only wants to go to bed", new DateTime(2022, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 32, "Funny story about family", "Father Wants To Go To Bed", 100, "father-wants-to-go-to-bed", 250 },
                    { 3, 3, null, "A stranger on horse back came to a river with which he was unfamiliar. The traveller asked a youngster if it was deep.\r\n\r\n\"No\", replied the boy, and the rider started to cross, but soon found that he and his horse had to swim for their lives.\r\n\r\nWhen the traveller reached the other side he turned and shouted : \"I thought you said it wasn't deep ?\"\r\n\r\n\"It isn't\", was the boy's reply : \"it only takes grandfather's ducks up to their middles !\"", new DateTime(2022, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 15, "Another Funny story", "The river isn't deep", 100, "the-river-isn-t-deep", 100 },
                    { 4, 2, null, "\"My daughter's music lessons are a fortune to me ?\"\r\n\r\n\"How is that ?\"\r\n\r\n\"They enabled me to buy the neighbors' houses at half price\"", new DateTime(2022, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 29, "Funny story about family", "My Daughter's Music Lessons", 100, "my-daughter-s-music-lessons", 100 },
                    { 5, 4, null, "Country Policeman (at the scene of murder) : \"You can't come in here\"\r\n\r\nReporter : \"But I've been sent to do the murder\"\r\n\r\nCountry Policeman : \"Well, you're too late, the murder's been done\".", new DateTime(2022, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 29, "Funny story about daily life", "A Policeman And A Reporter", 100, "a-policeman-and-a-reporter", 100 },
                    { 6, 5, null, "Artist : \"That, sir, is a cow grazing\"\r\n\r\nVisitor : \"Where is the grass ?\"\r\n\r\nArtist : \"The cow has eaten it\"\r\n\r\nVisitor : \"But where is the cow ?\"\r\n\r\nArtist : \"You don't suppose she'd be fool enough to stay there after she'd eaten all the grass, do you ?\"", new DateTime(2022, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 29, "Funny story about animal", "A Cow Grazing", 100, "a-cow-grazing", 100 },
                    { 7, 4, null, "Artist : \"That, sir, is a cow grazing\"\r\n\r\nVisitor : \"Where is the grass ?\"\r\n\r\nArtist : \"The cow has eaten it\"\r\n\r\nVisitor : \"But where is the cow ?\"\r\n\r\nArtist : \"You don't suppose she'd be fool enough to stay there after she'd eaten all the grass, do you ?\"", new DateTime(2022, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 29, "Funny story about daily life", "Let's Work Together", 100, "let-s-work-together", 100 },
                    { 8, 4, null, "\"Did you have any difficulty with your French in Paris ?\"\r\n\r\n\"No, but the French people did\"", new DateTime(2022, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 29, "Funny story about daily life", "The French People Have Difficulty", 100, "the-french-people-have-difficulty", 100 },
                    { 9, 4, null, "Newsboy : \"Great mystery! Fifty victims! Paper, mister ?\"\r\n\r\nPasserby : \"Here boy, I'll take one\" (After reading a moment) \"Say, boy, there's nothing of the kind in this paper. Where is it ?\"\r\n\r\nNewsboy : \"That's the mystery, sir. You're the fifty first victim\".", new DateTime(2022, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 29, "Funny story about daily life", "Great Mystery", 100, "great-mystery", 100 },
                    { 10, 4, null, "\"What's the idea of the Greens having French lessons ?\"\r\n\r\n\"They have adopted a French baby, and want to understand what she says when she begins to talk\".", new DateTime(2022, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 29, "Funny story about daily life", "Why Do They Have French Lesson?", 100, "why-do-they-have-french-lesson", 100 },
                    { 11, 4, null, "A man is at the bar, really drunk. Some guys decide to be good samaritans and get him home.\r\n\r\nSo they pick him up off the floor, and drag him out the door. On the way to the car, he falls down three times. When they get to his house, they help him out of the car and, he falls down four more times.\r\n\r\nThey ring the bell, and one says, \"Here s your husband!\"\r\n\r\nThe man s wife says, \"Where the hell is his wheelchair?\"", new DateTime(2022, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 29, "Funny story about daily life", "WHERE IS MY WHEELCHAIR?", 100, "where-is-my-wheelchair", 100 }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("f8853c24-2395-40b2-a7a9-47e46190fc4c"), new Guid("1eee39a2-ab38-456a-b8e3-4145b5ecb52e") },
                    { new Guid("d7bc1c00-3eb2-4db9-bb17-c18c1cde4443"), new Guid("513e04fc-760a-48c5-aef3-8bd3b2db2733") },
                    { new Guid("913f9729-54ad-496e-bf74-029be9537909"), new Guid("52c378ff-b013-4311-901f-ed2484895c41") }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CommentHeader", "CommentText", "CommentTime", "Email", "Name", "PostId" },
                values: new object[,]
                {
                    { 1, "Comment header 1", "Comment Text 1", new DateTime(2022, 10, 28, 10, 10, 10, 0, DateTimeKind.Unspecified), "Email1@gmail.com", "Name 1", 1 },
                    { 2, "Comment header 2", "Comment Text 2", new DateTime(2022, 10, 28, 10, 10, 10, 0, DateTimeKind.Unspecified), "Email2@gmail.com", "Name 2", 1 },
                    { 3, "Comment header 3", "Comment Text 3", new DateTime(2022, 10, 28, 10, 10, 10, 0, DateTimeKind.Unspecified), "Email3@gmail.com", "Name 3", 2 },
                    { 4, "Comment header 4", "Comment Text 4", new DateTime(2022, 10, 28, 10, 10, 10, 0, DateTimeKind.Unspecified), "Email4@gmail.com", "Name 4", 1 }
                });

            migrationBuilder.InsertData(
                table: "PostTagMaps",
                columns: new[] { "PostId", "TagId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 3 },
                    { 2, 4 },
                    { 3, 5 },
                    { 4, 6 },
                    { 5, 7 },
                    { 7, 7 },
                    { 8, 7 },
                    { 10, 7 },
                    { 11, 7 },
                    { 5, 8 },
                    { 6, 9 },
                    { 7, 10 },
                    { 9, 11 },
                    { 10, 12 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_CategoryId",
                table: "Posts",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PostTagMaps_PostId",
                table: "PostTagMaps",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Roles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "PostTagMaps");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
