using BoxTI.Challenge.Medical.API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BoxTI.Challenge.Medical.API.Data
{
    public class MedicalContext : DbContext
    {
        public MedicalContext(DbContextOptions<MedicalContext> options) : base(options)
        {
        }

        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }


    }
}
