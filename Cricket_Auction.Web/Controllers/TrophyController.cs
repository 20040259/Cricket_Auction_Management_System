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
    public class TrophyController : Controller
    {
        TrophiesService trophiesService = new TrophiesService();

        // GET: Trophy
        [HttpGet]
        public ActionResult Index()
        {
            TrophiesListingViewModel model = new TrophiesListingViewModel();

            model.PageTitle = "Trophies";
            model.PageDescription = "Trophies Listing Page";

            return PartialView(model);
        }

        public ActionResult Listing()
        {
            TrophiesListingViewModel model = new TrophiesListingViewModel();

            model.Trophies = trophiesService.GetAllTrophies();

            return PartialView(model);

        }

        //add new auction
        [HttpGet]
        public ActionResult Create()
        {
            TrophyViewModel model = new TrophyViewModel();

            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Create(TrophyViewModel model)
        {
            Trophy trophy = new Trophy();

            trophy.TrophyName = model.TrophyName;
            trophy.TrophyDescription = model.TrophyDescription;


            trophiesService.SaveTrophy(trophy);

            return RedirectToAction("Listing");
        }

        //update exist auction
        [HttpGet]
        public ActionResult Edit(int ID)
        {
            TrophyViewModel model = new TrophyViewModel();

            var trophy = trophiesService.GetTrophyID(ID);

            model.ID = trophy.ID;
            model.TrophyName = trophy.TrophyName;
            model.TrophyDescription = trophy.TrophyDescription;

            return PartialView(model);

        }

        [HttpPost]
        public ActionResult Edit(TrophyViewModel model)
        {

            Trophy trophy= new Trophy();

            trophy.ID = model.ID;
            trophy.TrophyName = model.TrophyName;
            trophy.TrophyDescription = model.TrophyDescription;

            trophiesService.UpdateTrophy(trophy);

            return RedirectToAction("Listing");

        }

        //delete auction
        //[HttpGet]
        // public ActionResult Delete(int ID)
        // {
        //     var auction = auctionsService.GetAuctionID(ID);

        //     return View(auction);
        // }


        [HttpPost]
        public ActionResult Delete(Trophy trophy)
        {
            trophiesService.Deletecategory(trophy);

            return RedirectToAction("Listing");
        }

        [HttpGet]
        public ActionResult Details(string TrophyName)
        {
            TrophyDetailsViewModel model = new TrophyDetailsViewModel();

            model.trophy = trophiesService.GetTrophyName(TrophyName);

            model.PageTitle = "Trophy Details: " + model.trophy.TrophyName;
            model.PageDescription = model.trophy.TrophyDescription.Substring(0, 10);

            return View(model);
        }
    }
}