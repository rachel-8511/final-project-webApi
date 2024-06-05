using System.Text.Json;
using Entities;
using Project;
using Repository;

namespace Service
{
    public class RatingService : IRatingService

    {

        IRatingRepository _ratingRepository;
        public RatingService(IRatingRepository ratingRepository)
        {
            _ratingRepository = ratingRepository;
        }
        public async Task<Rating> addRating(Rating rating)
        {
           
               return await _ratingRepository.addRating(rating);
           
        }
    }
}
