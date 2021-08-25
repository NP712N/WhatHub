using Portal.Domain.Core.Auth;

namespace Portal.Domain.Core
{
    public class Post : BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Image { get; set; }
        public bool IsAnonymous { get; set; }

        //Data configuration DB
        public string CreatedBy { get; set; }

        public virtual User User { get; set; }
    }
}