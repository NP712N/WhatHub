using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Portal.Domain.Model;
using Portal.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.API.Controllers.v1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [AllowAnonymous]
    public class TestController : BaseApiController
    {
        private readonly IService _service;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<TestController> _logger;
        public TestController(
            IService service,
            IUnitOfWork unitOfWork,
            ILogger<TestController> logger)
        {
            _logger = logger;
            _service = service;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Test()
        {
            return SuccessResult("ok v1");
        }

        [HttpGet("posts/all")]
        public IActionResult GetAllAuthor()
        {
            _logger.LogError("test");
            var posts = _unitOfWork.PostRepository.GetAll();
            if (posts.Any())
            {
                var postModels = posts.Adapt<List<PostModel>>();
                return SuccessResult(postModels);
            }
            return ErrorResult("no.data");
        }
    }
}
