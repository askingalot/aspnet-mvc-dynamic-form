using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DynamicForms.Models;
using DynamicForms.Models.ViewModels;

namespace DynamicForms.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            QuoteRatingViewModel viewmodel = new QuoteRatingViewModel {
               QuoteRatings = AllQuotes.Select(q => 
                    new QuoteRating {
                        Quote = q
                    }
                ).ToList()
            };

            return View(viewmodel);
        }

        [HttpPost]
        public IActionResult Index(QuoteRatingViewModel viewmodel) {
            // READ THIS
            // Put a breakpoint in this method and 
            //  look look at the value of 'viewmodel'
            // This is where we'd save the ratings
            //  if we wanted to do that sort of thing


            return View(viewmodel);
        }

        private List<Quote> AllQuotes {
            get {
                return new List<Quote> {
                    new Quote {
                        Id = 1,
                        Speaker = "Groucho Marx",
                        Text = "Outside of a dog, a book is a man's best friend. Inside of a dog it's too dark to read."
                    },
                    new Quote {
                        Id = 2,
                        Speaker = "Groucho Marx",
                        Text = "I, not events, have the power to make me happy or unhappy today. I can choose which it shall be. Yesterday is dead, tomorrow hasn't arrived yet. I have just one day, today, and I'm going to be happy in it."
                    },
                    new Quote {
                        Id = 3,
                        Speaker = "Groucho Marx",
                        Text = "Getting older is no problem. You just have to live long enough."
                    },
                    new Quote {
                        Id = 4,
                        Speaker = "Mark Twain",
                        Text = "Whenever you find yourself on the side of the majority, it is time to pause and reflect."
                    },
                    new Quote {
                        Id = 5,
                        Speaker = "Mark Twain",
                        Text = "It is better to keep your mouth closed and let people think you are a fool than to open it and remove all doubt."
                    },
                    new Quote {
                        Id = 6,
                        Speaker = "Mark Twain",
                        Text = "The secret of getting ahead is getting started."
                    },
                    new Quote {
                        Id = 7,
                        Speaker = "Gracie Allen",
                        Text = "Brains, integrity, and force may be all very well, but what you need today is Charm. Go ahead and work on your economic programs if you want to, I'll develop my radio personality."
                    },
                    new Quote {
                        Id = 8,
                        Speaker = "Gracie Allen",
                        Text = "I read a book twice as fast as anybody else. First, I read the beginning, and then I read the ending, and then I start in the middle and read toward whatever end I like best."
                    },
                    new Quote {
                        Id = 9,
                        Speaker = "Gracie Allen",
                        Text = "I was so surprised at being born that I didn't speak for a year and a half."
                    },
                };
            }
        }
    }
}
