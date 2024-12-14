using Cricket_Auction.Entities;
using Cricket_Auction.Services;
using Cricket_Auction.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cricket_Auction.Web.Controllers
{
    public class CategoriesController : Controller
    {
        CategoriesService categoriesService = new CategoriesService();

        [HttpGet]
        public ActionResult Index()
        {
            CategoriesListingViewModel model = new CategoriesListingViewModel();

            model.PageTitle = "Categories";
            model.PageDescription = "Categories Listing Page";

            return PartialView(model);
        }

        public ActionResult Listing()
        {
            CategoriesListingViewModel model = new CategoriesListingViewModel();

            model.Categories = categoriesService.GetAllCategories();

            return PartialView(model);

        }

        //add new team
        [HttpGet]
        public ActionResult Create()
        {
            CategoryViewModel model = new CategoryViewModel();

            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Create(CategoryViewModel model)
        {
            Category category = new Category();

            category.TeamName = model.TeamName;
            category.TeamDescription = model.TeamDescription;
            category.MaxPrice = model.MaxPrice;
           

            categoriesService.SaveCategory(category);

            return RedirectToAction("Listing");
        }

        //update exist team
        [HttpGet]
        public ActionResult Edit(int ID)
        {
            CategoryViewModel model = new CategoryViewModel();

            var category = categoriesService.GetCategoryID(ID);

            model.ID = category.ID;
            model.TeamName = category.TeamName;
            model.TeamDescription = category.TeamDescription;
            model.MaxPrice = category.MaxPrice;

            return PartialView(model);

        }

        [HttpPost]
        public ActionResult Edit(CategoryViewModel model)
        {

            Category category = new Category();

            category.ID = model.ID;
            category.TeamName = model.TeamName;
            category.TeamDescription = model.TeamDescription;
            category.MaxPrice = model.MaxPrice;
            
            categoriesService.UpdateCategory(category);

            return RedirectToAction("Listing");

        }

        //delete team
        //[HttpGet]
        // public ActionResult Delete(int ID)
        // {
        //     var auction = auctionsService.GetAuctionID(ID);

        //     return View(auction);
        // }


        [HttpPost]
        public ActionResult Delete(Category category)
        {
            categoriesService.Deletecategory(category);

            return RedirectToAction("Listing");
        }

        [HttpGet]
        public ActionResult Details(int ID)
        {
            CategoryDetailsViewModel model = new CategoryDetailsViewModel();

            model.Category = categoriesService.GetCategoryID(ID);

            model.PageTitle = "Category Details: " + model.Category.TeamName;
            model.PageDescription = model.Category.TeamDescription.Substring(0, 10);

            return View(model);
        }
    }
}