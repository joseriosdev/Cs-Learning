using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyACTIO.Entities;
using SqlConnection = System.Data.SqlClient.SqlConnection;
using SqlCommand = System.Data.SqlClient.SqlCommand;
using SqlDataReader = System.Data.SqlClient.SqlDataReader;

namespace TinyACTIO.Utilities
{
    public class DBMethods
    {
        private static string _connectionStr = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\User\\Documents\\WORK\\TinyACTIO\\TinyActio.mdf;Integrated Security=True";

        private static void Ok()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("SUCCESS");
            Console.ResetColor();
        }
        public static User GetCurrentUser()
        {
            using (SqlConnection connection = new SqlConnection(_connectionStr))
            {
                string sql = "SELECT Id,Name,Email FROM USERS WHERE Name='Jose Rios'";
                SqlCommand sqlCommand = new SqlCommand(sql, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    reader.Read();
                    var u = new User();
                    u.Id = reader.GetInt32(0);
                    u.Name = reader.GetString(1);
                    u.Email = reader.GetString(2);
                    reader.Close();
                    connection.Close();
                    return u;
                }
                catch (Exception ex)
                {
                    throw new Exception("ERROR: " + ex.Message);
                }
            }
        }

        public static Workspace GetCurrentWorkspace()
        {
            using (SqlConnection connection = new SqlConnection(_connectionStr))
            {
                string sql = "SELECT Id,Name,Description,User_Id FROM WORKSPACE WHERE Name='Jose Rios WS'";
                SqlCommand sqlCommand = new SqlCommand(sql, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    reader.Read();
                    var ws = new Workspace();
                    ws.Id = reader.GetInt32(0);
                    ws.Name = reader.GetString(1);
                    ws.Description = reader.GetString(2);
                    ws.UserId = reader.GetInt32(3);
                    reader.Close();
                    connection.Close();
                    return ws;
                }
                catch (Exception ex)
                {
                    throw new Exception("ERROR: " + ex.Message);
                }
            }
        }

        public static List<Event> GetAllEvents()
        {
            using (SqlConnection connection = new SqlConnection(_connectionStr))
            {
                string sql = "SELECT EVENTS.Id,EVENTS.Name,USERS.Name,Created_Date FROM EVENTS INNER JOIN USERS ON EVENTS.Organized_By=USERS.Id";
                SqlCommand sqlCommand = new SqlCommand(sql, connection);
                try
                {
                    var evts = new List<Event>();
                    connection.Open();
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    while(reader.Read())
                    {
                        var evt = new Event();
                        evt.Id = reader.GetInt32(0);
                        evt.Name = reader.GetString(1);
                        evt.OrganizedByName = reader.GetString(2);
                        evt.CreatedDate = reader.GetDateTime(3);
                        evts.Add(evt);
                    }
                    
                    reader.Close();
                    connection.Close();
                    Ok();
                    return evts;
                }
                catch (Exception ex)
                {
                    throw new Exception("ERROR: " + ex.Message);
                }
            }
        }

        public static List<Event> GetEventsByOrginizedId(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionStr))
            {
                string sql = $"SELECT Id,Name,Organized_By FROM EVENTS WHERE Organized_By={id}";
                SqlCommand sqlCommand = new SqlCommand(sql, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    var evts = new List<Event>();
                    while (reader.Read())
                    {
                        var evt = new Event();
                        evt.Id = reader.GetInt32(0);
                        evt.Name = reader.GetString(1);
                        evts.Add(evt);
                    }

                    reader.Close();
                    connection.Close();
                    Ok();
                    return evts;
                }
                catch (Exception ex)
                {
                    throw new Exception("ERROR: " + ex.Message);
                }
            }
        }

        public static void InsertEvent(Event evt)
        {
            using (SqlConnection connection = new SqlConnection(_connectionStr))
            {
                string sql = $"INSERT EVENTS ([Name],[Organized_By],[Workspace_Id],[Created_Date]) VALUES ('{evt.Name}',{evt.OrganizedById},{evt.WorkSpaceId},'{evt.CreatedDate}')";
                SqlCommand sqlCommand = new SqlCommand(sql, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    reader.Close();
                    connection.Close();
                    Ok();
                }
                catch (Exception ex)
                {
                    throw new Exception("ERROR: " + ex.Message);
                }
            }
        }

        public static void DeleteEvent(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionStr))
            {
                string sql = $"DELETE FROM EVENTS WHERE Id={id}";
                SqlCommand sqlCommand = new SqlCommand(sql, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    reader.Close();
                    connection.Close();
                    Ok();
                }
                catch (Exception ex)
                {
                    throw new Exception("ERROR: " + ex.Message);
                }
            }
        }

        public static void UpdateEvent(int id, string name)
        {
            using (SqlConnection connection = new SqlConnection(_connectionStr))
            {
                string sql = "UPDATE EVENTS SET Name=@name WHERE Id=@id";
                SqlCommand sqlCommand = new SqlCommand(sql, connection);
                sqlCommand.Parameters.AddWithValue("@name", name);
                sqlCommand.Parameters.AddWithValue("@id", id);
                try
                {
                    connection.Open();
                    sqlCommand.ExecuteNonQuery();

                    connection.Close();
                    Ok();
                }
                catch (Exception ex)
                {
                    throw new Exception("ERROR: " + ex.Message);
                }
            }
        }
    }
}
