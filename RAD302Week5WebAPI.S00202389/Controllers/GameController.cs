using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationGames.Data;
using WebApplicationGames.Models;

namespace RAD302Week5WebAPI.S00202389.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGame<Game> _repository;
        public GameController(IGame<Game> repository)
        {
            _repository = repository;
        }




        [HttpGet]
        [Authorize]
        public IEnumerable<Game> Get()
        {
            return _repository.GetAll();
        }



        [HttpGet("id/{id}")]
        [Authorize]
        public Game GetById(int id)
        {
            return _repository.Get(id);
        }



        [HttpPost]
        [Authorize]
        public void Post([FromBody] Game p)
        {
            _repository.Add(p);
        }
    }
}
