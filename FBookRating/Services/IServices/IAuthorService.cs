using FBookRating.Models.DTOs.Author;
using FBookRating.Models.Entities;

namespace FBookRating.Services.IServices
{
    public interface IAuthorService
    {
        Task<IEnumerable<AuthorReadDTO>> GetAllAuthorsAsync();
        Task<AuthorReadDTO> GetAuthorByIdAsync(Guid id);
        Task AddAuthorAsync(AuthorCreateDTO authorDTO);

        Task UpdateAuthorAsync(Guid id, AuthorUpdateDTO authorUpdateDTO);
        Task DeleteAuthorAsync(Guid id);
    }
}
