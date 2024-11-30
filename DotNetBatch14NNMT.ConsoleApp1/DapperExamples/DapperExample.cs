using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Dapper;

namespace DotNetBatch14NNMT.ConsoleApp1.DapperExamples
{
    internal class DapperExample
    {
        public void Run()
        {
            //Read();
            //Edit(2);
            //Create("Min Min", "m@gmail.com", 567);
            //Update(2, "T", "tt@gmail.com", 222);
            Delete(7);
        }

        private void Read()
        {
            IDbConnection db = new SqlConnection(ConnectionStrings._sqlConnectionStringBuilder.ConnectionString);
            List<Bean> lst = db.Query<Bean>("SELECT * FROM one").ToList();

            foreach (Bean bean in lst)
            {
                Console.WriteLine("Id => " + bean.id);
                Console.WriteLine("Name => " + bean.name);
                Console.WriteLine("Email => " + bean.email);
                Console.WriteLine("Password => " + bean.password);
                Console.WriteLine("________________________________");
            }

        }

        private void Edit(int id)
        {
            IDbConnection db = new SqlConnection(ConnectionStrings._sqlConnectionStringBuilder.ConnectionString);
            var item = db.Query("SELECT * FROM one WHERE id = @id", new Bean { id = id }).FirstOrDefault();

            if (item is null)
            {
                Console.WriteLine("No Data Found");
                return;
            }

            Console.WriteLine("Id => " + item.id);
            Console.WriteLine("Name => " + item.name);
            Console.WriteLine("Email => " + item.email);
            Console.WriteLine("Password => " + item.password);
            Console.WriteLine("________________________________");
        }

        private void Create(string name, string email, int password)
        {
            var item = new Bean
            {
                name = name,
                email = email,
                password = password
            };

            string query = @"INSERT INTO [dbo].[one]
           ([name]
           ,[email]
           ,[password])
     VALUES
           (@name
           ,@email
           ,@password)";

            IDbConnection db = new SqlConnection(ConnectionStrings._sqlConnectionStringBuilder.ConnectionString);
           
            int i = db.Execute(query, item);

            string message = i > 0 ? "Saving Successful" : "Saving Fail";
            Console.WriteLine(message);
        }

        private void Update(int id, string name, string email, int password)
        {
            var item = new Bean
            {
                id = id,
                name = name,
                email = email,
                password = password
            };

            string query = @"UPDATE [dbo].[one]
   SET [name] = @name
      ,[email] = @email
      ,[password] = @password
 WHERE id = @id";

            IDbConnection db = new SqlConnection(ConnectionStrings._sqlConnectionStringBuilder.ConnectionString);

            int i = db.Execute(query, item);

            string message = i > 0 ? "Updating Successful" : "Updating Fail";
            Console.WriteLine(message);
        }

        private void Delete(int id)
        {
            var item = new Bean { id = id };

            string query = @"DELETE FROM [dbo].[one]
      WHERE id = @id";

            IDbConnection db = new SqlConnection(ConnectionStrings._sqlConnectionStringBuilder.ConnectionString);

            int i =db.Execute(query, item);

            string message = i > 0 ? "Deleting Successful" : "Deleting Fail";
            Console.WriteLine(message);
        }
    }
}
