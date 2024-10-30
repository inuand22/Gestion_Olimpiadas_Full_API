using DTO;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Presentacion.Models;
using System.Threading;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Presentacion.Controllers
{
    public class EventoController : Controller
    {
        // GET: Evento/Index
        public ActionResult Index()
        {
            HttpClient cliente = new HttpClient();

            string url = "http://localhost:5118/api/EventoAtleta";
            Task<HttpResponseMessage> tarea1 = cliente.GetAsync(url);
            tarea1.Wait();

            HttpResponseMessage respuesta = tarea1.Result;
            HttpContent body = respuesta.Content;
            Task<string> tarea2 = body.ReadAsStringAsync();
            tarea2.Wait();

            if (respuesta.IsSuccessStatusCode)
            {
                string json = tarea2.Result;
                List<ListadoEventoAtletaDTO> eventoAtletaDTO = 
                    JsonConvert.DeserializeObject<List<ListadoEventoAtletaDTO>>(json);
                return View(eventoAtletaDTO);
            }
            else
            {
                string error = tarea2.Result;
                ViewBag.Error = error;
                return View(new List<ListadoEventoAtletaDTO>());
            }  

            //BUSCAR POR ID HARDCODEADO
            //HttpClient cliente = new HttpClient();
            //int id = 2;
            //string url = $"http://localhost:5118/api/EventoAtleta/{id}";

            //Task<HttpResponseMessage> tarea1 = cliente.GetAsync(url);
            //tarea1.Wait();

            //HttpResponseMessage respuesta = tarea1.Result;

            //HttpContent body = respuesta.Content;
            //Task<string> tarea2 = body.ReadAsStringAsync();
            //tarea2.Wait();

            //if (respuesta.IsSuccessStatusCode)
            //{
            //    string json = tarea2.Result;
            //    List<ListadoEventoAtletaDTO> dto = JsonConvert.DeserializeObject<List<ListadoEventoAtletaDTO>> (json);
            //    return View(dto);
            //} 
            //else
            //{
            //    string error = tarea2.Result;
            //    ViewBag.Error = error;
            //    return View(new List<ListadoEventoAtletaDTO>());
            //} 
        }


        //public EventoController(IAltaEvento cualtaEvento, IListadoEventos cuListadoEventos,
        //    IListadoAtletas cUListadoAtleta, IListadoDisciplina cuListadoDisciplina,
        //      IListadoEventosAtletas cuListadoEventoAtleta, IAltaEventoAtletaPuntaje cUAltaEventoPuntaje,
        //      IRepositorioEventoAtleta curepositorioEventoAtleta, ILoginUsuario cULoginUsuario)
        //{
        //    CUAltaEvento = cualtaEvento;
        //    CUListadoEventos = cuListadoEventos;
        //    CUListadoAtleta = cUListadoAtleta;
        //    CUListadoDisciplina = cuListadoDisciplina;
        //    CUListadoEventoAtleta = cuListadoEventoAtleta;
        //    CUAltaEventoPuntaje = cUAltaEventoPuntaje;
        //    CURepositorioEventoAtleta = curepositorioEventoAtleta;
        //    CULoginUsuario = cULoginUsuario;
        //}

        //public bool EstaLogueado()
        //{
        //    string email = HttpContext.Session.GetString("emailUsuarioLogueado");
        //    try
        //    {
        //        Usuario userLogueado = CULoginUsuario.FindByMail(email);
        //        if (userLogueado == null)
        //        {
        //            return false;
        //        }
        //        else
        //        {
        //            return true;
        //        }
        //    }
        //    catch (ExcepcionesUsuario ex)
        //    {
        //        ViewBag.Error = ex.Message;
        //        return false;
        //    }
        //}



        //[HttpPost]
        //public ActionResult Index(DateTime? fecha)
        //{
        //    if (EstaLogueado())
        //    {
        //        DateTime fechaConsulta = fecha ?? DateTime.Now;
        //        IEnumerable<ListadoEventosDTO> eventos = CUListadoEventos.GetEventosPorFecha(fechaConsulta);
        //        return View(eventos);
        //    }
        //    return RedirectToAction("Index", "Home");
        //}

        //// GET: EventoController/Create
        //public ActionResult Create()
        //{
        //    if (EstaLogueado())
        //    {
        //        try
        //        {
        //            var vm = new AltaEventoViewModel
        //            {
        //                DTOAltaEvento = new AltaEventoDTO(),
        //                DTOAtleta = CUListadoAtleta.GetAtletas(),
        //                DTODisciplinas = CUListadoDisciplina.GetDisciplinas()
        //            };
        //            return View(vm);
        //        }
        //        catch (ExcepcionesEvento ex)
        //        {
        //            ViewBag.Error = ex.Message;
        //            return RedirectToAction("Index", "Home");
        //        }
        //    }
        //    return RedirectToAction("Index", "Home");
        //}

        //// POST: EventoController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(AltaEventoViewModel vm)
        //{
        //    try
        //    {
        //        AltaEventoDTO dto = new AltaEventoDTO
        //        {
        //            NombreEvento = vm.DTOAltaEvento.NombreEvento,
        //            IdDisciplina = vm.DTOAltaEvento.IdDisciplina,
        //            FechaInicioEvento = vm.DTOAltaEvento.FechaInicioEvento,
        //            FechaFinalEvento = vm.DTOAltaEvento.FechaFinalEvento,
        //            IdsAtletas = vm.DTOAltaEvento.IdsAtletas
        //        };

        //        CUAltaEvento.AltaEve(dto);

        //        return RedirectToAction("Index");
        //    }
        //    catch (ExcepcionesEvento ex)
        //    {
        //        ViewBag.Error = ex.Message;
        //    }
        //    catch (Exception)
        //    {
        //        ViewBag.Error = "No es posible registrar el evento.";
        //    }

        //    vm.DTOAtleta = CUListadoAtleta.GetAtletas();
        //    vm.DTODisciplinas = CUListadoDisciplina.GetDisciplinas();

        //    return View(vm);
        //}

        //public ActionResult Edit(int id)
        //{
        //    if (EstaLogueado())
        //    {
        //        try
        //        {
        //            IEnumerable<ListadoEventoAtletaDTO> dto = CUListadoEventoAtleta.GetAtletasPorEvento(id);

        //            if (dto == null || !dto.Any())
        //            {
        //                ViewBag.Error = "No hay atletas registrados para este evento.";
        //                return RedirectToAction("Index");
        //            }

        //            ViewBag.IdEvento = id;

        //            return View(dto);
        //        }
        //        catch (ExcepcionesAtleta ex)
        //        {
        //            ViewBag.Error = ex.Message;
        //            return RedirectToAction("Index");
        //        }
        //        catch (Exception ex)
        //        {
        //            ViewBag.Error = "Ocurrió un error al obtener la lista de atletas: " + ex.Message;
        //            return RedirectToAction("Index");
        //        }
        //    }
        //    return RedirectToAction("Index", "Home");
        //}

        //[HttpPost]
        //public ActionResult RegistrarPuntaje(int IdAtleta, decimal? puntajeAtleta, int idEvento)
        //{
        //    try
        //    {
        //        AltaEventoAtletaPuntajeDTO dto = new AltaEventoAtletaPuntajeDTO
        //        {
        //            IdAtleta = IdAtleta,
        //            Puntaje = puntajeAtleta,
        //            IdEvento = idEvento
        //        };

        //        dto.Id = CURepositorioEventoAtleta.FindIdByAtletaEvento(idEvento, IdAtleta);
        //        CUAltaEventoPuntaje.AltaPuntaje(dto);
        //    }

        //    catch (ExcepcionesEvento ex)
        //    {
        //        ViewBag.Mensaje = ex.Message;
        //    }

        //    return RedirectToAction("Edit", "Evento", new { id = idEvento });
        //}
    }
}
