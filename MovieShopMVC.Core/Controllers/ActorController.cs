using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovieCRM.Core.Contracts.Service;
using MovieCRM.Core.Models;

namespace MovieShopMVC.Core.Controllers
{
    public class ActorController : Controller
    {
        IActorServerAsync actorServerAsync;
        public ActorController(IActorServerAsync _actorserver)
        {
            actorServerAsync = _actorserver;
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Actors = new SelectList(await actorServerAsync.GetAllActors(), "Id", "Name");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync(ActorsModel actorsModel)
        {
            if(ModelState.IsValid)
            {
                await actorServerAsync.InsertActors(actorsModel);
            }
            return View(actorsModel);
        }
    }
}
