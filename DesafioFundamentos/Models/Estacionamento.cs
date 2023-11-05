using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace DesafioFundamentos.Models
{

    //Estou utilizando a versão .NET 7.0!
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        //Criei um metodo para ler as placas para não se ter repetição de código.
        //Utilizei exceções para aceitar somente placas com 3 letras seguidas de 3 números.
        private string LerPlaca()
        {
            while (true)
            {
                string placa = Console.ReadLine().Trim().ToUpper();

                if (Regex.IsMatch(placa, @"^[A-Z]{3}\d{3}$"))
                {
                    return placa;
                }
                else
                {
                    Console.WriteLine("Placa inválida. Por favor digite novamente:");
                }
            }
        }

        public void AdicionarVeiculo()
        {
            // Implementado
            Console.WriteLine("Digite a placa do veículo:");
            try
            {
                string placa = LerPlaca();

                if (veiculos.Contains(placa))
                {
                    Console.WriteLine("Este veículo já está estacionado.");
                }
                else
                {
                    veiculos.Add(placa);
                    Console.WriteLine($"O veículo com a placa {placa} foi estacionado com sucesso.");
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

            // Implementado
            string placa = LerPlaca();

            // Verifica se o veículo existe
            while (!veiculos.Contains(placa))
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente.");
                Console.WriteLine("Digite a placa do veículo para remover:");
                placa = LerPlaca();
            }

            Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

            if (int.TryParse(Console.ReadLine(), out int horas))
            {
                decimal valorTotal = precoInicial + precoPorHora * horas;

                veiculos.Remove(placa);
                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Entrada inválida para a quantidade de horas.");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                // Implementado
                foreach (var placa in veiculos)
                {
                    Console.WriteLine(placa);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}