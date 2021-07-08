using BoxTI.Challenge.Medical.API.Data;
using BoxTI.Challenge.Medical.API.Models.Entities;
using BoxTI.Challenge.Medical.API.Repository.Contratos;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoxTI.Challenge.Medical.API.Repository
{
    public class MedicoRepository : IMedicoRepository
    {
        private readonly MedicalContext _context;

        public MedicoRepository(MedicalContext context)
        {
            _context = context;
        }

        public IEnumerable<Medico> ObterTodosMedicos => _context.Medicos.AsQueryable();


        public Medico Obter(int id)
        {

            return _context.Medicos.AsNoTracking().FirstOrDefault(m => m.Id == id);

        }

        public void Cadastrar(Medico medico)
        {
            _context.Add(medico);
            _context.SaveChanges();

        }

        public void Alterar(Medico medico)
        {

            _context.Update(medico);
            _context.SaveChanges();

        }

        public void Deletar(int id)
        {
            var medico = Obter(id);

            _context.Remove(medico);
            _context.SaveChanges();
            
        }
        
    }
}
