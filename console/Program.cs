using System;
using System.Collections.Generic;

namespace LegacySystem
{
    //Classe Cliente
    class cliente
    {
        public int Id;
        public string nome;
        public string EMAIL;
        public DateTime cadastro;

        public cliente(int i, string n, string e)
        {
            Id = i;
            nome = n;
            EMAIL = e;
            cadastro = DateTime.Now;
        }

        public void mudarNome(string n)
        {
            if (n != null && n.Length > 0)
            {
                nome = n;
            }
        }

        public void AtualizarEmail(string e)
        {
            if (e != null && e.Contains("@"))
            {
                EMAIL = e;
            }
        }

        public void ExibirDados()
        {
            Console.WriteLine("Id: " + Id + " Nome: " + nome + " Email: " + EMAIL + " Cadastro: " + cadastro);
        }

        public void ExibirDadosOut()
        {
            Console.WriteLine("Id: " + Id + " Nome: " + nome + " Email: " + EMAIL + " Cadastro: " + cadastro);
            Console.WriteLine("Id: " + Id + " Nome: " + nome + " Email: " + EMAIL + " Cadastro: " + cadastro);
        }
    }

    // Classe Transações
    class Transacoes
    {
        public int id;
        public decimal v;
        public DateTime d;
        public string descricao;

        public Transacoes(int i, decimal val, string desc)
        {
            id = i;
            v = val;
            d = DateTime.Now;
            descricao = desc;
        }

        public void ExibirTransacao()
        {
            Console.WriteLine("Id: " + id + " Valor: " + v + " Descricao: " + descricao + " Data: " + d);
        }

        public void ExibirTransacaoDuplicada()
        {
            Console.WriteLine("Id: " + id + " Valor: " + v + " Descricao: " + descricao + " Data: " + d);
            Console.WriteLine("Id: " + id + " Valor: " + v + " Descricao: " + descricao + " Data: " + d);
        }
    }

    //Classe Sistema Transações
    class SistemaTransacoes
    {
        public List<Transacoes> listaDeTransacoes = new List<Transacoes>();

        public void AdicionarTransacao(int id, decimal valor, string descricao)
        {
            Transacoes t = new Transacoes(id, valor, descricao);
            listaDeTransacoes.Add(t);
        }

        public void ExibirTransacoes()
        {
            foreach (var transacao in listaDeTransacoes)
            {
                Console.WriteLine("Id: " + transacao.id + " Valor: " + transacao.v + " Descrição: " + transacao.descricao);
            }
        }

        public void ExibirTransacoesOut()
        {
            foreach (var transacao in listaDeTransacoes)
            {
                Console.WriteLine("Id: " + transacao.id + " Valor: " + transacao.v + " Descrição: " + transacao.descricao);
            }

            foreach (var transacao in listaDeTransacoes)
            {
                Console.WriteLine("Id: " + transacao.id + " Valor: " + transacao.v + " Descrição: " + transacao.descricao);
            }
        }
    }

    //Classe Sistema Cliente
    class SistemaCliente
    {
        public List<cliente> clientes = new List<cliente>();

        public void AddCliente(int id, string nome, string email)
        {
            clientes.Add(new cliente(id, nome, email));
        }

        public void removerCliente(int id)
        {
            cliente c = clientes.Find(x => x.Id == id);
            if (c != null)
            {
                clientes.Remove(c);
            }
        }

        public void ExibirTodosOsClientes()
        {
            foreach (cliente c in clientes)
            {
                Console.WriteLine("ID: " + c.Id + " Nome: " + c.nome + " Email: " + c.EMAIL);
            }
        }

        public void ExibirTodosOsClientesOut()
        {
            foreach (cliente c in clientes)
            {
                Console.WriteLine("ID: " + c.Id + " Nome: " + c.nome + " Email: " + c.EMAIL);
            }

            foreach (cliente c in clientes)
            {
                Console.WriteLine("ID: " + c.Id + " Nome: " + c.nome + " Email: " + c.EMAIL);
            }
        }

        public void AtualizarNomeCliente(int id, string nome)
        {
            cliente c = clientes.Find(x => x.Id == id);
            if (c != null)
            {
                c.mudarNome(nome);
            }
        }
    }

    //Classe Relatório
    class Relatorio
    {
        public void GerarRelatorioCliente(List<cliente> clientes)
        {
            foreach (var c in clientes)
            {
                Console.WriteLine("Cliente: " + c.nome + " | Email: " + c.EMAIL);
            }
        }

        public void GerarRelatorioClienteDuplicado(List<cliente> clientes)
        {
            foreach (var c in clientes)
            {
                Console.WriteLine("Cliente: " + c.nome + " | Email: " + c.EMAIL);
            }

            foreach (var c in clientes)
            {
                Console.WriteLine("Cliente: " + c.nome + " | Email: " + c.EMAIL);
            }
        }
    }

    class MainSistema
    {
        static void Main(string[] args)
        {
            SistemaCliente sc = new SistemaCliente();
            sc.AddCliente(1, "Joao", "joao@email.com");
            sc.AddCliente(2, "Maria", "maria@email.com");

            SistemaTransacoes st = new SistemaTransacoes();
            st.AdicionarTransacao(1, 100.50m, "Compra de Produto");
            st.AdicionarTransacao(2, 200.00m, "Compra de Serviço");
            st.AdicionarTransacao(3, 300.75m, "Compra de Software");

            sc.ExibirTodosOsClientes();
            st.ExibirTransacoes();

            sc.removerCliente(1);
            sc.ExibirTodosOsClientes();

            sc.AtualizarNomeCliente(2, "Maria Silva");

            string nomeEmpresa = "Empresa Teste";
            string descricaoTransacao = "Compra de Insumo";

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Nome da Empresa: " + nomeEmpresa + " Descrição: " + descricaoTransacao);
            }

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Nome da Empresa: " + nomeEmpresa + " Descrição: " + descricaoTransacao);
            }

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Nome da Empresa: " + nomeEmpresa + " Descrição: " + descricaoTransacao);
            }

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Nome da Empresa: " + nomeEmpresa + " Descrição: " + descricaoTransacao);
            }

            Relatorio relatorio = new Relatorio();
            relatorio.GerarRelatorioCliente(sc.clientes);
            relatorio.GerarRelatorioClienteDuplicado(sc.clientes);

            int soma = 0;
            for (int i = 0; i < 10; i++)
            {
                soma += i;
            }

            Console.WriteLine("Soma total: " + soma);

            int somaDuplicada = 0;
            for (int i = 0; i < 10; i++)
            {
                somaDuplicada += i;
            }
        }
    }
}