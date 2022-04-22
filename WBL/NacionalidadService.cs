using BD;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WBL
{
    public interface INacionalidadService
    {
        Task<DBEntity> Create(NacionalidadEntity entity);
        Task<DBEntity> Delete(NacionalidadEntity entity);
        Task<IEnumerable<NacionalidadEntity>> Get();
        Task<IEnumerable<NacionalidadEntity>> GetLista();
        Task<NacionalidadEntity> GetByID(NacionalidadEntity entity);
        Task<DBEntity> Update(NacionalidadEntity entity);
    }

    public class NacionalidadService : INacionalidadService
    {
        private readonly IDataAccess sql;

        public NacionalidadService(IDataAccess _sql)
        {
            sql = _sql;
        }

        #region Metodos CRUD

        public async Task<IEnumerable<NacionalidadEntity>> Get()
        {
            try
            {
                var result = sql.QueryAsync<NacionalidadEntity>("dbo.NacionalidadObtener");
                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Medoto de obtener por Id

        public async Task<NacionalidadEntity> GetByID(NacionalidadEntity entity)
        {
            try
            {
                var result = sql.QueryFirstAsync<NacionalidadEntity>("dbo.NacionalidadObtener", new { entity.IdNacionalidad });
                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<DBEntity> Create(NacionalidadEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("dbo.NacionalidadInsertar", new
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

        public async Task<DBEntity> Update(NacionalidadEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("dbo.NacionalidadActualizar", new
                {
                    entity.IdNacionalidad,
                    entity.Nombre,
                });
                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<DBEntity> Delete(NacionalidadEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("dbo.NacionalidadEliminar", new { entity.IdNacionalidad });
                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion

        #region Metodos Varios

        public async Task<IEnumerable<NacionalidadEntity>> GetLista()
        {
            try
            {
                var result = sql.QueryAsync<NacionalidadEntity>("dbo.NacionalidadLista");
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
