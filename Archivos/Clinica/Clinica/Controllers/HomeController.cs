using Clinica.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Clinica.Datos;
using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Http.Extensions;


namespace Clinica.Controllers
{
    public class HomeController : Controller

    {
        private readonly ILogger<HomeController> _logger;
       
        public HomeController(ILogger<HomeController> logger)
        {
            this._logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }


        public IActionResult encuesta()
        {
            return View();
        }
        


        ContactoDatos _ContactoDatos = new ContactoDatos();
        public IActionResult agregarcita()
        {
            var olista = _ContactoDatos.listar();
            return View(olista);
            
        }

        public IActionResult Guardar() {
            //metodo devuelve a la vista
            
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(AsignarCitas ocitas)
        {
            //metodo recibe el objeto en la BD
            
            if (!ModelState.IsValid)
                return View();


            var respuesta = _ContactoDatos.guardar(ocitas);

            if (respuesta)
                return RedirectToAction("agregarcita");
            else 
            return View();

        }
        public IActionResult Editar(int Idcitas)
        {
            //metodo devuelve a la vista
            var ocitas = _ContactoDatos.Obtener(Idcitas);
            return View(ocitas);
        }

        [HttpPost]
        public IActionResult Editar(AsignarCitas ocitas)
        {
            //metodo recibe el objeto en la BD

            if (!ModelState.IsValid)
                return View();


            var respuesta = _ContactoDatos.editar(ocitas);

            if (respuesta)
                return RedirectToAction("agregarcita");
            else
                return View();
        }


        public IActionResult Eliminar(int Idcitas)
        {
            //metodo devuelve a la vista
            var ocitas = _ContactoDatos.Obtener(Idcitas);
            return View(ocitas);
        }

        [HttpPost]
        public IActionResult Eliminar(AsignarCitas ocitas)
        {
            //metodo recibe el objeto en la BD

           

            var respuesta = _ContactoDatos.eliminar(ocitas.Idcitas);

            if (respuesta)
                return RedirectToAction("agregarcita");
            else
                return View();
        }
        //------------------------------------------------



        InventarioDatos _InventarioDatos = new InventarioDatos();


        public IActionResult inventario()
        {
            var oinventario = _InventarioDatos.listInventario();
            return View(oinventario);
        }

        public IActionResult Guardarinventario()
        {
            //metodo devuelve a la vista

            return View();
        }

        [HttpPost]
        public IActionResult Guardarinventario(Inventario oinve)
        {
            //metodo recibe el objeto en la BD

            if (!ModelState.IsValid)
                return View();


            var resultado = _InventarioDatos.guardarinventario(oinve);

            if (resultado)
                return RedirectToAction("inventario");
            else
                return View();
        }

        public IActionResult Editarinventario(int Idinventario)
        { //metodo devuelve a la vista
            var oinve = _InventarioDatos.Obtenerinventario(Idinventario);

            return View(oinve);
        }

        [HttpPost]
        public IActionResult Editarinventario(Inventario oinve)
        {
            //metodo recibe el objeto en la BD
            if (!ModelState.IsValid)
                return View();

            var resultado = _InventarioDatos.editarinventario(oinve);
            if (resultado)
                return RedirectToAction("inventario");
            else
                return View();
        }

        public IActionResult Eliminarinventario(int Idinventario)
        {
            //metodo devuelve a la vista
            var oinve = _InventarioDatos.Obtenerinventario(Idinventario);
            return View(oinve);
        }

        [HttpPost]
        public IActionResult Eliminarinventario(Inventario oinve)
        {
            //metodo recibe el objeto en la BD

            var resultado = _InventarioDatos.eliminarinventario(oinve.Idinventario);

            if (resultado)
                return RedirectToAction("inventario");
            else
                return View();
        }


        //----------------------------------------------


        FichaDatos _FichaDatos = new FichaDatos();

        public IActionResult ficha()
        {
            var oficha = _FichaDatos.listarficha();
            return View(oficha);
        }


        public IActionResult Guardarficha()
        {
            //metodo devuelve a la vista
            return View();
        }

        [HttpPost]
        public IActionResult Guardarficha(Ficha ofichero)
        {
            //metodo de DB

            if (!ModelState.IsValid)
                return View();

            var resultante = _FichaDatos.guardarficha(ofichero);

            if (resultante)
                return RedirectToAction("ficha");
            else
                return View();

        }


        public IActionResult Editarficha(int Idficha)
        {
            //metodo devuelve la vista
            var ofichero = _FichaDatos.Obtenerficha(Idficha);
            return View(ofichero);
        }

        [HttpPost]

        public IActionResult Editarficha(Ficha ofichero)
        {
            //metodo recibe el onjeto de la bd

            if (!ModelState.IsValid)
                return View();

            var resultante = _FichaDatos.editarficha(ofichero);

            if (resultante)
                return RedirectToAction("ficha");
            else
                return View();

        }


        public IActionResult Eliminarficha(int Idficha)
        {
            //metodo devuelve la vista

            var ofichero = _FichaDatos.Obtenerficha(Idficha);
            return View(ofichero);

        }

        [HttpPost]
        public IActionResult Eliminarficha(Ficha ofichero)
        {
            //metodo recibe el objeto en la BD

            var resultante = _FichaDatos.eliminarficha(ofichero.Idficha);

            if (resultante)
                return RedirectToAction("ficha");
            else
                return View();
        }



        public ActionResult CerrarSesion()
        {
            //Session["usuario"] = null;
            return RedirectToAction("Login", "Acceso");
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}