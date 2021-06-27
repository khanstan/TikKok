using System;
using System.Collections.Generic;
using System.Text;

namespace TikKok.Services.Data.Models
{
    public class VideosDto
    {
        public IEnumerable<string> VideoUrl { get; set; }

        public int VideosCount { get; set; }
    }
}
