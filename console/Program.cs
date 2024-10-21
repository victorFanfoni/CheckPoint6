using System;
using System.Collections.Generic;

namespace LegacyProductSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Legacy Product System - Iniciando...");

            // Inicializa produtos
            var produtoManager = new ProdutoManager();
            produtoManager.AdicionarProduto("Produto 1", "Descrição longa para o Produto 1", 10.99m);
            produtoManager.AdicionarProduto("Produto 2", "Descrição longa para o Produto 2", 15.50m);

            // Realiza operações
            produtoManager.ListarProdutos();
            produtoManager.RemoverProduto(1);
            produtoManager.ListarProdutos();
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

        public void RemoverProduto(int id)
        {
            Produto produtoARemover = null;
            foreach (var produto in produtos)
            {
                if (produto.Id == id)
                {
                    produtoARemover = produto;
                    break;
                }
            }

            if (produtoARemover != null)
            {
                produtos.Remove(produtoARemover);
            }
            else
            {
                Console.WriteLine("Produto não encontrado.");
            }
        }

        public void ListarProdutos()
        {
            Console.WriteLine("Listando produtos...");
            foreach (var produto in produtos)
            {
                Console.WriteLine("Produto ID: " + produto.Id + ", Nome: " + produto.Nome + ", Preço: " + produto.Preco);
            }
        }

        public void ProcessarPagamento(int idProduto, string numeroCartao, string nomeTitular, DateTime dataExpiracao, decimal valorPago)
        {
            var produto = produtos.Find(p => p.Id == idProduto);
            if (produto != null)
            {
                if (valorPago >= produto.Preco)
                {
                    // Simula a aprovação do pagamento
                    Console.WriteLine("Pagamento aprovado para o produto " + produto.Nome);
                }
                else
                {
                    // Trata o erro de pagamento
                    Console.WriteLine("Valor insuficiente para o produto " + produto.Nome);
                }
            }
            else
            {
                Console.WriteLine("Produto não encontrado.");
            }
        }
    }
}