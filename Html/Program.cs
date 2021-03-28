using System;
using System.Text;

namespace Html
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            Console.WriteLine("Enter a title of an article: ");
            string title = Console.ReadLine();
            string h1 = "<h1>\n\t" + title + "\n</h1>\n";
            sb.Append(h1);
            Console.WriteLine("Enter the content of that article: ");
            string content = Console.ReadLine();
            string article = "<article>\n\t" + content + "\n</article>\n";
            sb.Append(article);
            string comment;
            while((comment = Console.ReadLine()) != "end of comments")
            {
                string div = "<div>\n\t" + comment + "\n</div>\n";
                sb.Append(div);
            }
            sb.ToString();
            Console.WriteLine(sb);
        }
    }
}
