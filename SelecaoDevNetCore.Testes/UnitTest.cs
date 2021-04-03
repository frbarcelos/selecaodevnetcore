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

        [Fact]
        public void TesteCalculaJuros()
        {
            decimal valorInicial = 100;
            _calculaJurosController._taxa = 0.01m;
            string retorno = _calculaJurosController.GetAsync(valorInicial, 5).Result;
            if (retorno != "105,10")
            {
                throw new Exception("O cálculo está errado!");
            }
        }
    }
}
