using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Backend.Business
{
    public interface ISearchStrategy
    {
        public Task<List<PublicationDto>> SearchAsync(string query);
    }
}