﻿using MoviePro.Models.Database;
using MoviePro.Models.TMDB;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MoviePro.Models.ViewModels
{
    public class LandingPageVM
    {
        public List<Collection> CustomCollections { get; set; }
        public MovieSearch NowPlaying { get; set; }
        public MovieSearch Popular { get; set; }
        public MovieSearch TopRated { get; set; }
        public MovieSearch Upcoming { get; set; }

    }
}
