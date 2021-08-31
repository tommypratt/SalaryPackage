using System;
using System.Collections.Generic;
using System.Text;

namespace SalaryPackage
{
    class PayFrequency
    {
        public string Frenquency(string frequency)
        {
            if (frequency == "W" || frequency == "F" || frequency == "M")
            {
                return "Continue";
            }
            else
            {
                return "Redo";
            }
        }

        public double GetPayPacket(string payFrequency, double netIncome)
        {
            double payPacket;

            switch (payFrequency)
            {
                case "W":
                    payPacket = netIncome / 52;
                    break;
                case "F":
                    payPacket = netIncome / 26;
                    break;
                case "M":
                    payPacket = netIncome / 12;
                    break;
                default:
                    break;
            }

            return payPacket;
        }

    }
}
