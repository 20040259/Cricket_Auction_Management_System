using Cricket_Auction.Data;
using Cricket_Auction.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cricket_Auction.Web.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(AccountAccess objUser)
        {
            if (ModelState.IsValid)
            {
                Cricket_Auction_Context context = new Cricket_Auction_Context();

                    var obj = context.Account.Where(a => a.Username.Equals(objUser.Username) && a.Password.Equals(objUser.Password)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["ID"] = obj.ID.ToString();
                        Session["Username"] = obj.Username.ToString();
                        return RedirectToAction("_DashboardLayout");
                    }
                
            }
            return View(objUser);
        }

        public ActionResult _DashboardLayout()
        {
            if (Session["ID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index","Home");
            }
        }

        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("Index", "Home");
        }
    }
}  
    
