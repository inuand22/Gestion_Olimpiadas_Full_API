using ExcepcionesPropias;
using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CU
{
    public class BorrarDisciplina : IRemoveDisciplina
    {
        public IRepositorioDisciplina Repositorio { get; set; }

        public BorrarDisciplina(IRepositorioDisciplina repositorio)
        {
            Repositorio = repositorio;
        }

        public void BorrarDisci(int id)
        {
            if (id <= 0)
            {
                throw new ExcepcionesDisciplina("El id debe ser un entero positivo");
            }
            Repositorio.Remove(id);
        }
    }
}
