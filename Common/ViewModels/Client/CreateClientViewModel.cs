using Flunt.Extensions.Br.Validations;
using Flunt.Notifications;
using Flunt.Validations;
using MeterAPI.Models;

namespace MeterAPI.Common.ViewModels.Client;

public class CreateClientViewModel : Notifiable<Notification>
{
    public required string Name { get; set; }
    public required string TypePerson { get; set; }
    public required string Document { get; set; }
    public required string Address { get; set; }
    public required string Phone { get; set; }
    public required string Email { get; set; }

    public Models.Client MapTo()
    {
        Contract<Notification> contract = ValidateCostumerData();

        if (!string.IsNullOrEmpty(Email)) contract.IsEmail(Email, "Email", "Email inválido");

        AddNotifications(contract);

        return new Models.Client
        {
            Name = Name,
            TypePerson = TypePerson,
            Document = Document,
            Address = Address,
            Phone = Phone,
            Email = Email
        };
    }

    private Contract<Notification> ValidateCostumerData() =>
            new Contract<Notification>()
                .Requires();
}