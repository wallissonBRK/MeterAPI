using Flunt.Extensions.Br.Validations;
using Flunt.Notifications;
using Flunt.Validations;
using MeterAPI.Models;

namespace MeterAPI.Common.ViewModels;

public class CreateClientViewModel : Notifiable<Notification>
{
    public required string Name { get; set; }
    public required string Document { get; set; }
    public required string Adress { get; set; }
    public required string Phone { get; set; }
    public required string Email { get; set; }

    public Client MapTo()
    {
        Contract<Notification> contract = ValidateCostumerData();

        if (!string.IsNullOrEmpty(Email)) contract.IsEmail(Email, "Email", "Email inválido");

        AddNotifications(contract);

        return new Client
        {
            Name = Name,
            Document = Document,
            Address = Adress,
            Phone = Phone,
            Email = Email
        };
    }

    private Contract<Notification> ValidateCostumerData() =>
            new Contract<Notification>()
                .Requires()
                .IsNotNullOrEmpty(Name, "Name", "Nome da empresa é obrigatório.")
                .IsCpfOrCnpj(Document, "Document", "O numero informado não é um CPF ou CNPJ.")
                .IsNotNullOrEmpty(Adress, "Adress", "O endereço é obrigatório.")
                .IsNotNullOrEmpty(Phone, "Phone", "O telefone é obrigatório.");
}