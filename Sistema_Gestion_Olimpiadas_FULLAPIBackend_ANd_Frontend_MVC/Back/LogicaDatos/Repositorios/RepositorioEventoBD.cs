using ExcepcionesPropias;
using LogicaNegocio.EntidadesDominio;
using LogicaNegocio.InterfacesRepositorios;
using Microsoft.EntityFrameworkCore;

namespace LogicaDatos.Repositorios
{
    public class RepositorioEventoBD : IRepositorioEvento
    {
        public OlimpiadasContext Context { get; set; }

        public RepositorioEventoBD(OlimpiadasContext context)
        {
            Context = context;
        }

        public void Add(Evento obj)
        {
            obj.Validate();
            if (obj != null)
            {
                Context.Eventos.Add(obj);
                Context.SaveChanges();
            }
            else
            {
                throw new ExcepcionesEvento("No se encuentra el evento");
            }
        }

        public void Update(Evento obj)
        {
            if (obj != null)
            {
                Context.Eventos.Update(obj);
                Context.SaveChanges();
            }
            else
            {
                throw new ExcepcionesEvento("No se encuentra el evento");
            }
        }

        public Evento FindById(int id)
        {
            var evento = Context.Eventos
                .Include(eve => eve.Disciplina)
                .SingleOrDefault(eve => eve.Id == id);

            if (evento == null)
            {
                throw new ExcepcionesEvento("Evento no encontrado.");
            }

            return evento;
        }

        public IEnumerable<Evento> FindAll()
        {
            return Context.Eventos
                .Include(eve => eve.Disciplina)
                .Include(eve => eve.EventosAtletas)
                .ToList();
        }

        public void Remove(int id)
        {
            var eve = Context.Eventos.Find(id);
            if (eve != null)
            {
                Context.Eventos.Remove(eve);
                Context.SaveChanges();
            }
            else
            {
                throw new ExcepcionesEvento("No se encuentra el evento");
            }
        }

        public IEnumerable<Evento> GetEventosPorFecha(DateTime fecha)
        {
            return Context.Eventos
                    .Where(eve => eve.FechaFinal == fecha)
                    .Include(eve => eve.Disciplina)
                    .Include(eve => eve.EventosAtletas)
                    .ToList();
        }

        public Evento FindByName(string nombreEvento)
        {
            if (nombreEvento != null)
            {
                return Context.Eventos
                    .Include(eve => eve.Disciplina)
                    .Where(eve => eve.NombreEvento.Valor == nombreEvento)
                    .SingleOrDefault();
            }
            else
            {
                throw new ExcepcionesEvento("Nombre no encontrado");
            }
        }

        public IEnumerable<Evento> GetEVentosPorIdDisciplina(int id)
        {
            if (id <= 0)
            {
                throw new ExcepcionesEvento("El id debe ser un entero positivo");
            }
            return Context.Eventos
                .Include(eve => eve.Disciplina)
                .Include(eve => eve.EventosAtletas)
                .Where(eve => eve.Disciplina.Id == id)
                .ToList();
        }

        public IEnumerable<Evento> GetEventosPorRangoFechas(DateTime fechaInicial, DateTime fechaFinal)
        {
            if (fechaInicial > fechaFinal)
            {
                throw new ExcepcionesEvento("La fecha inicial no debe ser mayor a la fecha final");
            }
            return Context.Eventos
                .Include(eve => eve.Disciplina)
                .Include(eve => eve.EventosAtletas)
                .Where(eve => eve.FechaInicio.Date == fechaInicial.Date && eve.FechaFinal.Date == fechaFinal.Date)
                .ToList();
        }

        public IEnumerable<Evento> GetEventosPorNombreEvento(string name)
        {
            name = name.Trim();
            if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
            {
                throw new ExcepcionesEvento("El nombre no puede ser vacío");
            }
            return Context.Eventos
                .Include(eve => eve.Disciplina)
                .Include(eve => eve.EventosAtletas)
                .Where(eve => eve.NombreEvento.Valor.Contains(name))
                .ToList();
        }
    }
}

