using Locação.Exceptions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Locação.Entidades
{
    class AluguelVeículo
    {
        private DateTime inicio;
        private DateTime prevista;
        private DateTime retorno;
        private double kmPrevista;
        private double kmRetorno;
        private Veículo veículo;
        private Cliente cliente;

        private FaturaLocação faturaLocaçao;

        public AluguelVeículo() { }

        public AluguelVeículo(double kmPrevista, double kmRetorno, Veículo veículo, Cliente cliente)
        {
            if (kmRetorno <= kmPrevista)
            {
                kmRetorno = kmPrevista;
            }
            this.kmPrevista = kmPrevista;
            this.kmRetorno = kmRetorno;
            this.veículo = veículo;
            this.cliente = cliente;
        }

        public AluguelVeículo(DateTime inicio, DateTime prevista, DateTime retorno, Veículo veículo,Cliente cliente)
        {
            DateTime now = DateTime.Now;

            if (inicio< now || prevista<now ||retorno <now)
            {
                throw new DominioException("Data de aluguel deve ser maior que a data de hoje");
            }
            if (retorno<=inicio || prevista<=inicio)
            {
                throw new DominioException("Data de retorno não pode ser menor que a data de inicio");
            }
            this.inicio = inicio;
            this.prevista = prevista;
            this.retorno = retorno;
            this.veículo = veículo;
            this.cliente = cliente;
        }

        public DateTime Inicio { get => inicio; set => inicio = value; }
        public DateTime Prevista { get => prevista; set => prevista = value; }
        public DateTime Retorno { get => retorno; set => retorno = value; }
        public double KmPrevista { get => kmPrevista; set => kmPrevista = value; }
        public double KmRetorno { get => kmRetorno; set => kmRetorno = value; }
        public Veículo Veículo { get => veículo; set => veículo = value; }
        public Cliente Cliente { get => cliente; set => cliente = value; }
        public FaturaLocação FaturaLocaçao { get => faturaLocaçao; set => faturaLocaçao = value; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(faturaLocaçao.ToString() + "\n");
            sb.Append(veículo.ToString() + "\n");
            sb.Append(cliente.ToString() + "\n");
            return sb.ToString();
        }
    }
}

