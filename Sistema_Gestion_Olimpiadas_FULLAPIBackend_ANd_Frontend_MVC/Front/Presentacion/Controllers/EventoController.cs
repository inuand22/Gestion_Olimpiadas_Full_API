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
        //GET: FiltrosEventos
        public ActionResult FiltrosEventos()
        {
            return View();
        }

        //Get: EventosXId  
        public ActionResult GetEventosXIdDisciplina(int id)
        {
            try
            {
                string url = "http://localhost:5118/api/eventos/disciplina/" + id;
                HttpClient cliente = new HttpClient();
                Task<HttpResponseMessage> tarea1 = cliente.GetAsync(url);
                tarea1.Wait();

                HttpResponseMessage respuesta = tarea1.Result;
                HttpContent body = respuesta.Content;

                Task<string> tarea2 = respuesta.Content.ReadAsStringAsync();
                tarea2.Wait();

                if (respuesta.IsSuccessStatusCode)
                {
                    string json = tarea2.Result;
                    IEnumerable<ListadoEventosDTO> dto = JsonConvert.
                        DeserializeObject<IEnumerable<ListadoEventosDTO>>(json);
                    return View(dto);
                }
                else
                {
                    string error = tarea2.Result;
                    ViewBag.Error = error;
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Ocurrió un error inesperado: " + ex.Message;
            }
            return View(new List<ListadoEventosDTO>());
        }

        //Get: EventosXNombre
        public ActionResult GetEventosXNombre(string nombre)
        {
            try
            {
                string url = "http://localhost:5118/api/eventos/nombre/" + nombre;
                HttpClient cliente = new HttpClient();
                Task<HttpResponseMessage> tarea1 = cliente.GetAsync(url);
                tarea1.Wait();

                HttpResponseMessage respuesta = tarea1.Result;
                HttpContent body = respuesta.Content;

                Task<string> tarea2 = respuesta.Content.ReadAsStringAsync();
                tarea2.Wait();

                if (respuesta.IsSuccessStatusCode)
                {
                    string json = tarea2.Result;
                    IEnumerable<ListadoEventosDTO> dto = JsonConvert.
                        DeserializeObject<IEnumerable<ListadoEventosDTO>>(json);
                    return View(dto);
                }
                else
                {
                    string error = tarea2.Result;
                    ViewBag.Error = error;
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Ocurrió un error inesperado: " + ex.Message;
            }
            return View(new List<ListadoEventosDTO>());
        }

        //Get: EventosXNombre
        public ActionResult GetEventosXRangoFechas(DateTime fechaIni, DateTime fechaFin)
        {
            try
            {
                string url = $"http://localhost:5118/api/eventos/rangoFecha/{fechaIni:yyyy-MM-dd},{fechaFin:yyyy-MM-dd}";
                HttpClient cliente = new HttpClient();
                Task<HttpResponseMessage> tarea1 = cliente.GetAsync(url);
                tarea1.Wait();

                HttpResponseMessage respuesta = tarea1.Result;
                HttpContent body = respuesta.Content;

                Task<string> tarea2 = respuesta.Content.ReadAsStringAsync();
                tarea2.Wait();

                if (respuesta.IsSuccessStatusCode)
                {
                    string json = tarea2.Result;
                    IEnumerable<ListadoEventosDTO> dto = JsonConvert.
                        DeserializeObject<IEnumerable<ListadoEventosDTO>>(json);
                    return View(dto);
                }
                else
                {
                    string error = tarea2.Result;
                    ViewBag.Error = error;
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Ocurrió un error inesperado: " + ex.Message;
            }
            return View(new List<ListadoEventosDTO>());
        }

        //Get: EventosXPuntaje
        public ActionResult GetEventosXRangoPuntajes(decimal ini, decimal max)
        {
            try
            {
                string url = $"http://localhost:5118/api/eventoAtleta/rangoPuntaje/{ini},{max}";
                HttpClient cliente = new HttpClient();
                Task<HttpResponseMessage> tarea1 = cliente.GetAsync(url);
                tarea1.Wait();

                HttpResponseMessage respuesta = tarea1.Result;
                HttpContent body = respuesta.Content;

                Task<string> tarea2 = respuesta.Content.ReadAsStringAsync();
                tarea2.Wait();

                if (respuesta.IsSuccessStatusCode)
                {
                    string json = tarea2.Result;
                    IEnumerable<ListadoEventoAtletaDTO> dto = JsonConvert.
                        DeserializeObject<IEnumerable<ListadoEventoAtletaDTO>>(json);
                    return View(dto);
                }
                else
                {
                    string error = tarea2.Result;
                    ViewBag.Error = error;
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Ocurrió un error inesperado: " + ex.Message;
            }
            return View(new List<ListadoEventoAtletaDTO>());
        }
    }
}


