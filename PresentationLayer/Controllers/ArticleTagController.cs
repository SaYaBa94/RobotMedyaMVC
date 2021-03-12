using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BussinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PresentationLayer.Models;

namespace PresentationLayer.Controllers
{
    public class ArticleTagController : Controller
    {
        private IArticleTagService _articleTagService;

        public ArticleTagController(IArticleTagService articleTagService)
        {
            _articleTagService = articleTagService;
        }
        [Authorize]
        public IActionResult AdminIndex()
        {
            SetViewBags();
            var model = new ArticleTagListViewModel
            {
                ArticleTags = _articleTagService.GetArticleTagList(),
                Tags= _articleTagService.GetTagList(),
            };
            return View(model);
        }
        [Authorize]
        public IActionResult AddArticleTag(ArticleTag articletag, Checkboxes[] chkboxes)
        {
            bool[] değer = new bool[chkboxes.Length];
            int[] id = new int[chkboxes.Length];
            for (int i = 0; i < chkboxes.Length; i++)
            {
                değer[i]= chkboxes[i].chkValue;
                id[i] = chkboxes[i].id;
            }
            _articleTagService.AddSelectedTags(articletag, değer, id );
            return RedirectToAction("AdminIndex");

            //try
            //{
                
            //}
            //catch (Exception)
            //{

            //    return RedirectToAction("Error");
            //}
        }
        [Authorize]
        public IActionResult DeleteArticleTag(string id)
        {
          

            var article = _articleTagService.GetArticleTag(id);
            _articleTagService.Delete(article);
            return RedirectToAction("AdminIndex");
        }

        public void SetViewBags()
        {

            List<SelectListItem> makaleler = (from makale in _articleTagService.GetArticleList()
                                              select new SelectListItem
                                              {
                                                  Text = makale.ArticleTitle,
                                                  Value = makale.ArticleID.ToString()
                                              }).ToList();
            ViewBag.makaleler = makaleler;

            List<Tag> etiketler = (from etiket in _articleTagService.GetTagList()
                                    select etiket).ToList();
            ViewBag.etiketler = etiketler;

            
        }
    }
}
