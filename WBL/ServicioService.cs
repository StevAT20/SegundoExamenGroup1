using BD;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WBL
{
    public interface IServicioService
    {
        Task<DBEntity> Create(ServicioEntity entity);
        Task<DBEntity> Delete(ServicioEntity entity);
        Task<IEnumerable<ServicioEntity>> Get();
        Task<IEnumerable<ServicioEntity>> GetListar();
        Task<ServicioEntity> GetByID(ServicioEntity entity);
        Task<DBEntity> Update(ServicioEntity entity);
    }

    public class ServicioService : IServicioService
    {
        private readonly IDataAccess sql;

        public ServicioService(IDataAccess _sql)
        {
            sql = _sql;
        }


        #region Metodos CRUD

        public async Task<IEnumerable<ServicioEntity>> Get()
        {
            try
            {
                var result = sql.QueryAsync<ServicioEntity>("dbo.ServicioObtener");
                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Medoto de obtener por Id

        public async Task<ServicioEntity> GetByID(ServicioEntity entity)
        {
            try
            {
                var result = sql.QueryFirstAsync<ServicioEntity>("dbo.ServicioObtener", new { entity.IdServicio });
                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<DBEntity> Create(ServicioEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("dbo.ServicioInsertar",
                new
                {
                    entity.NombreServicio,
                    entity.PlazoEntrega,
                    entity.CostoServicio,
                    entity.Estado,
                    entity.CuentaContable
                });

                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<DBEntity> Update(ServicioEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("dbo.ServicioActualizar", new
                {
                    entity.IdServicio,
                    entity.NombreServicio,
                    entity.PlazoEntrega,
                    entity.CostoServicio,
                    entity.Estado,
                    entity.CuentaContable
                });
                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<DBEntity> Delete(ServicioEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("dbo.ServicioEliminar", new { entity.IdServicio });
                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion

        #region ListarServico

        public async Task<IEnumerable<ServicioEntity>> GetLista()
        {
            try
            {
                var result = sql.QueryAsync<ServicioEntity>("dbo.ServicioLista");
                return await result;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public Task<IEnumerable<ServicioEntity>> GetListar()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
