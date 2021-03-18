using System;
using System.Text;

namespace ValidUsernames
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the usernames here: ");
            string[] usernames = Console.ReadLine().Split(", ");
            StringBuilder sb = new StringBuilder();
            foreach(string username in usernames)
            {
                bool check = true;
                if(username.Length < 3 || username.Length > 16)
                {
                    check = false;
                }

                foreach(char ch in username)
                {
                    int code = (int)ch;
                    if((code >= 48 && code <= 57) || (code >= 65 && code <= 90) || (code >= 97 && code <= 122) || code == 45 || code == 95)
                    {
                        continue;
                    }
                    else
                    {
                        check = false;
                    }
                }

                if(check == true)
                {
                    sb.Append(username + " ");
                }
            }
            string[] validUsernames = sb.ToString().Split(" ");
            foreach(string valid in validUsernames)
            {
                Console.WriteLine(valid);
            }
        }
    }
}
