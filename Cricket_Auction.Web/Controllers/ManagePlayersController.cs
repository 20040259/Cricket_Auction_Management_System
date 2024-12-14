using Cricket_Auction.Entities;
using Cricket_Auction.Services;
using Cricket_Auction.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Cricket_Auction.Web.Controllers
{
    public class ManagePlayersController : Controller
    {
        // GET: ManagePlayers
        ManagePlayersService playerService = new ManagePlayersService();
        TrophiesService trophiesService = new TrophiesService();

        [HttpGet]
        public ActionResult Index()
        {
            ManagePlayersListingViewModel model = new ManagePlayersListingViewModel();

            model.PageTitle = "Players";
            model.PageDescription = "Players Listing Page";

            return PartialView(model);
        }

        public ActionResult Listing()
        {
            ManagePlayersListingViewModel model = new ManagePlayersListingViewModel();

            model.players = playerService.GetAllPlayers();

            return PartialView(model);

        }

        //add new auction
        [HttpGet]
        public ActionResult Create()
        {
            ManagePlayerViewModel model = new ManagePlayerViewModel();

            model.Trophies = trophiesService.GetAllTrophies();

            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Create(ManagePlayerViewModel model)
        {
            Players players = new Players();
            players.Password = GetMD5(players.Password);

            players.TrophyID = model.TrophyID;
            players.FirstName = model.FirstName;
            players.LastName = model.LastName;
            players.Username = model.Username;
            players.Email = model.Email;
            players.Password = model.Password;
            players.Gender = model.Gender;
            players.PlayerRole = model.PlayerRole;
            players.Description = model.Description;


            playerService.SavePlayers(players);

            return RedirectToAction("Listing");
        }

        //update exist auction
        [HttpGet]
        public ActionResult Edit(int ID)
        {
            ManagePlayerViewModel model = new ManagePlayerViewModel();

            var players = playerService.GetPlayerID(ID);

            model.ID = players.ID;
            model.TrophyID = players.TrophyID;
            model.FirstName = players.FirstName;
            model.LastName = players.LastName;
            model.Username = players.Username;
            model.Email = players.Email;
            model.Password = players.Password;
            model.Gender = players.Gender;
            model.PlayerRole = players.PlayerRole;
            model.Description = players.Description;

            model.Trophies = trophiesService.GetAllTrophies();

            return PartialView(model);

        }

        [HttpPost]
        public ActionResult Edit(ManagePlayerViewModel model)
        {
            Players players = playerService.GetPlayerID(model.ID);
            players.Password = GetMD5(players.Password);

            players.TrophyID = model.TrophyID;
            players.FirstName = model.FirstName;
            players.LastName = model.LastName;
            players.Username = model.Username;
            players.Email = model.Email;
            players.Password = model.Password;
            players.Gender = model.Gender;
            players.PlayerRole = model.PlayerRole;
            players.Description = model.Description;

            //if (!string.IsNullOrEmpty(model.PlayerPictures))
            //{

            //    var pictureIDs = model.PlayerPictures.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(ID => int.Parse(ID)).ToList();

                //  players.PlayerPictures = new List<PlayerPictures>();

                //players.PlayerPictures.AddRange(pictureIDs.Select(x => new PlayerPictures() { playerId = players.ID, picId = x }).ToList());
            //}

            playerService.UpdatePlayers(players);

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
        public ActionResult Delete(Players players)
        {
            playerService.DeletePlayers(players);

            return RedirectToAction("Listing");
        }

        [HttpGet]
        public ActionResult Details(int ID)
        {
            PlayerDetailsViewModel model = new PlayerDetailsViewModel();

            model.Players = playerService.GetPlayerID(ID);

            model.PageTitle = "Player Details: " + model.Players.Username;
            model.PageDescription = model.Players.Description.Substring(0, 10);

            return View(model);
        }

        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }

    }
}