using Flunt.Extensions.Br.Validations;
using Flunt.Notifications;
using Flunt.Validations;
using MeterAPI.Models;

namespace MeterAPI.Common.ViewModels.Client;

public class UpdateClientViewModel : Notifiable<Notification>
{
    public required string Name { get; set; }
    public required string TypePerson { get; set; }
    public required string Document { get; set; }
    public required string Address { get; set; }
    public required string Phone { get; set; }
    public required string Email { get; set; }

    public Models.Client MapTo(Models.Client client)
    {
        Contract<Notification> contract = ValidateCostumerData();

        AddNotifications(contract);

        client.Name = Name;
        client.TypePerson = TypePerson;
        client.Document = Document;
        client.Address = Address;
        client.Phone = Phone;
        client.Email = Email;

        return client;
    }

    private Contract<Notification> ValidateCostumerData() =>
            new Contract<Notification>()
                .Requires();
}
