using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.User;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces.Services.User
{
    /*
        Os retornos estão apontados para Dtos distintos. Isso ocorre pq em * Get eu retorno somente nome e e-mail
        * Post eu retorno o Nome, email e data de criação
        * Update eu retorno nome, login e Atualização
        Isso ocorre porque casa Dto retorna uma cadeia diferente de dados. Em Get, não me interressa retornar a dara de
        criação por exemplo.
        Os Dtos estão definidos em Domain/Dtos/User
    */
    public interface IUserService
    {
        Task<UserDto> Get(Guid id);

        Task<IEnumerable<UserDto>> GetAll();

        Task<UserDtoCreateResult> Post(UserDtoCreate user);

        Task<UserDtoUpdateResult> Put(UserDtoUpdate user);

        Task<bool> Delete(Guid id);



    }
}
