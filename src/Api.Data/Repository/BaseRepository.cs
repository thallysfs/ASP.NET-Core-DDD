using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly MyContext _context;
        private DbSet<T> _dataset;

        public BaseRepository(MyContext context)
        {
            _context = context;
            _dataset = context.Set<T>();
        }
        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                /* aqui irei pesquisar um único objeto com o id igual a item.Id. Se encontrar, armazeno o objeto em 
                result, se não, returno nulo sem dar erro (SingleOrDefaultAsync)
                */
                //var resul = await SelectAsync(id); Exemplo de seleção aproveitando meu método abaixo de select
                var result = await _dataset.SingleOrDefaultAsync(x => x.Id.Equals(id));

                if (result == null)
                {
                    return false;
                }

                _dataset.Remove(result);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<T> InsertAsync(T item)
        {
            try
            {
                //verificar se o id existe
                if (item.Id == Guid.Empty)
                {
                    item.Id = Guid.NewGuid();
                }
                // aqui alimento o CreatAt com a data de agora do hora universal (3 horas a mais do Brasil)
                item.CreteAt = DateTime.UtcNow;
                _dataset.Add(item);

                await _context.SaveChangesAsync();


            }
            catch (Exception e)
            {
                throw e;
            }

            return item;
        }

        public async Task<bool> ExistAsync(Guid id)
        {
            // o retorno do AnyAsync já retorna bool.
            // Esse método vai procurar se o id passado já existe ou não
            return await _dataset.AnyAsync(x => x.Id.Equals(id));
        }


        public async Task<T> SelectAsync(Guid id)
        {
            try
            {
                return await _dataset.SingleOrDefaultAsync(x => x.Id.Equals(id));
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task<IEnumerable<T>> SelectAsync()
        {
            try
            {
                return await _dataset.ToListAsync();
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task<T> UpdateAsync(T item)
        {
            try
            {
                /* aqui irei pesquisar um único objeto com o id igual a item.Id. Se encontrar, armazeno o objeto em 
                result, se não, returno nulo sem dar erro (SingleOrDefaultAsync)
                */
                var result = await _dataset.SingleOrDefaultAsync(x => x.Id.Equals(item.Id));

                if (result == null)
                {
                    return null;
                }
                // alimentando a data da atualização
                item.UpdateAt = DateTime.UtcNow;
                // alimentando o creat com a mesma data que ele foi criado armazenada no banco. resul é o objeto com o resgistro do banco
                item.CreteAt = result.CreteAt;
                // aqui faço uma entrada em result (Entry) com os valores (CurrentValues.SetValues) de item
                _context.Entry(result).CurrentValues.SetValues(item);
                await _context.SaveChangesAsync();


            }
            catch (Exception e)
            {
                throw e;
            }

            return item;
        }
    }
}
