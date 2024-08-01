using System.Text;

namespace Infrastructure.Querys
{
    public static class PersonQuery
    {
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
                @Bio
                @ProfileImg,
                CURRENT_TIMESTAMP);
            ");
            return str.ToString();
        }
    }
}
