using PasqualiBackend.Business.Notificacoes;

namespace PasqualiBackend.Business.interfaces
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void Handle(Notificacao notificacao);
    }
}
