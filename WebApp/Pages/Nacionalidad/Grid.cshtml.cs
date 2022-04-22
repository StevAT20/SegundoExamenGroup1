using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Entity.dbo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WBL;

namespace WebApp.Pages.Nacionalidad
{
    public class GridModel : PageModel
    {
        private readonly INacionalidadService nacionalidadService;

        public GridModel(INacionalidadService nacionalidadService)
        {
            this.nacionalidadService = nacionalidadService;
        }

        public IEnumerable<NacionalidadEntity> GridList { get; set; } = new List<NacionalidadEntity>();

        public async Task<IActionResult> OnGet()
        {
            try
            {
                GridList = await nacionalidadService.Get();

                return Page();
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }

        public async Task<JsonResult> OnDeleteEliminar(int Id)
        {
            try
            {
                var result = await nacionalidadService.Delete(new()
                {
                    IdNacionalidad = Id
                }); ;

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
