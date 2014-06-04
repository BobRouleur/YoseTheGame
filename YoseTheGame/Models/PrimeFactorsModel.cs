using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebPages;

namespace YoseTheGame.Models
{
    public class PrimeFactorsModel
    {
        public Response Decompose(string number)
        {
            if (number.IsInt())
            {
                int temp = int.Parse(number);

                if (temp > 1000000)
                {
                    BigNumberResponse response = new BigNumberResponse();
                    response.number = temp;
                    response.error = "too big number (>1e6)";

                    return response;

                }
                else
                {
                    NumberResponse response = new NumberResponse();
                    response.number = int.Parse(number);
                    response.decomposition = GetPrimeFactors(int.Parse(number));

                    return response;
                }
                
               
                
            }
            else
            {
                ErrorResponse response = new ErrorResponse();
                response.number = number;
                response.error = "not a number";

                return response;
            }

            
        }

        static bool IsPrimeNumber(int num)
        {
            bool bPrime = true;
            int factor = num / 2;

            int i = 0;

            for (i = 2; i <= factor; i++)
            {
                if ((num % i) == 0)
                    bPrime = false;
            }
            return bPrime;
        }

        static public List<int> GetPrimeFactors(int num)
        {

            var factors = new List<int>();

            
            while (num % 2 == 0)
            {
                
                    factors.Add(2);
                    
                
                num = num / 2;
            }

            int divisor = 3;
            
            while (divisor <= num)
            {
                if (num % divisor == 0)
                {
                   
                        factors.Add(divisor);
                        
                    num = num / divisor;
                }
                else
                {
                    
                    divisor += 2;
                }

            }

            return factors;
        }
    } 

}