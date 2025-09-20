using Hero.Application.Hero.CreateHero;
using Hero.Application.Hero.GetHero;
using Hero.Application.Hero.GetHeroType;
using Hero.Shared.DTO.Hero;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Server.Features.Hero.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroController(IMediator mediator)
        : ControllerBase
    {
        //private readonly IHeroViewService _heroViewService = heroViewService;
        private readonly IMediator _mediator = mediator;

        [HttpGet("GetHeroes")]
        [ResponseCache(Duration = 3600)]
        public async Task<IReadOnlyList<HeroDTO>> GetHero()
        {
            var result = await _mediator.Send(new GetHeroQuery());  
            if (!result.Success)
            {
                throw new InvalidOperationException(result.Error);
            }
            return result.Value!;
        }

        [HttpGet("GetHeroTypes")]
        //[ResponseCache(Duration = 3600)]
        public async Task<IReadOnlyList<HeroTypeDTO>> GetHeroTypes()
        {
            var result = await _mediator.Send(new GetHeroTypeQuery());
            if (!result.Success)
            {
                throw new InvalidOperationException(result.Error);
            }
            return result.Value!;
        }

        [HttpGet("GetHeroById/{heroid}")]
        public async Task<HeroDTO> GetHeroById(int heroid)
        {
            var result = await _mediator.Send(new GetHeroByIdQuery() { HeroId = heroid });
            if (!result.Success)
            {
                throw new InvalidOperationException(result.Error);
            }
            return result;
        }

        [HttpGet("GetHeroAttributes/{heroid}")]
        //[ResponseCache(Duration = 3600)]
        public async Task<HeroAttributesDTO> GetHeroAttributes(int heroid)
        {
            var result = await _mediator.Send(new GetHeroAttributesQuery() { HeroId = heroid });
            if (!result.Success)
            {
                throw new InvalidOperationException(result.Error);
            }
            return result.Value!;
        }

        [HttpPost("CreateHero")]
        public async Task<HeroDTO> CreateHero(HeroDTO hero)
        {
            var result = await _mediator.Send(new CreateHeroCommand()
            {
                Name = hero.name,
                Type = hero.type,
                Story = hero.story
            });
            if (!result.Success)
            {
                throw new InvalidOperationException(result.Error);
            }
            return result.Value;
        }

        [HttpPut("UpdateHero/{heroid}")]
        public async Task<HeroDTO?> UpdateHero(int heroid, HeroDTO hero)
        {
            var result = await _mediator.Send(new UpdateHeroCommand()
            {
                Id = heroid,
                Name = hero.name,
                Type = hero.type,
                Story = hero.story
            });
            if (!result.Success)
            {
                throw new InvalidOperationException(result.Error);
            }
            return result.Value;
        }
    }
}
