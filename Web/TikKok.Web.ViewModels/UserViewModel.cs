namespace TikKok.Web.ViewModels
{
    using System;

    public class UserViewModel
    {
        public string UserId { get; set; }

        public string Username { get; set; }

        public DateTime CreatedOn { get; set; }

        public int Posts { get; set; }

        public int Likes { get; set; }

        public int Followers { get; set; }

        public int Following { get; set; }
    }
}
