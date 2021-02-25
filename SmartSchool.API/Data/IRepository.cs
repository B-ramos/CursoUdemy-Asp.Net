using SmartSchool.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.API.Data
{
    public interface IRepository//<T> where T : class
    {
        public void Add<T>(T entity) where T : class;
        public void Update<T>(T entity) where T : class;
        public void Remove<T>(T entity) where T : class;
        bool SaveChanges();

        //Alunos
        Aluno[] GetAllAlunos(bool includeProfessor = false);
        Aluno[] GetAllAlunosByDisciplinaId(int disciplinaId, bool includeProfessor);
        Aluno GetAlunoById(int alunoId, bool includeProfessor = false);

        //Professores
        Professor[] GetAllProfessores(bool includeAlunos = false);
        Professor[] GetAllProfessoresByDisciplinaId(int disciplinaId, bool includeAlunos);
        Professor GetProfessorById(int professorId, bool includeAlunos = false);

    }
}
