using System;

namespace Alura.LeilaoOnline.Core
{
    public class Lance : IComparable
    {
        public Interessada Cliente { get; }
        public double Valor { get; }

        public Lance(Interessada cliente, double valor)
        {
            Cliente = cliente;
            Valor = valor;
        }

        //Método criado para comparar valores em uma lista
        public int CompareTo(object obj)
        {
            if (!(obj is Lance))
            {
                throw new Exception("Valor inválido");
            }
            Lance other = obj as Lance;
            return Valor.CompareTo(other.Valor);
        }
    }
}
