using BD;
using Entity.dbo;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WBL
{
    public interface IClienteService
    {
        Task<DBEntity> Create(ClienteEntity entity);
        Task<DBEntity> Delete(ClienteEntity entity);
        Task<IEnumerable<ClienteEntity>> Get();
        Task<ClienteEntity> GetByID(ClienteEntity entity);
        Task<DBEntity> Update(ClienteEntity entity);
    }

    public class ClienteService : IClienteService
    {
        private readonly IDataAccess sql;

        public ClienteService(IDataAccess _sql)
        {
            sql = _sql;
        }

        #region Metodos CRUD

        public async Task<IEnumerable<ClienteEntity>> Get()
        {
            try
            {
                var result = sql.QueryAsync<ClienteEntity, NacionalidadEntity>("dbo.ClienteObtener", "IdCliente,IdNacionalidad");
                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Medoto de obtener por Id

        public async Task<ClienteEntity> GetByID(ClienteEntity entity)
        {
            try
            {
                var result = sql.QueryFirstAsync<ClienteEntity>("dbo.ClienteObtener", new { entity.IdCliente });
                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<DBEntity> Create(ClienteEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("dbo.ClienteInsertar", new
                {
                    entity.Identificacion,
                    entity.IdNacionalidad,
                    entity.IdTipoIdentificacion,
                    entity.Nombre,
                    entity.PrimerApellido,
                    entity.SegundoApellido,
                    entity.FechaNacimiento,                    
                    entity.FechaDefuncion,
                    entity.Genero,
                    entity.NombreApellidosPadre,
                    entity.NombreApellidosMadre,
                    entity.Pasaporte,
                    entity.CuentaIBAN,
                    entity.CorreoNotifica
                });
                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<DBEntity> Update(ClienteEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("dbo.ClienteActualizar", new
                {
                    entity.IdCliente,
                    entity.IdNacionalidad,
                    entity.Identificacion,
                    entity.IdTipoIdentificacion,
                    entity.Nombre,
                    entity.PrimerApellido,
                    entity.SegundoApellido,
                    entity.FechaNacimiento,                    
                    entity.FechaDefuncion,
                    entity.Genero,
                    entity.NombreApellidosPadre,
                    entity.NombreApellidosMadre,
                    entity.Pasaporte,
                    entity.CuentaIBAN,
                    entity.CorreoNotifica
                });
                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<DBEntity> Delete(ClienteEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("dbo.ClienteEliminar", new { entity.IdCliente });
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
