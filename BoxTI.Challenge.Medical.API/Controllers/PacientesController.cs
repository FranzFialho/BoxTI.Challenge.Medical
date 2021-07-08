using BoxTI.Challenge.Medical.API.Models.Entities;
using BoxTI.Challenge.Medical.API.Repository.Contratos;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BoxTI.Challenge.Medical.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacientesController : ControllerBase
    {
        private readonly IPacienteRepository _repository;

        public PacientesController(IPacienteRepository repository)
        {
            _repository = repository;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Paciente>> GetPacientes()
        {
            var cadastro = _repository.ObterTodosPacientes.OrderBy(p => p.Id).ToList();

            if (cadastro == null)
            {
                return NotFound();
            }

            return Ok(cadastro);
           
        }


        [HttpGet("{id}")]
        public ActionResult GetPaciente(int id)
        {
            var paciente = _repository.Obter(id);

            if (paciente == null)
            {
                return NotFound();
            }

            return Ok(paciente);
        }


        [HttpPut("{id}")]
        public ActionResult PutPaciente(int id, [FromBody]Paciente paciente)
        {
            var obj = _repository.Obter(id);

            if (obj == null) return NotFound();

            if (paciente == null) return BadRequest();

            if (!ModelState.IsValid) return UnprocessableEntity(ModelState); //Não é possivel processar as instruções presentes.

            if (id != paciente.Id)
            {
                return BadRequest();
            }

            _repository.Alterar(paciente);

            return Ok();
        }


        [HttpPost]
        public ActionResult PostPaciente(Paciente paciente)
        {
            if (paciente == null) return BadRequest();

            if (!ModelState.IsValid) return UnprocessableEntity(ModelState);

            _repository.Cadastrar(paciente);

            return CreatedAtAction("GetMedico", new { id = paciente.Id }, paciente);
        }


        [HttpDelete("{id}")]
        public ActionResult DeletePaciente(int id)
        {
            var paciente = _repository.Obter(id);
            if (paciente == null)
            {
                return NotFound();
            }

            _repository.Deletar(id);

            return NoContent();
        }   
    }
}
