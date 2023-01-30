using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorizationCianPageTests
{
    internal class DealTypesNames
    {
        public static string ByPurchase { get; } = "Купить";
        public static string BySell { get; } = "Продать";
        public static string BySelltoBuy { get; } = "Продать, чтобы купить";
        public static string BySearchingforRental { get; } = "Снять";
        public static string ByOffersforRent { get; } = "Сдать";
    }
}
