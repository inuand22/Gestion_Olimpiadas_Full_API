using DTO;
using DTO.Mappers;
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
    public class UpdateDisci : IUpdateDisciplina
    {
        public IRepositorioDisciplina Repositorio { get; set; }

        public UpdateDisci(IRepositorioDisciplina repositorio)
        {
            Repositorio = repositorio;
        }

        public void UpdateDisciplina(AltaDisciplinaDTO dto)
        {
            if (dto == null)
            {
                throw new ExcepcionesDisciplina("La disciplina no puede ser vacía.");
            }

            Repositorio.Update(MappersDisciplina.FromDTO(dto));
        }
    }
}
