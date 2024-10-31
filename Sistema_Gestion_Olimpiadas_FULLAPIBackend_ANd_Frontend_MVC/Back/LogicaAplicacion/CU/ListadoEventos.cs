using DTO;
using DTO.Mappers;
using ExcepcionesPropias;
using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.EntidadesDominio;
using LogicaNegocio.InterfacesRepositorios;

namespace LogicaAplicacion.CU
{
    public class ListadoEventos : IListadoEventos
    {
        public IRepositorioEvento RepositorioEvento { get; set; }
        public IRepositorioAtleta RepositorioAtleta { get; set; }
        public IRepositorioDisciplina RepositorioDisciplina { get; set; }

        public ListadoEventos(IRepositorioEvento repositorioEvento,
            IRepositorioAtleta repositorioAtleta, IRepositorioDisciplina repositorioDisciplina)
        {
            RepositorioEvento = repositorioEvento;
            RepositorioAtleta = repositorioAtleta;
            RepositorioDisciplina = repositorioDisciplina;
        }

        public IEnumerable<ListadoEventosDTO> GetEventosPorFecha(DateTime fecha)
        {
            IEnumerable<Evento> eventos = RepositorioEvento.GetEventosPorFecha(fecha);
            var eventosDTO = MappersEventos.ToDTOs(eventos.ToList());
            return eventosDTO;
        }

        public IEnumerable<ListadoEventosDTO> GetEventosPorIdDisci(int id)
        {
            IEnumerable<Evento> eventos = RepositorioEvento.GetEVentosPorIdDisciplina(id);
            var eventosDTO = MappersEventos.ToDTOs(eventos.ToList());
            return eventosDTO;
        }

        public IEnumerable<ListadoEventosDTO> GetEventosPorRangoFechas(DateTime fechaIni, DateTime fechaFin)
        {
            IEnumerable<Evento> eventos = RepositorioEvento.GetEventosPorRangoFechas(fechaIni, fechaFin);
            var eventosDTO = MappersEventos.ToDTOs(eventos.ToList());
            return eventosDTO;
        }

        public IEnumerable<ListadoEventosDTO> GetEventosPorName(string nombre)
        {
            IEnumerable<Evento> eventos = RepositorioEvento.GetEventosPorNombreEvento(nombre);
            var eventosDTO = MappersEventos.ToDTOs(eventos.ToList());
            return eventosDTO;
        }
    }
}
