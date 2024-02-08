using PasqualiBackend.Business.interfaces;
using PasqualiBackend.Business.Models;
using PasqualiBackend.Data.Context;

namespace PasqualiBackend.Data.Repository
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(MeuDbContext context) : base(context)
        {
        }
    }
}
