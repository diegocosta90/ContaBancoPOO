using System;
using System.Collections.Generic;
using System.Text;

namespace DIOBank
{
    class Conta
    {
        private TipoConta TipoConta { get; set; }//será utilizado um tipo ENUM
        private double Saldo { get; set; }
        private double Credito { get; set; }
        private string Nome { get; set; }

        public Conta(TipoConta tipoConta, double saldo, double credito, string nome)
        {
            TipoConta = tipoConta;
            Saldo = saldo;
            Credito = credito;
            Nome = nome;
        }


        public bool Sacar(double valorSaque)
        {
            //validar se existe saldo para saque
            if (Saldo - valorSaque < Credito * -1)
            {
                Console.WriteLine("Saldo insuficiente");
                return false;//não conseguiu realizar o saque
            }
            Saldo -= valorSaque;
            Console.WriteLine("O saldo atual da conta de {0} é {1}", Nome, Saldo);//o ze´ro é o nome e o 1 é o saldo

            return true;//conseguiu realizar o saque
        }

        public void Depositar(double valorDeposito)
        {
             Saldo += valorDeposito;
            Console.WriteLine("Saldo atual da conta de {0} é {1}.", Nome, Saldo);
        }

        public void Transferir(double valorTransferencia, Conta contaDestino)
        {
            if (Sacar(valorTransferencia))//reusa o método saque para tirar o valor da conta
            {
                contaDestino.Depositar(valorTransferencia);//reusa o método depositar para transferir o dinheiro da conta
            }
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "TipoConta " + TipoConta + " | ";
            retorno += "Nome " + Nome + " | ";
            retorno += "Saldo " + Saldo + " | ";
            retorno += "Crédito " + Credito;
            return retorno;
        }
    }
}
