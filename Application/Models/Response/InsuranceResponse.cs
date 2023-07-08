namespace Application.Models.Response
{
    public class InsuranceResponse
    {
        public InsuranceResponse(decimal insurancePrice, string brand, string model)
        {
            InsurancePrice = insurancePrice;
            Brand = brand;
            Model = model;
        }

        public decimal InsurancePrice { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }


    }


}
