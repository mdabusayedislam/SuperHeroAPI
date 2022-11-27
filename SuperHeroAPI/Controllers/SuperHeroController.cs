﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SuperHeroAPI.Services.SuperHeroService;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private static List<SuperHero> superHeroes = new List<SuperHero>()
            {
                new SuperHero
                {
                    Id = 1,
                    Name = "SuperMan",
                    FirstName = "Super",
                    LastName = "Man",
                    Place = "USA"
                },
                new SuperHero
                {
                    Id = 2,
                    Name = "SpiderMan",
                    FirstName = "Spider",
                    LastName = "Man",
                    Place = "UK"
                },
                new SuperHero
                {
                    Id = 3,
                    Name = "IronMan",
                    FirstName = "Iron",
                    LastName = "Man",
                    Place = "USA"
                }
            };
        private readonly ISuperHeroService _superHeroService;
        public SuperHeroController(ISuperHeroService superHeroService)
        {
            _superHeroService = superHeroService;
        }

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetAllHeroes()
        {
            return await _superHeroService.GetAllHeroes();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> GetSingleHero(int id)
        {
            var result = await _superHeroService.GetSingleHero(id);
            if (result is null)
                return NotFound("Super Hero  not found");
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddSuperHero(SuperHero hero)
        {
            var result = await _superHeroService.AddSuperHero(hero);
            if (result is null)
                return NotFound("Super Hero  not found");
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<SuperHero>>> UpdateSingleHero(int id, SuperHero request)
        {
            var result = await _superHeroService.UpdateSingleHero(id, request);
            if (result is null)
                return NotFound("Super Hero  not found");
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> DeleteSingleHero(int id)
        {
            var result = await _superHeroService.DeleteSingleHero(id);
            if (result is null)
                return NotFound("Super Hero  not found");
            return Ok(result);
        }
    }
}
