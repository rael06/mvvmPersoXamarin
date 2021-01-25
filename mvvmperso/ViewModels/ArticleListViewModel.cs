using System;
using System.Collections.Generic;
using System.Windows.Input;
using mvvmperso.Models;
using mvvmperso.Views;
using Xamarin.Forms;

namespace mvvmperso.ViewModels
{
    public class ArticleListViewModel : ViewModelBase
    {
        public ICommand LoadedCommand { get; }

        private List<Article> _articles;
        public List<Article> Articles
        {
            get => _articles;
            private set
            {
                if (_articles != value)
                {
                    _articles = value;
                    OnPropertyChanged(nameof(Articles));
                }
            }
        }

        private Article _selectedArticle;
        public Article SelectedArticle
        {
            get
            {
                return _selectedArticle;
            }
            set
            {
                if (_selectedArticle != value)
                {
                    _selectedArticle = value;
                    OnPropertyChanged(nameof(SelectedArticle));
                    GotoArticleDetailsPage();
                }
            }
        }

        public ArticleListViewModel()
        {
            LoadedCommand = new Command(Loaded);
        }

        public async void Loaded()
        {
            var articlesResponse = await apiService.GetArticles();
            if (articlesResponse.IsSuccess)
                Articles = articlesResponse.Data;
        }

        private void GotoArticleDetailsPage()
        {
            Locator.ArticleDetailsViewModel.Article = SelectedArticle;
            Navigation.PushAsync(new ArticleDetailsPage());
        }
    }
}
