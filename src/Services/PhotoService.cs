using RedeSocialAPI.Models.Data;
using RedeSocialAPI.src.Base.Contracts.Repository;
using RedeSocialAPI.src.Base.Contracts.Service;

namespace RedeSocialAPI.src.Services
{
    public class PhotoService : IPhotoService
    {
        #region Constructor
        private readonly IPhotosRepository _repository;
        private readonly string _uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "Public", "img");
        public PhotoService(IPhotosRepository repository)
        {
            _repository = repository;
        }

        #endregion

        public async Task<List<Photos>> Create(List<IFormFile> files, int postId)
        {
            if (files == null || files.Count == 0)
            {
                throw new Exception("Nenhum arquivo foi enviado");
            }
            List<Photos> photos = new List<Photos>();
            foreach (IFormFile file in files)
            {
                if (file.Length > 0)
                {
                    string guid = Guid.NewGuid().ToString();
                    string newName = guid + Path.GetExtension(file.FileName);
                    var filePath = Path.Combine(_uploadFolder, newName);
                    string getFileName = Path.GetFileName(filePath);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    var photo = await _repository.Create(new Photos()
                    {
                        PostId = postId,
                        UrlPhoto = getFileName
                    });
                    photos.Add(photo);
                }
            }

            return photos;
        }

        public async Task<bool> Delete(int id)
        {
            return await _repository.Delete(id);
        }

        public async Task<Photos> Get(int id)
        {
            return await _repository.Get(id);
        }

        public async Task<List<Photos>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<Photos> Update(Photos updateDTO)
        {
            return await _repository.Update(updateDTO);
        }

        public async Task<Photos> UpdateById(int id, Photos updateDTO)
        {
            return await _repository.UpdateById(id, updateDTO);
        }
    }
}
