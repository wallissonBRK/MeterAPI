using Flunt.Extensions.Br.Validations;
using Flunt.Notifications;
using Flunt.Validations;
using MeterAPI.Models;

namespace MeterAPI.Common.ViewModels;

public class UpdateCostumerViewModel : Notifiable<Notification>
{
    public required string NomeEmpresa { get; set; }
    public required string CNPJ { get; set; }
    public required string Email { get; set; }
    public required string Aplicativo { get; set; }
    public required int QuantidadeLicencas { get; set; }
    public int PeriodoLicenca { get; set; }

    //public SmClientelicenca MapTo(SmClientelicenca costumer)
    //{
    //    Contract<Notification> contract = ValidateCostumerData();

    //    AddNotifications(contract);

    //    costumer.SmClEmpresa = NomeEmpresa;
    //    costumer.SmClCnpj = CNPJ;
    //    costumer.SmClEmail = Email;
    //    costumer.SmClAplicativo = Aplicativo;
    //    costumer.SmClQuantLicencas = QuantidadeLicencas;
    //    costumer.SmClPeriodoLicenca = PeriodoLicenca;

    //    return costumer;
    //}

    private Contract<Notification> ValidateCostumerData() =>
            new Contract<Notification>()
                .Requires()
                .IsNotNullOrEmpty(NomeEmpresa, "NomeEmpresa", "Nome da empresa é obrigatório")
                .IsNotNullOrEmpty(Email, "Email", "E-mail é obrigatório")
                .IsEmail(Email, "Email", "E-mail inválido")
                .IsNotNullOrEmpty(Aplicativo, "Aplicativo", "A escolha de Aplicativo é obrigatório")
                .IsNotNullOrEmpty(CNPJ, "CNPJ", "Deve informar o CNPJ")
                .IsCnpj(CNPJ, "CNPJ", "CNPJ inválido")
                .IsGreaterThan(QuantidadeLicencas, 0, "QuantidadeLicencas", "Quantidade de licenças deve ser maior que 0");
}
