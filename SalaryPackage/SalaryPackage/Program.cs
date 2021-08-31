using System;

namespace SalaryPackage
{
    class Program
    {
        static void Main(string[] args)
        {
            PayFrequency findResult = new PayFrequency();
            Packaging packaging = new Packaging();
            string result = "";
            string payFrequency = "";
            double grossSalaryPackage;

            try
            {
                Console.WriteLine("Please enter your Gross Salary Package: $");
                string userInputSalary = Console.ReadLine();
                grossSalaryPackage = Double.Parse(userInputSalary);
            }
            catch(FormatException fex)
            {
                Console.WriteLine(fex.Message);
            }

            double super = packaging.GetSuperAnnuation(grossSalaryPackage);
            double taxableIncome = packaging.GetTaxableIncome(grossSalaryPackage);
            int medicareLevy = packaging.GetMedicareLevy(taxableIncome);
            int budgetRepair = packaging.GetBudgetRepair(taxableIncome);
            int incomeTax = packaging.GetIncomeTax(taxableIncome);
            int netIncome = packaging.GetNetIncome(taxableIncome, incomeTax, medicareLevy, budgetRepair);


            try
            {
                do
                {
                    Console.WriteLine("Enter your pay frequency (W for weekly, F for fortnightly, M for monthly): ");
                    payFrequency = Console.ReadLine();
                    result = findResult.Frenquency(payFrequency);
                    if (result == "Redo") Console.WriteLine("Please re-enter with correct spelling.");
                }
                while (result != "Continue");
            }
            catch (FormatException fex)
            {
                Console.WriteLine(fex.Message);
            }

            double payPacket = findResult.GetPayPacket(payFrequency, netIncome);

            Console.WriteLine("Calculating salary details...");

            Console.WriteLine("Gross Package: $" + grossSalaryPackage);
            Console.WriteLine("Superannuation: $" + super);

            Console.WriteLine("Taxable Income: $" + taxableIncome);

            Console.WriteLine("Decuctions:");

            Console.WriteLine("Medicare Levy: $" + medicareLevy);
            Console.WriteLine("Budget Repair Levy: $" + budgetRepair);
            Console.WriteLine("Income Tax: $" + incomeTax);

            Console.WriteLine("Net income: $" + incomeTax);
            Console.WriteLine("Pay Packet: $" + payPacket);
        }
    }
}
