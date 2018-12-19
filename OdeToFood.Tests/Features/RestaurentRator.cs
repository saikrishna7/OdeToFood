using System;
using System.Linq;
using OdeToFood.Models;

namespace OdeToFood.Tests.Features
{
    class RestaurentRator
    {
        private Restaurent _restaurent;

        public RestaurentRator(Restaurent restaurent)
        {
            this._restaurent = restaurent;
        }

        
        public RatingResult ComputeResult(IRatingAlgorithm algorithm, int numOfReviewsToUse)
        {
            var filteredReviews = _restaurent.Reviews.Take(numOfReviewsToUse);
            return algorithm.Compute(filteredReviews.ToList());
        }
    }
}