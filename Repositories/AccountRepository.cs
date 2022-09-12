using Bank.Models;
using Bank.Repositories.Interfaces;

namespace Bank.Repositories;

public class AccountRepository : IAccountRepository
{
    private List<Account> _accounts = new List<Account>()
    {
        new Account() {Name = "Alice", Number = 1, Balance = 500.00, CreditLimit = 1000.00, CreditUsage = 0.0},
        new Account() {Name = "Tamara", Number = 2, Balance = 1500.00, CreditLimit = 2000.00, CreditUsage = 500.00},
        new Account() {Name = "Filipe", Number = 3, Balance = 2500.00, CreditLimit = 3000.00, CreditUsage = 100.00},
        new Account() {Name = "Gabriel", Number = 4, Balance = 3500.00, CreditLimit = 4000.00, CreditUsage = 0.0},
        new Account() {Name = "Murilo", Number = 5, Balance = 400.00, CreditLimit = 5000.00, CreditUsage = 200.00},
        new Account() {Name = "Liah", Number = 6, Balance = 900.00, CreditLimit = 500.00, CreditUsage = 0.0},
        new Account() {Name = "Israel", Number = 7, Balance = 100.00, CreditLimit = 1500.00, CreditUsage = 0.0},
        new Account() {Name = "Rebeca", Number = 8, Balance = 200.00, CreditLimit = 1200.00, CreditUsage = 0.0},
        new Account() {Name = "Cemilda", Number = 9, Balance = 300.00, CreditLimit = 1800.00, CreditUsage = 250.0},
        new Account() {Name = "Ednei", Number = 10, Balance = 450.00, CreditLimit = 1200.00, CreditUsage = 50.00}
    };

    public Account GetByNumber(int accountNumber)
    {
        return _accounts.Where(_ => _.Number == accountNumber).FirstOrDefault();
    }
}