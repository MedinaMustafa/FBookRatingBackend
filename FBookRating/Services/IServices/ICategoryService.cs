﻿using FBookRating.Models.DTOs.Category;
using FBookRating.Models.Entities;

namespace FBookRating.Services.IServices
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryReadDTO>> GetAllCategoriesAsync();
        Task<CategoryReadDTO> GetCategoryByIdAsync(Guid id);
        Task AddCategoryAsync(CategoryCreateDTO categoryCreateDTO);
        Task UpdateCategoryAsync(Guid id, CategoryUpdateDTO categoryUpdateDTO);
        Task DeleteCategoryAsync(Guid id);
    }
}
