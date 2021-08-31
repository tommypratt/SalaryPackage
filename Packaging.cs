using System;
using System.Collections.Generic;
using System.Text;

namespace SalaryPackage
{
    class Packaging
    {
        //call tax values to be used for equations
        readonly TaxLaws tax = new TaxLaws();

        public double twoPercent = 0.02;

        public double GetTaxableIncome(double salary)
        {
            //get super, perform deduction from salary package
            double super = getSuperAnnuation(salary);
            int taxableIncome = salary - super;

            return taxableIncome;
        }

        public double GetSuperAnnuation(double salary)
        {
            double superPercent = tax.superPercent;
            double super = salary * superPercent;
            double result = Math.Round(super, 2);
            
            return result;
        }

        public int GetMedicareLevy(double taxableIncome)
        {
            //if statements to determine and return medicarelevy total
            double baseLevy = tax.baseLevy;
            double maxLevy = tax.maxLevy;
            double result;
            int medicareLevy;
            double tenPercent = 0.1;
            
            if (taxableIncome <= baseLevy)
            {
                return 0;
            }
            else if(taxableIncome > baseLevy && taxableIncome <= maxLevy)
            {
                result = (taxableIncome - baseLevy) * tenPercent;
                medicareLevy = (int)Math.Ceiling(result);

                return medicareLevy;

            }
            else if(taxableIncome > maxLevy)
            {
                result = (taxableIncome - maxLevy) * twoPercent;
                medicareLevy = (int)Math.Ceiling(result);

                return medicareLevy;
            }
        }

        public int GetBudgetRepair(double taxableIncome)
        {
            //if statements to determine and return budget repair total
            double baseRepair = tax.baseRepair;
            int budgetRepair;

            if (taxableIncome <= baseRepair)
            {
                return 0;
            }
            else if(taxableIncome > baseRepair)
            {
                double result = (taxableIncome - baseRepair) * twoPercent;
                budgetRepair = (int)Math.Ceiling(result);

                return budgetRepair;
            }
        }

        public int GetIncomeTax(int taxableIncome)
        {
            //collect tax values, then run if statements to determine and return income tax total, 
            double baseIncome = tax.baseIncome;
            double lowIncome = tax.lowIncome;
            double midIncome = tax.midIncome;
            double taxHigh = tax.highIncome;
            double baseIncomePercent = tax.baseIncomePercent;
            double lowIncomePercent = tax.lowIncomePercent;
            double midIncomePercent = tax.midIncomePercent;
            double highIncomePercent = tax.highIncomePercent;
            int incomeTax;

            if (taxableIncome <= baseIncome)
            {
                return 0;
            }
            else if (taxableIncome > baseIncome && taxableIncome <= lowIncome)
            {
                double result = (taxableIncome - baseIncome) * baseIncomePercent;
                incomeTax = (int)Math.Ceiling(result);

                return incomeTax;
            }
            else if (taxableIncome > lowIncome && taxableIncome <= midIncome)
            {
                double result = 3572 + ((taxableIncome - lowIncome) * lowIncomePercent);
                incomeTax = (int)Math.Ceiling(result);

                return incomeTax;
            }
            else if (taxableIncome > midIncome && taxableIncome <= taxHigh)
            {
                double result = 19822 + ((taxableIncome - midIncome) * midIncomePercent);
                incomeTax = (int)Math.Ceiling(result);

                return incomeTax;
            }
            else if (taxableIncome > taxHigh)
            {
                double result = 54232 + ((taxableIncome - taxHigh) * highIncomePercent);
                incomeTax = (int)Math.Ceiling(result);

                return incomeTax;
            }
        }

        public int GetNetIncome(double taxableIncome, int incomeTax, int medicareLevy, int baseRepair)
        {
            //deductions taken from taxable income (taxable income already accounting for super deduction)
            double netIncome = taxableIncome - Convert.ToDouble(incomeTax) - Convert.ToDouble(medicareLevy) - Convert.ToDouble(baseRepair);
            return netIncome;
        }
    }
}
