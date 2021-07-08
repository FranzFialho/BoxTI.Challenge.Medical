using BoxTI.Challenge.Medical.API.Data;
using BoxTI.Challenge.Medical.API.Models.Entities;
using BoxTI.Challenge.Medical.API.Repository.Contratos;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BoxTI.Challenge.Medical.API.Repository
{
    public class PacienteRepository : IPacienteRepository
    {
        private readonly MedicalContext _context;

        public PacienteRepository(MedicalContext context)
        {
            _context = context;
        }

        public IEnumerable<Paciente> ObterTodosPacientes => _context.Pacientes.AsQueryable();


        public Paciente Obter(int id)
        {
            return _context.Pacientes.AsNoTracking().FirstOrDefault(p => p.Id == id);
        }

        public void Cadastrar(Paciente paciente)
        {
            _context.Pacientes.Add(paciente);
            _context.SaveChanges();
        }

        public void Alterar(Paciente paciente)
        {

            _context.Pacientes.Update(paciente);
            _context.SaveChanges();

        }

        public void Deletar(int id)
        {
            var paciente = Obter(id);

            _context.Remove(paciente);
            _context.SaveChanges();

        }

    }
}
