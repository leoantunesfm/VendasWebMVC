﻿using System.Collections.Generic;
using System.Linq;

namespace VendasWebMVC.Models
{
    public class Vendedor
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public double SalarioBase { get; set; }
        public Departamento Departamento { get; set; }
        public ICollection<DocumentoVenda> Vendas { get; set; } = new List<DocumentoVenda>();

        public Vendedor() { }

        public Vendedor(int id, string codigo, string name, string email, DateTime dataNascimento, double salarioBase, Departamento departamento)
        {
            Id = id;
            Codigo = codigo;
            Name = name;
            Email = email;
            DataNascimento = dataNascimento;
            SalarioBase = salarioBase;
            Departamento = departamento;
        }

        public void AdicionarVendas(DocumentoVenda venda)
        {
            Vendas.Add(venda);
        }

        public void RemoverVendas(DocumentoVenda venda)
        {
            Vendas.Remove(venda);
        }

        public double TotalVendas(DateTime periodoInicial, DateTime periodoFinal)
        {
            return Vendas.Where(venda => venda.DataEmissao >= periodoInicial && venda.DataEmissao <= periodoFinal).Sum(venda => venda.ValorTotal);
        }
    }
}
