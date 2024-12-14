using Cricket_Auction.Data;
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
    public class ReportController : Controller
    {
        // GET: Report

        public ActionResult AuctionReport()
        {
            AuctionsListingViewModel model = new AuctionsListingViewModel();
            AuctionsService service = new AuctionsService();
            model.Auctions = service.GetAllAuctions();

            return PartialView(model);
        }

        public ActionResult GenerateReport()
        {
            
            return new Rotativa.ActionAsPdf("AuctionReport");
        }

        public ActionResult PlayerReport()
        {
            ManagePlayersListingViewModel model = new ManagePlayersListingViewModel();
            ManagePlayersService service = new ManagePlayersService();
            model.players = service.GetAllPlayers();

            return PartialView(model);
        }

        public ActionResult GeneratePlayerReport()
        {

            return new Rotativa.ActionAsPdf("PlayerReport");
        }

        public ActionResult TeamReport()
        {
            CategoriesListingViewModel model = new CategoriesListingViewModel();
            CategoriesService service = new CategoriesService();
            model.Categories = service.GetAllCategories();

            return PartialView(model);
        }

        public ActionResult GenerateTeamReport()
        {

            return new Rotativa.ActionAsPdf("TeamReport");
        }

        public ActionResult TrophyReport()
        {
            TrophiesListingViewModel model = new TrophiesListingViewModel();
            TrophiesService service = new TrophiesService();
            model.Trophies = service.GetAllTrophies();

            return PartialView(model);
        }

        public ActionResult GenerateTrophyReport()
        {

            return new Rotativa.ActionAsPdf("TrophyReport");
        }
    }
}