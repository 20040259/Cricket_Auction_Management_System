using Cricket_Auction.Entities;
using Cricket_Auction.Services;
using Cricket_Auction.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Cricket_Auction.Web.Controllers
{
    public class AuctionsController : Controller
    {

        AuctionsService auctionsService = new AuctionsService();

        CategoriesService categoriesService = new CategoriesService();
 
        public ActionResult Index(int? categoryID, string searchTerm, int? pageNo)
        {
            AuctionsListingViewModel model = new AuctionsListingViewModel();

            model.PageTitle = "Auctions";
            model.PageDescription = "Auction Listing Page";

            model.CategoryID = categoryID;
            model.SearchTerm = searchTerm;
            model.PageNo = pageNo;

            model.Categories = categoriesService.GetAllCategories();

            return View(model);
        }

        public ActionResult Listing(int? categoryID, string searchTerm, int? pageNo)
        {
            var pageSize = 5;

            AuctionsListingViewModel model = new AuctionsListingViewModel();

            model.Auctions = auctionsService.SearchAuctions(categoryID, searchTerm, pageNo, pageSize);

            var totalAuctions = auctionsService.GetAuctionCount(categoryID, searchTerm);

            model.Pager = new Pager(totalAuctions,pageNo,pageSize);

            return PartialView(model);
            
        }

        //add new auction
        [HttpGet]
        public ActionResult Create()
        {
            CreateAuctionViewModel model = new CreateAuctionViewModel();

            model.Categories = categoriesService.GetAllCategories();

            return PartialView(model);
        }

        [HttpPost]
        public JsonResult Create(CreateAuctionViewModel model)
        {
            JsonResult result = new JsonResult();

            if (ModelState.IsValid)
            {
                Auction auction = new Auction();

                auction.Title = model.Title;
                auction.CategoryID = model.CategoryID;
                auction.Description = model.Description;
                auction.ActualAmount = model.ActualAmount;
                auction.Status = model.Status;
                auction.StartingTime = model.StartingTime;
                auction.EndingTime = model.EndingTime;

                //var pictureIDs = new List<int>();

                //check auction picture ids null 
                if (!string.IsNullOrEmpty(model.AuctionPictures))
                {

                    var pictureIDs = model.AuctionPictures.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(ID => int.Parse(ID)).ToList();

                    auction.AuctionPictures = new List<AuctionPicture>();

                    auction.AuctionPictures.AddRange(pictureIDs.Select(x => new AuctionPicture() { PictureID = x }).ToList());
                }

                //foreach(var picID in pictureIDs)
                //{
                //    var auctionpicture = new AuctionPicture();
                //    auctionpicture.PictureID = picID;

                //    auction.AuctionPictures.Add(auctionpicture);
                //}

                auctionsService.SaveAuction(auction);

                result.Data = new { Success = true };
            }
            else 
            {
                result.Data = new { Success = false, Error = "Unable to save auction. Please enter valid values" };
            }
            return result;
        }

        //update exist auction
         [HttpGet]
         public ActionResult Edit(int ID)
           {
                CreateAuctionViewModel model = new CreateAuctionViewModel();

                var auction = auctionsService.GetAuctionID(ID);

                model.ID = auction.ID;
                model.Title = auction.Title;
                model.CategoryID = auction.CategoryID;
                model.ActualAmount = auction.ActualAmount;
                model.Description = auction.Description;
                model.Status = auction.Status;
                model.StartingTime = auction.StartingTime;
                model.EndingTime = auction.EndingTime;

                model.Categories = categoriesService.GetAllCategories();
                model.AuctionPicturesList = auction.AuctionPictures;

                return PartialView(model);

           }

         [HttpPost]
         public ActionResult Edit(CreateAuctionViewModel model)
           {

            Auction auction = new Auction();

            auction.ID = model.ID;
            auction.Title = model.Title;
            auction.CategoryID = model.CategoryID;
            auction.Description = model.Description;
            auction.ActualAmount = model.ActualAmount;
            auction.Status = model.Status;
            auction.StartingTime = model.StartingTime;
            auction.EndingTime = model.EndingTime;

            if (!string.IsNullOrEmpty(model.AuctionPictures))
            {

                var pictureIDs = model.AuctionPictures.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(ID => int.Parse(ID)).ToList();

                auction.AuctionPictures = new List<AuctionPicture>();

                auction.AuctionPictures.AddRange(pictureIDs.Select(x => new AuctionPicture() { AuctionID = auction.ID,PictureID = x }).ToList());
            }
 
            auctionsService.UpdateAuction(auction);

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
        public ActionResult Delete(Auction auction)
        {
            auctionsService.DeleteAuction(auction);

            return RedirectToAction("Listing");
        }

        [HttpGet]
        public ActionResult Details(int ID)
        {
            AuctionDetailsViewModel model = new AuctionDetailsViewModel();

            model.Auction = auctionsService.GetAuctionID(ID);

            model.PageTitle = "Auctions Details: " + model.Auction.Title;
            //model.PageDescription = model.Auction.Description.Substring(0, 10);

            return View(model);
        }

    }
}