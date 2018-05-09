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
    }
}
