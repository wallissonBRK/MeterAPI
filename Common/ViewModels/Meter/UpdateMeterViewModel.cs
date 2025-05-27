using Flunt.Notifications;
using Flunt.Validations;
using MeterAPI.Models;

namespace MeterAPI.Common.ViewModels.Meter;

public class UpdateMeterViewModel : Notifiable<Notification>
{
    public required string SerialNumber { get; set; }
    public required int ClientId { get; set; }
    public required int ModelId { get; set; }
    public required string InstallationLocal { get; set; }
    public required bool IsActive { get; set; }

    public Models.Meter MapTo(Models.Meter meter)
    {
        Contract<Notification> contract = ValidateCostumerData();

        AddNotifications(contract);

        meter.SerialNumber = SerialNumber;
        meter.ClientId = ClientId;
        meter.ModelId = ModelId;
        meter.InstallationLocation = InstallationLocal;
        meter.IsActive = IsActive;

        return meter;
    }

    private Contract<Notification> ValidateCostumerData() =>
            new Contract<Notification>()
                .Requires();
}