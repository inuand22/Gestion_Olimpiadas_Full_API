using DTO;
using DTO.Mappers;
using ExcepcionesPropias;
using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.EntidadesDominio;
using LogicaNegocio.InterfacesRepositorios;

namespace LogicaAplicacion.CU
{
    public class ListadoAtletas : IListadoAtletas
    {
        public IRepositorioAtleta Repositorio { get; set; }
        public IRepositorioDisciplina RepositorioDisciplina { get; set; }

        public ListadoAtletas(IRepositorioAtleta repositorio, IRepositorioDisciplina repositorioDisciplina)
        {
            Repositorio = repositorio;
            RepositorioDisciplina = repositorioDisciplina;
        }

        public ListadoAtletasDTO GetAtletaPorId(int id)
        {
            if (id != 0 || id > 0)
            {
                return MappersAtleta.FromAtleta(Repositorio.FindById(id));
            }
            throw new ExcepcionesAtleta("Atleta no encontrado");
        }

        public IEnumerable<ListadoAtletasDTO> GetAtletas()
        {
            return MappersAtleta.FromAtletas(Repositorio.FindAll());
        }

        public IEnumerable<ListadoAtletasDTO> GetAtletasPorDisciplina(int disciplinaId)
        {
            IEnumerable<Atleta> atletas = Repositorio.FindByDisciplinaId(disciplinaId);
            foreach (Atleta item in atletas)
            {
                item.IdDisciplinas = item.Disciplinas.Select(disci => disci.Id).ToList();
            }
            return MappersAtleta.FromAtletas(atletas);
        }
    }
}
