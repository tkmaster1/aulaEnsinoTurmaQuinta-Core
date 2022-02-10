using TKMaster.AulaEnsino.Core.Domain.Entities;
using TKMaster.AulaEnsino.Core.WebApi.ViewModels.DTOs;
using TKMaster.AulaEnsino.Core.WebApi.ViewModels.Request;

namespace TKMaster.AulaEnsino.Core.WebApi.Mapper
{
    public static class FornecedorEntityToViewModel
    {
        public static FornecedorDTO ToResponse(this Fornecedor entity)
        {
            return new FornecedorDTO()
            {
                Codigo = entity.Codigo,
                Nome = entity.Nome,
                Status = entity.Status,
                Documento = entity.Documento,
                TipoPessoa = entity.TipoPessoa.Trim().ToUpper()
            };
        }

        public static Fornecedor ToRequest(this RequestFornecedor request)
        {
            var retorno = new Fornecedor();

            if (request != null)
            {
                retorno.Codigo = request.Codigo ?? 0;
                retorno.Nome = request.Nome;
                retorno.Documento = request.Documento;
                retorno.TipoPessoa = request.TipoPessoa.Trim().ToUpper();
            }

            return retorno;
        }

        public static Fornecedor ToRequest(this RequestReativarExcluirFornecedor request)
        {
            return new Fornecedor()
            {
                Codigo = request.Codigo
            };
        }
    }
}
