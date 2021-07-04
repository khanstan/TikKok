namespace TikKok.Web.ViewModels.Profile
{
    using System;

    public class ProfileLikedViewModel
    {
        public string PostId { get; set; }

        public string Path { get; set; }

        public string CredentialUsername { get; set; }

        public DateTime UploadDate { get; set; }

        public int Likes { get; set; }

        public string Liked { get; set; }

        public string Description { get; set; }

    }
}
