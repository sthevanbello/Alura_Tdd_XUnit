using Alura.LeilaoOnline.Core;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Alura.LeilaoOnline.Tests
{
    public class LeilaoTerminaPregao
    {

        [Theory]
        [InlineData(1200, new double[] { 800, 900, 1000, 1100, 1200 })]
        [InlineData(1200, new double[] { 800, 1100, 1000, 1200, 1150 })]
        [InlineData(800, new double[] { 800 })]
        public void RetornaMaiorValorDadoLeilaoComPeloMenosUmLance(double valorEsperado, double[] ofertas)
        {
            // Arrange - Cenário de entrada
            // Dado leilão com três clientes e lances realizados por eles
            var leilao = new Leilao("Van Gogh");
            var homer = new Interessada(nome: "Homer Simpson", leilao: leilao);


            foreach (var valor in ofertas)
            {
                leilao.RecebeLance(homer, valor);
            }

            // Act - Método sob teste
            // Quando o pregão/leilão termina 
            leilao.TerminaPregao();

            Console.WriteLine("Leilão com vários lances");

            // Assert
            // Então o valor esperado é o maior valor ofertado pelo cliente
            // O cliente ganhador é o que ofertou o maior lance

            var valorObtido = leilao.Ganhador.Valor;

            Assert.Equal(valorEsperado, valorObtido);
        }


        [Fact]
        public void RetornaZeroDadoLeilaoComPeloMenosUmValor()
        {
            var leilao = new Leilao("Van Gogh");
            leilao.TerminaPregao();

            var valorEsperado = 0;
            var valorObtido = leilao.Ganhador.Valor;

            Assert.Equal(valorEsperado, valorObtido);
        }

    }
}
