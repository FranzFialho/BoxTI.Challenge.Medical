using BoxTI.Challenge.Medical.API.Models.Entities;
using BoxTI.Challenge.Medical.API.Repository.Contratos;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BoxTI.Challenge.Medical.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicosController : ControllerBase
    {
        private readonly IMedicoRepository _repository;

        public MedicosController(IMedicoRepository repository)
        {
            _repository = repository;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Medico>> GetMedicos()
        {
            var cadastro = _repository.ObterTodosMedicos.OrderBy(p => p.Id).ToList();

            if(cadastro == null)
            {
                return NotFound();
            }

            return Ok(cadastro);
        }
    

        [HttpGet("{id}")]
        public ActionResult GetMedico(int id)
        {
            var medico = _repository.Obter(id);

            if (medico == null)
            {
                return NotFound();
            }

            return Ok(medico);
        }


        [HttpPut("{id}")]
        public ActionResult PutMedico(int id, [FromBody]Medico medico)
        {
            var obj = _repository.Obter(id);

            if (obj == null)  return NotFound();

            if (medico == null) return BadRequest();

            if (!ModelState.IsValid) return UnprocessableEntity(ModelState); //Não é possivel processar as instruções presentes.

            if (id != medico.Id)
            {
                return BadRequest();
            }

            _repository.Alterar(medico);

            return Ok();
        }


        [HttpPost]
        public ActionResult PostMedico([FromBody]Medico medico)
        {
            if (medico == null) return BadRequest();

            if (!ModelState.IsValid) return UnprocessableEntity(ModelState);

            _repository.Cadastrar(medico);

            return CreatedAtAction("GetMedico", new { id = medico.Id }, medico);
        }


        [HttpDelete("{id}")]
        public ActionResult DeleteMedico(int id)
        {
            var medico = _repository.Obter(id);
            if (medico == null)
            {
                return NotFound();
            }

            _repository.Deletar(id);
           
            return NoContent();
        }
    }
}
