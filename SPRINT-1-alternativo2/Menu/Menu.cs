


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

            Console.WriteLine("===== MENU =====");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("1 - Ver dados dos professores");
            Console.WriteLine("2 - Ver dados dos alunos");
            Console.WriteLine("3 - Adicionar professor");
            Console.WriteLine("4 - Adicionar nota para aluno");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("0 - Sair");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\nEscolha uma opção: ");

            string opcao = Console.ReadLine()!;
            Console.Clear();

            switch (opcao)
            {
                case "1":

                    foreach (var professor in _professores)
                    {
                        professor.ApresentarDados();
                        professor.ApresentarDisciplinas();

                        Console.WriteLine("\n---------------------------\n");
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
        bool escolhendoTurma = true;

        while (escolhendoTurma)
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("===== SELEÇÃO DE TURMA =====");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("1 - Turma A");
            Console.WriteLine("2 - Turma B");
            Console.WriteLine("0 - Voltar");

            Console.Write("\nEscolha: ");

            string escolhaTurma = Console.ReadLine();

            List<Alunos> turmaSelecionada = null;

            if (escolhaTurma == "1")
                turmaSelecionada = _turmaA;

            else if (escolhaTurma == "2")
                turmaSelecionada = _turmaB;

            else if (escolhaTurma == "0")
                return;

            if (turmaSelecionada != null)
            {
                Console.Clear();

                foreach (var aluno in turmaSelecionada)
                {
                    aluno.ApresentarDados();
                    Console.WriteLine();
                }

                Pausar();
            }
            else
            {
                Console.WriteLine("Opção inválida.");
                Console.ReadKey();
            }
        }
    }

    private void AdicionarProfessor()
    {
        Console.Clear();

        Professores novoProfessor = new Professores();

        Console.Write("Nome do professor: ");
        novoProfessor.Nome = Console.ReadLine();

        // CPF (apenas números)
        while (true)
        {
            Console.Write("CPF (apenas números): ");
            string cpf = Console.ReadLine();

            if (cpf.All(char.IsDigit) && cpf.Length == 11)
            {
                novoProfessor.CPF = cpf;
                break;
            }

            Console.WriteLine("CPF inválido! Digite apenas 11 números.");
        }

        // Data de nascimento
        while (true)
        {
            Console.Write("Data de nascimento (dd/mm/aaaa): ");
            string data = Console.ReadLine();

            if (DateTime.TryParse(data, out DateTime dataConvertida))
            {
                novoProfessor.DataDeNascimento = data;
                break;
            }

            Console.WriteLine("Data inválida!");
        }

        // Salário
        while (true)
        {
            Console.Write("Salário: ");
            string salario = Console.ReadLine();

            if (double.TryParse(salario, out double valor))
            {
                novoProfessor.Salario = salario;
                break;
            }

            Console.WriteLine("Digite um valor válido!");
        }

        // Disciplinas
        Console.Write("Disciplina do professor: ");
        string disciplina = Console.ReadLine();
        novoProfessor.Disciplinas.Add(disciplina);

        // Turmas
        Console.WriteLine("\nQuais turmas ele ensina?");

        Console.WriteLine("1 - Turma A");
        Console.WriteLine("2 - Turma B");

        Console.Write("Escolha (ex: 1,2): ");
        string turmas = Console.ReadLine();

        if (turmas.Contains("1"))
            novoProfessor.Turmas.Add("Turma A");

        if (turmas.Contains("2"))
            novoProfessor.Turmas.Add("Turma B");

        _professores.Add(novoProfessor);

        Console.WriteLine("\nProfessor adicionado com sucesso!");

        Pausar();
    }


    private void AdicionarNota()
    {
        Console.Clear();

        Console.WriteLine("Escolha a turma:");
        Console.WriteLine("1 - Turma A");
        Console.WriteLine("2 - Turma B");

        string escolhaTurma = Console.ReadLine();

        List<Alunos> turmaSelecionada = null;

        if (escolhaTurma == "1")
            turmaSelecionada = _turmaA;

        else if (escolhaTurma == "2")
            turmaSelecionada = _turmaB;

        if (turmaSelecionada == null)
        {
            Console.WriteLine("Turma inválida!");
            Pausar();
            return;
        }

        Console.Clear();

        Console.WriteLine("Escolha o aluno:\n");

        for (int i = 0; i < turmaSelecionada.Count; i++)
        {
            Console.WriteLine($"{i} - {turmaSelecionada[i].Nome}");
        }

        Console.Write("\nNúmero do aluno: ");
        int escolhaAluno = int.Parse(Console.ReadLine());

        Console.Write("Digite a nota: ");
        double nota = double.Parse(Console.ReadLine());

        turmaSelecionada[escolhaAluno].Notas.Add(nota);

        Console.WriteLine("\nNota adicionada com sucesso!");

        Pausar();
    }

    private void Pausar()
    {
        Console.WriteLine("\nPressione qualquer tecla para continuar...");
        Console.ReadKey();
    }
}
