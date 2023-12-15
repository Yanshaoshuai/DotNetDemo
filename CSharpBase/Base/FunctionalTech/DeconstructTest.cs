using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpBase.Base.FunctionalTech
{
    internal class DeconstructTest
    {
        private static (string, double, int, int, int, int) QueryCityDataForYears(string name, int year1, int year2)
        {
            int population1 = 0, popution2 = 0;
            double area = 0;
            if (name == "New York City")
            {
                area = 468.48;
                if (year1 == 1960)
                {
                    population1 = 7781984;
                }
                if (year2 == 2010)
                {
                    popution2 = 8175133;
                }
                return (name, area, year1, population1, year2, popution2);
            }
            return ("", 0, 0, 0, 0, 0);
        }

        static void Main(string[] args)
        {
            //解构元组
            var (_, _, _, pop1, _, pop2) = QueryCityDataForYears("New York City", 1960, 2010);
            Console.WriteLine($"Popution change,1960 to 2010:{pop2 - pop1:N0}");
        }
    }


}
