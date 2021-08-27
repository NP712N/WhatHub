using Microsoft.AspNetCore.Identity;
using Portal.Domain.Core;
using Portal.Domain.Core.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Infrastructure.Services.Posts
{
    public class PostService: IPostService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<User> _userManager;
        public PostService(
            IUnitOfWork unitOfWork,
            UserManager<User> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        public async Task<List<string>> CreateAsync(Post post)
        {
            var errorMessage = new List<string>();
            if (string.IsNullOrEmpty(post.Title))
                errorMessage.Add("title.is.required");
            if (string.IsNullOrEmpty(post.Content))
                errorMessage.Add("content.is.required");
            if (string.IsNullOrEmpty(post.Image))
                errorMessage.Add("image.is.required");
            if (string.IsNullOrEmpty(post.CreatedBy))
                errorMessage.Add("userId.is.required");

            if(!errorMessage.Any())
            {
                var user = await _userManager.FindByIdAsync(post.CreatedBy);
                if (user is null)
                {
                    errorMessage.Add("userId.not.found");
                    return errorMessage;
                }
                else
                {
                    _unitOfWork.PostRepository.Create(post);
                    _unitOfWork.SaveChanges();
                    return new List<string>();
                }
            }
            else
            {
                return errorMessage;
            }
        }
    }
}
