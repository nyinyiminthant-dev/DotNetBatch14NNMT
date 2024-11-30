// See https://aka.ms/new-console-template for more information
using DotNetBatch14NNMT.ConsoleApp1.AdoDotNetExamples;

Console.WriteLine("Hello, World!");

AdoDotNetExample ado = new AdoDotNetExample();

//ado.Read();

//ado.Edit(2); 

//ado.Create("Nyi Nyi","n@gmail.com",1234);

//ado.Update(2, "Thant", "t@gmail.com", 123);

ado.Delete(5);

Console.ReadKey();