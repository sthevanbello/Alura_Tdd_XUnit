using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Alura.LeilaoOnline.Core;
using System.Linq;

namespace Alura.LeilaoOnline.Tests
{
    public class LeilaoRecebeOferta
    {
        //[Fact]
        //public void NaoPermiteNovosLancesDadoLeilaoFinalizado()
        //{
        //    //Arrange -Cenário
        //    var leilao = new Leilao("Van Gogh");
        //    var homer = new Interessada("Homer Simpson", leilao);
        //    leilao.RecebeLance(homer, 800);
        //    leilao.RecebeLance(homer, 900);
        //    leilao.TerminaPregao();

        //    // Act - Método sob teste
        //    leilao.RecebeLance(homer, 1000);

        //    var valorEsperado = 2;
        //    var valorObtido = leilao.Lances.Count();

        //    Assert.Equal(valorEsperado, valorObtido);
        //}
        [Theory]
        [InlineData(2, new double[] {800, 900})]
        [InlineData(5, new double[] {800, 900, 1000, 1200, 1500})]
        [InlineData(6, new double[] {800, 900, 1100, 1250, 1645, 1750})]
        
        public void NaoPermiteNovosLancesDadoLeilaoFinalizado(int quantidadeEsperada, double[] ofertas)
        {
            //Arrange -Cenário
            var leilao = new Leilao("Van Gogh");
            var homer = new Interessada("Homer Simpson", leilao);

            leilao.IniciaPregao();

            foreach (var valor in ofertas)
            {
                leilao.RecebeLance(homer, valor);
            }

            leilao.TerminaPregao();

            // Act - Método sob teste
            leilao.RecebeLance(homer, 1000);

            var quantidadeObtida = leilao.Lances.Count();

            Assert.Equal(quantidadeEsperada, quantidadeObtida);
        }
    }
}
