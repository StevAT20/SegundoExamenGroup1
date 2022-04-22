using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Entity;
using WBL;
using Entity;

namespace WebApp.Pages.Cliente
{
    public class EditModel : PageModel
    {
        private readonly IClienteService clienteService;
        private readonly INacionalidadService nacionalidadService;
        private readonly ITipoClienteService tipoClienteService;

        public EditModel(IClienteService clienteService, INacionalidadService nacionalidadService, ITipoClienteService tipoClienteService)
        {
            this.clienteService = clienteService;
            this.nacionalidadService = nacionalidadService;
            this.tipoClienteService = tipoClienteService;
        }

        [BindProperty(SupportsGet = true)]
        public int? id { get; set; }

        [BindProperty]
        [FromBody]
        public ClienteEntity Entity { get; set; } = new ClienteEntity();

        public IEnumerable<NacionalidadEntity> NacionalidadLista { get; set; } = new List<NacionalidadEntity>();

        public IEnumerable<TipoClienteEntity> TipoClienteLista { get; set; } = new List<TipoClienteEntity>();

        public async Task<IActionResult> OnGet()
        {
            try
            {
                if (id.HasValue)
                {
                    Entity = await clienteService.GetByID(new()
                    {
                        IdCliente = id
                    });
                }

                NacionalidadLista = await nacionalidadService.GetLista();

                TipoClienteLista = await tipoClienteService.GetLista();

                return Page();
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }

        public async Task<IActionResult> OnPost()
        {
            try
            {
                var result = new DBEntity();
                //Actualización
                if (Entity.IdCliente.HasValue)
                {
                    result = await clienteService.Update(Entity);
                }
                else
                //Metodo insertar
                {
                    result = await clienteService.Create(Entity);
                }
                return new JsonResult(result);
            }
            catch (Exception ex)
            {
                return new JsonResult(new DBEntity
                {
                    CodeError = ex.HResult,
                    MsgError = ex.Message
                });
            }
        }

    }
}
