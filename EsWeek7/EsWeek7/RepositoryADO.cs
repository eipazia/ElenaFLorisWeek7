using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsWeek7
{
    internal class RepositoryADO
    {
        const string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Registro;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public Utente GetUserByCredentials(string username, string password)
        {
            Utente user = null;
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
               
               
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "select * from Utenti where UserName = @username and Password = @password";

                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);
                //try
                //{
                //    throw new UserNotFoundException();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var uname = (string)reader["Username"];
                        var pwd = (string)reader["Password"];
                        var id = (string)reader["Id"];
                        user = new Utente(id, uname, pwd);
                    }
                    return user;
                //if (user==null)
                //{
                //    throw new UserNotFoundException("Non trovo utente");
                //}
                //}
                //catch (UserNotFoundException ex)
                //{
                //    Console.WriteLine($"Utente non trovato. Dettagli: {ex.Message}");
                //    return null;
                //}
                //finally
                //{
                //    if (user == null)
                //        connection.Close();
                //}
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Problemi con la connection string. Dettagli: {ex.Message}");
                return user;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore generico. Dettagli: {ex}");
                return user;
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }

            }
           
        }
    }
