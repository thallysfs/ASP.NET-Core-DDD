using System;
using System.Net;
using System.Threading.Tasks;
using Api.Domain.Dtos.User;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    // Declaração para identificar as rotas e para que o controller seja de api
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _service;

        public UsersController(IUserService service)
        {
            _service = service;
        }


        [Authorize("Bearer")]
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            // verifica se na model não está ok
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); //400 bad request - Solicitação inválida
            }

            try
            {
                return Ok(await _service.GetAll()); //200 Requisição bem sucedida
            }
            catch (ArgumentException e)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Authorize("Bearer")]
        // localhost:5000/api/users/3215645
        [HttpGet]
        [Route("{id}", Name = "GetWithId")]
        public async Task<ActionResult> Get(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); //400 bad request - Solicitação inválida
            }

            try
            {
                return Ok(await _service.Get(id)); //200 Requisição bem sucedida
            }
            catch (ArgumentException e)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Authorize("Bearer")]
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UserDtoCreate user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); //400 bad request - Solicitação inválida
            }

            try
            {
                var result = await _service.Post(user);
                if (result != null)
                {
                    /* aqui irei retornar o objeto result
                    * E no cabeçalho, irei retornar o link do get por id Uri(Url.Link("GetWithId", new {id = result.Id})
                    */
                    return Created(new Uri(Url.Link("GetWithId", new { id = result.Id })), result);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (ArgumentException e)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Authorize("Bearer")]
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] UserDtoUpdate user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); //400 bad request - Solicitação inválida
            }

            try
            {
                var result = await _service.Put(user);
                if (result != null)
                {
                    /* aqui irei retornar o objeto result
                    * E no cabeçalho, irei retornar o link do get por id Uri(Url.Link("GetWithId", new {id = result.Id})
                    */
                    return Ok(result);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (ArgumentException e)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }

        }

        [Authorize("Bearer")]
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); //400 bad request - Solicitação inválida
            }

            try
            {
                return Ok(await _service.Delete(id)); //200 Requisição bem sucedida
            }
            catch (ArgumentException e)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
