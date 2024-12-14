using Cricket_Auction.Data;
using Cricket_Auction.Entities;
using Cricket_Auction.Services;
using Cricket_Auction.Web.Models;
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
    public class PlayerController : Controller
    {
        Cricket_Auction_Context context = new Cricket_Auction_Context();

        ManagePlayersService playerService = new ManagePlayersService();

        TrophiesService trophiesService = new TrophiesService();

        public ActionResult Index()
        {
            if (Session["ID"] == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        //overloding
        public ActionResult Register()
        {
            //PlayerModel model = new PlayerModel();
            //model.PageTitle = "Register";
            //model.PageDescription = "Register Page";
            return View();
        }

        //oveloading
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Register(Players player)
        {

            if (ModelState.IsValid)
            {
                var check = context.Players.FirstOrDefault(s => s.Username == player.Username);
                if (check == null)
                {
                    player.Password = GetMD5(player.Password);
                    context.Configuration.ValidateOnSaveEnabled = false;

                    //        //string fileName = Path.GetFileNameWithoutExtension(player.ImageFile.FileName);
                    //        //string extension = Path.GetExtension(player.ImageFile.FileName);
                    //        //fileName = fileName + DateTime.Now.ToString("yymmssff") + extension;
                    //        //player.PictureURL = "~/Content/images/" + fileName;
                    //        //fileName = Path.Combine(Server.MapPath("~/Content/images/"), fileName);
                    //        //player.ImageFile.SaveAs(fileName);

                    context.Players.Add(player);
                    context.SaveChanges();
                    return RedirectToAction("Login");
                }
                else
                {
                    ViewBag.error = "Username already exists";
                    return View();
                }
            }

            return View();


        }

//        //create a string MD5(encryption code)
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

    public ActionResult Login()
    {
            //PlayerModel model = new PlayerModel();
            //model.PageTitle = "Login";
            //model.PageDescription = "Register Page";
            return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Login(string username, string password)
    {
    if (ModelState.IsValid)
    {


        var f_password = GetMD5(password);
        var data = context.Players.Where(s => s.Username.Equals(username) && s.Password.Equals(f_password)).ToList();
        if (data.Count() > 0)
        {
            //add session
            Session["PlayerName"] = data.FirstOrDefault().FirstName + " " + data.FirstOrDefault().LastName;
            Session["Username"] = data.FirstOrDefault().Username;
            //Session["ID"] = data.FirstOrDefault().ID;
            return RedirectToAction("Index");

        }
        else
        {
            ViewBag.error = "Login failed";
            return RedirectToAction("Login");
        }
    }
    return View();
}


//Logout
public ActionResult Logout()
{
    Session.Clear();//remove session
    return RedirectToAction("Index", "Home");
}


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

            return View(model);

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

            return RedirectToAction("_DshboardLayout");

        }

    }
}
