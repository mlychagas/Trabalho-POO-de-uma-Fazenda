using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FazendaLibrary.Mapeamento
{
    public class CompraAnimais
    {
        // Representa uma compra de animais, incluindo dados da nota fiscal, fornecedor e informações de controle.
        private double _valorTotal;
        private int _quantidade;
        public int IdCompra { get; set; }
        public DateTime DataCompra { get; set; }
        public string NumeroNotaFiscal { get; set; }
        // Valor total da nota fiscal. Deve ser maior que zero; caso contrário, lança exceção.
        public double ValorTotalNota { get { return _valorTotal; } set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(
                "O Valor Total da Nota não pode ser menor ou igual a zero.");
                }
                _valorTotal = value;
            } }
        public double? ValorFrete { get; set; }
        public string GTA { get; set; }
        
        public int Quantidade { get { return _quantidade; }
            set {
                if (value<=0)
                {
                    throw new ArgumentOutOfRangeException(
                "A Quantidade não pode ser menor ou igual a zero.");
                }
                _quantidade = value;
            } }
        public Fornecedor Fornecedor { get; set; }

        // Propriedades auxiliares criadas para exibição em grids ou relatórios.
        public string RazaoSocialFornecedor => Fornecedor?.RazaoSocial;
        public string CpfCnpjFornecedor => Fornecedor?.CpfCnpj;
        public string TelefoneFornecedor => Fornecedor?.Telefone;
    }
}
