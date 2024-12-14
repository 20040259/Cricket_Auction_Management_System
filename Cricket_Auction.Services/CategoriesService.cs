using Cricket_Auction.Data;
using Cricket_Auction.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cricket_Auction.Services
{
    public class CategoriesService
    {
        public List<Category> GetAllCategories()
        {
            Cricket_Auction_Context context = new Cricket_Auction_Context();

            return context.Categories.ToList();
        }

        public Category GetCategoryID(int ID)
        {
            Cricket_Auction_Context context = new Cricket_Auction_Context();

            return context.Categories.Find(ID);
        }

        public void SaveCategory(Category category)
        {
            Cricket_Auction_Context context = new Cricket_Auction_Context();

            context.Categories.Add(category);

            context.SaveChanges();
        }

        public void UpdateCategory(Category category)
        {
            Cricket_Auction_Context context = new Cricket_Auction_Context();

            context.Entry(category).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }

        public void Deletecategory(Category category)
        {
            Cricket_Auction_Context context = new Cricket_Auction_Context();

            context.Entry(category).State = System.Data.Entity.EntityState.Deleted;
            context.SaveChanges();
        }
    }
}

