// See https://aka.ms/new-console-template for more information
using DotNetBatch14NNMT.ConsoleApp1.AdoDotNetExamples;
using DotNetBatch14NNMT.ConsoleApp1.DapperExamples;
using DotNetBatch14NNMT.ConsoleApp1.EFCoreExamples;

Console.WriteLine("Hello, World!");

AdoDotNetExample ado = new AdoDotNetExample();

//ado.Read();

//ado.Edit(2); 

//ado.Create("Nyi Nyi","n@gmail.com",1234); 

//ado.Update(2, "Thant", "t@gmail.com", 123);

//ado.Delete(5);

//DapperExample dp = new DapperExample();

//dp.Run();


EFCoreExample ef = new EFCoreExample();

ef.Run();

Console.ReadKey();