using MovieCRM.Core.Contracts.Repository;
using MovieCRM.Core.Entities;
using MovieCRM.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCRM.Infrastructure.Repository
{
    public class ActorsRepositoryAsync : BaseRepositoryAsync<MovieActors>, IActorsRepositoryAsync
    {
        public ActorsRepositoryAsync(MovieShopDbContext _content) : base(_content)
        {

        }
    }
}
