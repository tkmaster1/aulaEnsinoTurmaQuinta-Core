using System.ComponentModel.DataAnnotations.Schema;

namespace TKMaster.AulaEnsino.Core.Domain.Entities
{
    public class Fornecedor : Entity
    {
        public string Documento { get; set; }

        public string TipoPessoa { get; set; }

        [NotMapped]
        public string StatusPesquisa { get; set; }
    }
}
