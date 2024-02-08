using PasqualiBackend.Business.interfaces;
using PasqualiBackend.Business.Models;
using PasqualiBackend.Business.Models.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasqualiBackend.Business.Services
{
    public class UsuarioService : BaseService, IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository,

                                 INotificador notificador) : base(notificador)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task Adicionar(Usuario usuario)
        {
            if (!ExecutarValidacao(new UsuarioValidation(), usuario)) return;

            if (_usuarioRepository.Buscar(f => f.Cpf == usuario.Cpf).Result.Any())
            {
                Notificar("Já existe um usuario com este cpf infomado.");
                return;
            }

            await _usuarioRepository.Adicionar(usuario);
        }

        public async Task Atualizar(Usuario usuario)
        {
            if (!ExecutarValidacao(new UsuarioValidation(), usuario)) return;

            if (_usuarioRepository.Buscar(f => f.Cpf == usuario.Cpf && f.Id != usuario.Id).Result.Any())
            {
                Notificar("Já existe um usuario com este cpf infomado.");
                return;
            }

            await _usuarioRepository.Atualizar(usuario);
        }

        public async Task Remover(Guid id)
        {
            var usuario = _usuarioRepository.ObterPorId(id).Result;
            if (usuario == null)
            {
                Notificar("Usuario não encontrado!");
                return;
            }

            await _usuarioRepository.Remover(id);
        }

        public void Dispose()
        {
            _usuarioRepository?.Dispose();
        }
    }
}
