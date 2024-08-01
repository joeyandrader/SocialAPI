using System.Text;

namespace Infrastructure.Querys
{
    public static class PersonQuery
    {


        /// <summary>
        /// Create Person query
        /// </summary>
        /// <returns></returns>
        public static string Create()
        {
            StringBuilder str = new();
            str.Append(@"
                INSERT INTO public.persons
                (username, email, passwordhash, bio, profilepictureurl, createdat)
                VALUES(
                @UserName, 
                @Email, 
                @PasswordHash,
                @Bio,
                @ProfileUrl,
                current_date)
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

        public static string Get()
        {
            StringBuilder str = new();
            str.Append(@"SELECT * FROM public.persons WHERE id = @Id");
            return str.ToString();
        }

        /// <summary>
        /// Get All persons
        /// </summary>
        /// <returns></returns>
        public static string GetAll()
        {
            StringBuilder str = new();
            str.Append(@"SELECT id,
                                username,
                                email,
                                bio,
                                profilepictureurl,
                                createdat,
                                updatedat
                        FROM public.persons");
            return str.ToString();
        }

        public static string Delete()
        {
            StringBuilder str = new();
            str.Append(@"DELETE FROM public.persons
                WHERE id = @Id;");
            return str.ToString();
        }

        public static string Update()
        {
            StringBuilder str = new();
            str.Append(@"
            UPDATE public.persons
            SET username = @UserName,
                email = @Email, 
                passwordhash  =@PasswordHash, 
                bio = @Bio, 
                profilepictureurl = @ProfilePictureUrl, 
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
    }
}
