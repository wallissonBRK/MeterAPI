using Flunt.Notifications;
using Flunt.Validations;

namespace MeterAPI.Common.ViewModels;

public class LoginViewModel : Notifiable<Notification>
{
    public required string Usuario { get; set; }
    public required string Senha { get; set; }

    public void Validate()
    {
        AddNotifications(new Contract<Notification>()
            .Requires()
            .IsNotNullOrEmpty(Usuario, "Usuario", "Nome de usuário é obrigatório")
            .IsNotNullOrEmpty(Senha, "Senha", "Senha é obrigatória")
        );
    }
}
