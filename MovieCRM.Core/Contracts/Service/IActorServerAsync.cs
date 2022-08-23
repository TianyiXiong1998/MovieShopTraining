using MovieCRM.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCRM.Core.Contracts.Service
{
    public interface IActorServerAsync
    {
        Task<int> InsertActors(ActorsModel actorsModel);
        Task<IEnumerable<ActorsModel>> GetAllActors();
        Task<int> DeleteActors(int id);
        Task<int> UpdateActors(ActorsModel actorsModel);
        Task<ActorsModel> GetActorsById(int id);
    }
}
