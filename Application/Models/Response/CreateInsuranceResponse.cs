namespace Application.Models.Response
{
    public record CreateInsuranceResponse
    {
        public CreateInsuranceResponse(string message)
        {
            Message = message;
        }

        public string Message { get; set; }
    }
}
