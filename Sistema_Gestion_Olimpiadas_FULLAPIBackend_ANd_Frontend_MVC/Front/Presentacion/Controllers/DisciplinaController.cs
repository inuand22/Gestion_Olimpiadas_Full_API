using DTO;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Presentacion.Controllers
{
    public class DisciplinaController : Controller
    {
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



    

//public DisciplinaController(IAltaDisciplina cUAltaDisciplina, IListadoDisciplina cUListadoDisciplina,
//    ILoginUsuario cULoginUsuario)
//{
//    CUAltaDisciplina = cUAltaDisciplina;
//    CUListadoDisciplina = cUListadoDisciplina;
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

//public bool EsDigitador()
//{
//    string admin = HttpContext.Session.GetString("rolUsuarioLogueado");
//    if (admin == "Digitador")
//    {
//        return true;
//    }
//    else
//    {
//        return false;
//    }
//}
//// GET: DisciplinaController
//public ActionResult Index()
//{
//    if (EstaLogueado() && EsDigitador())
//    {
//        return View(CUListadoDisciplina.GetDisciplinas());
//    }
//    else
//    {
//        return RedirectToAction("Index", "Home");
//    }
//}

//// GET: DisciplinaController/Create
//public ActionResult Create()
//{
//    if (EstaLogueado() && EsDigitador())
//    {
//        AltaDisciplinaDTO dto = new AltaDisciplinaDTO();
//        return View(dto);
//    }
//    else
//    {
//        return RedirectToAction("Index", "Home");
//    }
//}

//// POST: DisciplinaController/Create
//[HttpPost]
//[ValidateAntiForgeryToken]
//public ActionResult Create(AltaDisciplinaDTO dto)
//{
//    try
//    {
//        CUAltaDisciplina.AltaDisci(dto);
//        return RedirectToAction(nameof(Index));
//    }
//    catch (ExcepcionesDisciplina ex)
//    {
//        ViewBag.Error = ex.Message;
//        return View();
//    }
//}

//// GET: DisciplinaController/Details/5
//public ActionResult Details(int id)
//{
//    return View();
//}

//// GET: DisciplinaController/Edit/5
//public ActionResult Edit(int id)
//{
//    return View();
//}

//// POST: DisciplinaController/Edit/5
//[HttpPost]
//[ValidateAntiForgeryToken]
//public ActionResult Edit(int id, IFormCollection collection)
//{
//    try
//    {
//        return RedirectToAction(nameof(Index));
//    }
//    catch
//    {
//        return View();
//    }
//}

//// GET: DisciplinaController/Delete/5
//public ActionResult Delete(int id)
//{
//    return View();
//}

//// POST: DisciplinaController/Delete/5
//[HttpPost]
//[ValidateAntiForgeryToken]
//public ActionResult Delete(int id, IFormCollection collection)
//{
//    try
//    {
//        return RedirectToAction(nameof(Index));
//    }
//    catch
//    {
//        return View();
//    }
//}


