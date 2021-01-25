using System;
namespace mvvmperso.ViewModels
{
    public class ViewModelLocator
    {
        public ArticleListViewModel ArticleListViewModel { get; } = new();
        public ArticleDetailsViewModel ArticleDetailsViewModel { get; } = new();
    }
}
