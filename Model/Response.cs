namespace SocialNetworkAPI.Model
{
    /// <summary>
    /// Creating a response class that will be passed to the frontend
    /// </summary>
    public class Response
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public List<Registration> listRegistation { get; set; }
        public Registration Registration { get; set; }
        public List<Article> listArticle { get; set; }
        public List<News> listNews { get; set; }
        public List<Events> listEvents { get; set; }


    }
}
