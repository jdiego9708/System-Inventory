namespace EntidadesInventory.Helpers
{
    public class ErrorModel
    {
        public ErrorModel()
        {

        }

        public ErrorModel(int errorCode, string errorMessage, object errorResponse)
        {
            this.ErrorCode = errorCode;
            this.ErrorMessage = errorMessage;
            this.ErrorResponse = errorResponse;
        }

        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public object ErrorResponse { get; set; }
    }
}
