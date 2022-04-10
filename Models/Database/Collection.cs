using System.Collections.Generic;

namespace MoviePro.Models.Database
{
    public class Collection
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        // nav property
        //the Collection will have MovieCollection as its childern 
        public ICollection<MovieCollection> MovieCollections { get; set; } = new HashSet<MovieCollection>();
    }
}
