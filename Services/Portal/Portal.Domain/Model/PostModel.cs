namespace Portal.Domain.Model
{
    public class PostModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Image { get; set; }
        public string CreatedBy { get; set; }
    }

    public class PostCreateReqModel: PostModel
    {
    }
}