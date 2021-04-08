using System;
using Xunit;

namespace SelecaoDevNetCore.Testes
{
    public class UnitTest
    {
        private readonly API1.Controllers.RetornaTaxaController _retornaTaxaController;
        private readonly API2.Controllers.CalculaJurosController _calculaJurosController;

        public UnitTest()
        {
            _retornaTaxaController = new API1.Controllers.RetornaTaxaController();
            _calculaJurosController = new API2.Controllers.CalculaJurosController();
        }

        [Fact]
        public void TesteRetornaTaxa()
        {
            API1.Taxa taxa = new API1.Taxa();
            taxa.Valor = _retornaTaxaController.Get();
            if (taxa.Valor != 0.01)
            {
                throw new Exception("A taxa está errada!");
            }
        }

        [Theory]
        [InlineData(100, 5, 0.01, "105,10")]
        [InlineData(200, 6, 0.01, "212,30")]
        [InlineData(100, 6, 0.01, "106,15")]
        public void TesteCalculaJuros(decimal valorInicial, int meses, decimal taxa, string resultado)
        {
            string retorno = _calculaJurosController.Get(valorInicial, meses, taxa);
            if (retorno != resultado)
            {
                throw new Exception("O cálculo está errado!");
            }
        }
    }
}
