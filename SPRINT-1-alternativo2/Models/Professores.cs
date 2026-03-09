public class Professores : Pessoa
//salario e lista de turmas list<double>//
{
    public List<string> Disciplinas = new List<string>();
    public List<string> Turmas = new List<string>();

    public string Disciplina;
    public string Salario;


    public void ApresentarDisciplinas()
    {
        Console.WriteLine($"As disciplinas que eu ensino são as de: {string.Join(",", Disciplinas)}.");
    }
    public override void ApresentarDados()
    {
        Console.WriteLine($"Olá, meu nome é {Nome}, eu nasci em {DataDeNascimento}, meu salário é {Salario}, meu CPF é: {CPF} e minhas turmas são: {string.Join(", ", Turmas)};");
    }

}



