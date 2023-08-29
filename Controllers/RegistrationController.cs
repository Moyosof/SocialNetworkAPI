
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialNetworkAPI.Model;
using System.Data.SqlClient;

namespace SocialNetworkAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public RegistrationController( IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        [Route("Registration")]
        
        public Response Registration(Registration registration )
        {
            Response response= new Response();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("SNCon").ToString());
            Dal dal = new();
            response = dal.Registration(registration,connection);   
            return response;
        }

        [HttpPost]
        [Route("Login")]

        public Response Login(Registration registration)
        {
            Response response= new Response();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("SNCon").ToString());
            Dal dal = new();
            response = dal.Login(registration, connection);
            return response;
        }

        [HttpPost]
        [Route("UserApproval")]

        public Response UserApproval(Registration registration)
        {
            Response res = new();
            SqlConnection connection = new(_configuration.GetConnectionString("SNCon").ToString());
            Dal dal = new();
            res = dal.UserApproval(registration,connection);
            return res;
        }

        [HttpPost]
        [Route("StaffRegistration")]

        public Response StaffRegistration(Staff staff)
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("SNCon").ToString());
            Dal dal = new();
            response = dal.StaffRegistration(staff, connection);
            return response;
        }

        [HttpPost]
        [Route("DeleteStaff")]

        public Response DeleteStaff(Staff staff)
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("SNCon").ToString());
            Dal dal = new();
            response = dal.DeleteStaff(staff, connection);
            return response;
        }

        [HttpGet]
        [Route("RegistrationList")]

        public Response RegistrationList()
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("SNCon").ToString());
            Dal dal = new();
            response = dal.RegistrationList( connection);
            return response;
        }

    }
}
