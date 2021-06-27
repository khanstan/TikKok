namespace TikKok.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using TikKok.Data;
    using TikKok.Data.Models;
    using TikKok.Services.Data;
    using TikKok.Web.ViewModels.Video.Upload;

    public class VideoController : Controller
    {

        private readonly ApplicationDbContext db;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IVideoUploadService videoUploadService;
        private readonly IWebHostEnvironment environment;

        public VideoController(
        UserManager<ApplicationUser> userManager,
        IVideoUploadService videoUploadService,
        IWebHostEnvironment environment)
        {
            this.userManager = userManager;
            this.videoUploadService = videoUploadService;
            this.environment = environment;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        [HttpGet]
        public IActionResult Upload()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Upload(UploadVideoInputModel input)
        {

            // var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = await this.userManager.GetUserAsync(this.User);

            await this.videoUploadService.CreateAsync(input, user.Id, $"{this.environment.WebRootPath}/videos");

            this.TempData["Message"] = "Video added successfully.";

            return this.Redirect("/");
        }

        // [HttpPost]
        //    public async Task<ActionResult> Upload(IFormFile file)
        //    {

        //        try
        //        {
        //            string webRootPath = this._webHostEnvironment.WebRootPath;
        //            string contentRootPath = this._webHostEnvironment.ContentRootPath;

        //            string username = this.Request.Form["username"];

        //            string timenowoutputfile = DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss") + ".mp4";

        //            string output_path = Path.Combine(this.HttpContext.Request.PathBase + ("~/output"), timenowoutputfile);

        //            if (file.Length > 0)
        //            {
        //                var fileName = Path.GetFileName(file.FileName);

        //                string path1 = Path.Combine(Server.MapPath("~/UploadedFiles"), fileName);

        //                long fileSizeInBytes = file.Length;
        //                MemoryStream target = new MemoryStream();
        //                file.OpenReadStream().CopyTo(target);
        //                byte[] data = target.ToArray();

        //                await Task.Run(() =>
        //                {
        //                    using (FileStream
        //fileStream = new FileStream(path1, FileMode.Create))
        //                    {

        //                        for (int i = 0; i < data.Length; i++)
        //                        {
        //                            fileStream.WriteByte(data[i]);
        //                        }
        //                    }

        //                });

        //                this.ViewBag.Message = "File Uploaded Successfully!";

        //                if (System.IO.File.Exists(path1))
        //                {
        //                    try
        //                    {
        //                        string ffmpeg = $"-i {path1} -i 1.png -i 1.png -filter_complex \"[0:v]drawtext=fontfile=med.otf:text='@ {username}':fontcolor=White@1.0:fontsize=17:enable=between(t\\,0\\,5):x=5:y=((h-text_h)/2)+37,drawtext=fontfile=med.otf:text='@ {username}':fontcolor=white@1.0:fontsize=17:enable=between(t\\,5\\,100):x=w-tw-11:y=h-th-162[text];[text][1:v]overlay=x=main_w*0.02:y=((main_h-overlay_h)/2)-9:enable='between(t,0,5)':[ol1];[ol1][2:v]overlay=main_w-overlay_w-15:main_h-overlay_h-180:enable='between(t,5,100)':[filtered]\" -map \"[filtered]\" -codec:v libx264 -codec:a copy -map 0:a? {output_path}";
        //                        FFMpegConverter wrap = new FFMpegConverter();
        //                        wrap.Invoke(ffmpeg);
        //                    }
        //                    catch (Exception ex)
        //                    {
        //                    }
        //                }

        //                // un comment this in release:
        //                if (System.IO.File.Exists(path1))
        //                {
        //                    System.IO.File.Delete(path1);
        //                }

        //                this.ViewBag.download = "Download the logo added video from here";

        //                var path = this.HttpContext.Request.Path;
        //                var query = this.HttpContext.Request.QueryString;
        //                var pathAndQuery = path + query;

        //                string fullUrl = this.AbsoluteUri;
        //                string querystring = path + query;
        //                string url = fullUrl.Replace(querystring, string.Empty) + "/";

        //                //  ViewBag.downloadpath = url + output_path;

        //                this.ViewBag.downloadpath = url + "output/" + timenowoutputfile;
        //            }

        //            return this.View("Index");
        //        }
        //        catch
        //        {
        //            this.ViewBag.Message = "File upload failed!!";
        //            return this.View("Index");
        //        }
        //    }
    }
}
