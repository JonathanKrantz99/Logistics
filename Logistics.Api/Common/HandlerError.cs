namespace Logistics.Api.Common
{
    internal class HandlerError
    {
        private readonly string _errorMessage;
        public string ErrorMessage => _errorMessage;

        private HandlerError(string errorMessage)
        {
            _errorMessage = errorMessage;
        }

        public static HandlerError Create(string errorMessage)
        {
            var handlerError = new HandlerError(errorMessage);

            return handlerError;
        }
    }
}
