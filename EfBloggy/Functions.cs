using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfBloggy
{
    public class Functions
    {
        static BlogContext context = new BlogContext();

        public static void ClearDatabase()
        {
            context.RemoveRange(context.BlogPosts);


            context.SaveChanges();
        }

       

        public static void AddSomeTitles()
        {

        var lilyPost = new BlogPost { Title = "The sun is bright", Author = "Lily" };
        var ethanPost = new BlogPost { Title = "I will go swimming", Author = "Ethan" };

            using (var context = new BlogContext())
            {
                context.BlogPosts.AddRange(lilyPost, ethanPost);
                context.SaveChanges();
            }
        }
    }
}
