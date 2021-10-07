using Alura.LeilaoOnline.Core;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Alura.LeilaoOnline.Tests
{
    public class LeilaoTestes
    {

        [Fact]
        public void LeilaoComTresClientes()
        {
            // Arrange - Cenário de entrada
            // Dado leilão com três clientes e lances realizados por eles
            var leilao = new Leilao("Van Gogh");
            var homer = new Interessada(nome: "Homer Simpson", leilao: leilao);
            var marge = new Interessada("Marge Simpson", leilao);
            var lisa = new Interessada("Lisa Simpson", leilao);

            leilao.RecebeLance(homer, 800);
            leilao.RecebeLance(marge, 900);
            leilao.RecebeLance(lisa, 950);
            leilao.RecebeLance(homer, 1000);
            leilao.RecebeLance(marge, 1100);
            leilao.RecebeLance(lisa, 1200);


            // Act - Método sob teste
            // Quando o pregão/leilão termina 
            leilao.TerminaPregao();

            Console.WriteLine("Leilão com vários lances");
            
            // Assert
            // Então o valor esperado é o maior valor ofertado pelo cliente
            // O cliente ganhador é o que ofertou o maior lance
            var valorEsperado = 1200;
            var valorObtido = leilao.Ganhador.Valor;

            Assert.Equal(valorEsperado, valorObtido);
            Assert.Equal(lisa, leilao.Ganhador.Cliente);
        }


        [Fact]
        public void LeilaoLancesOrdenadosPorValor()
        {
            // Arrange - Cenário de entrada
            var leilao = new Leilao("Van Gogh");
            var homer = new Interessada(nome: "Homer Simpson", leilao: leilao);
            var marge = new Interessada("Marge Simpson", leilao);

            leilao.RecebeLance(homer, 800);
            leilao.RecebeLance(marge, 900);
            leilao.RecebeLance(marge, 950);
            leilao.RecebeLance(homer, 1000);
            leilao.RecebeLance(marge, 1100);
            leilao.RecebeLance(marge, 1200);

            // Act - Método sob teste
            leilao.TerminaPregao();

            Console.WriteLine("Leilão com vários lances");
            // Assert
            var valorEsperado = 1200;
            var valorObtido = leilao.Ganhador.Valor;

            Assert.Equal(valorEsperado, valorObtido);
        }

        [Fact]
        public void LeilaoComApenasUmLance()
        {
            var leilao = new Leilao("Van Gogh");
            var homer = new Interessada(nome: "Homer Simpson", leilao: leilao);
            leilao.RecebeLance(homer, 800);
            leilao.TerminaPregao();

            var valorEsperado = 800;
            var valorObtido = leilao.Ganhador.Valor;

            Console.WriteLine("Leilão com apenas um lance");

            Assert.Equal(valorEsperado, valorObtido);
        }


        [Fact]
        public void LeilaoComVariosLances()
        {
            // Arrange - Cenário de entrada
            var leilao = new Leilao("Van Gogh");
            var homer = new Interessada(nome: "Homer Simpson", leilao: leilao);
            var marge = new Interessada("Marge Simpson", leilao);

            leilao.RecebeLance(homer, 800);
            leilao.RecebeLance(marge, 1200);
            leilao.RecebeLance(marge, 900);
            leilao.RecebeLance(homer, 1000);
            leilao.RecebeLance(marge, 1100);
            leilao.RecebeLance(marge, 900);

            // Act - Método sob teste
            leilao.TerminaPregao();

            Console.WriteLine("Leilão com vários lances");
            // Assert
            var valorEsperado = 1200;
            var valorObtido = leilao.Ganhador.Valor;

            Assert.Equal(valorEsperado, valorObtido);

            
        }

        [Fact]
        public void LeilaoSemLances()
        {
            var leilao = new Leilao("Van Gogh");
            leilao.TerminaPregao();

            var valorEsperado = 0;
            var valorObtido = leilao.Ganhador.Valor;

            Assert.Equal(valorEsperado, valorObtido);
        }

    }
}
