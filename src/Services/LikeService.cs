using RedeSocialAPI.Models.Data;
using RedeSocialAPI.src.Base.Contracts.Repository;
using RedeSocialAPI.src.Base.Contracts.Service;

namespace RedeSocialAPI.src.Services
{
    public class LikeService : ILikeService
    {

        #region Constructor
        private readonly ILikeRepository _repository;
        public LikeService(ILikeRepository respository)
        {
            _repository = respository;
        }
        #endregion


        public async Task<Like> Create(Like createDTO)
        {
            Like checkLike = await _repository.GetExistLike(createDTO.PostId);
            if (checkLike != null)
            {
                await this.Delete(checkLike.Id);
                return null;
            }
            return await _repository.Create(createDTO);
        }

        public Task<bool> Delete(int id)
        {
            return _repository.Delete(id);
        }

        public Task<Like> Get(int id)
        {
            return _repository.Get(id);
        }

        public Task<List<Like>> GetAll()
        {
            throw new NotImplementedException();
        }


        public Task<Like> Update(Like updateDTO)
        {
            throw new NotImplementedException();
        }

        public Task<Like> UpdateById(int id, Like updateDTO)
        {
            throw new NotImplementedException();
        }
    }
}
