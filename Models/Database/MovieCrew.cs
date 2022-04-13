namespace MoviePro.Models.Database
{
    public class MovieCrew
    {
        public int Id { get; set; }
        public int MovieId { get; set; } //  foreign key

        public int CrewID { get; set; }
        public string Department { get; set; }
        public string Name { get; set; }
        public string Job { get; set; }
        public string ImageUrl { get; set; } //  this property stores full path to am image online for this crew member

        // nav property
        public Movie Movie { get; set; }  //  holds the entire movie record pointed to by the movieId foreign key
    }
}
