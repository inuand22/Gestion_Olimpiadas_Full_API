using DTO;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Presentacion.Controllers
{
    public class DisciplinaController : Controller
    {
        public ActionResult FiltrosDisciplinas()
        {
            return View();
        }

        public ActionResult GetDisciplinaXNombre(string nombre)
        {
            try
            {
                string url = "http://localhost:5118/nombre/" + nombre;
                HttpClient cliente = new HttpClient();

                Task<HttpResponseMessage> tarea1 = cliente.GetAsync(url);
                tarea1.Wait();

                HttpResponseMessage respuesta = tarea1.Result;

                HttpContent contenido = respuesta.Content;

                Task<string> tarea2 = contenido.ReadAsStringAsync();
                tarea2.Wait();

                if (respuesta.IsSuccessStatusCode)
                {
                    string json = tarea2.Result;
                    ListadoDisciplinaDTO disciplina = JsonConvert.DeserializeObject<ListadoDisciplinaDTO>(json);
                    return View(disciplina);
                }
                else
                {
                    string error = tarea2.Result;
                    ViewBag.Error = error;
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Ocurrión un error inesperado!";
            }

            return View(new ListadoDisciplinaDTO());
        }


        //GET
        public ActionResult Index()
        {
            try
            {
                HttpClient cliente = new HttpClient();

                string url = "http://localhost:5118/api/disciplinas";
                Task<HttpResponseMessage> tarea1 = cliente.GetAsync(url);
                tarea1.Wait();

                HttpResponseMessage respuesta = tarea1.Result;
                HttpContent body = respuesta.Content;
                Task<string> tarea2 = body.ReadAsStringAsync();
                tarea2.Wait();

                if (respuesta.IsSuccessStatusCode)
                {
                    string json = tarea2.Result;
                    List<ListadoDisciplinaDTO> dto =
                        JsonConvert.DeserializeObject<List<ListadoDisciplinaDTO>>(json);
                    return View(dto);
                }
                else
                {
                    string error = tarea2.Result;
                    ViewBag.Error = error;
                    return View(new List<ListadoDisciplinaDTO>());
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            return View();
        }
        public ActionResult AtletasXDisciplina(int id)
        {
            try
            {
                HttpClient cliente = new HttpClient();

                string url = "http://localhost:5118/api/atleta/disciplina/" + id;
                Task<HttpResponseMessage> tarea1 = cliente.GetAsync(url);
                tarea1.Wait();

                HttpResponseMessage respuesta = tarea1.Result;
                HttpContent body = respuesta.Content;
                Task<string> tarea2 = body.ReadAsStringAsync();
                tarea2.Wait();

                if (respuesta.IsSuccessStatusCode)
                {
                    string json = tarea2.Result;
                    List<ListadoAtletasDTO> dto =
                        JsonConvert.DeserializeObject<List<ListadoAtletasDTO>>(json);
                    return View(dto);
                }
                else
                {
                    string error = tarea2.Result;
                    ViewBag.Error = error;
                    return View(new List<ListadoAtletasDTO>());
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            return View();
        }


        // GET: DisciplinaController/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: DisciplinaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AltaDisciplinaDTO dto)
        {
            try
            {

                string url = "http://localhost:5118/api/disciplinas";
                HttpClient cliente = new HttpClient();

                var tarea1 = cliente.PostAsJsonAsync(url, dto);
                tarea1.Wait();

                if (tarea1.Result.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    var tarea2 = tarea1.Result.Content.ReadAsStringAsync();
                    tarea2.Wait();

                    ViewBag.Error = tarea2.Result;
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Ocurrió un error y no se realizó el alta.";
            }

            return View(dto);
        }
        // GET: DisciplinaController/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                string url = "http://localhost:5118/api/disciplinas/" + id;
                HttpClient cliente = new HttpClient();

                Task<HttpResponseMessage> tarea1 = cliente.GetAsync(url);
                tarea1.Wait();

                HttpResponseMessage respuesta = tarea1.Result;

                HttpContent contenido = respuesta.Content;

                Task<string> tarea2 = contenido.ReadAsStringAsync();
                tarea2.Wait();

                if (respuesta.IsSuccessStatusCode)
                {
                    string json = tarea2.Result;
                    AltaDisciplinaDTO disciplina = JsonConvert.DeserializeObject<AltaDisciplinaDTO>(json);
                    return View(disciplina);
                }
                else
                {
                    string error = tarea2.Result;
                    ViewBag.Error = error;
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Ocurrión un error inesperado!";
            }

            return View();
        }

        // GET: DisciplinaController/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                string url = "http://localhost:5118/api/disciplinas/" + id;
                HttpClient cliente = new HttpClient();

                Task<HttpResponseMessage> tarea1 = cliente.GetAsync(url);
                tarea1.Wait();

                HttpResponseMessage respuesta = tarea1.Result;

                HttpContent contenido = respuesta.Content;

                Task<string> tarea2 = contenido.ReadAsStringAsync();
                tarea2.Wait();

                if (respuesta.IsSuccessStatusCode)
                {
                    string json = tarea2.Result;
                    ListadoDisciplinaDTO disciplina = JsonConvert.DeserializeObject<ListadoDisciplinaDTO>(json);
                    return View(disciplina);
                }
                else
                {
                    string error = tarea2.Result;
                    ViewBag.Error = error;
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Ocurrión un error inesperado!";
            }

            return View();
        }

        // POST: DisciplinaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AltaDisciplinaDTO dto)
        {
            try
            {

                string url = "http://localhost:5118/api/disciplinas/" + dto.IdDisciplina;

                HttpClient cliente = new HttpClient();
                var tarea1 = cliente.PutAsJsonAsync(url, dto);
                tarea1.Wait();

                if (tarea1.Result.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    var tarea2 = tarea1.Result.Content.ReadAsStringAsync();
                    tarea2.Wait();

                    ViewBag.Error = tarea2.Result;
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Ocurrió un error y no se realizó la modificación.";
            }

            return View(dto);
        }

        // GET: DisciplinaController/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                string url = "http://localhost:5118/api/disciplinas/" + id;
                HttpClient cliente = new HttpClient();

                Task<HttpResponseMessage> tarea1 = cliente.GetAsync(url);
                tarea1.Wait();

                HttpResponseMessage respuesta = tarea1.Result;

                HttpContent contenido = respuesta.Content;

                Task<string> tarea2 = contenido.ReadAsStringAsync();
                tarea2.Wait();

                if (respuesta.IsSuccessStatusCode)
                {
                    string json = tarea2.Result;
                    AltaDisciplinaDTO disciplina = JsonConvert.DeserializeObject<AltaDisciplinaDTO>(json);
                    return View(disciplina);
                }
                else
                {
                    string error = tarea2.Result;
                    ViewBag.Error = error;
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Ocurrión un error inesperado!";
            }

            return RedirectToAction(nameof(Index));
        }

        // POST: DisciplinaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(AltaDisciplinaDTO dto)
        {
            try
            {

                string url = "http://localhost:5118/api/disciplinas/" + dto.IdDisciplina;

                HttpClient cliente = new HttpClient();
                var tarea1 = cliente.DeleteAsync(url);
                tarea1.Wait();

                if (tarea1.Result.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    var tarea2 = tarea1.Result.Content.ReadAsStringAsync();
                    tarea2.Wait();

                    ViewBag.Error = tarea2.Result;
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Ocurrió un error y no se realizó el borrado";
            }

            return View(dto);
        }
    }
}







