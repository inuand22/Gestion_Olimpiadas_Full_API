using DTO;
using DTO.Mappers;
using ExcepcionesPropias;
using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.EntidadesDominio;
using LogicaNegocio.InterfacesRepositorios;

namespace LogicaAplicacion.CU
{
    public class ListadoDisciplina : IListadoDisciplina
    {
        public IRepositorioDisciplina Repositorio { get; set; }
        public IRepositorioAtleta RepositorioAtleta { get; set; }

        public ListadoDisciplina(IRepositorioDisciplina repositorio, IRepositorioAtleta repositorioAtleta)
        {
            Repositorio = repositorio;
            RepositorioAtleta = repositorioAtleta;
        }

        public IEnumerable<ListadoDisciplinaDTO> GetDisciplinas()
        {
            return MappersDisciplina.FromDisciplinas(Repositorio.FindAll());
        }

        public IEnumerable<ListadoDisciplinaDTO> GetDisciplinasDisponibles(int idAtleta)
        {
            return MappersDisciplina.FromDisciplinas(RepositorioAtleta.FindAllDisponible(idAtleta));
        }

        public IEnumerable<ListadoDisciplinaDTO> GetDisciplinasRegistradas(int idAtleta)
        {
            return MappersDisciplina.FromDisciplinas(RepositorioAtleta.FindAllRegistrada(idAtleta));
        }

        public ListadoDisciplinaDTO GetDisciplinaXId(int idDisciplina)
        {
            ListadoDisciplinaDTO dto = new ListadoDisciplinaDTO();
            Disciplina disci = Repositorio.FindById(idDisciplina);
            if (disci != null)
            {
                dto = MappersDisciplina.FromDisciplina(disci);
                return dto;
            }
            throw new ExcepcionesDisciplina("No se encontró Disciplina");
        }
    }
}