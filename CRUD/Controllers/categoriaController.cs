using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entidades;
using Negocio;

namespace CRUD.Controllers
{
    public class categoriaController : Controller
    {
        // GET: categoria
        public ActionResult Index()
        {
            gestor gestor = new gestor();
            ViewBag.listadocategoriapaginacion = gestor.listadocategoriapaginacion(1,5);
            ViewBag.listadocategoriapaginacioncount = gestor.listadocategoriapaginacioncount(5);
            ViewBag.nropagina = 1;
            return View("categoria");
        }
        public ActionResult opguardar(becategoria obj)
        {
            gestor gestor = new gestor();
            if (obj.idcategoria==0)
            {
                // insertar                 
                gestor.insertarcategoria(obj);
            }
            else
            {
                // actualizar 
                gestor.actualizarcategoria(obj);
            }

            // ViewBag.listadocategoria = gestor.listadocategoria(null);

            ViewBag.listadocategoriapaginacion = gestor.listadocategoriapaginacion(1, 5);
            ViewBag.listadocategoriapaginacioncount = gestor.listadocategoriapaginacioncount(5);
            ViewBag.nropagina = 1;           
            return View("categoria");
        }

        public ActionResult getcategoria(Int32 idcategoria)
        {
            gestor gestor = new gestor();

            //ViewBag.listadocategoria = gestor.listadocategoria(null);
            ViewBag.listadocategoriapaginacion = gestor.listadocategoriapaginacion(1, 5);
            ViewBag.listadocategoriapaginacioncount = gestor.listadocategoriapaginacioncount(5);
            ViewBag.nropagina = 1;

            ViewBag.categoria = gestor.obtenercategoria(idcategoria);               
            return View("categoria");
        }

        public ActionResult eliminar(Int32 idcategoria)
        {
            gestor gestor = new gestor();
            gestor.eliminarcategoria(idcategoria);
            // ViewBag.listadocategoria = gestor.listadocategoria(null);
            ViewBag.listadocategoriapaginacion = gestor.listadocategoriapaginacion(1, 5);
            ViewBag.listadocategoriapaginacioncount = gestor.listadocategoriapaginacioncount(5);
            ViewBag.nropagina = 1;
            return View("categoria");
        }

        public ActionResult paginar(Int32 nropagina)
        {
            gestor gestor = new gestor();
            ViewBag.nropagina = nropagina;
            ViewBag.listadocategoriapaginacion = gestor.listadocategoriapaginacion(nropagina,5);
            ViewBag.listadocategoriapaginacioncount = gestor.listadocategoriapaginacioncount(5);
            return View("categoria");
        }
    }
}