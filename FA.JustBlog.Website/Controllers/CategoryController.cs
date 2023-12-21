using FA.JustBlog.Core;
using FA.JustBlog.Website.Models;
using Microsoft.AspNetCore.Mvc;

namespace FA.JustBlog.Website.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: CategoryController
        public ActionResult Index()
        {
            var categories = _categoryService.GetAll();
            var categoryVm = new List<CategoryVm>();

            foreach (var category in categories)
            {
                categoryVm.Add(new CategoryVm()
                {
                    Id = category.Id,
                    Name = category.Name,
                    UrlSlug = category.UrlSlug,
                    Description = category.Description,
                });
            }

            return View(categoryVm);
        }

        // GET: CategoryController/Details/5
        public ActionResult Details(Guid id)
        {
            try
            {
                var category = _categoryService.Find(id);
                if (category != null)
                {
                    var categoryVm = new CategoryVm()
                    {
                        Id = category.Id,
                        Name = category.Name,
                        UrlSlug = category.UrlSlug,
                        Description = category.Description,
                    };

                    return View(categoryVm);
                }
            }
            catch
            {
            }
            return RedirectToAction("Index");
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var categoryName = collection["Name"].ToString();
                //var categorySlug = collection["UrlSlug"].ToString();
                var categoryDescription = collection["Description"].ToString();
                var categoryUrlSlug = categoryName.Slugify();

                _categoryService.Add(new Category()
                {
                    Name = categoryName,
                    UrlSlug = categoryUrlSlug,
                    Description = categoryDescription,
                });
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Edit/5
        public ActionResult Edit(Guid id)
        {
            try
            {
                var category = _categoryService.Find(id);
                var categoryVm = new CategoryVm()
                {
                    Name = category.Name,
                    UrlSlug = category.UrlSlug,
                    Description = category.Description,
                };

                if (categoryVm != null)
                {
                    return View(categoryVm);
                }
            }
            catch
            {
            }

            return RedirectToAction(nameof(Index));
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, CategoryVm categoryVm)
        {
            try
            {
                var category = new Category()
                {
                    Id = categoryVm.Id,
                    Name = categoryVm.Name,
                    UrlSlug = categoryVm.UrlSlug,
                    Description = categoryVm.Description,
                };

                _categoryService.Update(category);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Delete/5
        public ActionResult Delete(Guid id)
        {
            try
            {
                var category = _categoryService.Find(id);

                if (category != null)
                    _categoryService.Delete(category);
            }
            catch
            {
            }
            return RedirectToAction("Index");
        }
    }
}