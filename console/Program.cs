using System;
using System.Collections.Generic;

namespace LegacySystem
{
    class MainSistema
    {
        static void Main(string[] args)
        {s
            SistemaCliente sistemaClientes = new SistemaCliente();
            sistemaClientes.AdicionarCliente(1, "Joao", "joao@email.com");
            sistemaClientes.AdicionarCliente(2, "Maria", "maria@email.com");

            SistemaTransacoes sistemaTransacoes = new SistemaTransacoes();
            sistemaTransacoes.AdicionarTransacao(1, 100.50m, "Compra de Produto");
            sistemaTransacoes.AdicionarTransacao(2, 200.00m, "Compra de Serviço");
            sistemaTransacoes.AdicionarTransacao(3, 300.75m, "Compra de Software");

            Console.WriteLine("Clientes:");
            sistemaClientes.ExibirTodosOsClientes();

            Console.WriteLine("\nTransações:");
            sistemaTransacoes.ExibirTransacoes();

            sistemaClientes.RemoverCliente(1);
            Console.WriteLine("\nClientes após remoção:");
            sistemaClientes.ExibirTodosOsClientes();

            sistemaClientes.AtualizarNomeCliente(2, "Maria Silva");

            const string NomeEmpresa = "Empresa Teste";
            const string DescricaoTransacao = "Compra de Insumo";
            const int Repeticoes = 5;

            ExibirNomeEmpresa(NomeEmpresa, DescricaoTransacao, Repeticoes);

            Relatorio relatorio = new Relatorio();
            relatorio.GerarRelatorioClientes(sistemaClientes.ObterClientes());

            int soma = SomarNumeros(10);
            Console.WriteLine("\nSoma total: " + soma);
        }

        #region Métodos Utilitários

        static void ExibirNomeEmpresa(string nomeEmpresa, string descricaoTransacao, int repeticoes)
        {
            for (int i = 0; i < repeticoes; i++)
            {
                Console.WriteLine($"Nome da Empresa: {nomeEmpresa} Descrição: {descricaoTransacao}");
            }
        }

        static int SomarNumeros(int limite)
        {
            int soma = 0;
            for (int i = 0; i < limite; i++)
            {
                soma += i;
            }
            return soma;
        }

        #endregion
    }

    #region Classes de Sistema

    public class SistemaCliente
    {
        private readonly List<Cliente> _clientes = new List<Cliente>();

        public void AdicionarCliente(int id, string nome, string email)
        {
            _clientes.Add(new Cliente(id, nome, email));
        }

        public void RemoverCliente(int id)
        {
            _clientes.RemoveAll(c => c.Id == id);
        }

        public void AtualizarNomeCliente(int id, string novoNome)
        {
            Cliente cliente = _clientes.Find(c => c.Id == id);
            if (cliente != null)
            {
                cliente.AtualizarNome(novoNome);
            }
        }

        public void ExibirTodosOsClientes()
        {
            foreach (Cliente cliente in _clientes)
            {
                Console.WriteLine(cliente);
            }
        }

        public List<Cliente> ObterClientes()
        {
            return new List<Cliente>(_clientes);
        }
    }

    public class SistemaTransacoes
    {
        private readonly List<Transacao> _transacoes = new List<Transacao>();

        public void AdicionarTransacao(int id, decimal valor, string descricao)
        {
            _transacoes.Add(new Transacao(id, valor, descricao));
        }

        public void ExibirTransacoes()
        {
            foreach (Transacao transacao in _transacoes)
            {
                Console.WriteLine(transacao);
            }
        }
    }

    #endregion

    #region Classes de Modelos

    public class Cliente
    {
        public int Id { get; }
        public string Nome { get; private set; }
        public string Email { get; }

        public Cliente(int id, string nome, string email)
        {
            Id = id;
            Nome = nome;
            Email = email;
        }

        public void AtualizarNome(string novoNome)
        {
            Nome = novoNome;
        }

        public override string ToString()
        {
            return $"Cliente: {Id}, Nome: {Nome}, Email: {Email}";
        }
    }

    public class Transacao
    {
        public int Id { get; }
        public decimal Valor { get; }
        public string Descricao { get; }

        public Transacao(int id, decimal valor, string descricao)
        {
            Id = id;
            Valor = valor;
            Descricao = descricao;
        }

        public override string ToString()
        {
            return $"Transação: {Id}, Valor: {Valor}, Descrição: {Descricao}";
        }
    }

    public class Relatorio
    {
        public void GerarRelatorioClientes(List<Cliente> clientes)
        {
            Console.WriteLine("\nRelatório de Clientes:");
            foreach (Cliente cliente in clientes)
            {
                Console.WriteLine(cliente);
            }
        }
    }

    #endregion
}
