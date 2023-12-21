namespace FA.JustBlog.Core
{
    public class SeedData
    {
        public void Seed(JustBlogContext context)
        {
            context.Database.EnsureCreated();

            if (!context.Categories.Any())
            {
                // Add categories
                var categories = new List<Category>
                {
                    new Category
                    {
                        Name = "Technology",
                        UrlSlug = "technology",
                        Description = "Technology Blog",
                    },

                    new Category
                    {
                        Name = "Business",
                        UrlSlug = "business",
                        Description = "Business Blog",
                    },

                    new Category
                    {
                        Name = "Media",
                        UrlSlug = "media",
                        Description = "Media Blog",
                    },
                };

                context.Categories.AddRange(categories);

                // Add Posts
                var posts = new List<Post>
                {
                    new Post
                    {

                        Title = "1st post",
                        ShortDescription = "The first post",
                        PostContent = "1st content",
                        UrlSlug = "post1",
                        Published = true,
                        PostedOn = DateTime.Now,
                        Modified = DateTime.Now,
                        ViewCount = 1,
                        RateCount = 1,
                        TotalRate = 1,
                        Category = categories.Single(x => x.Name == categories[0].Name),
                    },

                    new Post
                    {
                        Title = "2nd post",
                        ShortDescription = "The second post",
                        PostContent = "2nd content",
                        UrlSlug = "post2",
                        Published = true,
                        PostedOn = DateTime.Now,
                        Modified = DateTime.Now,
                        ViewCount = 2,
                        RateCount = 2,
                        TotalRate = 2,
                        Category = categories.Single(x => x.Name == categories[0].Name),
                    },

                    new Post
                    {
                        Title = "3rd post",
                        ShortDescription = "The third post",
                        PostContent = "3rd content",
                        UrlSlug = "post3",
                        Published = true,
                        PostedOn = DateTime.Now,
                        Modified = DateTime.Now,
                        ViewCount = 2,
                        RateCount = 1,
                        TotalRate = 2,
                        Category = categories.Single(x => x.Name == categories[2].Name),
                    },

                    new Post
                    {
                        Title = "4th post",
                        ShortDescription = "The fourth post",
                        PostContent = "4th content",
                        UrlSlug = "post4",
                        Published = true,
                        PostedOn = DateTime.Now,
                        Modified = DateTime.Now,
                        ViewCount = 3,
                        RateCount = 1,
                        TotalRate = 3,
                        Category = categories.Single(x => x.Name == categories[1].Name),
                    },

                    new Post
                    {
                        Title = "5th post",
                        ShortDescription = "The fifth post",
                        PostContent = "5th content",
                        UrlSlug = "post5",
                        Published = true,
                        PostedOn = DateTime.Now,
                        Modified = DateTime.Now,
                        ViewCount = 3,
                        RateCount = 2,
                        TotalRate = 3,
                        Category = categories.Single(x => x.Name == categories[2].Name),
                    },

                    new Post
                    {
                        Title = "6th post",
                        ShortDescription = "The sixth post",
                        PostContent = "6th content",
                        UrlSlug = "post6",
                        Published = true,
                        PostedOn = DateTime.Now,
                        Modified = DateTime.Now,
                        ViewCount = 3,
                        RateCount = 3,
                        TotalRate = 3,
                        Category = categories.Single(x => x.Name == categories[1].Name),
                    },
                };

                context.Posts.AddRange(posts);

                // Add tags
                var tags = new List<Tag>
                {
                    new Tag
                    {
                        Name = "#tech",
                        UrlSlug = "technology",
                        Description = "Technology Tag",
                    },

                    new Tag
                    {
                        Name = "#business",
                        UrlSlug = "business",
                        Description = "Business Tag",
                    },

                    new Tag
                    {

                        Name = "#media",
                        UrlSlug = "media",
                        Description = "Media Tag",
                    },

                    new Tag
                    {
                        Name = "#world",
                        UrlSlug = "world",
                        Description = "World Tag",
                    },

                    new Tag
                    {
                        Name = "#local",
                        UrlSlug = "local",
                        Description = "Local Tag",
                    },
                };

                context.Tags.AddRange(tags);

                // Add PostTagMaps
                var postTagMaps = new List<PostTagMap>
                {
                    new PostTagMap
                    {
                        Post = posts[0],
                        Tag = tags[0],
                    },

                    new PostTagMap
                    {
                        Post = posts[0],
                        Tag = tags[4],
                    },

                    new PostTagMap
                    {
                        Post = posts[1],
                        Tag = tags[0],
                    },

                    new PostTagMap
                    {
                        Post = posts[1],
                        Tag = tags[3],
                    },

                    new PostTagMap
                    {
                        Post = posts[2],
                        Tag = tags[2],
                    },

                    new PostTagMap
                    {
                        Post = posts[2],
                        Tag = tags[4],
                    },

                    new PostTagMap
                    {
                        Post = posts[3],
                        Tag = tags[1],
                    },

                    new PostTagMap
                    {
                        Post = posts[3],
                        Tag = tags[3],
                    },

                    new PostTagMap
                    {
                        Post = posts[4],
                        Tag = tags[2],
                    },

                    new PostTagMap
                    {
                        Post = posts[4],
                        Tag = tags[3],
                    },

                    new PostTagMap
                    {
                        Post = posts[5],
                        Tag = tags[1],
                    },

                    new PostTagMap
                    {
                        Post = posts[5],
                        Tag = tags[4],
                    },
                };

                context.PostTagMaps.AddRange(postTagMaps);

                // Add Comments
                var comments = new List<Comment>
                {
                    new Comment
                    {
                        Name = "1st comment",
                        Email = "minh@gmail.com",
                        CommentHeader = "1st comment",
                        CommentText = "The first comment",
                        CommentTime = DateTime.Now,
                        Post = posts.Single(x => x.Title == posts[0].Title),
                    },

                    new Comment
                    {
                        Name = "2nd comment",
                        Email = "giang@gmail.com",
                        CommentHeader = "2nd comment",
                        CommentText = "The second comment",
                        CommentTime = DateTime.Now,
                        Post = posts.Single(x => x.Title == posts[1].Title),
                    },

                    new Comment
                    {
                        Name = "3rd comment",
                        Email = "duc@gmail.com",
                        CommentHeader = "3rd comment",
                        CommentText = "The third comment",
                        CommentTime = DateTime.Now,
                        Post = posts.Single(x => x.Title == posts[2].Title),
                    },

                    new Comment
                    {
                        Name = "4th comment",
                        Email = "dat@gmail.com",
                        CommentHeader = "4th comment",
                        CommentText = "The fourth comment",
                        CommentTime = DateTime.Now,
                        Post = posts.Single(x => x.Title == posts[3].Title),
                    },

                    new Comment
                    {
                        Name = "5th comment",
                        Email = "nga@gmail.com",
                        CommentHeader = "5th comment",
                        CommentText = "The fifth comment",
                        CommentTime = DateTime.Now,
                        Post = posts.Single(x => x.Title == posts[4].Title),
                    },

                    new Comment
                    {
                        Name = "6th comment",
                        Email = "hanh@gmail.com",
                        CommentHeader = "6th comment",
                        CommentText = "The sixth comment",
                        CommentTime = DateTime.Now,
                        Post = posts.Single(x => x.Title == posts[5].Title),
                    },
                };

                context.Comments.AddRange(comments);

                context.SaveChanges();
            }
        }
    }
}
