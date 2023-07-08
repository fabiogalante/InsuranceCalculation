namespace Application.Interfaces
{
    public interface IInsuranceData
    {
        decimal CalculateInsurancePrice();
        decimal ValueOfTheVehicle { get; set; }
    }
}
