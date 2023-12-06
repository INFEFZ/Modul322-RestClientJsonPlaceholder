using RestClient.Models;
using RestClient.Repositories;
using RestClient.Utility;
using System.Collections.ObjectModel;

namespace RestClient.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private ObservableCollection<Album> _albumList = new();
        public RelayCommand LoadCommand { get; set; }


        public MainViewModel()
        {
            LoadCommand = new RelayCommand(async param => await Execute_LoadAsync(), param => true);
        }

        private async Task Execute_LoadAsync()
        {
            var res = await Api.GetAlbum();
            if (res != null) 
                AlbumList = new ObservableCollection<Album>(res);
        }

        public ObservableCollection<Album> AlbumList
        {
            get => _albumList;
            set
            {
                SetProperty(ref _albumList, value);
            } 
        }
    }
}
