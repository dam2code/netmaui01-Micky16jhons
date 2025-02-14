using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace MovieCatalog.ViewModels;

public class MovieListViewModel : ObservableObject
{
    private MovieViewModel _selectedMovie;

    public ObservableCollection<MovieViewModel> Movies { get; }

    public MovieViewModel SelectedMovie
    {
        get => _selectedMovie;
        set => SetProperty(ref _selectedMovie, value);
    }
    public object MovieService { get; }

    public MovieListViewModel()
    {
        Movies = new ObservableCollection<MovieViewModel>(MovieService.LoadMovies());
    }

    internal void DeleteMovie(MovieViewModel movie)
    {
        throw new NotImplementedException();
    }

    internal async Task<object> RefreshMovies()
    {
        throw new NotImplementedException();
    }
}