using Mapster;
using Microsoft.AspNetCore.Mvc;
using Portal.Domain.Core;
using Portal.Domain.Model;
using Portal.Infrastructure;
using Portal.Infrastructure.Repositories.Posts;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.API.Controllers.v1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class PostsController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IService _service;

        public PostsController(
            IUnitOfWork unitOfWork,
            IService service)
        {
            _unitOfWork = unitOfWork;
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var posts = _unitOfWork.PostRepository.GetAll();
            return SuccessResult(posts.Adapt<List<PostModel>>());
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] PostCreateReqModel reqModel)
        {
            var result = await _service.PostService.CreateAsync(reqModel.Adapt<Post>());
            if (result.Any())
                return ErrorResult(result);
            else
                return SuccessResult("created");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            if (id > 0)
            {
                var post = _unitOfWork.PostRepository.GetById(id);
                if (post is not null)
                {
                    _unitOfWork.PostRepository.Delete(post);
                    _unitOfWork.SaveChanges();
                    return SuccessResult("deleted");
                }
                else
                    return ErrorResult("id.not.found");
            }
            else
                return ErrorResult("id.not.valid");
        }
    }
}