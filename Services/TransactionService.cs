using Bank.Extensions;
using Bank.Models;
using Bank.Repositories.Interfaces;
using Bank.Services.Interafaces;

namespace Bank.Services;

public class TransactionService : ITransactionService
{
    private readonly IAccountRepository _accountRepository;

    public TransactionService(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }

    public double Withdraw(int number, double amount)
    {
        var account = GetValidAccount(number);

        account.ValidateAmountBiggerThanBalance(amount);
        
        account.Balance -= amount;

        return amount;
    }

    public void Deposit(int number, double amount)
    {
        var account = GetValidAccount(number);

        account.Balance += amount;
    }

    public double UseCredit(int number, double amount)
    {
        var account = GetValidAccount(number);
        account.ValidateAmountBiggerThanAvailableCredit(amount);
        
        account.CreditUsage += amount;

        return amount;
    }

    public void PayCredit(int number, double amount)
    {
        var account = GetValidAccount(number);
        account.ValidateAmountBiggerThenUsedCredit(amount);

        account.CreditUsage -= amount;
    }

    public void PayCreditWithBalance(int number, double amount)
    {
        var account = GetValidAccount(number);

        account.ValidateAmountBiggerThanBalance(amount);
        account.ValidateAmountBiggerThenUsedCredit(amount);

        account.Balance -= amount;
        account.CreditUsage -= amount;
    }

    public void PayAllCreditWithBalance(int number)
    {
        var account = GetValidAccount(number);
        account.ValidateCreditUsageBiggerThenBalance();

        account.Balance -= account.CreditUsage;
        account.CreditUsage = 0;
    }

    private Account GetValidAccount(int number)
    {
        var account = _accountRepository.GetByNumber(number);

        account.ValidateWhenNull();

        return account;
    }
}