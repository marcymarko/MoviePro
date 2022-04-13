using MoviePro.Enums;
using MoviePro.Models.TMDB;
using System.Threading.Tasks;

namespace MoviePro.Services.Interfaces
{
    public interface IRemoteMovieService
    {
        Task<MovieDetail> MovieDetailAsync(int id); // takes an Id and returns a task of type MovieDetail
        Task<MovieSearch> SearchMovieAsync(MovieCategory category, int count);
        Task<ActorDetail> ActorDetailAsync(int id);
    }
}
