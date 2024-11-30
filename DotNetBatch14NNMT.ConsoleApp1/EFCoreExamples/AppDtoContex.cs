using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetBatch14NNMT.ConsoleApp1.Model;
using Microsoft.EntityFrameworkCore;

namespace DotNetBatch14NNMT.ConsoleApp1.EFCoreExamples;

internal  class AppDtoContex : DbContext
{

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(ConnectionStrings._sqlConnectionStringBuilder.ConnectionString);
    }
    public DbSet<Bean> beans { get; set; }
}
