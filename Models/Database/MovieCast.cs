namespace MoviePro.Models.Database
{
    public class MovieCast
    {
        public int Id { get; set; }
        public int MovieId { get; set; } //foreign key, links the cast member to a particular movie by referencing the primary key of the movie

        public int CastID { get; set; }

        public string Department { get; set; }
        public string Name { get; set; }
        public string Character { get; set; }
        public string ImageUrl { get; set; }  //this property stores full path to am image online for this cast member

        //  navigational property
        public Movie Movie { get; set; }  //holds the entire movie record pointed to by the movieId foreign key
    }
}
