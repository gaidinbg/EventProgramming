using AssignmentManager.DataAccess;
using AssignmentManager.Entities;
using AssignmentManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AssignmentManager.Controllers
{
    public class CommentController : Controller
    {
        //
        // GET: /Comment/
        public ActionResult Index(int id)
        {
            var commentsRepository = new CommentsRepository();
            List<Comment> comments = new List<Comment>();

            //var commentsList = commentsRepository.GetAll();
            //foreach (var comment in commentsList)
            //{
            //    if( comment.AssignmentId == id)
            //    {
            //        comments.Add(comment);
            //    }
            //}

            comments.AddRange(commentsRepository.GetAll(comment => comment.AssignmentId == id));

            var firstComment = comments.FirstOrDefault(); //vadi ni pyrviq komentar, ako nqma takyv, vryshta null

            //Navigational Properties Example
            //
            //ViewBag.AssignmentTitle = firstComment != null ? firstComment.Assignment.Title : ""; //  Trinaren operator - ako e veren izraza, se izpylnqva pyrvata chast sled ?, ako ne - vtorata sled : 


            var assignmentRepository = new AssignmentRepository();

            ViewBag.AssignmentTitle = assignmentRepository.GetbyId(id).Title;
            ViewBag.AssignmentId = id;

            return View(comments);
        }
        [HttpGet]
        public ActionResult Create(int id)
        {
            var  model = new CommentViewModel()
            {
                AssignmentId = id  //pri inicializaciqta na obekta oshte mu kazvame kakvo shte e AssignmentId
            };


           // entiity.AssignmentId = id;


            return View(model);
        }
            [HttpPost]
        public ActionResult Create (CommentViewModel model)
        {

            var entity = new Comment();
            entity.AssignmentId = model.AssignmentId;
            entity.Content = model.Content;
            entity.CreatedAt = DateTime.Now;
            entity.UpdatedAt = DateTime.Now;

            var commentsRepository = new CommentsRepository();
            commentsRepository.Insert(entity);
           
            return RedirectToAction("Index/" + entity.AssignmentId);

        }
        [HttpGet]
        public ActionResult Update (int id)
        {
            var commentsRepository = new CommentsRepository();
            var entity = commentsRepository.GetbyId(id);


            return View(entity);
        }

        [HttpPost]
        public ActionResult Update(Comment entity)
        {
            entity.UpdatedAt = DateTime.Now;

            var commentsRepository = new CommentsRepository();
            commentsRepository.Update(entity);

            return RedirectToAction("Index/" + entity.AssignmentId);
        }

        public ActionResult Delete(int id)
        {
            var commentsRepository = new CommentsRepository();
            var entity = commentsRepository.GetbyId(id);

            commentsRepository.Delete(entity);
            return RedirectToAction("Index/" + entity.AssignmentId);
        }
	}
}