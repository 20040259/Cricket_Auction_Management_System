using Cricket_Auction.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cricket_Auction.Web.ViewModels
{
    public class CategoriesListingViewModel : PageViewModel
    {
        public List<Category> Categories { get; set; }
    }

    public class CategoriesViewModel : PageViewModel
    {
        public List<Category> AllCategories { get; set; }
    }

    public class CategoryDetailsViewModel : PageViewModel
    {
        public Category Category { get; set; }
    }

    public class CategoryViewModel : PageViewModel
    {
        public int ID { get; set; }
        public string TeamName { get; set; }
        public string TeamDescription { get; set; }
        public double MaxPrice { get; set; }

        public List<Auction> Auctions { get; set; }

    }

   
}