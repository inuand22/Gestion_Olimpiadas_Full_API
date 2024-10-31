using LogicaNegocio.EntidadesDominio;

namespace LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioEvento : IRepositorio<Evento>
    {
        Evento FindByName(string nombreEvento);
        IEnumerable<Evento> GetEventosPorFecha(DateTime fecha);

        IEnumerable<Evento> GetEVentosPorIdDisciplina(int id);
        IEnumerable<Evento> GetEventosPorRangoFechas(DateTime fechaInicial, DateTime fechaFinal);
        IEnumerable<Evento> GetEventosPorNombreEvento(string name); //QUE CONTENGA UNA PARTE (PARCIAL)        
    }
}
