using Bank.Models;

namespace Bank.Repositories.Interfaces;

public interface IAccountRepository
{
    Account GetByNumber(int number);
}