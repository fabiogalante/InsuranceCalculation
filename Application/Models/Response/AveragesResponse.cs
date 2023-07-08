namespace Application.Models.Response
{
    public class AveragesResponse
    {
        public AveragesResponse(decimal average, decimal sumOfValues, decimal numberOfElements)
        {
            Average = average;
            SumOfValues = sumOfValues;
            NumberOfElements = numberOfElements;
        }

        public decimal Average { get; set; }
        public decimal SumOfValues { get; set; }
        public decimal NumberOfElements { get; set; }
    }
}
