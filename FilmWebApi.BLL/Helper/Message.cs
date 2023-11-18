

using FluentValidation.Results;

namespace FilmWebApi.BLL.Helper
{
    public static class Message
    {

        public static string ErrorMessages(ValidationResult message)
        {

            string errorMessage = "";
            foreach (var item in message.Errors)
            {
                if (message.Errors[message.Errors.Count - 1].ErrorMessage != item.ErrorMessage)
                    errorMessage += item.ErrorMessage + "\n";
                else
                    errorMessage += item.ErrorMessage;

            }
            return errorMessage;
        }

    }
}
