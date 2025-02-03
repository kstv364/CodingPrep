using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//You are given the customer visit log of a shop represented by a 0-indexed string customers consisting only of characters 'N' and 'Y':

//if the ith character is 'Y', it means that customers come at the ith hour
//whereas 'N' indicates that no customers come at the ith hour.
//If the shop closes at the jth hour (0 <= j <= n), the penalty is calculated as follows:

//For every hour when the shop is open and no customers come, the penalty increases by 1.
//For every hour when the shop is closed and customers come, the penalty increases by 1.
//Return the earliest hour at which the shop must be closed to incur a minimum penalty.

//Note that if a shop closes at the jth hour, it means the shop is closed at the hour j.
namespace Solutions.TwoPointers
{
    internal class CountPenalties
    {
        public int BestClosingTime(string customers)
        {
            int n = customers.Length;
            int[] prefix = new int[n + 1];
            for (int i = 0; i < n; i++)
            {
                prefix[i + 1] = prefix[i] + (customers[i] == 'N' ? 1 : 0);
            }
            int minPenalty = int.MaxValue;
            int result = 0;
            for(int i=0; i <= n; i++)
            {
                int penalty = prefix[i] + (n-i-prefix[n]+prefix[i]);
                if(penalty < minPenalty)
                {
                    minPenalty = penalty;
                    result = i;
                }
            }
            return result;


        }
    }
}
