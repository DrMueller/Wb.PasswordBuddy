
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.Wb.PasswordBuddy.CrossCutting.Errors.Implementation
{
    public class GenericError : ServerError
    {
        public GenericError(string errorMessage)
        {
            Guard.StringNotNullOrEmpty(() => errorMessage);

            ErrorMessage = errorMessage;
        }

        public string ErrorMessage { get; }

        public override string ToDescription()
        {
            return ErrorMessage;
        }
    }
}