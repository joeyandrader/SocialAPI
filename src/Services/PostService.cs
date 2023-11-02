using RedeSocialAPI.Models.Data;
using RedeSocialAPI.src.Base.Contracts.Repository;
using RedeSocialAPI.src.Base.Contracts.Service;

namespace RedeSocialAPI.src.Services
{
    public class PostService : IPostService
    {
        #region Constructor
        private readonly IPostRepository _repository;
        public PostService(IPostRepository repository)
        {
            _repository = repository;
        }

        public async Task<Post> Create(Post createDTO)
        {
            return await _repository.Create(createDTO);
        }

        public async Task<bool> Delete(int id)
        {
            return await _repository.Delete(id);
        }

        public async Task<Post> Get(int id)
        {
            return await _repository.Get(id);
        }

        public async Task<List<Post>> List()
        {
            return await _repository.List();
        }

        public async Task<Post> Update(Post updateDTO)
        {
            return await _repository.Update(updateDTO);
        }

        public async Task<Post> UpdateById(int id, Post updateDTO)
        {
            return await _repository.UpdateById(id, updateDTO);
        }
        #endregion
    }
}
