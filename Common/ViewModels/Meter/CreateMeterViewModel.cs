using Flunt.Notifications;
using Flunt.Validations;
using MeterAPI.Models;

namespace MeterAPI.Common.ViewModels.Meter;

public class CreateMeterViewModel : Notifiable<Notification>
{
    public required string SerialNumber { get; set; }
    public required int ClientId { get; set; }
    public required int ModelId { get; set; }
    public required string InstallationLocal { get; set; }
    public required bool IsActive { get; set; }

    public Models.Meter MapTo()
    {
        Contract<Notification> contract = ValidateCostumerData();

        AddNotifications(contract);

        return new Models.Meter
        {
            SerialNumber = SerialNumber,
            ClientId = ClientId,
            ModelId = ModelId,
            InstallationLocation = InstallationLocal,
            IsActive = IsActive
        };
    }

    private Contract<Notification> ValidateCostumerData() =>
            new Contract<Notification>()
                .Requires();
}
