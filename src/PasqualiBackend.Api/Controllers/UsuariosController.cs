using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PasqualiBackend.Api.ViewModels;
using PasqualiBackend.Business.interfaces;
using PasqualiBackend.Business.Models;

namespace PasqualiBackend.Api.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/usuarios")]
    public class UsuarioController : MainController
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;

        public UsuarioController(IUsuarioService usuarioService,
                                 IUsuarioRepository usuarioRepository,
                                 IMapper mapper,
                                 INotificador notificador) : base(notificador)
        {
            _usuarioService = usuarioService;
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }
        
        [HttpGet]
        public async Task<IEnumerable<UsuarioViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<UsuarioViewModel>>(await _usuarioRepository.ObterTodos());
        }
        
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<UsuarioViewModel>> ObterPorId(Guid id)
        {
            var produtoViewModel = await ObterUsuario(id);

            if (produtoViewModel == null) return NotFound();

            return produtoViewModel;
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioViewModel>> Adicionar(UsuarioAddViewModel usuarioViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _usuarioService.Adicionar(_mapper.Map<Usuario>(usuarioViewModel));

            return CustomResponse(usuarioViewModel);
        }       

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Atualizar(Guid id, UsuarioViewModel usuarioViewModel)
        {
            if (id != usuarioViewModel.Id)
            {
                NotificarErro("Os ids informados não são iguais!");
                return CustomResponse();
            }

            var usuario = await ObterUsuario(id);

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            usuario.Id = usuarioViewModel.Id;
            usuario.Nome = usuarioViewModel.Nome;
            usuario.DataNascimento = usuarioViewModel.DataNascimento;
            usuario.Renda = usuarioViewModel.Renda;

            await _usuarioService.Atualizar(_mapper.Map<Usuario>(usuario));

            return CustomResponse(usuarioViewModel);
        }
        
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<UsuarioViewModel>> Excluir(Guid id)
        {
            var usuario = await ObterUsuario(id);

            if (usuario == null) return NotFound();

            await _usuarioService.Remover(id);

            return CustomResponse(usuario);
        }

        private async Task<UsuarioViewModel> ObterUsuario(Guid id)
        {
            return _mapper.Map<UsuarioViewModel>(await _usuarioRepository.ObterPorId(id));
        }
    }
}
