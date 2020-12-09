using System;
using System.Collections.Generic;
using System.Text;

namespace EfBloggy
{
    public class App
    {
        static BlogContext context = new BlogContext();

        public void Run()
        {
            //Functions.ClearDatabase();                //Körs en gång sedan kommenteras ut (because if u keep runing it it will reset your data)
            //Functions.AddSomeTitles();                //Körs en gång sedan kommenteras ut
            MainMenu();
        }
        public void MainMenu()
        {
            Header("Huvudmeny");

            ShowAllBlogPostsBrief();

            Console.WriteLine("\nWhat do you want to do?");
            Console.WriteLine("a) Gå till huvudmeny");
            Console.WriteLine("b) Uppdatera en blogpost");
            Console.WriteLine("c) Lägg till en blogpost");
            Console.WriteLine("d) Radera en blogpost");
            Console.WriteLine("q) Avsluta");
            ConsoleKey command = Console.ReadKey(true).Key;

            if (command == ConsoleKey.A)
                MainMenu();

            if (command == ConsoleKey.B)
                PageUpdatePost();

            if (command == ConsoleKey.C)
                InsertPost();

            if (command == ConsoleKey.D)
                DeletePost();
        }

        private void PageUpdatePost()
        {
            Header("Uppdatera");

            ShowAllBlogPostsBrief();

            Write("\nVilken bloggpost vill du uppdatera? ");

            int blogPostId = int.Parse(Console.ReadLine());

            var blogPost = context.BlogPosts.Find(blogPostId);

            WriteLine("Den nuvarande titeln är: " + blogPost.Title);

            Write("Skriv in ny titel: ");

            string newTitle = Console.ReadLine();

            blogPost.Title = newTitle;

            WriteLine("Den nuvarande författaren är: " + blogPost.Author);

            Write("Skriv in ny författare: ");

            string newFörfattare = Console.ReadLine();

            blogPost.Author = newFörfattare;

            context.BlogPosts.Update(blogPost);
            context.SaveChanges();

            Write("Bloggposten uppdaterad.");
            Console.ReadKey();
            MainMenu();
        }

   
        public void InsertPost()
        {
            var insertedPost = new BlogPost();

            Header("Lägg till");

            ShowAllBlogPostsBrief();

            Write("Lägg till en ny title: ");

            string newTitle = string.Format(Console.ReadLine());

            Write("Lägg till en ny författare: ");

            string newAuthor = string.Format(Console.ReadLine());

            insertedPost.Title = newTitle;

            insertedPost.Author = newAuthor;

            context.Add(insertedPost);

            context.SaveChanges();

            Write("Nya bloggen har lagts till");
            Console.ReadKey();
            MainMenu();

        }

        public void DeletePost()
        {

            Header("Radera");

            ShowAllBlogPostsBrief();

            Write("Vilken blog vill  du radera?");

            int blogdId = int.Parse(Console.ReadLine());

            var blogpost = context.BlogPosts.Find(blogdId);

            context.Remove(blogpost);

            context.SaveChanges();

            Write("Bloggen är nu raderad");
            Console.ReadKey();
            MainMenu();

        }



        private void ShowAllBlogPostsBrief()
        {
            foreach (var x in context.BlogPosts)
            {
                WriteLine(x.Id.ToString().PadRight(5) + x.Title.PadRight(30) + x.Author.PadRight(20));
            }
        }

        private void Header(string text)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine(text.ToUpper());
            Console.WriteLine();
        }
        private void WriteLine(string text = "")
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(text);
        }

        private void Write(string text)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(text);
        }
    }

}
