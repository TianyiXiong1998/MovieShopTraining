using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieCRM.Core.Contracts.Service;
using MovieCRM.Core.Models;
using MovieShopMVC.Core.Controllers;
using MovieShopMVC.Core.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MVCProject.Controllers
{
    public class MovieController : Controller
    {
        IActorServerAsync actorServerAsync;
        public MovieController(IActorServerAsync _actorserver)
        {
            actorServerAsync = _actorserver;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var results = await actorServerAsync.GetAllActors();
            var actors = new List<ActorsModel>();
            foreach (var result in results)
            {
                actors.Add(result);
            }
            return View(actors);
        }
        // GET: /<controller>/

    }
}