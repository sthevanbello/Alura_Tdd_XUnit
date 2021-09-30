
using Alura.LeilaoOnline.Core;
using System;

namespace Alura.LeilaoOnline.ConsoleApp
{
    class Program
    {
        static void Main()
        {
            var leilao = new Leilao("Van Gogh");
            var homer = new Interessada(nome: "Homer Simpson", leilao: leilao);
            var marge = new Interessada("Marge Simpson", leilao);

            leilao.RecebeLance(homer, 800);
            leilao.RecebeLance(marge, 1200);
            leilao.RecebeLance(marge, 900);
            leilao.RecebeLance(homer, 1000);
            leilao.RecebeLance(marge, 1100);
            leilao.RecebeLance(marge, 900);

            leilao.TerminaPregao();

            Console.WriteLine(leilao.Ganhador.Cliente.Nome); 
            Console.WriteLine(leilao.Ganhador.Valor); 


            Console.ReadKey();
        }
    }
}
