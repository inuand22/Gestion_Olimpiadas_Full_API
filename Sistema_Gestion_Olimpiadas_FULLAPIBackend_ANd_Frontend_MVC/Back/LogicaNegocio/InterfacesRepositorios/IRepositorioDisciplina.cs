using LogicaNegocio.EntidadesDominio;

namespace LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioDisciplina:IRepositorio<Disciplina>
    {
        List<Disciplina> FindAllDisciplinasById(List<int> ids);
        IEnumerable<Disciplina> FindAll();
        List<Disciplina> FindAllByAtletaId(int idAtleta);
        Disciplina FindById(int idDisciplina); 
    }    
}
