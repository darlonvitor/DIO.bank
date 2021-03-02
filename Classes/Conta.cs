using System;
namespace DIO.bank
{
    public class Conta
    {
        private TipoConta TipoConta { get; set; }
        private double Saldo { get; set; }
        private double Credito { get; set; }
        private string Nome { get; set; }
    

        public Conta(TipoConta tipoConta,double saldo,double credito,string nome)
        {
            this.TipoConta   = tipoConta;
            this.Saldo       = saldo;
            this.Credito     = credito;
            this.Nome        = nome;
        }

        public bool Sacar(double saque)
        {
            if ((this.Saldo-saque) > this.Credito)
            {
                Console.WriteLine("Saldo insuficiente");
                return false;
            }

            this.Saldo -= saque;
            Console.WriteLine($"O saldo atual na conta de {this.Nome} é de R$ {this.Saldo}");
            return true;
        }

        public void Depositar(double deposito)
        {
            this.Saldo += deposito;
            Console.WriteLine($"O saldo atual na conta de {this.Nome} é de R$ {this.Saldo}");
        }

        public void Transferir(double valorTransferencia, Conta contaDestino)
        {
            if (this.Sacar(valorTransferencia))
            {
                contaDestino.Depositar(valorTransferencia);
            }
        }

        public override string ToString()
        {
            return $"Tipo Conta: {this.TipoConta} | Nome: {this.Nome} | Saldo: {this.Saldo} | Credito: {this.Credito}";
        }

        
    }
}