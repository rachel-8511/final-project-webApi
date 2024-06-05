using Entities;

namespace Service
{
    public interface IRatingService
    {
        Task<Rating> addRating(Rating rating);
    }
}