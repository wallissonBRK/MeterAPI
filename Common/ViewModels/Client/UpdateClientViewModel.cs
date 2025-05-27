using Flunt.Extensions.Br.Validations;
using Flunt.Notifications;
using Flunt.Validations;
using MeterAPI.Models;

namespace MeterAPI.Common.ViewModels.Client;

public class UpdateClientViewModel : Notifiable<Notification>
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Document { get; set; }
    public required string Adress { get; set; }
    public required string Phone { get; set; }
    public required string Email { get; set; }

    public Models.Client MapTo(Models.Client client)
    {
        Contract<Notification> contract = ValidateCostumerData();

        AddNotifications(contract);

        client.Name = Name;
        client.Document = Document;
        client.Address = Adress;
        client.Phone = Phone;
        client.Email = Email;

        return client;
    }

    private Contract<Notification> ValidateCostumerData() =>
            new Contract<Notification>()
                .Requires()
                .IsNotNullOrEmpty(Name, "Name", "Nome da empresa é obrigatório.")
                .IsCpfOrCnpj(Document, "Document", "O numero informado não é um CPF ou CNPJ.")
                .IsNotNullOrEmpty(Adress, "Adress", "O endereço é obrigatório.")
                .IsNotNullOrEmpty(Phone, "Phone", "O telefone é obrigatório.");
}
