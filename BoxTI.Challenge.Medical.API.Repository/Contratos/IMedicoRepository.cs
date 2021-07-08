using BoxTI.Challenge.Medical.API.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxTI.Challenge.Medical.API.Repository.Contratos
{
    public interface IMedicoRepository
    {

        IEnumerable<Medico> ObterTodosMedicos { get; }
        Medico Obter(int id);
        void Cadastrar(Medico medico);
        void Alterar(Medico medico);
        void Deletar(int id);


    }
}
