using MovieCRM.Core.Contracts.Repository;
using MovieCRM.Core.Contracts.Service;
using MovieCRM.Core.Entities;
using MovieCRM.Core.Models;
using MovieCRM.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCRM.Infrastructure.Service
{
    public class ActorsServerAsync : IActorServerAsync
    {
        IActorsRepositoryAsync actorsRepositoryAsync;
        public ActorsServerAsync(IActorsRepositoryAsync _actorsRepositoryAsync)
        {
            actorsRepositoryAsync = _actorsRepositoryAsync;
        }

        public Task<int> DeleteActors(int id)
        {
            return actorsRepositoryAsync.DeleteAsync(id);
        }

        public async Task<ActorsModel> GetActorsById(int id)
        {
            var actors = await actorsRepositoryAsync.GetByIdAsync(id);
            if (actors != null)
            {
                ActorsModel actorsModel = new ActorsModel();
                actorsModel.Id = actors.Id;
                actorsModel.Name = actors.Name;
                return actorsModel;
            }
            else return null;
            
        }

        public async Task<IEnumerable<ActorsModel>> GetAllActors()
        {
            var result = await actorsRepositoryAsync.GetAllAsync();
            List<ActorsModel> actors = new List<ActorsModel>();
            if(result!=null)
            {
                foreach(var item in result)
                {
                    ActorsModel a = new ActorsModel();
                    a.Id = item.Id;
                    a.Name = item.Name;
                    actors.Add(a);
                }
            }
            
            return actors;

        }

        public  Task<int> InsertActors(ActorsModel actorsModel)
        {
            MovieActors actors = new MovieActors();
            actors.Name = actorsModel.Name;
            var action = actorsRepositoryAsync.InsertAsync(actors);
            return action;
        }

        public Task<int> UpdateActors(ActorsModel actorsModel)
        {
            MovieActors actors = new MovieActors();
            actors.Id = actorsModel.Id;
            actors.Name = actorsModel.Name;
            var action = actorsRepositoryAsync.UpdateAsync(actors);
            return action;
        }
    }
}
