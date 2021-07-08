using BoxTI.Challenge.Medical.API.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxTI.Challenge.Medical.API.Repository.Contratos
{
    public interface IPacienteRepository
    {

        IEnumerable<Paciente> ObterTodosPacientes { get; }
        Paciente Obter(int id);
        void Cadastrar(Paciente paciente);
        void Alterar(Paciente paciente);
        void Deletar(int id);

    }
}
