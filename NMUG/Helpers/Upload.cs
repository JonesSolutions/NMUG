
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using NMUG.Models;

namespace NMUG.Helpers
{
    public class Upload
    {

        //private static IHostingEnvironment _environment;

        internal static async Task UploadFile(Models.Jobs jobs, ICollection<IFormFile> files, IHostingEnvironment environment)
        {

			// use the path class to create files and not have to worry about path formatting
			// Path.combine just manages that for you.
            var uploads = Path.Combine(environment.WebRootPath, "uploads");
            foreach (var file in files)
            {
                if (file.Length > 0)
                {
                    using (var fileStream = new FileStream(Path.Combine(uploads, 
						System.IO.Path.GetFileName(file.FileName)), 
						FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                        jobs.FileName = file.FileName;
                    }

                }
            }
        }


    }
}