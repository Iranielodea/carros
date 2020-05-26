using Carros.Comum;
using System;

namespace Carros.Dominio.ValueObject
{
    public class CPF
    {
        public string Numero { get; set; }
        public CPF(string cpf)
        {
            Numero = cpf.SoNumeros();
            ValidaCPF(Numero);
        }

        private void ValidaCPF(string cpf)
        {
            if (!Validacao.ValidarCPF(cpf))
                throw new Exception("CPF Inválido!");
        }
    }
}
