using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using BussinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PresentationLayer.Extensions;
using PresentationLayer.Models;

namespace PresentationLayer.Controllers
{
    public class AuthorController : Controller
    {
        private IAuthorService _authorgService;

        public AuthorController(IAuthorService authorgService)
        {
            _authorgService = authorgService;
        }

        public IActionResult Index()
        {
            return View();
        }


        [Authorize]
        public IActionResult AdminIndex()
        {

            var model = new AuthorListViewModel
            {
                Authors = _authorgService.GetAll()
            };
            return View(model);
        }
        [Authorize]
        public IActionResult AdminUpdate(int id)
        {
            var model = new AuthorListViewModel
            {
                Author = _authorgService.GetAuthor(id)
            };
            return View(model);
        }
        [Authorize]
        public IActionResult AddAuthor(Author author)
        {
          
            try
            {
                using (SHA256 sha256Hash = SHA256.Create())
                {
                    HashHelper hhelper = new HashHelper();
                    string hash = hhelper.GetHash(sha256Hash, author.AuthorPassword);
                    author.AuthorPassword = hash;
                    _authorgService.Add(author);
                    return RedirectToAction("AdminIndex");
                }
            }
            catch (Exception)
            {

                return RedirectToAction("Error");
            }
        }
        [Authorize]
        public IActionResult DeactiveAuthor(int id)
        {
            var author = _authorgService.GetAuthor(id);
            author.IsEnable = false;
            _authorgService.Update(author);
            return RedirectToAction("AdminIndex");
        }
        [Authorize]
        public IActionResult UpdateAuthor(Author author)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                HashHelper hhelper = new HashHelper();
                string hash = hhelper.GetHash(sha256Hash, author.AuthorPassword);
                author.AuthorPassword = hash;

                _authorgService.Update(author);
                return RedirectToAction("AdminIndex");
            }
        }


        public IActionResult AdminLogin()
        {

            var model = new AuthorListViewModel();
            return View(model);
        }

        public async Task<IActionResult> Login(Author author)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                HashHelper hhelper = new HashHelper();
                string hash = hhelper.GetHash(sha256Hash, author.AuthorPassword);

                var model = new AuthorListViewModel()
                {
                    Author = _authorgService.Get(author.AuthorEmail, hash)
                };

                if (model.Author!=null)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, "AdminGiris" )
                    };

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);
                    var props = new AuthenticationProperties();
                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,principal, props).Wait();

                    return RedirectToAction("AdminIndex", "Article");
                }

                return RedirectToAction("AdminLogin", "Author");

            }

        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("AdminLogin", "Author");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
