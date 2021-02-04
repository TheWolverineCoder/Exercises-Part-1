using System;
using System.Collections.Generic;
using System.Linq;

namespace Article2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Article> articles = new List<Article>();
            Console.WriteLine("Enter the number of articles: ");
            int numberOfArticles = int.Parse(Console.ReadLine());
            for(int i = 0; i < numberOfArticles; i++)
            {
                string[] input = Console.ReadLine().Split(", ");
                Article article = new Article(input[0], input[1], input[2]);
                articles.Add(article);
            }
            Console.WriteLine("Enter the criteria of sorting: ");
            string criteria = Console.ReadLine();
            var order = articles.OrderBy(s => s.Title);
            if(criteria == "title")
            {
                
            }
            else if(criteria == "author")
            {
                order = articles.OrderBy(s => s.Author);
            }
            else
            {
                order = articles.OrderBy(s => s.Content);
            }
           
            
            foreach (Article article in order)
            {
                Console.WriteLine(article.Title + " - " + article.Content + " : " + article.Author);
            }

        }
    }

    class Article
    {
        public Article(string title, string content, string author)
        {
            Title = title;
            Content = content;
            Author = author;
        }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }

        

    }
}
