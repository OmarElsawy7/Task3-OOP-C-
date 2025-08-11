using System;
using System.Collections.Generic;

public class BankAccount
{
    public string AccountNumber { get; set; }
    public string AccountHolder { get; set; }
    public decimal Balance { get; set; }

    public BankAccount(string accountNumber, string accountHolder, decimal balance)
    {
        AccountNumber = accountNumber;
        AccountHolder = accountHolder;
        Balance = balance;
    }

    public virtual decimal CalculateInterest()
    {
        return 0;
    }

    public virtual void ShowAccountDetails()
    {
        Console.WriteLine($"Account Number: {AccountNumber}");
        Console.WriteLine($"Account Holder: {AccountHolder}");
        Console.WriteLine($"Balance: {Balance:C}");
    }
}

public class SavingAccount : BankAccount
{
    public decimal InterestRate { get; set; }

    public SavingAccount(string accountNumber, string accountHolder, decimal balance, decimal interestRate)
        : base(accountNumber, accountHolder, balance)
    {
        InterestRate = interestRate;
    }

    public override decimal CalculateInterest()
    {
        return Balance * InterestRate / 100;
    }

    public override void ShowAccountDetails()
    {
        base.ShowAccountDetails();
        Console.WriteLine($"Interest Rate: {InterestRate}%");
    }
}

public class CurrentAccount : BankAccount
{
    public decimal OverdraftLimit { get; set; }

    public CurrentAccount(string accountNumber, string accountHolder, decimal balance, decimal overdraftLimit)
        : base(accountNumber, accountHolder, balance)
    {
        OverdraftLimit = overdraftLimit;
    }

    public override decimal CalculateInterest()
    {
        return 0; // Always returns 0 for current account
    }

    public override void ShowAccountDetails()
    {
        base.ShowAccountDetails();
        Console.WriteLine($"Overdraft Limit: {OverdraftLimit:C}");
    }
}

class Program
{
    static void Main()
    {
        // Create SavingAccount
        SavingAccount saving = new SavingAccount("S001", "Ali Ahmed", 5000m, 5m);

        // Create CurrentAccount
        CurrentAccount current = new CurrentAccount("C001", "Sara Mohamed", 3000m, 1000m);

        // Add to list of BankAccount (Polymorphism)
        List<BankAccount> accounts = new List<BankAccount> { saving, current };

        // Loop and display details + interest
        foreach (var account in accounts)
        {
            account.ShowAccountDetails();
            Console.WriteLine($"Calculated Interest: {account.CalculateInterest():C}");
            Console.WriteLine(new string('-', 30));
        }
    }
}