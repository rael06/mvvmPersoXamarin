using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using mvvmperso.Core;
using mvvmperso.Models;

namespace mvvmperso.Services
{
    public interface IApiService
    {
        Task<Response<List<Article>>> GetArticles();
    }
}
