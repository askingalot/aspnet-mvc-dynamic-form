using System.Collections.Generic;
using DynamicForms.Models;

namespace DynamicForms.Models.ViewModels {
    public class QuoteRatingViewModel {
        public List<Rating> RatingOptions {get; set;}
        public List<QuoteRating> QuoteRatings {get; set;}

        public QuoteRatingViewModel()
        {
            RatingOptions = new List<Rating> {
                new Rating {
                    Id = 1,
                    Text = "Bad",
                },
                new Rating {
                    Id = 2,
                    Text = "Average",
                },
                new Rating {
                    Id = 3,
                    Text = "Good",
                },
            };
        }
    }
}