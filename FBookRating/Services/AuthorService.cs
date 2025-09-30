using FBookRating.DataAccess.UnitOfWork;
using FBookRating.Models.DTOs.Author;
using FBookRating.Models.Entities;
using FBookRating.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace FBookRating.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AuthorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Get all authors.
        /// </summary>
        public async Task<IEnumerable<AuthorReadDTO>> GetAllAuthorsAsync()
        {
            var authors = await _unitOfWork.Repository<Author>().GetAll().ToListAsync();
            return authors.Select(author => new AuthorReadDTO
            {
                Id = author.Id,
                Name = author.Name,
                Biography = author.Biography,
                BirthDate = author.BirthDate
            }).ToList();
        }

        /// <summary>
        /// Get an author by ID.
        /// </summary>
        public async Task<AuthorReadDTO> GetAuthorByIdAsync(Guid id)
        {
            var author = await _unitOfWork.Repository<Author>().GetByCondition(a => a.Id == id).FirstOrDefaultAsync();
            if (author == null) return null;

            // Map entity to DTO
            return new AuthorReadDTO
            {
                Id = author.Id,
                Name = author.Name,
                Biography = author.Biography,
                BirthDate = author.BirthDate
            };
        }

        /// <summary>
        /// Add a new author.
        /// </summary>
        public async Task AddAuthorAsync(AuthorCreateDTO authorDTO)
        {
            var author = new Author
            {
                Name = authorDTO.Name,
                Biography = authorDTO.Biography,
                BirthDate = authorDTO.BirthDate
            };

            _unitOfWork.Repository<Author>().Create(author);
            await _unitOfWork.Repository<Author>().SaveChangesAsync();
        }

        /// <summary>
        /// Update an existing author.
        /// </summary>
        /// <param name="id">ID of the author to update.</param>
        /// <param name="author">Updated author details.</param>
        /// 


        /// <summary>
        /// Update an existing author.
        /// </summary>
        public async Task UpdateAuthorAsync(Guid id, AuthorUpdateDTO authorUpdateDTO)
        {
            var existingAuthor = await _unitOfWork.Repository<Author>().GetByCondition(a => a.Id == id).FirstOrDefaultAsync();
            if (existingAuthor == null) throw new Exception("Author not found.");

            // Update only the fields you want to modify
            existingAuthor.Name = authorUpdateDTO.Name;
            existingAuthor.Biography = authorUpdateDTO.Biography;
            existingAuthor.BirthDate = authorUpdateDTO.BirthDate;

            _unitOfWork.Repository<Author>().Update(existingAuthor);
            await _unitOfWork.Repository<Author>().SaveChangesAsync();
        }

        /// <summary>
        /// Delete an author.
        /// </summary>
        public async Task DeleteAuthorAsync(Guid id)
        {
            var author = await _unitOfWork.Repository<Author>().GetByCondition(a => a.Id == id).FirstOrDefaultAsync();
            if (author != null)
            {
                _unitOfWork.Repository<Author>().Delete(author);
                await _unitOfWork.Repository<Author>().SaveChangesAsync();
            }
        }
    }
}
