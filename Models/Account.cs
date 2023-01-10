using Bank.Exceptions;

namespace Bank.Models
{
    public class Account
    {
        public string Name { get; set; }
        public int Number { get; set; }
        public double Balance { get; set; }
        public double CreditLimit { get; set; }
        public double CreditUsage { get; set; }

        public void ValidateAmountBiggerThanBalance(double amount)
        {
            if (amount > Balance)
                throw new BalanceException("Amount to big to your balance.");
        }
        
        public double CalculateAvailableCredit()
        {
            return CreditLimit - CreditUsage;
        }
       
        public void ValidateAmountBiggerThanAvailableCredit(double amount)
        {
            if (amount > CalculateAvailableCredit()) 
                throw new CreditException("Your amount is bigger than your available credit, please contact the support.");
        }
        
        public void ValidateAmountBiggerThenUsedCredit(double amount)
        {
            if (amount > CreditUsage) 
                throw new CreditException("Your amount is bigger than your used credit, please contact the support.");
        }
        
        public void ValidateCreditUsageBiggerThenBalance()
        {
            if(CreditUsage > Balance)
                throw new CreditException("Your credit usage is bigger than your balance.");
        }
    }
}