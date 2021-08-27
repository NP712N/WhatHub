using Portal.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Infrastructure.Services.Posts
{
    public interface IPostService
    {
        Task<List<string>> CreateAsync(Post post);
    }
}
