namespace TKMaster.AulaEnsino.Core.WebApi.ViewModels.Request
{
    public class RequestBuscarFornecedor
    {
        public string Nome { get; set; }

        public string Documento { get; set; }

        public string StatusPesquisa { get; set; }

        public string TipoPessoa { get; set; }
    }
}
