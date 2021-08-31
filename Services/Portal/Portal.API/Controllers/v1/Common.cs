using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection;
using System.Threading.Tasks;

namespace Portal.API.Controllers.v1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [AllowAnonymous]
    public class Common : BaseApiController
    {
        [HttpPost("upload-image/{container}")]
        public IActionResult UploadImage([FromRoute] string container, IFormFile image)
        {
            if (image == null || !image.ContentType.ToString().Contains("image")) 
                return ErrorResult("incorrect.format.file");
            if (string.IsNullOrEmpty(container))
                return ErrorResult("incorrect.container.name");
            else
            {
                var currentPaht = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", container);
                if(!Directory.Exists(currentPaht))
                    return ErrorResult("container.name.not.exists");
            }

            try
            {
                if (image.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(image.ContentDisposition).FileName.Trim('"');
                    var fileExtension = Path.GetExtension(fileName);
                    var folderName = Path.Combine("wwwroot", "images", container.Trim().ToLower());
                    //var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                    //var fullPath = Path.Combine(pathToSave, fileName);
                    //var dbPath = Path.Combine(folderName, fileName);
                    //using var stream = new FileStream(fullPath, FileMode.Create);
                    //image.CopyTo(stream);

                    var path = Path.Combine(Directory.GetCurrentDirectory(), folderName, $"{Guid.NewGuid()}{fileExtension}");
                    var stream = new FileStream(path, FileMode.Create);
                    image.CopyToAsync(stream);
                    var imgResultUrl = path.Split(@"wwwroot")[1];
                    return SuccessResult(imgResultUrl.Replace("\\", "/"));
                }
                else
                    return ErrorResult("file.not.valid");
            }
            catch (Exception ex)
            {
                return ErrorResult("file.not.valid");
            }


        }
    }
}
