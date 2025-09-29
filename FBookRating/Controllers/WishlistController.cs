using FBookRating.Models.DTOs.WishList;
using FBookRating.Models.Entities;
using FBookRating.Services;
using FBookRating.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FBookRating.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class WishlistController : ControllerBase
    {
        private readonly IWishlistService _wishlistService;

        public WishlistController(IWishlistService wishlistService)
        {
            _wishlistService = wishlistService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserWishlists()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var wishlists = await _wishlistService.GetWishlistsByUserAsync(userId);
            return Ok(wishlists);
        }

        [HttpPost]
        public async Task<IActionResult> AddWishlist([FromBody] WishlistCreateDTO wishlistDTO)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await _wishlistService.AddWishlistAsync(wishlistDTO, userId);
            return Created("", "Wishlist created successfully.");
        }

        [HttpPost("{wishlistId}/books/{bookId}")]
        public async Task<IActionResult> AddBookToWishlist(Guid wishlistId, Guid bookId)
        {
            await _wishlistService.AddBookToWishlistAsync(wishlistId, bookId);
            return NoContent();
        }

        [HttpDelete("{wishlistId}/books/{bookId}")]
        public async Task<IActionResult> RemoveBookFromWishlist(Guid wishlistId, Guid bookId)
        {
            await _wishlistService.RemoveBookFromWishlistAsync(wishlistId, bookId);
            return NoContent();
        }

        [HttpDelete("{wishlistId}")]
        public async Task<IActionResult> DeleteWishlist(Guid wishlistId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Console.WriteLine($"DeleteWishlist controller called with wishlistId: {wishlistId}, userId: {userId}");
            
            if (string.IsNullOrEmpty(userId))
            {
                Console.WriteLine("User ID is null or empty");
                return Unauthorized("User not authenticated");
            }
            
            await _wishlistService.DeleteWishlistAsync(wishlistId, userId);
            return Ok("Wishlist deleted successfully.");
        }
    }
}
