using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBatch14NNMT.ConsoleApp1.AdoDotNetExamples;

internal class AdoDotNetExample
{
    private readonly SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
    {
        DataSource = ".",
        InitialCatalog = "relesson",
        UserID = "sa",
        Password = "sasa@123"
    };

    public void Read ()
    {
        SqlConnection connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
        connection.Open ();
        string query = "SELECT * FROM one";
        SqlCommand cmd = new SqlCommand(query, connection);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable dt  = new DataTable();
        adapter.Fill (dt);  
        
      
        connection.Close ();

        foreach (DataRow dr in dt.Rows)
        {
            Console.WriteLine("Id => " + dr["id"]);
            Console.WriteLine("Name => " + dr["name"]);
            Console.WriteLine("Email => " + dr["email"]);
            Console.WriteLine("Password => " + dr["password"]);
            Console.WriteLine("______________________________________");
        }

       
    }

    public void Edit(int id)
    {
        SqlConnection connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);

        connection.Open ();

        string query = "SELECT * FROM one WHERE id = @id";
        SqlCommand cmd = new SqlCommand (query, connection);
        cmd.Parameters.AddWithValue("@id", id);
        SqlDataAdapter adapter = new SqlDataAdapter (cmd);
        DataTable dt = new DataTable ();
        adapter.Fill (dt);

        if(dt.Rows.Count == 0)
        {
            Console.WriteLine("No Data Found");
            return;
        }

        DataRow dr = dt.Rows [0];
        Console.WriteLine("Id => " + dr["id"]);
        Console.WriteLine("Name => " + dr["name"]);
        Console.WriteLine("Email => " + dr["email"]);
        Console.WriteLine("Password => " + dr["password"]);
        Console.WriteLine("______________________________________");

        connection.Close();
    }

    public void Create (string name, string email, int password)
    {
        SqlConnection connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);

        connection.Open ();

        string query = @"INSERT INTO [dbo].[one]
           ([name]
           ,[email]
           ,[password])
     VALUES
           (@name
           ,@email
           ,@password)";

        SqlCommand cmd = new SqlCommand(query, connection);
        cmd.Parameters.AddWithValue ("@name", name);
        cmd.Parameters.AddWithValue("@email", email);
        cmd.Parameters.AddWithValue("@password", password);

        int i = cmd.ExecuteNonQuery ();

        string message = i > 0 ? "Saving Successful" : "Saving Fail";

        Console.WriteLine(message);

        connection.Close ();
    }

    public void Update(int id, string name, string email, int password)
    {
        SqlConnection connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);

        connection.Open ();

        string query = @"UPDATE [dbo].[one]
   SET [name] = @name
      ,[email] = @email
      ,[password] = @password
 WHERE id = @id";

        SqlCommand cmd = new SqlCommand (query, connection);
        cmd.Parameters.AddWithValue("@id",id);
        cmd.Parameters.AddWithValue("@name",name);
        cmd.Parameters.AddWithValue("@email", email);
        cmd.Parameters.AddWithValue("@password", password);

        int i = cmd.ExecuteNonQuery();

        string message = i > 0 ? "Updating Successful" : "Updating Fail";

        Console.WriteLine(message);

        connection.Close();
    }

    public void Delete(int id)
    {
        SqlConnection connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);

        connection.Open ();

        string query = @"DELETE FROM [dbo].[one]
      WHERE id = @id";

        SqlCommand cmd = new SqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@id", id);

        int i = cmd.ExecuteNonQuery();

        string message = i > 0 ? "Deleting Successful" : "Deleting Fail";

        Console.WriteLine(message);

        connection.Close();

    }
}
