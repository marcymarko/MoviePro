namespace MoviePro.Models.Database
{
    public class MovieCollection
    {
        public int Id { get; set; }
        public int CollectionId { get; set; }
        public int MovieId { get; set; }

        public int Order { get; set; }

        //nav property
        public Collection Collection { get; set; }  //  stores the entire record that has the primary key of # in the collection table
        public Movie Movie { get; set; }  // stores the entire record that has the primary key of # in the Movie table
    }
}
