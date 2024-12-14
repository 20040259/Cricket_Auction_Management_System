using Cricket_Auction.Services;
using Cricket_Auction.Web.ViewModels;
using System;
using System.Web.Mvc;

namespace Cricket_Auction.Web.Controllers
{
    public class HomeController : Controller
    {
        AuctionsService service = new AuctionsService();

        public ActionResult Index() 
        {
            AuctionsViewModel Vmodel = new AuctionsViewModel();

            Vmodel.PageTitle = "Home Page";
            Vmodel.PageDescription = "This is home page";

            Vmodel.AllAuctions = service.GetAllAuctions();
            Vmodel.PromotedAuctions = service.GetPromotedAuctions(); 

            return View(Vmodel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}