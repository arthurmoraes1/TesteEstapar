using System;
using System.Collections.Generic;
using System.Text;
using TesteEstapar.Business.Notificacoes;

namespace TesteEstapar.Business.Interfaces
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacao();
        void Handle(Notificacao notificacao);
    }
}
