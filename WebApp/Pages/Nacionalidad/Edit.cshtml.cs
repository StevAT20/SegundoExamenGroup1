using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WBL;

namespace WebApp.Pages.Nacionalidad
{
    public class EditModel : PageModel
    {
        private readonly INacionalidadService nacionalidadService;

        public EditModel(INacionalidadService nacionalidadService)
        {
            this.nacionalidadService = nacionalidadService;
        }

        [BindProperty(SupportsGet = true)]
        public int? id { get; set; }

        [BindProperty]
        [FromBody]
        public NacionalidadEntity Entity { get; set; } = new NacionalidadEntity();

        public async Task<IActionResult> OnGet()
        {
            try
            {
                if (id.HasValue)
                {
                    Entity = await nacionalidadService.GetByID(new()
                    {
                        IdNacionalidad = id
                    });
                }
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
                if (Entity.IdNacionalidad.HasValue)
                {
                    result = await nacionalidadService.Update(Entity);
                }
                else
                //Metodo insertar
                {
                    result = await nacionalidadService.Create(Entity);
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
