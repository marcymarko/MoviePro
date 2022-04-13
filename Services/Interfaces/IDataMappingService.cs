using MoviePro.Models.Database;
using MoviePro.Models.TMDB;
using System.Threading.Tasks;

namespace MoviePro.Services.Interfaces
{
    public interface IDataMappingService
    {
        Task<Movie> MapMovieDetailAsync(MovieDetail movie);
        Task<Movie> MapActorDetail(ActorDetail actor);
    }
}
