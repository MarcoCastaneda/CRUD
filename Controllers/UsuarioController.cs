using Microsoft.AspNetCore.Mvc;
using CRUD.Datos;
using CRUD.Models;
namespace CRUD.Controllers
{
    public class UsuarioController : Controller
    {
        UsuarioDatos _UsuarioDatos = new UsuarioDatos();
        public IActionResult GetAll()
        {
            var oLista = _UsuarioDatos.GetAll();
            return View(oLista);
        }

        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(UsuarioModel oUsuario)
        {
            var respuesta = _UsuarioDatos.Add(oUsuario);

            if (respuesta)
                return RedirectToAction("GetAll");
            else

                return View();
        }
    }
}
