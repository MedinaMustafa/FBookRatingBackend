﻿using FBookRating.Models.DTOs.WishList;
using FBookRating.Models.Entities;

namespace FBookRating.Services.IServices
{
    public interface IWishlistService
    {
        Task<IEnumerable<WishlistReadDTO>> GetWishlistsByUserAsync(string userId);
        Task AddWishlistAsync(WishlistCreateDTO wishlistDTO, string userId);
        Task AddBookToWishlistAsync(Guid wishlistId, Guid bookId);
        Task RemoveBookFromWishlistAsync(Guid wishlistId, Guid bookId);
        Task DeleteWishlistAsync(Guid wishlistId, string userId);
    }
}
