using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetBatch14NNMT.ConsoleApp1.AdoDotNetExamples;
using DotNetBatch14NNMT.ConsoleApp1.Model;

namespace DotNetBatch14NNMT.ConsoleApp1.EFCoreExamples
{
    internal class EFCoreExample
    {
        private readonly AppDtoContex db = new AppDtoContex();

        
       
        public void Run()
        {
            //Read();
            //Edit(2);
            //Create("Min","mm@gmail.com",223);
            //Update(2, "G", "g@gmail.com", 334);
            Delete(2);
        }

        private void Read()
        {

           var lst =  db.beans.ToList();

            foreach (var item in lst)
            {
                Console.WriteLine("Id => " + item.id);
                Console.WriteLine("Name => " + item.name);
                Console.WriteLine("Email => " + item.email);
                Console.WriteLine("Password => " + item.password);
                Console.WriteLine("________________________________________");
            }

        }

        private void Edit(int id)
        {
            var item = db.beans.FirstOrDefault(x => x.id == id);

            if (item is null)
            {
                Console.WriteLine("No Data Found");
                return;
            }

            Console.WriteLine("Id => " + item.id);
            Console.WriteLine("Name => " + item.name);
            Console.WriteLine("Email => " + item.email);
            Console.WriteLine("Password => " + item.password);
            Console.WriteLine("________________________________________");
        }

        private void Create(string name, string email, int password)
        {
            var item = new Bean
            {
                name = name,
                email = email,
                password = password
            };

            db.beans.Add(item);
            int i = db.SaveChanges();

            string message = i > 0 ? "Saving Successful" : "Saving Fail";
            Console.WriteLine(message);
        }

        private void Update (int id, string name, string email, int password)
        {
           var item = db.beans.FirstOrDefault(x => x.id == id);

            if( item is null)
            {
                Console.WriteLine("No Data Found");
                return;
            }

            item.id = id;
            item.name = name;
            item.email = email;
            item.password = password;

            int i = db.SaveChanges();

            string message = i > 0 ? "Updating Successful" : "Updating Fail";
            Console.WriteLine(message);
        }

        private void Delete (int id)
        {
            var item = db.beans.FirstOrDefault( x => x.id == id);

            if( item is null )
            {
                Console.WriteLine("No Data Found");
                return;
            }

            db.beans.Remove(item);

            int i = db.SaveChanges();

            string message = i > 0 ? "Deleting Successful" : "Deleting Fail";
            Console.WriteLine(message);
        }
    }
}
