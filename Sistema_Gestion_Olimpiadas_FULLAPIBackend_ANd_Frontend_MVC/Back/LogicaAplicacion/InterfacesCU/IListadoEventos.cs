using DTO;
using LogicaNegocio.EntidadesDominio;

namespace LogicaAplicacion.InterfacesCU
{
    public interface IListadoEventos
    {
        IEnumerable<ListadoEventosDTO> GetEventosPorFecha(DateTime fecha);
        IEnumerable<ListadoEventosDTO> GetEventosPorIdDisci(int id);
        IEnumerable<ListadoEventosDTO> GetEventosPorRangoFechas(DateTime fechaIni, DateTime fechaFin);
        IEnumerable<ListadoEventosDTO> GetEventosPorName(string nombre);
    }
}
