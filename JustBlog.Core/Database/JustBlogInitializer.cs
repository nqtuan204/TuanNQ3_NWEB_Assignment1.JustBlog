using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JustBlog.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace JustBlog.Core.Database
{
    public static class JustBlogInitializer
    {
        public static void Seed(this ModelBuilder builder)
        {
            builder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "Friends",
                    UrlSlug = "friends",
                    Description = "Funny story about friends"
                },
                new Category
                {
                    Id = 2,
                    Name = "Family",
                    UrlSlug = "family",
                    Description = "Funny story about family"
                },
                new Category
                {
                    Id = 3,
                    Name = "Others",
                    UrlSlug = "others",
                    Description = "Other funny story"
                },
                new Category
                {
                    Id = 4,
                    Name = "Daily life",
                    UrlSlug = "daily-life",
                    Description = "Funny story about daily life"
                },
                new Category
                {
                    Id = 5,
                    Name = "Animal",
                    UrlSlug = "animal",
                    Description = "Funny story about animal"
                }
            );

            builder.Entity<Post>().HasData(
                new Post
                {
                    Id = 1,
                    Title = "Money And Friends",
                    UrlSlug = "money-and-friends",
                    ShortDescription = "Funny story about friends",
                    PostContent = "\"Since he lost his money, half his friends don't know him any more\"\r\n\r\n\"And the other half ?\"\r\n\r\n\"They don't know yet that has lost it\"",
                    PostedOn = new DateTime(2022, 10, 25),
                    Published = true,
                    CategoryId = 1,
                    RateCount = 23,
                    TotalRate = 100,
                    ViewCount = 150
                },
                new Post
                {
                    Id = 2,
                    Title = "Father Wants To Go To Bed",
                    UrlSlug = "father-wants-to-go-to-bed",
                    ShortDescription = "Funny story about family",
                    PostContent = "Next-door Neighbor's Little Boy :\r\n\r\n\"Father say could you lend him your cassette player for tonight ?\"\r\n\r\nHeavy - Metal Enthusiast :\r\n\r\n\"Have you a party on ?\"\r\n\r\nLittle Boy : \"Oh, no. Father only wants to go to bed",
                    PostedOn = new DateTime(2022, 10, 25),
                    Published = true,
                    CategoryId = 2,
                    RateCount = 32,
                    TotalRate = 100,
                    ViewCount = 250
                },
                new Post
                {
                    Id = 3,
                    Title = "The river isn't deep",
                    UrlSlug = "the-river-isn-t-deep",
                    ShortDescription = "Another Funny story",
                    PostContent = "A stranger on horse back came to a river with which he was unfamiliar. The traveller asked a youngster if it was deep.\r\n\r\n\"No\", replied the boy, and the rider started to cross, but soon found that he and his horse had to swim for their lives.\r\n\r\nWhen the traveller reached the other side he turned and shouted : \"I thought you said it wasn't deep ?\"\r\n\r\n\"It isn't\", was the boy's reply : \"it only takes grandfather's ducks up to their middles !\"",
                    PostedOn = new DateTime(2022, 10, 25),
                    Published = true,
                    CategoryId = 3,
                    RateCount = 15,
                    TotalRate = 100,
                    ViewCount = 100
                },
                new Post
                {
                    Id = 4,
                    Title = "My Daughter's Music Lessons",
                    UrlSlug = "my-daughter-s-music-lessons",
                    ShortDescription = "Funny story about family",
                    PostContent = "\"My daughter's music lessons are a fortune to me ?\"\r\n\r\n\"How is that ?\"\r\n\r\n\"They enabled me to buy the neighbors' houses at half price\"",
                    PostedOn = new DateTime(2022, 10, 25),
                    Published = true,
                    CategoryId = 2,
                    RateCount = 29,
                    TotalRate = 100,
                    ViewCount = 100
                },
                new Post
                {
                    Id = 5,
                    Title = "A Policeman And A Reporter",
                    UrlSlug = "a-policeman-and-a-reporter",
                    ShortDescription = "Funny story about daily life",
                    PostContent = "Country Policeman (at the scene of murder) : \"You can't come in here\"\r\n\r\nReporter : \"But I've been sent to do the murder\"\r\n\r\nCountry Policeman : \"Well, you're too late, the murder's been done\".",
                    PostedOn = new DateTime(2022, 10, 25),
                    Published = true,
                    CategoryId = 4,
                    RateCount = 29,
                    TotalRate = 100,
                    ViewCount = 100
                },
                new Post
                {
                    Id = 6,
                    Title = "A Cow Grazing",
                    UrlSlug = "a-cow-grazing",
                    ShortDescription = "Funny story about animal",
                    PostContent = "Artist : \"That, sir, is a cow grazing\"\r\n\r\nVisitor : \"Where is the grass ?\"\r\n\r\nArtist : \"The cow has eaten it\"\r\n\r\nVisitor : \"But where is the cow ?\"\r\n\r\nArtist : \"You don't suppose she'd be fool enough to stay there after she'd eaten all the grass, do you ?\"",
                    PostedOn = new DateTime(2022, 10, 25),
                    Published = true,
                    CategoryId = 5,
                    RateCount = 29,
                    TotalRate = 100,
                    ViewCount = 100
                },
                new Post
                {
                    Id = 7,
                    Title = "Let's Work Together",
                    UrlSlug = "let-s-work-together",
                    ShortDescription = "Funny story about daily life",
                    PostContent = "Artist : \"That, sir, is a cow grazing\"\r\n\r\nVisitor : \"Where is the grass ?\"\r\n\r\nArtist : \"The cow has eaten it\"\r\n\r\nVisitor : \"But where is the cow ?\"\r\n\r\nArtist : \"You don't suppose she'd be fool enough to stay there after she'd eaten all the grass, do you ?\"",
                    PostedOn = new DateTime(2022, 10, 25),
                    Published = true,
                    CategoryId = 4,
                    RateCount = 29,
                    TotalRate = 100,
                    ViewCount = 100
                },
                new Post
                {
                    Id = 8,
                    Title = "The French People Have Difficulty",
                    UrlSlug = "the-french-people-have-difficulty",
                    ShortDescription = "Funny story about daily life",
                    PostContent = "\"Did you have any difficulty with your French in Paris ?\"\r\n\r\n\"No, but the French people did\"",
                    PostedOn = new DateTime(2022, 10, 25),
                    Published = true,
                    CategoryId = 4,
                    RateCount = 29,
                    TotalRate = 100,
                    ViewCount = 100
                },
                new Post
                {
                    Id = 9,
                    Title = "Great Mystery",
                    UrlSlug = "great-mystery",
                    ShortDescription = "Funny story about daily life",
                    PostContent = "Newsboy : \"Great mystery! Fifty victims! Paper, mister ?\"\r\n\r\nPasserby : \"Here boy, I'll take one\" (After reading a moment) \"Say, boy, there's nothing of the kind in this paper. Where is it ?\"\r\n\r\nNewsboy : \"That's the mystery, sir. You're the fifty first victim\".",
                    PostedOn = new DateTime(2022, 10, 25),
                    Published = true,
                    CategoryId = 4,
                    RateCount = 29,
                    TotalRate = 100,
                    ViewCount = 100
                },
                new Post
                {
                    Id = 10,
                    Title = "Why Do They Have French Lesson?",
                    UrlSlug = "why-do-they-have-french-lesson",
                    ShortDescription = "Funny story about daily life",
                    PostContent = "\"What's the idea of the Greens having French lessons ?\"\r\n\r\n\"They have adopted a French baby, and want to understand what she says when she begins to talk\".",
                    PostedOn = new DateTime(2022, 10, 25),
                    Published = true,
                    CategoryId = 4,
                    RateCount = 29,
                    TotalRate = 100,
                    ViewCount = 100
                },
                new Post
                {
                    Id = 11,
                    Title = "WHERE IS MY WHEELCHAIR?",
                    UrlSlug = "where-is-my-wheelchair",
                    ShortDescription = "Funny story about daily life",
                    PostContent = "A man is at the bar, really drunk. Some guys decide to be good samaritans and get him home.\r\n\r\nSo they pick him up off the floor, and drag him out the door. On the way to the car, he falls down three times. When they get to his house, they help him out of the car and, he falls down four more times.\r\n\r\nThey ring the bell, and one says, \"Here s your husband!\"\r\n\r\nThe man s wife says, \"Where the hell is his wheelchair?\"",
                    PostedOn = new DateTime(2022, 10, 25),
                    Published = true,
                    CategoryId = 4,
                    RateCount = 29,
                    TotalRate = 100,
                    ViewCount = 100
                }
            );

            builder.Entity<Tag>().HasData(
                new Tag
                {
                    Id = 1,
                    Name = "Money",
                    UrlSlug = "money",
                    Description = "Funny story about money",
                    Count = 1
                },
                new Tag
                {
                    Id = 2,
                    Name = "Friends",
                    UrlSlug = "friends",
                    Description = "Funny story about friends",
                    Count = 2
                },
                new Tag
                {
                    Id = 3,
                    Name = "Father",
                    UrlSlug = "father",
                    Description = "Funny story about father",
                    Count = 3
                },
                new Tag
                {
                    Id = 4,
                    Name = "Family",
                    UrlSlug = "family",
                    Description = "Funny story about family",
                    Count = 4
                },
                new Tag
                {
                    Id = 5,
                    Name = "Natural",
                    UrlSlug = "natural",
                    Description = "Funny story about natural",
                    Count = 5
                },
                new Tag
                {
                    Id = 6,
                    Name = "Music",
                    UrlSlug = "music",
                    Description = "Funny story about music",
                    Count = 6
                },
                new Tag
                {
                    Id = 7,
                    Name = "Human",
                    UrlSlug = "human",
                    Description = "Funny story about human",
                    Count = 7
                },
                new Tag
                {
                    Id = 8,
                    Name = "Policeman",
                    UrlSlug = "policeman",
                    Description = "Funny story about policeman",
                    Count = 8
                },
                new Tag
                {
                    Id = 9,
                    Name = "Animal",
                    UrlSlug = "animal",
                    Description = "Funny story about animal",
                    Count = 9
                },
                new Tag
                {
                    Id = 10,
                    Name = "Office",
                    UrlSlug = "office",
                    Description = "Funny story about office",
                    Count = 10
                },
                new Tag
                {
                    Id = 11,
                    Name = "Mistery",
                    UrlSlug = "mistery",
                    Description = "Funny story about mistery",
                    Count = 11
                },
                new Tag
                {
                    Id = 12,
                    Name = "French",
                    UrlSlug = "mistery",
                    Description = "Funny story about French",
                    Count = 12
                }

            );

            builder.Entity<PostTagMap>().HasData(
                new PostTagMap() { PostId = 1, TagId = 1 },
                new PostTagMap() { PostId = 1, TagId = 2 },
                new PostTagMap() { PostId = 2, TagId = 3 },
                new PostTagMap() { PostId = 2, TagId = 4 },
                new PostTagMap() { PostId = 3, TagId = 5 },
                new PostTagMap() { PostId = 4, TagId = 6 },
                new PostTagMap() { PostId = 5, TagId = 7 },
                new PostTagMap() { PostId = 5, TagId = 8 },
                new PostTagMap() { PostId = 6, TagId = 9 },
                new PostTagMap() { PostId = 7, TagId = 10 },
                new PostTagMap() { PostId = 7, TagId = 7 },
                new PostTagMap() { PostId = 8, TagId = 7 },
                new PostTagMap() { PostId = 9, TagId = 11 },
                new PostTagMap() { PostId = 10, TagId = 12 },
                new PostTagMap() { PostId = 10, TagId = 7 },
                new PostTagMap() { PostId = 11, TagId = 7 }
            );

            builder.Entity<Comment>().HasData(
                new Comment()
                {
                    Id = 1,
                    CommentHeader = "Comment header 1",
                    CommentText = "Comment Text 1",
                    CommentTime = new DateTime(2022, 10, 28, 10, 10, 10),
                    Email = "Email1@gmail.com",
                    Name = "Name 1",
                    PostId = 1
                },
                new Comment()
                {
                    Id = 2,
                    CommentHeader = "Comment header 2",
                    CommentText = "Comment Text 2",
                    CommentTime = new DateTime(2022, 10, 28, 10, 10, 10),
                    Email = "Email2@gmail.com",
                    Name = "Name 2",
                    PostId = 1
                },
                new Comment()
                {
                    Id = 3,
                    CommentHeader = "Comment header 3",
                    CommentText = "Comment Text 3",
                    CommentTime = new DateTime(2022, 10, 28, 10, 10, 10),
                    Email = "Email3@gmail.com",
                    Name = "Name 3",
                    PostId = 2
                },
                new Comment()
                {
                    Id = 4,
                    CommentHeader = "Comment header 4",
                    CommentText = "Comment Text 4",
                    CommentTime = new DateTime(2022, 10, 28, 10, 10, 10),
                    Email = "Email4@gmail.com",
                    Name = "Name 4",
                    PostId = 1
                }
            );

            var roles = new IdentityRole<Guid>[]
            {
                new IdentityRole<Guid>
                {
                    Id = Guid.NewGuid(),
                    Name = "Blog Owner",
                    NormalizedName = "BLOG OWNER"
                },
                new IdentityRole<Guid>
                {
                    Id = Guid.NewGuid(),
                    Name = "Contributor",
                    NormalizedName = "CONTRIBUTOR"
                },
                new IdentityRole<Guid>
                {
                    Id = Guid.NewGuid(),
                    Name = "User",
                    NormalizedName = "USER"
                }
            };

            builder.Entity<IdentityRole<Guid>>().HasData(
                roles
            );

            var hasher = new PasswordHasher<AppUser>();

            var users = new AppUser[]
            {
                new AppUser
                {
                    Id = Guid.NewGuid(),
                    Age = 26,
                    AboutMe = "Nothing to say",
                    UserName = "nqtuan204@gmail.com",
                    NormalizedUserName = "NQTUAN204@GMAIL.COM",
                    Email = "nqtuan204@gmail.com",
                    NormalizedEmail = "NQTUAN204@GMAIL.COM",
                    EmailConfirmed = true,
                    AccessFailedCount = 0,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    PasswordHash = hasher.HashPassword(null, "Matkhau1234!")
                },
                new AppUser
                {
                    Id = Guid.NewGuid(),
                    Age = 26,
                    AboutMe = "Nothing to say",
                    UserName = "nqtuan205@gmail.com",
                    NormalizedUserName = "NQTUAN205@GMAIL.COM",
                    Email = "nqtuan205@gmail.com",
                    NormalizedEmail = "NQTUAN205@GMAIL.COM",
                    EmailConfirmed = true,
                    AccessFailedCount = 0,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    PasswordHash = hasher.HashPassword(null, "Matkhau1234!")
                },
                new AppUser
                {
                    Id = Guid.NewGuid(),
                    Age = 26,
                    AboutMe = "Nothing to say",
                    UserName = "nqtuan206@gmail.com",
                    NormalizedUserName = "NQTUAN206@GMAIL.COM",
                    Email = "nqtuan206@gmail.com",
                    NormalizedEmail = "NQTUAN206@GMAIL.COM",
                    EmailConfirmed = true,
                    AccessFailedCount = 0,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    PasswordHash = hasher.HashPassword(null, "Matkhau1234!")
                },
            };

            builder.Entity<AppUser>().HasData(users);

            builder.Entity<IdentityUserRole<Guid>>().HasData(
                new IdentityUserRole<Guid>
                {
                    RoleId = roles[0].Id,
                    UserId = users[0].Id
                },
                new IdentityUserRole<Guid>
                {
                    RoleId = roles[1].Id,
                    UserId = users[1].Id
                },
                new IdentityUserRole<Guid>
                {
                    RoleId = roles[2].Id,
                    UserId = users[2].Id
                }
            );
        }
    }
}