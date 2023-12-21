using FA.JustBlog.Core;
using FA.JustBlog.Website.Models;
using Microsoft.AspNetCore.Mvc;

namespace FA.JustBlog.Website.Controllers
{
    public class TagController : Controller
    {
        private readonly ITagService _tagService;

        public TagController(ITagService tagService)
        {
            _tagService = tagService;
        }

        // GET: TagController
        public ActionResult Index()
        {
            var tags = _tagService.GetAll();
            var tagVm = new List<TagVm>();

            foreach (var tag in tags)
            {
                tagVm.Add(new TagVm()
                {
                    Id = tag.Id,
                    Name = tag.Name,
                    UrlSlug = tag.UrlSlug,
                    Description = tag.Description,
                });
            }
            //var tagtop = _tagService.GetTopTags();
            //if (tagtop != null)
            //{
            //    foreach (var item in tagtop)
            //    {
            //        tagVm.Add(new TagVm()
            //        {
            //            Id = item.Id,
            //            Name = item.Name,
            //            UrlSlug = item.UrlSlug,
            //            Description = item.Description,
            //        });
            //    }
            //}

            //TempData["Tags"] = tagVm;
            return View(tagVm);
        }

        // GET: TagController/Details/5
        public ActionResult Details(Guid id)
        {
            try
            {
                var tag = _tagService.Find(id);
                if (tag != null)
                {
                    var tagVm = new TagVm()
                    {
                        Id = tag.Id,
                        Name = tag.Name,
                        UrlSlug = tag.UrlSlug,
                        Description = tag.Description,
                    };

                    return View(tagVm);
                }
            }
            catch
            {
            }
            return RedirectToAction("Index");
        }

        // GET: TagController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TagController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var tagName = collection["Name"].ToString();
                //var tagUrlSlug = collection["UrlSlug"].ToString();
                var tagUrlSlug = tagName.Slugify();
                var tagDescription = collection["Description"].ToString();

                _tagService.Add(new Tag()
                {
                    Name = tagName,
                    UrlSlug = tagUrlSlug,
                    Description = tagDescription,
                });

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TagController/Edit/5
        public ActionResult Edit(Guid id)
        {
            try
            {
                var tag = _tagService.Find(id);
                var tagVm = new TagVm()
                {
                    Name = tag.Name,
                    UrlSlug = tag.UrlSlug,
                    Description = tag.Description,
                };

                if (tagVm != null)
                {
                    return View(tagVm);
                }
            }
            catch
            {
            }

            return RedirectToAction(nameof(Index));
        }

        // POST: TagController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, TagVm tagVm)
        {
            try
            {
                var tag = new Tag()
                {
                    Id = tagVm.Id,
                    Name = tagVm.Name,
                    UrlSlug = tagVm.UrlSlug,
                    Description = tagVm.Description,
                };

                _tagService.Update(tag);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TagController/Delete/5
        public ActionResult Delete(Guid id)
        {
            try
            {
                var tag = _tagService.Find(id);

                if (tag != null)
                    _tagService.Delete(tag);
            }
            catch
            {
            }
            return RedirectToAction("Index");
        }
    }
}