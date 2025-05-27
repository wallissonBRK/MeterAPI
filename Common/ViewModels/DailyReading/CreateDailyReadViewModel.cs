using Flunt.Notifications;
using Flunt.Validations;

namespace MeterAPI.Common.ViewModels.DailyReading;

public class CreateDailyReadViewModel : Notifiable<Notification>
{
    public required int MeterId { get; set; }
    public required decimal DirectEnergyPeak { get; set; }
    public required decimal DirectEnergyOffPeak { get; set; }
    public required decimal DirectEnergyIntermediate { get; set; }
    public required decimal ReserveEnergyPeak { get; set; }
    public required decimal ReserveEnergyOffPeak { get; set; }
    public required decimal ReserveEnergyIntermediate { get; set; }
    public required decimal TotalReactiveEnergy { get; set; }
    public required decimal MaxDemand { get; set; }
    public required decimal PowerFactor { get; set; }
    public required decimal AvgVoltage { get; set; }
    public required decimal AvgCurrent { get; set; }

    public Models.DailyReading MapTo()
    {
        Contract<Notification> contract = ValidateCostumerData();

        AddNotifications(contract);

        return new Models.DailyReading
        {
            ActiveEnergyDirectIntermediate = DirectEnergyIntermediate,
            ActiveEnergyDirectOffpeak = DirectEnergyOffPeak,
            ActiveEnergyDirectPeak = DirectEnergyPeak,
            ActiveEnergyReverseIntermediate = ReserveEnergyIntermediate,
            ActiveEnergyReverseOffpeak = ReserveEnergyOffPeak,
            ActiveEnergyReversePeak = ReserveEnergyPeak,
            MeterId = MeterId,
            ReactiveEnergyTotal = TotalReactiveEnergy,
            MaxDemand = MaxDemand,
            PowerFactor = PowerFactor,
            AvgVoltage = AvgVoltage,
            AvgCurrent = AvgCurrent
        };
    }

    private Contract<Notification> ValidateCostumerData() =>
            new Contract<Notification>()
                .Requires();
}