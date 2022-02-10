using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using TKMaster.AulaEnsino.Core.Domain.Interfaces.Notifications;
using TKMaster.AulaEnsino.Core.Domain.Interfaces.Services;
using TKMaster.AulaEnsino.Core.Domain.Notifications;
using TKMaster.AulaEnsino.Core.WebApi.Mapper;
using TKMaster.AulaEnsino.Core.WebApi.ViewModels.Request;
using TKMaster.AulaEnsino.Core.WebApi.ViewModels.Responses;

namespace TKMaster.AulaEnsino.Core.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FornecedorController : APIController
    {
        #region Properties

        private readonly IFornecedorAppService _fornecedorApp;

        #endregion

        #region Constructor

        public FornecedorController(INotificationHandler<DomainNotification> notifications,
            IFornecedorAppService fornecedorApp) : base(notifications)
        {
            _fornecedorApp = fornecedorApp;
        }

        #endregion

        #region Methods

        [HttpGet("ListarTodos")]
        [Consumes("application/Json")]
        [Produces("application/Json")]
        [ProducesResponseType(typeof(ResponseEntidadeBase), 200)]
        [ProducesResponseType(typeof(ResponseFalha), 400)]
        [ProducesResponseType(typeof(ResponseFalha), 403)]
        [ProducesResponseType(typeof(ResponseFalha), 409)]
        [ProducesResponseType(typeof(ResponseFalha), 500)]
        [ProducesResponseType(typeof(ResponseFalha), 502)]
        public async Task<IActionResult> ListarTodos()
        {
            var retorno = await _fornecedorApp.ListarTodos();
            return Response(retorno.Select(x => x.ToResponse()));
        }

        [HttpGet("ObterPorCodigo/{codigo}")]
        [Consumes("application/Json")]
        [Produces("application/Json")]
        [ProducesResponseType(typeof(ResponseEntidadeBase), 200)]
        [ProducesResponseType(typeof(ResponseFalha), 400)]
        [ProducesResponseType(typeof(ResponseFalha), 403)]
        [ProducesResponseType(typeof(ResponseFalha), 409)]
        [ProducesResponseType(typeof(ResponseFalha), 500)]
        [ProducesResponseType(typeof(ResponseFalha), 502)]
        public async Task<IActionResult> ObterPorCodigo(int codigo)
        {
            var retorno = await _fornecedorApp.ObterPorCodigo(codigo);
            return Response(retorno?.ToResponse());
        }

        [HttpPost("Adicionar")]
        [Consumes("application/Json")]
        [Produces("application/Json")]
        [ProducesResponseType(typeof(ResponseEntidadeBase), 200)]
        [ProducesResponseType(typeof(ResponseFalha), 400)]
        [ProducesResponseType(typeof(ResponseFalha), 403)]
        [ProducesResponseType(typeof(ResponseFalha), 409)]
        [ProducesResponseType(typeof(ResponseFalha), 500)]
        [ProducesResponseType(typeof(ResponseFalha), 502)]
        public async Task<IActionResult> Adicionar([FromBody] RequestFornecedor request)
        {
            return Response(await _fornecedorApp.Adicionar(request.ToRequest()));
        }

        [HttpPut("Atualizar")]
        [Consumes("application/Json")]
        [Produces("application/Json")]
        [ProducesResponseType(typeof(ResponseEntidadeBase), 200)]
        [ProducesResponseType(typeof(ResponseFalha), 400)]
        [ProducesResponseType(typeof(ResponseFalha), 403)]
        [ProducesResponseType(typeof(ResponseFalha), 409)]
        [ProducesResponseType(typeof(ResponseFalha), 500)]
        [ProducesResponseType(typeof(ResponseFalha), 502)]
        public async Task<IActionResult> Atualizar([FromBody] RequestFornecedor request)
        {
            return Response(await _fornecedorApp.Atualizar(request.ToRequest()));
        }

        [HttpPut("Excluir")]
        [Consumes("application/Json")]
        [Produces("application/Json")]
        [ProducesResponseType(typeof(ResponseEntidadeBase), 200)]
        [ProducesResponseType(typeof(ResponseFalha), 400)]
        [ProducesResponseType(typeof(ResponseFalha), 403)]
        [ProducesResponseType(typeof(ResponseFalha), 409)]
        [ProducesResponseType(typeof(ResponseFalha), 500)]
        [ProducesResponseType(typeof(ResponseFalha), 502)]
        public async Task<IActionResult> Excluir([FromBody] RequestReativarExcluirFornecedor request)
        {
            return Response(await _fornecedorApp.Excluir(request.ToRequest()));
        }

        [HttpPut("Reativar")]
        [Consumes("application/Json")]
        [Produces("application/Json")]
        [ProducesResponseType(typeof(ResponseEntidadeBase), 200)]
        [ProducesResponseType(typeof(ResponseFalha), 400)]
        [ProducesResponseType(typeof(ResponseFalha), 403)]
        [ProducesResponseType(typeof(ResponseFalha), 409)]
        [ProducesResponseType(typeof(ResponseFalha), 500)]
        [ProducesResponseType(typeof(ResponseFalha), 502)]
        public async Task<IActionResult> Reativar([FromBody] RequestReativarExcluirFornecedor request)
        {
            return Response(await _fornecedorApp.Reativar(request.ToRequest()));
        }

        [HttpGet("NomeExiste/{nomeFornecedor}")]
        [Consumes("application/Json")]
        [Produces("application/Json")]
        [ProducesResponseType(typeof(ResponseEntidadeBase), 200)]
        [ProducesResponseType(typeof(ResponseFalha), 400)]
        [ProducesResponseType(typeof(ResponseFalha), 403)]
        [ProducesResponseType(typeof(ResponseFalha), 409)]
        [ProducesResponseType(typeof(ResponseFalha), 500)]
        [ProducesResponseType(typeof(ResponseFalha), 502)]
        public async Task<IActionResult> NomeExiste(string nomeFornecedor)
        {
            var retorno = await _fornecedorApp.NomeExiste(nomeFornecedor);
            return Response(retorno?.ToResponse());
        }

        [HttpGet("DocumentoExiste/{documento}")]
        [Consumes("application/Json")]
        [Produces("application/Json")]
        [ProducesResponseType(typeof(ResponseEntidadeBase), 200)]
        [ProducesResponseType(typeof(ResponseFalha), 400)]
        [ProducesResponseType(typeof(ResponseFalha), 403)]
        [ProducesResponseType(typeof(ResponseFalha), 409)]
        [ProducesResponseType(typeof(ResponseFalha), 500)]
        [ProducesResponseType(typeof(ResponseFalha), 502)]
        public async Task<IActionResult> DocumentoExiste(string documento)
        {
            var retorno = await _fornecedorApp.DocumentoExiste(documento);
            return Response(retorno?.ToResponse());
        }

        #endregion
    }
}
