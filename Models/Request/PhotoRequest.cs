using RedeSocialAPI.Models.Data;

namespace RedeSocialAPI.Models.Request
{
    public class PhotoRequest : Photos
    {
        public List<IFormFile> Files { get; set; }
    }
}
