namespace SocialNetworkAPI.Model
{
    public class News
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Email { get; set; }
        public int IsActive { get; set; }
        public string CreatedOn { get; set; }
    }
}
