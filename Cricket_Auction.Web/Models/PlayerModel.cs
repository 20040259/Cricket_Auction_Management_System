using Cricket_Auction.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cricket_Auction.Web.Models
{
    //public class ManagePlayersListingViewModel : PageViewModel
    //{
    //    public List<Players> players { get; set; }
    //}

    //public class ManagePlayersViewModel : PageViewModel
    //{
    //    public List<Players> AllPlayers { get; set; }
    //}

    //public class PlayerDetailsViewModel : PageViewModel
    //{
    //    public Players Players { get; set; }
    //}

    //public class ManagePlayerViewModel : PageViewModel
    //{
    //    public int ID { get; set; }


    //    //[DisplayName("Upload photo")]
    //    //  public string PictureURL { get; set; }

    //    //validations
    //    [Required]
    //    // [StringLength(50, MinimumLength = 3, ErrorMessage = "First name must be minimum of 3 letters")]
    //    public string FirstName { get; set; }

    //    [Required]
    //    // [StringLength(50, MinimumLength = 3, ErrorMessage = "Last name must be minimum of 3 letters")]
    //    public string LastName { get; set; }

    //    [Required]
    //    [StringLength(20, MinimumLength = 3, ErrorMessage = "User name must be minimum of 3 letters")]
    //    public string Username { get; set; }

    //    [Required]
    //    [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Please Enter Valid Email ID")]
    //    public string Email { get; set; }

    //    [Required]
    //    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,15}$", ErrorMessage = "Password must be minimum of 8 characters include numbers,letters")]
    //    public string Password { get; set; }


    //    [Required]
    //    public string Gender { get; set; }

    //    [Required]
    //    public string PlayerRole { get; set; }

    //    [Required]
    //    public string Description { get; set; }

    //    //  public string PlayerPictures { get; set; }

    //    //use to get full name of player
    //    //public string PlayerName()
    //    //{
    //    //    return this.FirstName + " " + LastName;
    //    //}
    //    //  public List<PlayerPictures> PlayerPicturesList { get; set; }
    //}
    public class PlayerModel : PageViewModel
    {
        //validations
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string LastName { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 3)]
        public string Username { get; set; }

        [Required]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}")]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,15}$")]
        public string Password { get; set; }


        [Required]
        public string Gender { get; set; }

        [Required]
        public string PlayerRole { get; set; }

        [Required]
        public string Description { get; set; }

        //use to get full name of player
        public string PlayerName()
        {
            return this.FirstName + " " + LastName;
        }
    }
}