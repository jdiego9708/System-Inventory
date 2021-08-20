using System;

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

        public ErrorModel(Exception ex)
        {
            this.ErrorCode = ex.HResult;
            this.ErrorMessage = ex.Message;
            this.ErrorResponse = ex.InnerException;
        }

        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public object ErrorResponse { get; set; }
        public string CustomMessage { get; set; }
    }
}
