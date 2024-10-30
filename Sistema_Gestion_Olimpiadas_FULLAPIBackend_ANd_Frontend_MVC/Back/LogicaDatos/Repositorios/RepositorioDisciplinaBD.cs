using ExcepcionesPropias;
using LogicaNegocio.EntidadesDominio;
using LogicaNegocio.InterfacesRepositorios;
using Microsoft.EntityFrameworkCore;

namespace LogicaDatos.Repositorios
{
    public class RepositorioDisciplinaBD : IRepositorioDisciplina
    {
        public OlimpiadasContext Context { get; set; }

        public RepositorioDisciplinaBD(OlimpiadasContext context)
        {
            Context = context;
        }

        public IEnumerable<Disciplina> FindAll()
        {
            return Context.Disciplinas.
                OrderBy(d => d.Nombre.Valor).
                ToList();
        }

        public List<Disciplina> FindAllDisciplinasById(List<int> ids)
        {
            return Context.Disciplinas.Where(disci => ids.Contains(disci.Id)).ToList();
        }

        public Disciplina FindById(int id)
        {
            return Context.Disciplinas.
                Where(disci => disci.Id == id)
                .SingleOrDefault();
        }

        public Disciplina FindByName(string name)
        {
            if (name != null)
            {
                return Context.Disciplinas.Where(disc => disc.Nombre.Valor == name).SingleOrDefault();
            }
            else
            {
                throw new ExcepcionesDisciplina("Nombre de disciplina no encontrado");
            }
        }

        public List<Disciplina> FindAllByAtletaId(int atletaId)
        {
            return Context.Disciplinas
                .Where(disci => disci.Atletas.Any(atle => atle.Id == atletaId))
                .ToList();
        }

        public void Update(Disciplina obj)
        {
            Disciplina disci = FindById(obj.Id);
            if (disci != null)
            {
                Context.Entry(disci).State = EntityState.Detached;
                Context.Disciplinas.Update(obj);
                Context.SaveChanges();
            }
            else
            {
                throw new ExcepcionesDisciplina("Disciplina no Encontrada");
            }
        }

        public void Remove(int id)
        {
            Disciplina obj = Context.Disciplinas.Find(id);
            if (obj == null)
            {
                throw new ExcepcionesDisciplina("Disciplina no encontrada.");
            }
            else
            {
                bool existeEnAtletas = Context.Atletas
                    .Where(atl => atl.Disciplinas.Any(disci => disci.Id == id))
                    .Count() > 0;

                bool existeEnEventos = Context.Eventos
                    .Where(eve => eve.Disciplina.Id == id)
                    .Count() > 0;
                if (existeEnAtletas && existeEnEventos)
                {
                    throw new ExcepcionesDisciplina("La Disciplina está siendo usada " +
                        "Por Atleta y/o Evento");
                }
            }
            Context.Disciplinas.Remove(obj);
            Context.SaveChanges();
        }

        public void Add(Disciplina obj)
        {
            if (obj != null)
            {
                if (FindByName(obj.Nombre.Valor) == null)
                {
                    Context.Disciplinas.Add(obj);
                    Context.SaveChanges();
                }
                else
                {
                    throw new ExcepcionesDisciplina("Disciplina ya existente");
                }
            }
            else
            {
                throw new ExcepcionesDisciplina("No se encuentra la disciplina");
            }
        }
    }
}
