using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.API.Data;
using SmartSchool.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SmartSchool.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessoresController : ControllerBase
    {
        private readonly IRepository _repo;

        public ProfessoresController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var professor = _repo.GetAllProfessores(true);
            return Ok(professor);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var professor = _repo.GetProfessorById(id);

            if (professor == null) return BadRequest("O Professor não foi encontrado");

            return Ok(professor);
        }

        [HttpPost]
        public IActionResult Post(Professor professor)
        {
            _repo.Add(professor);

            if(_repo.SaveChanges())
                return Ok(professor);

            return BadRequest("Professor não cadastrado.");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Professor professor)
        {
            var professorExiste = _repo.GetProfessorById(id);

            if (professorExiste == null) return BadRequest("O professor não foi encontrado");

            _repo.Update(professor);

            if (_repo.SaveChanges())
                return Ok(professor);

            return BadRequest("Professor não atualizado.");
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Professor professor)
        {
            var professorExiste = _repo.GetProfessorById(id);

            if (professorExiste == null) return BadRequest("O professor não foi encontrado");

            _repo.Update(professor);

            if (_repo.SaveChanges())
                return Ok(professor);

            return BadRequest("Professor não Atualizados.");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var professor = _repo.GetProfessorById(id);

            if (professor == null) return BadRequest("O Professor não foi encontrado");

            _repo.Remove(professor);

            if (_repo.SaveChanges())
                return Ok("Professor removido com sucesso.");

            return BadRequest("Professor não foi deletado.");
        }

    }
}
