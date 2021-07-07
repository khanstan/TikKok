namespace TikKok.Web.ViewModels.Home
{
    using System;

    using TikKok.Data.Models;

    public class IndexViewModel
    {
        public string PostId { get; set; }

        public string VideoId { get; set; }

        public string Description { get; set; }

        public string CredentialUsername { get; set; }

        public int Likes { get; set; }

        public string Liked { get; set; }

        public string UploaderId { get; set; }

        public ApplicationUser Uploader { get; set; }

        public DateTime UploadDate { get; set; }

        public TimeSpan Duration { get; set; }

        public int Size { get; set; }

        public string Extension { get; set; }

        public string Path { get; set; }

        public string Followed { get; set; }
    }
}
