using System.Collections.Generic;
using System.Linq;
using Jaskaranjot_Singh.Models;

namespace Jaskaranjot_Singh
{
    public static class IncomeRepository
    {
        private static readonly List<Income> Incomes = new();

        public static double GetTotalIncome(int userId)
        {
            return Incomes.Where(i => i.UserId == userId).Sum(i => i.Amount);
        }

        public static IEnumerable<Income> GetReceivedIncomes(int userId, bool isReceived)
        {
            return Incomes.Where(i => i.UserId == userId && i.IsReceived == isReceived);
        }

        public static void DeleteIncomes(int userId)
        {
            Incomes.RemoveAll(i => i.UserId == userId);
        }

        public static Income AddIncome(Income income)
        {
            income.Id = Incomes.Any() ? Incomes.Max(i => i.Id) + 1 : 1;
            Incomes.Add(income);
            return income;
        }
    }
}
