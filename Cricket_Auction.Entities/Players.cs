using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cricket_Auction.Entities
{
    public class Players : BaseEntity
    {

        public virtual Trophy Trophy { get; set; }
        public int TrophyID { get; set; }
      
        //[DisplayName("Upload photo")]

        //validations
        //[Required]
        //[StringLength(50, MinimumLength = 3)]

        public string FirstName { get; set; }

        //[Required]
        //[StringLength(50, MinimumLength = 3)]
        public string LastName { get; set; }

        //[Required]
        //[StringLength(15, MinimumLength = 3)]
        public string Username { get; set; }

        //[Required]
        //[RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}")]
        public string Email { get; set; }

        //[Required]
        //[RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,15}$")]
        public string Password { get; set; }


        //[Required]
        public virtual string Gender { get; set; }

        //[Required]
        public virtual string PlayerRole { get; set; }

        //[Required]
        public string Description { get; set; }

        //use to get full name of player
        //public string PlayerName()
        //{
        //    return this.FirstName + " " + LastName;
        //}

        // public virtual List<PlayerPictures> PlayerPictures { get; set; }
    }
}
