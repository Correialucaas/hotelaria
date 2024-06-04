using System;

class Pessoa
{
    private string nome;
    private string cpf;

    public Pessoa(string nome, string cpf)
    {
        this.nome = nome;
        this.cpf = cpf;
    }

    public string GetNome()
    {
        return nome;
    }

    public string GetCpf()
    {
        return cpf;
    }
}

class Suíte
{
    private int numero;
    private string tipo;
    private double valorDiaria;

    public Suíte(int numero, string tipo, double valorDiaria)
    {
        this.numero = numero;
        this.tipo = tipo;
        this.valorDiaria = valorDiaria;
    }

    public int GetNumero()
    {
        return numero;
    }

    public string GetTipo()
    {
        return tipo;
    }

    public double GetValorDiaria()
    {
        return valorDiaria;
    }
}

class Reserva
{
    private Pessoa pessoa;
    private Suíte suite;
    private DateTime dataCheckIn;
    private DateTime dataCheckout;
    private double valorTotal;

    public Reserva(Pessoa pessoa, Suíte suite, DateTime dataCheckIn, DateTime dataCheckout)
    {
        this.pessoa = pessoa;
        this.suite = suite;
        this.dataCheckIn = dataCheckIn;
        this.dataCheckout = dataCheckout;
        this.CalcularValorTotal();
    }

    private int CalcularDuracaoEstadia()
    {
        TimeSpan diferenca = dataCheckout - dataCheckIn;
        return diferenca.Days;
    }

    private void CalcularValorTotal()
    {
        int duracao = CalcularDuracaoEstadia();
        double valorBase = duracao * suite.GetValorDiaria();
        valorTotal = valorBase;

        if (duracao > 10)
        {
            valorTotal *= 0.9;
        }
    }

    public Pessoa GetPessoa()
    {
        return pessoa;
    }

    public Suíte GetSuite()
    {
        return suite;
    }

    public DateTime GetDataCheckIn()
    {
        return dataCheckIn;
    }

    public DateTime GetDataCheckout()
    {
        return dataCheckout;
    }

    public double GetValorTotal()
    {
        return valorTotal;
    }
}


Pessoa pessoa = new Pessoa("Lucas Correia", "12345678900");
Suíte suite = new Suíte(101, "Dupla", 200.00);
DateTime dataCheckIn = new DateTime(2024, 06, 10);
DateTime dataCheckout = new DateTime(2024, 06, 20);

Reserva reserva = new Reserva(pessoa, suite, dataCheckIn, dataCheckout);

Console.WriteLine("Nome do Hóspede: " + reserva.GetPessoa().GetNome());
Console.WriteLine("Número da Suíte: " + reserva.GetSuite().GetNumero());
Console.WriteLine("Data de Check-in: " + reserva.GetDataCheckIn().ToString("yyyy-MM-dd"));
Console.WriteLine("Data de Checkout: " + reserva.GetDataCheckout().ToString("yyyy-MM-dd"));
Console.WriteLine("Valor Total: R$ " + reserva.GetValorTotal());