using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Querys
{
    public static class PostQuery
    {
        public static string Create()
        {
            StringBuilder str = new StringBuilder();
            str.Append(@"
            INSERT INTO public.posts (PersonId, Title, Content, ImageUrl, CreatedAt)
            VALUES(@PersonId, @Title, @Content, @ImageUrl, current_date)
            RETURNING Id, PersonId, Title, Content, ImageUrl, CreatedAt, UpdatedAt
            ");
            return str.ToString();
        }

        public static string Update()
        {
            StringBuilder str = new StringBuilder();
            str.Append(@"
                 UPDATE public.posts
            SET Title = @Title,
                Content = @Content, 
                ImageUrl  =@ImageUrl, 
                bio = @Bio,
                updatedat = current_date
            WHERE id = @Id
            RETURNING 
                id,
                username,
                email,
                bio,
                profilepictureurl,
                createdat,
                updatedat;
            ");
            return str.ToString();
        }

        public static string Delete()
        {
            StringBuilder str = new();
            str.Append(@"DELETE FROM public.posts
                WHERE id = @Id;");
            return str.ToString();

        }

        public static string Get()
        {
            StringBuilder str = new StringBuilder();
            str.Append(@"
            SELECT Id,
                Title,
                Content,
                PersonId,
                ImageUrl,
                CreatedAt,
                UpdatedAt
             FROM public.posts
             WHERE Id = @Id
            ");
            return str.ToString();
        }

        public static string GetAll()
        {
            StringBuilder str = new StringBuilder();
            str.Append(@"
            SELECT Id,
                Title,
                Content,
                PersonId,
                ImageUrl,
                CreatedAt,
                UpdatedAt
             FROM public.posts
            ");
            return str.ToString();
        }
    }
}
