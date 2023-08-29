using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialNetworkAPI.Model;
using System.Data.SqlClient;

namespace SocialNetworkAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public ArticleController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        [Route("AddArticle")]

        public Response AddArticle(Article article)
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("SNCon").ToString());
            Dal dal = new();
            response = dal.AddArticle(article, connection);
            return response;
        }

        [HttpPost]
        [Route("Get_all_Article")]

        public Response GetAllArticle()
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("SNCon").ToString());
            Dal dal = new();
            response = dal.ArticleList(connection);
            return response;
        }

        [HttpPost]
        [Route("ArticleApproval")]

        public Response ArticleApproval(Article article)
        {
            Response res = new();
            SqlConnection connection = new(_configuration.GetConnectionString("SNCon").ToString());
            Dal dal = new();
            res = dal.ArticleApproval(article, connection);
            return res;
        }
    }
}
