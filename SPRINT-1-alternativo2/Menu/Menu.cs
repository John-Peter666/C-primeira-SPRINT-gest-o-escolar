


using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

namespace ProjetoEscola.Menu;

public class MenuSistema
{
    private List<Professores> _professores;
    private List<Alunos> _turmaA;
    private List<Alunos> _turmaB;

    public MenuSistema(List<Professores> professores, List<Alunos> turmaA, List<Alunos> turmaB)
    {
        _professores = professores;
        _turmaA = turmaA;
        _turmaB = turmaB;
    }

    public void Exibir()
    {
        bool executando = true;

        while (executando)
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("===== SISTEMA ESCOLAR =====\n");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("1 - Ver professores");
            Console.WriteLine("2 - Ver alunos");
            Console.WriteLine("3 - Adicionar professor");
            Console.WriteLine("4 - Remover professor");
            Console.WriteLine("5 - Adicionar aluno");
            Console.WriteLine("6 - Remover aluno");
            Console.WriteLine("7 - Adicionar nota");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("0 - Sair");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\nEscolha: ");

            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    foreach (var professor in _professores)
                    {
                        professor.ApresentarDados();
                        professor.ApresentarDisciplinas();
                        Console.WriteLine("-----------------------");
                    }
                    Pausar();
                    break;

                case "2":
                    MostrarAlunos();
                    break;

                case "3":
                    AdicionarProfessor();
                    break;

                case "4":
                    RemoverProfessor();
                    break;

                case "5":
                    AdicionarAluno();
                    break;

                case "6":
                    RemoverAluno();
                    break;

                case "7":
                    AdicionarNota();
                    break;

                case "0":
                    executando = false;
                    break;

                default:
                    Console.WriteLine("Opção inválida!");
                    Pausar();
                    break;
            }
        }
    }

    private void MostrarAlunos()
    {
        Console.Clear();

        Console.WriteLine("1 - Turma A");
        Console.WriteLine("2 - Turma B");

        string escolha = Console.ReadLine();

        List<Alunos> turma = null;

        if (escolha == "1") turma = _turmaA;
        if (escolha == "2") turma = _turmaB;

        if (turma == null)
        {
            Console.WriteLine("Turma inválida!");
            Pausar();
            return;
        }

        Console.Clear();

        foreach (var aluno in turma)
        {
            aluno.ApresentarDados();
            Console.WriteLine();
        }

        Pausar();
    }

    private void AdicionarProfessor()
    {
        Console.Clear();

        Professores novoProfessor = new Professores();

        Console.Write("Nome: ");
        novoProfessor.Nome = Console.ReadLine();

        while (true)
        {
            Console.Write("CPF (11 números): ");
            string cpf = Console.ReadLine();

            if (cpf.All(char.IsDigit) && cpf.Length == 11)
            {
                novoProfessor.CPF = cpf;
                break;
            }

            Console.WriteLine("CPF inválido!");
        }

        while (true)
        {
            Console.Write("Data nascimento (dd/mm/aaaa): ");
            string data = Console.ReadLine();

            if (DateTime.TryParseExact(data, "dd/MM/yyyy", null,
                DateTimeStyles.None, out DateTime dataConvertida))
            {
                novoProfessor.DataDeNascimento = data;
                break;
            }

            Console.WriteLine("Formato inválido!");
        }

        while (true)
        {
            Console.Write("Salário: ");
            string salario = Console.ReadLine();

            if (salario.All(char.IsDigit))
            {
                novoProfessor.Salario = salario;
                break;
            }

            Console.WriteLine("Digite apenas números!");
        }

        Console.Write("Disciplina: ");
        string disciplina = Console.ReadLine();
        novoProfessor.Disciplinas.Add(disciplina);

        Console.WriteLine("\nTurmas que ensina:");
        Console.WriteLine("1 - Turma A");
        Console.WriteLine("2 - Turma B");

        string turmas = Console.ReadLine();

        if (turmas.Contains("1"))
            novoProfessor.Turmas.Add("Turma A");

        if (turmas.Contains("2"))
            novoProfessor.Turmas.Add("Turma B");

        _professores.Add(novoProfessor);

        Console.WriteLine("\nProfessor adicionado!");
        Pausar();
    }

    private void RemoverProfessor()
    {
        Console.Clear();

        if (_professores.Count == 0)
        {
            Console.WriteLine("Nenhum professor cadastrado.");
            Pausar();
            return;
        }

        for (int i = 0; i < _professores.Count; i++)
        {
            Console.WriteLine($"{i} - {_professores[i].Nome}");
        }

        Console.Write("\nEscolha: ");

        if (int.TryParse(Console.ReadLine(), out int escolha) &&
            escolha >= 0 && escolha < _professores.Count)
        {
            _professores.RemoveAt(escolha);
            Console.WriteLine("Professor removido!");
        }
        else
        {
            Console.WriteLine("Opção inválida!");
        }

        Pausar();
    }

    private void AdicionarAluno()
    {
        Console.Clear();

        Console.WriteLine("Escolha turma:");
        Console.WriteLine("1 - Turma A");
        Console.WriteLine("2 - Turma B");

        string escolha = Console.ReadLine();

        List<Alunos> turma = null;

        if (escolha == "1") turma = _turmaA;
        if (escolha == "2") turma = _turmaB;

        if (turma == null)
        {
            Console.WriteLine("Turma inválida!");
            Pausar();
            return;
        }

        Alunos novoAluno = new Alunos();

        Console.Write("Nome: ");
        novoAluno.Nome = Console.ReadLine();

        while (true)
        {
            Console.Write("Matrícula: ");
            string matricula = Console.ReadLine();

            if (matricula.All(char.IsDigit))
            {
                novoAluno.Matricula = matricula;
                break;
            }

            Console.WriteLine("Digite apenas números!");
        }

        while (true)
        {
            Console.Write("Data nascimento (dd/mm/aaaa): ");
            string data = Console.ReadLine();

            if (DateTime.TryParseExact(data, "dd/MM/yyyy", null,
                DateTimeStyles.None, out DateTime dataConvertida))
            {
                novoAluno.DataDeNascimento = data;
                break;
            }

            Console.WriteLine("Formato inválido!");
        }

        turma.Add(novoAluno);

        Console.WriteLine("Aluno adicionado!");
        Pausar();
    }

    private void RemoverAluno()
    {
        Console.Clear();

        Console.WriteLine("1 - Turma A");
        Console.WriteLine("2 - Turma B");

        string escolha = Console.ReadLine();

        List<Alunos> turma = null;

        if (escolha == "1") turma = _turmaA;
        if (escolha == "2") turma = _turmaB;

        if (turma == null)
        {
            Console.WriteLine("Turma inválida!");
            Pausar();
            return;
        }

        for (int i = 0; i < turma.Count; i++)
        {
            Console.WriteLine($"{i} - {turma[i].Nome}");
        }

        Console.Write("\nEscolha: ");

        if (int.TryParse(Console.ReadLine(), out int aluno) &&
            aluno >= 0 && aluno < turma.Count)
        {
            turma.RemoveAt(aluno);
            Console.WriteLine("Aluno removido!");
        }
        else
        {
            Console.WriteLine("Opção inválida!");
        }

        Pausar();
    }

    private void AdicionarNota()
    {
        Console.Clear();

        Console.WriteLine("1 - Turma A");
        Console.WriteLine("2 - Turma B");

        string escolha = Console.ReadLine();

        List<Alunos> turma = null;

        if (escolha == "1") turma = _turmaA;
        if (escolha == "2") turma = _turmaB;

        if (turma == null)
        {
            Console.WriteLine("Turma inválida!");
            Pausar();
            return;
        }

        for (int i = 0; i < turma.Count; i++)
        {
            Console.WriteLine($"{i} - {turma[i].Nome}");
        }

        Console.Write("\nEscolha aluno: ");

        if (!int.TryParse(Console.ReadLine(), out int aluno) ||
            aluno < 0 || aluno >= turma.Count)
        {
            Console.WriteLine("Aluno inválido!");
            Pausar();
            return;
        }

        Console.Write("Nota: ");

        if (double.TryParse(Console.ReadLine(), out double nota))
        {
            turma[aluno].Notas.Add(nota);
            Console.WriteLine("Nota adicionada!");
        }
        else
        {
            Console.WriteLine("Nota inválida!");
        }

        Pausar();
    }

    private void Pausar()
    {
        Console.WriteLine("\nPressione qualquer tecla...");
        Console.ReadKey();
    }
}
