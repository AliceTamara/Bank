using Bank.Exceptions;
using Bank.Models;

namespace Bank.Extensions
{
    public static class AccountExtensions
    {
        public static void ValidateWhenNull(this Account account)
        {
            if(account == null)
                throw new InvalidAccountNumberException("Your account number was not found, please contact the support.");
        }
    }
}
