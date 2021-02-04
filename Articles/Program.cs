using System;

namespace Articles
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your input: ");
            string input = Console.ReadLine();
            string[] inputInfo = input.Split(", ");
            Article article = new Article(inputInfo[0], inputInfo[1], inputInfo[2]);
            Console.WriteLine("Enter the number of operations you want to conduct(1-3): ");
            int operations = int.Parse(Console.ReadLine());
            if(operations == 1)
            {
                article.Edit();
            }
            else if(operations == 2)
            {
                article.Edit();
                article.ChangeAuthor();
            }
            else
            {
                article.Edit();
                article.ChangeAuthor();
                article.ChangeTitle();
            }

            Console.WriteLine($"{article.Content} - {article.Author} - {article.Title}");
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

        public void Edit()
        {
            Console.Write("Edit: ");
            string newContent = Console.ReadLine();
            Content = newContent;
        }

        public void ChangeAuthor()
        {
            Console.Write("Author: ");
            string newAuthor = Console.ReadLine();
            Author = newAuthor;
        }

        public void ChangeTitle()
        {
            Console.Write("Title: ");
            string newTitle = Console.ReadLine();
            Title = newTitle;
        }

    }
}
