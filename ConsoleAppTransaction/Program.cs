using ConsoleAppTransaction.Models;
using Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal;


T2301eSem3Context context = new T2301eSem3Context();

using (SqlServerTransaction transaction = (SqlServerTransaction)context.Database.BeginTransaction())
{
    try
    {
        int money = 50;

        Transaction fromAccount = context.Transactions.Where(a => a.Id == 1).First();

        Transaction toAccount = context.Transactions.Where(a => a.Id == 2).First();

        Console.WriteLine("From Account: " + fromAccount.Balance);
        Console.WriteLine("To Account: " + toAccount.Balance);

        toAccount.Balance += money;
        context.SaveChanges();

        fromAccount.Balance -= money;
        context.SaveChanges();

        transaction.Commit();
        Console.WriteLine("Transfer completed");
    }
    catch(Exception e)
    {
        transaction.Rollback();
        Console.WriteLine("Error Rollback " + e.Message);
    }
    
}
