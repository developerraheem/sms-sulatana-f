using System;
using School;
using School._class;

class Program
{
    static void Main()
    {
        try
        {
            Console.WriteLine("Starting test...");
            SYSTEMSETTING.branch_ID = "6";
            SYSTEMSETTING.sessionid = "68";
            FEE fee = new FEE();
            double arr = fee.GetPreviousOutstandingArrears("20261", "09 2026", "", "6", "68");
            Console.WriteLine("Outstanding Arrears for 20261 for 09 2026 = " + arr);

            double arr08 = fee.GetPreviousOutstandingArrears("20261", "08 2026", "", "6", "68");
            Console.WriteLine("Outstanding Arrears for 20261 for 08 2026 = " + arr08);
        }
        catch (Exception ex)
        {
            Console.WriteLine("EXCEPTION: " + ex);
        }
    }
}
