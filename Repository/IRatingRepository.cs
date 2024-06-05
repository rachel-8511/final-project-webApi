using Entities;

namespace Repository
{
    public interface IRatingRepository
    {
        Task<Rating> addRating(Rating rating);
    }
}