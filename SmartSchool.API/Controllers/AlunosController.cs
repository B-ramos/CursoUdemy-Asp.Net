using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.API.Data;
using SmartSchool.API.Dtos;
using SmartSchool.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SmartSchool.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunosController : ControllerBase
    {
        private readonly IRepository _repo;
        private readonly IMapper _mapper;

        public AlunosController(IRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var alunos = _repo.GetAllAlunos();

            return Ok(_mapper.Map<IEnumerable<AlunoDto>>(alunos));

        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var aluno = _repo.GetAlunoById(id);

            if (aluno == null) return BadRequest("O Aluno não foi encontrado");

            return Ok(aluno);
        }

        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            _repo.Add(aluno);

            if(_repo.SaveChanges())
                return Ok(aluno);

            return BadRequest("Aluno não cadastrado.");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {
            var alunoExiste = _repo.GetAlunoById(id);

            if (alunoExiste == null) return BadRequest("O Aluno não foi encontrado");

            _repo.Update(aluno);

            if (_repo.SaveChanges())
                return Ok(aluno);

            return BadRequest("Aluno não atualizado.");
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno)
        {
            var alunoExiste = _repo.GetAlunoById(id);

            if (alunoExiste == null) return BadRequest("O Aluno não foi encontrado");

            _repo.Update(aluno);

            if (_repo.SaveChanges())
                return Ok(aluno);

            return BadRequest("Aluno não Atualizados.");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var aluno = _repo.GetAlunoById(id);

            if (aluno == null) return BadRequest("O Aluno não foi encontrado");

            _repo.Remove(aluno);

            if (_repo.SaveChanges())
                return Ok("Aluno removido com sucesso.");

            return BadRequest("Aluno não foi deletado.");
        }

    }
}
