using Microsoft.Extensions.Logging;
using System.Data;
using System.Data.SqlClient;

namespace SocialNetworkAPI.Model
{
    public class Dal
    {
        public Response Registration(Registration registration, SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("INSERT INTO Registration(Name, Email, Password, PhoneNo, IsActive, IsApproved) VALUES('"+registration.Name + "', '"+registration.Email + "','"+registration.Password + "','"+registration.PhoneNo + "',1,0)", connection);
            connection.Open();
            int i  = cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                response.StatusCode= 200;
                response.StatusMessage = "Registration successful";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Registration failed";
            }

            return response;
        }

        public Response Login(Registration registration, SqlConnection connection)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Registration WHERE Email = '" + registration.Email + "' AND Password = '" + registration.Password+"' ",connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Response response = new Response();
            if(dt.Rows.Count > 0)
            {
                response.StatusCode= 200;
                response.StatusMessage = "Login Successful";

                Registration reg = new Registration();
                reg.ID = Convert.ToInt32(dt.Rows[0]["Id"]);
                reg.Name = Convert.ToString(dt.Rows[0]["Name"]);
                reg.Email = Convert.ToString(dt.Rows[0]["Email"]);
                response.Registration = reg;
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Login Failed";
                response.Registration = null;
            }
            return response;
        }

        public Response UserApproval(Registration registration, SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("UPDATE Registration SET IsApproved = 1 WHERE Id = '"+registration.ID+"' AND IsActive = 1",connection );
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if(i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "User approved";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "User approval failed";
            }
            return response;
        }

        public Response AddNews(News news, SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand cmd = new("INSERT INTO News(Title,Content,Email,IsActive,CreatedOn) VALUES('"+news.Title+"','"+news.Content+"','"+news.Email+"',1,GETDATE()) ", connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if(i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "News created";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "New creation failed";
            }
            return response;
        }

        public Response NewsList(SqlConnection connection)
        {
            Response response = new Response();
            SqlDataAdapter da = new("SELECT * FROM News WHERE IsActive =1", connection);
            DataTable dt = new();
            da.Fill(dt);
            List<News> listNews = new List<News>();
            if(dt.Rows.Count > 0)
            {
                for(int i = 0;i < dt.Rows.Count; i++)
                {
                    News news = new News();
                    news.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                    news.Title = Convert.ToString(dt.Rows[i]["Title"]);
                    news.Content = Convert.ToString(dt.Rows[i]["Content"]);
                    news.Email = Convert.ToString(dt.Rows[i]["Email"]);
                    news.IsActive = Convert.ToInt32(dt.Rows[i]["IsActive"]);
                    news.CreatedOn = Convert.ToString(dt.Rows[i]["CreatedOn"]);
                    listNews.Add(news);
                }
                if(listNews.Count > 0)
                {
                    response.StatusCode = 200;
                    response.StatusMessage = "News data found";
                    response.listNews= listNews;
                }
                else
                {
                    response.StatusCode = 100;
                    response.StatusMessage = "No News data found";
                    response.listNews = null;
                }
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No News data found";
                response.listNews = null;
            }
            return response;
        }

        public Response AddArticle(Article article, SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand cmd = new("INSERT INTO Article(Title,Content,Email,Image,IsActive,IsApproved) VALUES('" + article.Title + "','" + article.Content + "','" + article.Email + "','" + article.Image + "',1,0) ", connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Article created";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Article creation failed";
            }
            return response;
        }

        public Response ArticleList(SqlConnection connection)
        {
            Response response = new Response();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Article WHERE IsActive = 1", connection);
            DataTable dt = new();
            da.Fill(dt);
            List<Article> listArt = new List<Article>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Article art = new Article();
                    art.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                    art.Title = Convert.ToString(dt.Rows[i]["Title"]);
                    art.Content = Convert.ToString(dt.Rows[i]["Content"]);
                    art.Email = Convert.ToString(dt.Rows[i]["Email"]);
                    art.IsActive = Convert.ToInt32(dt.Rows[i]["IsActive"]);
                    art.Image = Convert.ToString(dt.Rows[i]["Image"]);
                    listArt.Add(art);
                }
                if (listArt.Count > 0)
                {
                    response.StatusCode = 200;
                    response.StatusMessage = "Article data found";
                    response.listArticle = listArt;
                }
                else
                {
                    response.StatusCode = 100;
                    response.StatusMessage = "No Article data found";
                    response.listArticle = null;
                }
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No Article data found";
                response.listArticle = null;
            }
            return response;
        }

        public Response ArticleApproval(Article article, SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("UPDATE Registration SET IsApproved = 1 WHERE Id = '" + article.ID + "' AND IsActive = 1", connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "article approved";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "article approval failed";
            }
            return response;
        }

        public Response StaffRegistration(Staff staff , SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("INSERT INTO Registration(Name, Email, Password, IsActive) VALUES('" + staff.Name + "', '" + staff.Email + "','" + staff.Password + "',1)", connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Staff successful";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Staff failed";
            }

            return response;
        }

        public Response DeleteStaff(Staff staff, SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("DELETE FROM Staff WHERE ID ='" + staff.Id + "' AND IsActive =1", connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Staff deleted successful";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Staff deletion failed";
            }

            return response;
        }

        public Response AddEvent(Events events, SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand cmd = new("INSERT INTO Article(Title,Content,Email,IsActive,CreatedOn) VALUES('" + events.Title + "','" + events.Content + "','" + events.Email + "',1,GETDATE()) ", connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Event created";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Event creation failed";
            }
            return response;
        }

        public Response EventList(SqlConnection connection)
        {
            Response response = new Response();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Events WHERE IsActive =1", connection); ;
            
            DataTable dt = new();
            da.Fill(dt);
            List<Events> listEvents = new List<Events>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Events events = new Events();
                    events.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                    events.Title = Convert.ToString(dt.Rows[i]["Title"]);
                    events.Content = Convert.ToString(dt.Rows[i]["Content"]);
                    events.Email = Convert.ToString(dt.Rows[i]["Email"]);
                    events.IsActive = Convert.ToInt32(dt.Rows[i]["IsActive"]);
                    events.CreatedOn = Convert.ToString(dt.Rows[i]["CreatedOn"]);

                    listEvents.Add(events);
                }
                if (listEvents.Count > 0)
                {
                    response.StatusCode = 200;
                    response.StatusMessage = "Events data found";
                    response.listEvents = listEvents;
                }
                else
                {
                    response.StatusCode = 100;
                    response.StatusMessage = "No Events data found";
                    response.listEvents = null;
                }
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No Article data found";
                response.listEvents = null;
            }
            return response;
        }
        public Response RegistrationList( SqlConnection connection)
        {
            Response response = new Response();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Registration WHERE IsActive = 1" , connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<Registration> list = new List<Registration>();
            if(dt.Rows.Count > 0)
            {
                for(int i = 0; i < dt.Rows.Count; i++)
                {
                    Registration reg = new Registration();
                    reg.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                    reg.Name = Convert.ToString(dt.Rows[i]["Name"]);
                    reg.Password = Convert.ToString(dt.Rows[i]["Password"]);
                    reg.PhoneNo = Convert.ToString(dt.Rows[i]["PhoneNo"]);
                    reg.IsActive = Convert.ToInt32(dt.Rows[i]["IsActive"]);
                    reg.IsApproved = Convert.ToInt32(dt.Rows[i]["IsApproved"]);

                    list.Add(reg);
                }
                if (list.Count > 0)
                {
                    response.StatusCode = 200;
                    response.StatusMessage = "Registration data found";
                    response.listRegistation = list;
                }
                else
                {
                    response.StatusCode = 100;
                    response.StatusMessage = "No Registration data found";
                    response.listRegistation = null;
                }
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No Registration data found";
                response.listRegistation = null;
            }
            return response;
        }

    }
}
