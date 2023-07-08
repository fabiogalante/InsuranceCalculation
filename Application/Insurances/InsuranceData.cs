using Application.Interfaces;

namespace Application.Insurances;

public class InsuranceData : IInsuranceData
{
    private const decimal MarginInsurance = 0.03m;
    private const decimal ProfitMargin = 0.05m;
    public decimal ValueOfTheVehicle { get; set; }

    public decimal CalculateInsurancePrice()
    {
        var riskFee = ComputeRiskFee();
        var riskPremium = ComputeRiskPremium(riskFee);
        var purePremium = ComputePurePremium(riskPremium);
        var commercialPremium = ComputeCommercialPremium(purePremium);
        return Math.Round(commercialPremium, 2); ;
    }

    private decimal ComputeRiskFee() => (5m * ValueOfTheVehicle) / (2 * ValueOfTheVehicle);

    private decimal ComputeRiskPremium(decimal riskFee) => riskFee / 100m * ValueOfTheVehicle;

    private static decimal ComputePurePremium(decimal riskPremium) => riskPremium * (1 + MarginInsurance);

    private static decimal ComputeCommercialPremium(decimal purePremium) => purePremium + (ProfitMargin * purePremium);
}