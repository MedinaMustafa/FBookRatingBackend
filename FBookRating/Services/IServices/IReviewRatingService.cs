﻿using FBookRating.Models.DTOs.ReviewRating;
using FBookRating.Models.Entities;

namespace FBookRating.Services.IServices
{
    public interface IReviewRatingService
    {
        Task<IEnumerable<ReviewRatingReadDTO>> GetReviewsForBookAsync(Guid bookId);
        Task AddReviewAsync(ReviewRatingCreateDTO reviewRatingDTO, string userId);
        Task<double> GetAverageRatingForBookAsync(Guid bookId);
    }
}
