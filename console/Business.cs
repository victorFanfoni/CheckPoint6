using System;
using System.Collections.Generic;

namespace LegacySystem
{
    class Client
    {
        public int Id { get; set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public DateTime RegistrationDate { get; private set; }

        public Client(int id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
            RegistrationDate = DateTime.Now;
        }

        public void UpdateName(string name)
        {
            if (!string.IsNullOrWhiteSpace(name))
            {
                Name = name;
            }
        }

        public void UpdateEmail(string email)
        {
            if (!string.IsNullOrWhiteSpace(email) && email.Contains("@"))
            {
                Email = email;
            }
        }

        public void DisplayData()
        {
            Console.WriteLine($"Id: {Id} | Name: {Name} | Email: {Email} | Registration Date: {RegistrationDate}");
        }
    }

    class Transaction
    {
        public int Id { get; set; }
        public decimal Amount { get; private set; }
        public DateTime Date { get; private set; }
        public string Description { get; private set; }

        public Transaction(int id, decimal amount, string description)
        {
            Id = id;
            Amount = amount;
            Date = DateTime.Now;
            Description = description;
        }

        public void DisplayTransaction()
        {
            Console.WriteLine($"Id: {Id} | Amount: {Amount} | Description: {Description} | Date: {Date}");
        }
    }

    class TransactionSystem
    {
        private List<Transaction> transactions = new List<Transaction>();

        public void AddTransaction(int id, decimal amount, string description)
        {
            transactions.Add(new Transaction(id, amount, description));
        }

        public void DisplayTransactions()
        {
            foreach (var transaction in transactions)
            {
                transaction.DisplayTransaction();
            }
        }
    }

    class ClientSystem
    {
        private List<Client> clients = new List<Client>();

        public void AddClient(int id, string name, string email)
        {
            clients.Add(new Client(id, name, email));
        }

        public void RemoveClient(int id)
        {
            clients.RemoveAll(c => c.Id == id);
        }

        public void DisplayAllClients()
        {
            foreach (var client in clients)
            {
                client.DisplayData();
            }
        }

        public void UpdateClientName(int id, string name)
        {
            Client client = clients.Find(c => c.Id == id);
            client?.UpdateName(name);
        }
    }

    class Report
    {
        public void GenerateClientReport(List<Client> clients)
        {
            foreach (var client in clients)
            {
                Console.WriteLine($"Client: {client.Name} | Email: {client.Email}");
            }
        }
    }
}
