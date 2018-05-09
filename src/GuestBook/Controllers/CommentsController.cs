using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GuestBook.Data.Infrastructure.Logic;
using GuestBook.Models;
using GuestBook.Services.Interfaces;
using GuestBook.Services.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace GuestBook.Controllers
{
    [Authorize]
    [Route("comments")]
    public class CommentsController : Controller
    {
        private readonly ICommentManager _commentManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public CommentsController(ICommentManager commentManager,
            UserManager<ApplicationUser> userManager)
        {
            _commentManager = commentManager;
            _userManager = userManager;
        }

        // GET: Comments
        //[HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            //return _commentManager.GetComments();
            var comments = await _commentManager.GetComments();
            ViewData["AddCommentModel"] = new AddCommentModel();
            return View(comments);
        }

        //// GET: Comments/Details/5
        //public async Task<IActionResult> Details(string id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var comment = await _context.Comments
        //        .Include(c => c.User)
        //        .SingleOrDefaultAsync(m => m.CommentId == id);
        //    if (comment == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(comment);
        //}

        // GET: Comments/Create
        //public IActionResult Create()
        //{
        //    //ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
        //    //return View();
        //    return View();
        //}

        // POST: Comments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<object> Create(AddCommentModel comment)
        {
            var user = await GetCurrentUser();

            if (ModelState.IsValid)
            {
                comment.AuthorId = user.Id;
                await _commentManager.AddComment(comment);

                return new CommentViewModel
                {
                    Description = comment.Description,
                    FullName = user.FullName
                };
            }
            //ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", comment.UserId);
            //return View(comment);

            return BadRequest();
        }

        private async Task<ApplicationUser> GetCurrentUser()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User) ??
                await _userManager.FindByEmailAsync(HttpContext.User.Identity.Name);

            return user;
        }

        //// GET: Comments/Edit/5
        //public async Task<IActionResult> Edit(string id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var comment = await _context.Comments.SingleOrDefaultAsync(m => m.CommentId == id);
        //    if (comment == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", comment.UserId);
        //    return View(comment);
        //}

        //// POST: Comments/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(string id, [Bind("CommentId,Description,UserId")] Comment comment)
        //{
        //    if (id != comment.CommentId)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(comment);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!CommentExists(comment.CommentId))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", comment.UserId);
        //    return View(comment);
        //}

        //// GET: Comments/Delete/5
        //public async Task<IActionResult> Delete(string id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var comment = await _context.Comments
        //        .Include(c => c.User)
        //        .SingleOrDefaultAsync(m => m.CommentId == id);
        //    if (comment == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(comment);
        //}

        //// POST: Comments/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(string id)
        //{
        //    var comment = await _context.Comments.SingleOrDefaultAsync(m => m.CommentId == id);
        //    _context.Comments.Remove(comment);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool CommentExists(string id)
        //{
        //    return _context.Comments.Any(e => e.CommentId == id);
        //}
    }
}
