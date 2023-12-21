using FA.JustBlog.Core;
using FA.JustBlog.Website.Models;
using Microsoft.AspNetCore.Mvc;

namespace FA.JustBlog.Website.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }
        // GET: CommentController
        public ActionResult Index()
        {
            var comments = _commentService.GetAll();
            var commentVms = new List<CommentVm>();

            foreach (var comment in comments)
            {
                commentVms.Add(new CommentVm()
                {
                    CommentId = comment.Id,
                    Name = comment.Name,
                    Email = comment.Email,
                    CommentHeader = comment.CommentHeader,
                    CommentText = comment.CommentText,
                    CommentTime = comment.CommentTime,
                    //PostId = comment.PostId,
                    //PostTitle = comment.Post.Title,
                });
            }

            return View(commentVms);
        }

        // GET: CommentController/Details/5
        public ActionResult Details(string id)
        {
            try
            {
                var comment = _commentService.Find(new Guid(id));
                if (comment != null)
                {
                    var commentVm = new CommentVm()
                    {
                        CommentId = comment.Id,
                        Name = comment.Name,
                        Email = comment.Email,
                        CommentHeader = comment.CommentHeader,
                        CommentText = comment.CommentText,
                        CommentTime = comment.CommentTime,
                        PostId = comment.PostId,
                        PostTitle = comment.Post.Title,
                    };
                    return View(commentVm);
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            catch
            {
            }
            return RedirectToAction("Index");
        }

        // GET: CommentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CommentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //string commentName, IFormCollection, CommentVm 
                    var commentName = collection["Name"].ToString();

                    _commentService.Add(new Comment() { Name = commentName });

                    return RedirectToAction(nameof(Index));
                }

                return View();

            }
            catch
            {
                return View();
            }
        }

        // GET: CommentController/Edit/5
        public ActionResult Edit(string id)
        {
            try
            {
                var comment = _commentService.Find(new Guid(id));
                if (comment != null)
                {
                    var commentVm = new CommentVm() { Name = comment.Name };
                    return View(commentVm);
                }
            }
            catch
            {
            }
            return RedirectToAction(nameof(Index));

        }

        // POST: CommentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, CommentVm commentVm)
        {
            try
            {
                var comment = new Comment() {
                    Id = commentVm.CommentId,
                    Name = commentVm.Name,
                    Email = commentVm.Email,
                    CommentHeader = commentVm.CommentHeader,
                    CommentText = commentVm.CommentText,
                    CommentTime = DateTime.Now,
                    PostId = commentVm.PostId
                };
                _commentService.Update(comment);

                return RedirectToAction(nameof(Index));

            }
            catch
            {
                return View();
            }
        }

        // GET: CommentController/Delete/5
        public ActionResult Delete(string id)
        {
            try
            {
                var comment = _commentService.Find(new Guid(id));
                if (comment != null)
                    _commentService.Delete(comment);
            }
            catch
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        //POST: CommentController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
