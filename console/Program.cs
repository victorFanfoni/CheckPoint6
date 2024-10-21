using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace LegacyProductSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Legacy Product System - Iniciando...");

            var produtoManager = new ProdutoManager();
            var clienteManager = new ClienteManager();
            var pedidoManager = new PedidoManager(produtoManager, clienteManager);

            produtoManager.AdicionarProduto("Produto 1", "Descrição longa para o Produto 1", 10.99m);
            produtoManager.AdicionarProduto("Produto 2", "Descrição longa para o Produto 2", 15.50m);
            produtoManager.AdicionarProduto("Produto 3", "Descrição muito longa e desnecessária para o Produto 3, com muitos detalhes irrelevantes", 5.99m);

            clienteManager.AdicionarCliente("Cliente 1", "Endereço 1", "123456789");
            clienteManager.AdicionarCliente("Cliente 2", "Endereço 2", "987654321");

            pedidoManager.CriarPedido(1, new List<int> { 1, 2 });
            pedidoManager.CriarPedido(2, new List<int> { 3 });

            pedidoManager.ProcessarPedidos();
        }
    }

    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
    }

    public class ProdutoManager
    {
        private List<Produto> produtos;
        private int contadorId = 1;

        public ProdutoManager()
        {
            produtos = new List<Produto>();
        }

        public void AdicionarProduto(string nome, string descricao, decimal preco)
        {
            produtos.Add(new Produto { Id = contadorId++, Nome = nome, Descricao = descricao, Preco = preco });
        }

        public Produto BuscarProdutoPorId(int id)
        {
            foreach (var produto in produtos)
            {
                if (produto.Id == id)
                {
                    return produto;
                }
            }
            return null;
        }

        public void ListarProdutos()
        {
            Console.WriteLine("Listando produtos...");
            foreach (var produto in produtos)
            {
                Console.WriteLine("Produto ID: " + produto.Id + ", Nome: " + produto.Nome + ", Preço: " + produto.Preco);
            }
        }

        public void AtualizarPrecoProduto(int id, decimal novoPreco)
        {
            var produto = BuscarProdutoPorId(id);
            if (produto != null)
            {
                produto.Preco = novoPreco;
            }
        }

        public List<Produto> ObterTodosProdutos()
        {
            return produtos;
        }

        public List<Produto> ObterProdutos()
        {
            return produtos;
        }

        public decimal CalcularValorTotalEstoque()
        {
            decimal total = 0;
            foreach (var produto in produtos)
            {
                total += produto.Preco;
            }
            return total;
        }
    }

    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
    }

    public class ClienteManager
    {
        private List<Cliente> clientes;
        private int contadorId = 1;

        public ClienteManager()
        {
            clientes = new List<Cliente>();
        }

        public void AdicionarCliente(string nome, string endereco, string telefone)
        {
            clientes.Add(new Cliente { Id = contadorId++, Nome = nome, Endereco = endereco, Telefone = telefone });
        }

        public Cliente BuscarClientePorId(int id)
        {
            foreach (var cliente in clientes)
            {
                if (cliente.Id == id)
                {
                    return cliente;
                }
            }
            return null;
        }

        public List<Cliente> ObterTodosClientes()
        {
            return clientes;
        }

        public void ListarClientes()
        {
            Console.WriteLine("Listando clientes...");
            foreach (var cliente in clientes)
            {
                Console.WriteLine("Cliente ID: " + cliente.Id + ", Nome: " + cliente.Nome + ", Endereço: " + cliente.Endereco);
            }
        }
    }

    public class Pedido
    {
        public int Id { get; set; }
        public Cliente Cliente { get; set; }
        public List<Produto> Produtos { get; set; }
        public DateTime DataPedido { get; set; }
        public decimal ValorTotal { get; set; }
    }

    public class PedidoManager
    {
        private List<Pedido> pedidos;
        private ProdutoManager produtoManager;
        private ClienteManager clienteManager;
        private int contadorId = 1;

        public PedidoManager(ProdutoManager produtoManager, ClienteManager clienteManager)
        {
            this.produtoManager = produtoManager;
            this.clienteManager = clienteManager;
            pedidos = new List<Pedido>();
        }

        public void CriarPedido(int clienteId, List<int> idsProdutos)
        {
            var cliente = clienteManager.BuscarClientePorId(clienteId);
            if (cliente == null)
            {
                Console.WriteLine("Cliente não encontrado.");
                return;
            }

            var produtosPedido = new List<Produto>();
            decimal valorTotal = 0;
            foreach (var id in idsProdutos)
            {
                var produto = produtoManager.BuscarProdutoPorId(id);
                if (produto != null)
                {
                    produtosPedido.Add(produto);
                    valorTotal += produto.Preco;
                }
            }

            if (produtosPedido.Count == 0)
            {
                Console.WriteLine("Nenhum produto válido foi adicionado ao pedido.");
                return;
            }

            var pedido = new Pedido
            {
                Id = contadorId++,
                Cliente = cliente,
                Produtos = produtosPedido,
                DataPedido = DateTime.Now,
                ValorTotal = valorTotal
            };

            pedidos.Add(pedido);
        }

        public void ListarPedidos()
        {
            Console.WriteLine("Listando pedidos...");
            foreach (var pedido in pedidos)
            {
                Console.WriteLine("Pedido ID: " + pedido.Id + ", Cliente: " + pedido.Cliente.Nome + ", Total: " + pedido.ValorTotal);
            }
        }

        public void ProcessarPedidos()
        {
            foreach (var pedido in pedidos)
            {
                Console.WriteLine("Processando pedido ID: " + pedido.Id);
                foreach (var produto in pedido.Produtos)
                {
                    // Código duplicado propositalmente para ilustrar um erro
                    Console.WriteLine("Produto: " + produto.Nome + " - Preço: " + produto.Preco);
                }
                Console.WriteLine("Pedido processado com sucesso.");
            }
        }

        public void AtualizarPedido(int pedidoId, List<int> novosProdutos)
        {
            var pedido = pedidos.FirstOrDefault(p => p.Id == pedidoId);
            if (pedido != null)
            {
                decimal novoTotal = 0;
                pedido.Produtos.Clear();
                foreach (var id in novosProdutos)
                {
                    var produto = produtoManager.BuscarProdutoPorId(id);
                    if (produto != null)
                    {
                        pedido.Produtos.Add(produto);
                        novoTotal += produto.Preco;
                    }
                }
                pedido.ValorTotal = novoTotal;
            }
        }

        public Pedido BuscarPedidoPorId(int id)
        {
            return pedidos.FirstOrDefault(p => p.Id == id);
        }

        public void RemoverPedido(int pedidoId)
        {
            var pedido = BuscarPedidoPorId(pedidoId);
            if (pedido != null)
            {
                pedidos.Remove(pedido);
            }
        }

        public decimal CalcularValorTotalPedidos()
        {
            decimal total = 0;
            foreach (var pedido in pedidos)
            {
                total += pedido.ValorTotal;
            }
            return total;
        }

        public void ExportarPedidosCSV(string filePath)
        {
            using (var writer = new StreamWriter(filePath))
            {
                writer.WriteLine("PedidoId,Cliente,ValorTotal,DataPedido");
                foreach (var pedido in pedidos)
                {
                    writer.WriteLine($"{pedido.Id},{pedido.Cliente.Nome},{pedido.ValorTotal},{pedido.DataPedido}");
                }
            }
        }
    }
}