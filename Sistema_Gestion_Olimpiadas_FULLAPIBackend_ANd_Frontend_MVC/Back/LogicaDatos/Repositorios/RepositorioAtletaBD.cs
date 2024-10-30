using ExcepcionesPropias;
using LogicaNegocio.EntidadesDominio;
using LogicaNegocio.InterfacesRepositorios;
using Microsoft.EntityFrameworkCore;

namespace LogicaDatos.Repositorios
{
    public class RepositorioAtletaBD : IRepositorioAtleta
    {
        public OlimpiadasContext Context { get; set; }

        public RepositorioAtletaBD(OlimpiadasContext context)
        {
            Context = context;
        }

        public Atleta FindById(int id)
        {
            if (id != 0 || id > 0)
            {
                return Context.Atletas
                .Include(atleta => atleta.Pais)
                .Include(atleta => atleta.Disciplinas)
                .Include(atleta => atleta.Pais.Delegado)
                .Where(atleta => atleta.Id == id)
                .SingleOrDefault();
            }
            else
            {
                throw new ExcepcionesAtleta("No existe Atleta");
            }

        }

        public IEnumerable<Atleta> FindAll()
        {
            return Context.Atletas
                  .Include(atleta => atleta.Pais)
                  .OrderBy(atleta => atleta.Pais.Nombre)
                  .ThenBy(atleta => atleta.Apellido)
                  .ThenBy(atleta => atleta.Nombre)
                  .ToList();
        }

        public void Update(int atletaId, int idDisciplina)
        {
            var atleta = Context.Atletas.Include(atleta => atleta.Disciplinas)
                                        .FirstOrDefault(atleta => atleta.Id == atletaId);

            if (atleta != null)
            {
                var nuevaDisciplina = Context.Disciplinas.FirstOrDefault(disiciplina => disiciplina.Id == idDisciplina);

                if (nuevaDisciplina != null)
                {
                    atleta.Disciplinas.Add(nuevaDisciplina);
                    Context.SaveChanges();
                }
                else
                {
                    throw new ExcepcionesDisciplina($"Disciplina con ID {idDisciplina} no encontrada.");
                }
            }
            else
            {
                throw new ExcepcionesAtleta("Atleta no encontrado");
            }
        }

        public IEnumerable<Disciplina> FindAllDisponible(int idAtleta)
        {
            if (idAtleta != 0 || idAtleta > 0)
            {
                var disciplinasRegistradas = Context.Atletas
                .Where(at => at.Id == idAtleta)
                .SelectMany(atleta => atleta.Disciplinas)
                .Select(disci => disci.Id)
                .ToList();

                return Context.Disciplinas
                    .Where(disci => !disciplinasRegistradas.Contains(disci.Id))
                    .ToList();
            }
            else
            {
                throw new ExcepcionesAtleta("Atleta no encontrado");
            }
        }

        public IEnumerable<Disciplina> FindAllRegistrada(int idAtleta)
        {
            if (idAtleta != 0 || idAtleta > 0)
            {
                var disciplinasRegistradas = Context.Atletas
                .Where(atleta => atleta.Id == idAtleta)
                .SelectMany(atleta => atleta.Disciplinas)
                .Select(disciplina => disciplina.Id)
                .ToList();

                return Context.Disciplinas
                    .Where(disciplina => disciplinasRegistradas.Contains(disciplina.Id))
                    .ToList();
            }
            else
            {
                throw new ExcepcionesAtleta("Atleta no encontrado");
            }
        }

        public IEnumerable<Atleta> FindByDisciplinaId(int IdDisciplinas)
        {
            if (IdDisciplinas <= 0)
            {
                throw new ExcepcionesDisciplina("El ID de la disciplina debe ser mayor a 0.");
            }

            if (IdDisciplinas == null)
            {
                throw new ExcepcionesDisciplina("El ID de la disciplina debe ser vacío.");
            }

            return Context.Atletas
                .Include(atleta => atleta.Pais)
                .Include(atleta => atleta.Disciplinas)
                .Where(atleta => atleta.Disciplinas.Any(disci => disci.Id == IdDisciplinas))
                .OrderBy(atleta => atleta.Nombre)
                .ThenBy(atleta => atleta.Apellido)
                .ToList();
        }
    }
}

