using Flunt.Notifications;
using Flunt.Validations;

namespace MeterAPI.Common.ViewModels.MeterEvent;

public class CreateMeterEventViewModel : Notifiable<Notification>
{
    public required int MeterId { get; set; }
    public required int ReadingId { get; set; }
    public required string EventType { get; set; }
    public required string Description { get; set; }

    public Models.MeterEvent MapTo()
    {
        Contract<Notification> contract = ValidateCostumerData();

        AddNotifications(contract);

        return new Models.MeterEvent
        {
            MeterId = MeterId,
            ReadingId = ReadingId,
            EventType = EventType,
            Description = Description
        };
    }

    private Contract<Notification> ValidateCostumerData() =>
            new Contract<Notification>()
                .Requires();
}