using Cricket_Auction.Data;
using Cricket_Auction.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cricket_Auction.Services
{
    public class SharedService
    {
        public int SavePicture(Picture picture)
        {
            Cricket_Auction_Context context = new Cricket_Auction_Context();

            context.Pictures.Add(picture);

            context.SaveChanges();

            return picture.ID;
        }

    }
}
