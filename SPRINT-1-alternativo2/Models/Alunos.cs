using System.Net.Http.Headers;
using System.Security.Cryptography;

public class Alunos : Pessoa
{
    public string Matricula { get; set; }

    public List<double> Notas = new List<double>();


    public int Nota;
    public double Media;


    // Matricula e lista de notas list<double>//

    public double CalcularMedia()
        
    {
        
        if (Notas.Count == 0)
        {
            return 0; // Evita divisão por zero


        }
        return Total() / Notas.Count;
        
        
    }

   



    public override void ApresentarDados()
    {
        Console.WriteLine($"Aluno(a) {Nome} (Matrícula: {Matricula})");
        Console.WriteLine($"Olá, meu nome é {Nome}, eu nasci em {DataDeNascimento} e meu CPF é: {CPF}.");
        Console.WriteLine($"Minhas notas são: {string.Join(", ", Notas)}.");
        Media = CalcularMedia();
        Console.WriteLine($"Minha média é: {CalcularMedia()}");
        if (Media >= 7)
        {
            Console.Write("Aluno(a) está: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("APROVADO");
            Console.ForegroundColor = ConsoleColor.Yellow;
        }
        else
        {
            Console.Write("Aluno(a) está: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("REPROVADO");
            Console.ForegroundColor = ConsoleColor.Yellow;
        }

        

    }

    public double Total()

    {
        double Total = 0;

        foreach (var nota in Notas)
        {

            Total += nota;

        }

        return Total;
    }



    
}
