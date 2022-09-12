namespace Bank.Services.Interafaces;

public interface ITransactionService
{
    double Withdraw(int number, double amount);
    void Deposit(int number, double amount);
    double UseCredit(int number, double amount);
    void PayCredit(int number, double amount);
    void PayCreditWithBalance(int number, double amount);
    void PayAllCreditWithBalance(int number);
}