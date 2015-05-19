using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
 
namespace ConsoleApplication
{
    class Program
    {
       static void Main(string[] args)
    
       {
           Console.Write("Text:"); 
           var pathText = Console.ReadLine();
           if (!File.Exists(pathText))
           {
               Console.WriteLine("File with text is not found!");
               Console.ReadKey(true);
               return;
           }
          
           Console.Write("Dictionary:"); 
           var dictPath = Console.ReadLine();
           if (!File.Exists(dictPath))
           {
               Console.WriteLine("File with dictionary is not found!");
               Console.ReadKey();
               return;
           }
           var words = File.ReadLines(dictPath,Encoding.Default).Select(i=>i.Trim()).ToArray();
           string result = "";
           using (var reader=new StreamReader(pathText,Encoding.Default))
           {
               while (!reader.EndOfStream)
               {
                   var w = reader.ReadLine().Split(new string[] {" "}, StringSplitOptions.RemoveEmptyEntries).ToArray();
                   for (int i = 0; i < w.Length; i++)
                   {
                       if (words.Contains(w[i]))
                       {
                           result += @"<b><i>" + w[i] + "</i></b>"+" ";
                       }
                       else
                       {
                           result += w[i] + " ";
                       }
                   }
                   result += "<br/>";
               }
           } 
         
           string header = @"<!DOCTYPE html>
                             <html>
                             <head>
                             <title>File</title>
                             <meta http-equiv=""content-type"" content=""text/html; charset=utf-8"" />
                             </head>
                             <body>
                             <div style=""margin:30px"">
                             <p>"+result+@"</p>
                             </div>
                             </body>
                             </html> ";
 
           File.WriteAllText("default.html",header,Encoding.Default);
           Process.Start("default.html");
 
       }
    
    }
}