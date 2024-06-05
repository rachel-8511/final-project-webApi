using Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using Microsoft.Extensions.Configuration;

namespace Repository
{
    public class RatingRepository : IRatingRepository
    {
        public IConfiguration _configuration { get; }
        public RatingRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
       
        public async Task<Rating> addRating(Rating rating)
        {
            

        string query = "INSERT INTO RATING(HOST, METHOD, PATH, REFERER,USER_AGENT,RECORD_DATE)" +
                               "VALUES(@HOST, @METHOD, @PATH, @REFERER,@USER_AGENT,@RECORD_DATE)";
                using (SqlConnection cn = new SqlConnection(_configuration["ConnectionStrings"]))
                using (SqlCommand cmd = new SqlCommand(query, cn))
                { 
                    cmd.Parameters.AddWithValue("@HOST", rating.Host);
                    cmd.Parameters.AddWithValue("@METHOD", rating.Method);
                    cmd.Parameters.AddWithValue("@PATH", rating.Path);
                    cmd.Parameters.AddWithValue("@REFERER", rating.Referer);
                    cmd.Parameters.AddWithValue("@USER_AGENT", rating.UserAgent);
                    cmd.Parameters.AddWithValue("@Record_Date", DateTime.Now);

                    cn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    cn.Close();

                }


                return rating;
           

        }
    }
}
