using System;
using mvvmperso.Models;

namespace mvvmperso.ViewModels
{
    public class ArticleDetailsViewModel : ViewModelBase
    {
        public Article Article { get; set; }

        public ArticleDetailsViewModel()
        {
        }
    }
}
