using BD;
using Entity;
using Entity.dbo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WBL
{
    public interface ITipoClienteService
    {
        Task<DBEntity> Create(TipoClienteEntity entity);
        Task<DBEntity> Delete(TipoClienteEntity entity);
        Task<IEnumerable<TipoClienteEntity>> Get();
        Task<TipoClienteEntity> GetByID(TipoClienteEntity entity);
        Task<IEnumerable<TipoClienteEntity>> GetLista();
        Task<DBEntity> Update(TipoClienteEntity entity);
    }

    public class TipoClienteService : ITipoClienteService
    {
        private readonly IDataAccess sql;

        public TipoClienteService(IDataAccess _sql)
        {
            sql = _sql;
        }

        #region Metodos CRUD

        public async Task<IEnumerable<TipoClienteEntity>> Get()
        {
            try
            {
                var result = sql.QueryAsync<TipoClienteEntity>("dbo.TipoClienteObtener");
                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Medoto de obtener por Id

        public async Task<TipoClienteEntity> GetByID(TipoClienteEntity entity)
        {
            try
            {
                var result = sql.QueryFirstAsync<TipoClienteEntity>("dbo.TipoClienteObtener", new { entity.IdTipoCliente });
                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<DBEntity> Create(TipoClienteEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("dbo.TipoClienteInsertar", new
                {
                    entity.Nombre,
                });
                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<DBEntity> Update(TipoClienteEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("dbo.TipoClienteActualizar", new
                {
                    entity.IdTipoCliente,
                    entity.Nombre,
                });
                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<DBEntity> Delete(TipoClienteEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("dbo.TipoClienteEliminar", new { entity.IdTipoCliente });
                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion

        #region Metodos Varios

        public async Task<IEnumerable<TipoClienteEntity>> GetLista()
        {
            try
            {
                var result = sql.QueryAsync<TipoClienteEntity>("dbo.TipoClienteLista");
                return await result;
            }
            catch (Exception)
            {

                throw;
            }

        }

        #endregion
    }
}
