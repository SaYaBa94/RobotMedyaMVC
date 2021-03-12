using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BussinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PresentationLayer.Models;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace PresentationLayer.Controllers
{
    public class ArticleController : Controller
    {
        private IArticleService _articleService;

        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        [ResponseCache(Duration = 30)]
        public IActionResult Index(int category, int typeid = 1)
        {
            var model = new ArticleListViewModel
            {
                Articles = category > 0 ? _articleService.GetArticleListByCategory(category) : _articleService.GetArticleList()
            };
            return View(model);
        }

       
        public IActionResult GetArticle()
        {
            int id = Convert.ToInt32(HttpContext.Request.Query["id"]);
            var model = new ArticleListViewModel
            {
                Article = _articleService.GetArticle(id).IsEnable!=true ? null : _articleService.GetArticle(id),
                ArticleTags = _articleService.GetTagsByArticle(id)
            };
            if (model.Article==null)
            {
                return RedirectToAction("Error");
            }
            return View(model);
        }

        public IActionResult GetArticleList(int id)
        {
            List<Article> articleList = new List<Article>();
            var model = new ArticleListViewModel();
            model.ArticleTags= _articleService.GetArticlesByTag(id);
            foreach (var article in model.ArticleTags)
            {
                Article a = _articleService.GetArticle(article.ArticleID);
                if (a.IsEnable==true)
                {
                    articleList.Add(a);
                }
            }
            model.Articles = articleList;
            return View(model);
        }

        [Authorize]
        public IActionResult AdminIndex()
        {
            SetViewBags();

            var model = new ArticleListViewModel
            {
                Articles = _articleService.GetArticleListToAdmin()
            };
            return View(model);
        }
        [Authorize]
        public IActionResult ArticleUpdate(int id)
        {
            SetViewBags();
            var model = new ArticleListViewModel
            {
                Article = _articleService.GetArticle(id)
            };
            return View(model);
        }
        [Authorize]
        public IActionResult AddArticle(Article article)
        {


                article.CreateDate = DateTime.Now;
                _articleService.Add(article);
                return RedirectToAction("AdminIndex");


        }
        [Authorize]
        public IActionResult DeleteArticle(int id)
        {
            var article = _articleService.GetArticle(id);
            _articleService.Delete(article);
            return RedirectToAction("AdminIndex");
        }
        [Authorize]
        public IActionResult DeactiveArticle(int id)
        {
            var article = _articleService.GetArticle(id);
            article.IsEnable = false;
            _articleService.Update(article);
            return RedirectToAction("AdminIndex");
        }
        [Authorize]
        public IActionResult ActiveArticle(int id)
        {
            var article = _articleService.GetArticle(id);
            article.IsEnable = true;
            _articleService.Update(article);
            return RedirectToAction("AdminIndex");
        }

        [Authorize]
        public IActionResult UpdateArticle(Article article)
        {
            article.CreateDate = _articleService.GetArticle(article.ArticleID).CreateDate;
            _articleService.Update(article);
            return RedirectToAction("AdminIndex");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
         
        public void SetViewBags()
        {

            List<SelectListItem> kategoriler = (from kategori in _articleService.GetCategoryList()
                                                select new SelectListItem
                                                {
                                                    Text = kategori.CategoryName,
                                                    Value = kategori.CategoryID.ToString()
                                                }).ToList();
            ViewBag.kategoriler = kategoriler;

            List<SelectListItem> yazarlar = (from yazar in _articleService.GetAuthorList()
                                             select new SelectListItem
                                             {
                                                 Text = yazar.AuthorName + " " + yazar.AuthorSurname,
                                                 Value = yazar.AuthorID.ToString()
                                             }).ToList();
            ViewBag.yazarlar = yazarlar;


            List<SelectListItem> kategoriTipleri = (from kategoritipi in _articleService.GetCategoryTypeList()
                                                    select new SelectListItem
                                                    {
                                                        Text = kategoritipi.CategoryTypeName,
                                                        Value = kategoritipi.CategoryTypeID.ToString()
                                                    }).ToList();
            ViewBag.kategoriTipleri = kategoriTipleri;
        }

    }

}