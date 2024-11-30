using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBatch14NNMT.ConsoleApp1.Model;

[Table("one")]
internal class Bean
{
    [Key]
    public int id { get; set; }
    public string name { get; set; }
    public string email { get; set; }
    public int password { get; set; }



}
