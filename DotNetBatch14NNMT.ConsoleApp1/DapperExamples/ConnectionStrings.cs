﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBatch14NNMT.ConsoleApp1.DapperExamples
{
    internal static class ConnectionStrings
    {
      public static  SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {

            DataSource = ".",
            InitialCatalog = "relesson",
            UserID = "sa",
            Password = "sasa@123"
        };
    }
}
