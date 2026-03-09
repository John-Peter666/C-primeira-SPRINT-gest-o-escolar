
using ProjetoEscola.Menu;

class Program
{
    static void Main()
    {


        List<Alunos> TurmaA = new List<Alunos>();
        List<Alunos> TurmaB = new List<Alunos>();



        Professores professor = new Professores
        {
            Nome = "João",
            CPF = "123.456.789-00",
            DataDeNascimento = "23/11/1980"
        };

        professor.Salario = ("5000");
        professor.Disciplinas.Add("Matemática e Física");
        professor.Turmas.Add("Turma A");
        professor.Turmas.Add("Turma B");

        Professores professor2 = new Professores
        {
            Nome = "Maria",
            CPF = "987.654.321-00",
            DataDeNascimento = "15/08/1985"
        };

        professor2.Salario = ("4500"); 
        professor2.Disciplinas.Add("Português e História");
        professor2.Turmas.Add("Turma A");
        professor2.Turmas.Add("Turma B");


        Professores professor3 = new Professores
        {
            Nome = "Carlos",
            CPF = "456.789.123-00",
            DataDeNascimento = "10/02/1975"
        };

        professor3.Salario = ("5500");
        professor3.Disciplinas.Add("Química e Biologia");
        professor3.Turmas.Add("Turma A");
        professor3.Turmas.Add("Turma B");



        TurmaA.Add(new Alunos
        {
            Nome = "Carlos",
            Matricula = "2024-001",
            CPF = "123.456.789-00",
            DataDeNascimento = "15/05/2005",
              Notas = new List<double> { 9.5, 8.0, 6.5 }

        });
        TurmaA.Add(new Alunos
        {
            Nome = "Maria",
            Matricula = "2020-005",
            CPF = "987.654.321-00",
            DataDeNascimento = "12/01/2005",
            Notas = new List<double> { 5.5, 9.0, 6.5 }

        });

        TurmaB.Add(new Alunos
        {
            Nome = "Ana",
            Matricula = "2025-001",
            CPF = "456.789.123-00",
            DataDeNascimento = "30/09/2005",
            Notas = new List<double> { 6.0, 4.0, 5.0 }


        });
        TurmaB.Add(new Alunos
        {
            Nome = "Pedro",
            Matricula = "2023-012",
            CPF = "321.654.987-00",
            DataDeNascimento = "20/03/2005",
            Notas = new List<double> { 7.0, 8.0, 6.0}

        });


       

        List<Professores> Professores = new List<Professores>
        {
            professor,
            professor2,
            professor3
        };

        List<List<Alunos>> Escola = new List<List<Alunos>>
        {
            TurmaA,
            TurmaB
        };

        MenuSistema menu = new MenuSistema(Professores, TurmaA, TurmaB);
        menu.Exibir();


    }
}



