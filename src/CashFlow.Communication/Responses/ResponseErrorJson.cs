namespace CashFlow.Communication.Responses
{
    public class ResponseErrorJson
    {
        public List<string> ErrorMessages { get; set; }

        public ResponseErrorJson(string Message)
        {
            ErrorMessages = [Message];
        }

        public ResponseErrorJson(List<string> Messages)
        {
            ErrorMessages = Messages;
        }
    }
}
