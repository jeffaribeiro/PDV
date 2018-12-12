using DesafioTotvsPDV.Business.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Moq;
using DesafioTotvsPDV.Domain.Interfaces.Repositorios;
using System.Collections.Generic;
using DesafioTotvsPDV.Domain.Entidades;
using DesafioTotvsPDV.Business.Implementacao;
using System;
using DesafioTotvsPDV.Business.Exceptions;

namespace DesafioTotvsPDV.Tests
{
    [TestClass]
    public class PagamentoBusinessTest
    {

        public PagamentoBusinessTest() { }

        [TestMethod]
        public void CalcularTroco_Sucesso()
        {
            var mockPagamentoRepo = new Mock<IPagamentoRepository>();
            var mockItemTrocoPagamentoRepo = new Mock<IItemTrocoPagamentoRepository>();
            decimal valorVenda = 105.42M;
            decimal valorPago = 150;
            Pagamento pagamento;

            PagamentoBusiness pb = new PagamentoBusiness(mockPagamentoRepo.Object, mockItemTrocoPagamentoRepo.Object);

            pagamento = pb.CalcularTroco(valorVenda, valorPago);

            Assert.IsTrue(pagamento != null);
        }

        [TestMethod]
        [ExpectedException(typeof(PagamentoBusinessException))]
        public void CalcularTroco_Falha()
        {
            var mockPagamentoRepo = new Mock<IPagamentoRepository>();
            var mockItemTrocoPagamentoRepo = new Mock<IItemTrocoPagamentoRepository>();
            decimal valorVenda = 150;
            decimal valorPago = 100;
            Pagamento pagamento;

            PagamentoBusiness pb = new PagamentoBusiness(mockPagamentoRepo.Object, mockItemTrocoPagamentoRepo.Object);

            pagamento = pb.CalcularTroco(valorVenda, valorPago);
        }

        [TestMethod]
        public void ObterItensTroco_Sucesso()
        {
            var mockPagamentoRepo = new Mock<IPagamentoRepository>();
            var mockItemTrocoPagamentoRepo = new Mock<IItemTrocoPagamentoRepository>();
            decimal valorVenda = 105.42M;
            decimal valorPago = 150;
            Pagamento pagamento;
            List<ItemTrocoPagamento> itensTroco;

            PagamentoBusiness pb = new PagamentoBusiness(mockPagamentoRepo.Object, mockItemTrocoPagamentoRepo.Object);

            pagamento = pb.CalcularTroco(valorVenda, valorPago);
            itensTroco = pb.ObterItensTroco(pagamento);

            Assert.IsTrue(itensTroco != null);
        }

        [TestMethod]
        public void SalvarPagamento_Sucesso()
        {
            var mockPagamentoRepo = new Mock<IPagamentoRepository>();
            var mockItemTrocoPagamentoRepo = new Mock<IItemTrocoPagamentoRepository>();
            decimal valorVenda = 105.42M;
            decimal valorPago = 150;
            Pagamento pagamento;
            List<ItemTrocoPagamento> itensTroco;

            PagamentoBusiness pb = new PagamentoBusiness(mockPagamentoRepo.Object, mockItemTrocoPagamentoRepo.Object);

            pagamento = pb.CalcularTroco(valorVenda, valorPago);
            itensTroco = pb.ObterItensTroco(pagamento);

            pb.SalvarPagamento(pagamento, itensTroco);
        }
    }
}
