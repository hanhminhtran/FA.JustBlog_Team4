using FA.JustBlog.Core;
using FA.JustBlog.Website.Models;
using Microsoft.AspNetCore.Mvc;

namespace FA.JustBlog.Website.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostService _postService;
        private readonly ICategoryService _categoryService;
        private readonly ITagService _tagService;

        public PostController(IPostService postService, ICategoryService categoryService, ITagService tagService)
        {
            _postService = postService;
            _categoryService = categoryService;
            _tagService = tagService;
        }

        // GET: PostController
        public ActionResult Index()
        {
            var posts = _postService.GetAll();
            var postVm = new List<PostVm>();

            foreach (var post in posts)
            {
                postVm.Add(new PostVm()
                {
                    Id = post.Id,
                    Title = post.Title,
                    ShortDescription = post.ShortDescription,
                    PostContent = post.PostContent,
                    UrlSlug = post.UrlSlug,
                    Published = post.Published,
                    //PostedOn = post.PostedOn,
                    //Modified = post.Modified,
                    //ViewCount = post.ViewCount,
                    //RateCount = post.RateCount,
                    //TotalRate = post.TotalRate
                    //CategoryId = post.CategoryId
                });
            }

            return View(postVm);
        }

        // GET: PostController/Details/5
        public ActionResult Details(Guid id)
        {
            try
            {
                var post = _postService.Find(id);
                if (post != null)
                {
                    var postVm = new PostVm()
                    {
                        Id = post.Id,
                        Title = post.Title,
                        ShortDescription = post.ShortDescription,
                        PostContent = post.PostContent,
                        UrlSlug = post.UrlSlug,
                        Published = post.Published,
                        PostedOn = post.PostedOn,
                        Modified = post.Modified,
                        ViewCount = post.ViewCount,
                        RateCount = post.RateCount,
                        TotalRate = post.TotalRate,
                        //CategoryId = post.CategoryId
                    };

                    return View(postVm);
                }
            }
            catch
            {
            }
            return RedirectToAction("Index");
        }

        // GET: PostController/Create
        public ActionResult Create()
        {
            //ViewBag.Categories = GetCategoryLists();
            //ViewBag.Tags = GetTagLists();
            return View();
        }
        //private List<CategoryList> GetCategoryLists()
        //{
        //    var posts = _categoryService.GetAll();

        //    List<CategoryList> items = new List<CategoryList>();
        //    foreach (var category in posts)
        //    {
        //        items.Add(new CategoryList() { Text = category.Name, Value = category.Id.ToString() });
        //    }
        //    return items;
        //}
        //private List<TagList> GetTagLists()
        //{
        //    var tags = _tagService.GetAll();

        //    List<TagList> items = new List<TagList>();
        //    foreach (var tag in tags)
        //    {
        //        items.Add(new TagList() { Text = tag.Name, Value = tag.Id.ToString() });
        //    }
        //    return items;
        //}

        // POST: PostController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PostVm postVm)
        {
            try
            {
                var postUrlSlug = postVm.Title.Slugify();

                _postService.Add(new Post()
                {
                    Title = postVm.Title,
                    ShortDescription = postVm.ShortDescription,
                    UrlSlug = postUrlSlug,
                    PostContent = postVm.PostContent,
                    PostedOn = DateTime.Now,
                    //CategoryId = postVm.CategoryId
                });

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PostController/Edit/5
        public ActionResult Edit(Guid id)
        {
            try
            {
                var post = _postService.Find(id);
                var postVm = new PostVm()
                {
                    Title = post.Title,
                    ShortDescription = post.ShortDescription,
                    UrlSlug = post.UrlSlug,
                    PostContent = post.PostContent,
                    Published = post.Published,
                    PostedOn = post.PostedOn,
                    //CategoryId = post.CategoryId
                };

                if (postVm != null)
                {
                    return View(postVm);
                }
            }
            catch
            {
            }

            return RedirectToAction(nameof(Index));
        }

        // POST: PostController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, PostVm postVm)
        {
            try
            {
                var post = new Post()
                {
                    Id = postVm.Id,
                    Title = postVm.Title,
                    ShortDescription = postVm.ShortDescription,
                    UrlSlug = postVm.UrlSlug,
                    PostContent = postVm.PostContent,
                    Published=postVm.Published,
                    Modified = DateTime.Now,
                    //CategoryId = postVm.CategoryId
                };

                _postService.Update(post);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PostController/Delete/5
        public ActionResult Delete(Guid id)
        {
            try
            {
                var post = _postService.Find(id);

                if (post != null)
                    _postService.Delete(post);
            }
            catch
            {
            }
            return RedirectToAction("Index");
        }
    }
}