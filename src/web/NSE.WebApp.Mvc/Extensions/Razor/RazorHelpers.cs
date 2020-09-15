using Microsoft.AspNetCore.Mvc.Razor;
using System.Security.Cryptography;
using System.Text;
using System.Threading;

namespace NSE.WebApp.Mvc.Extensions.Razor
{
    public static class RazorHelpers
    {
        public static string HashEmailForGravatar(this RazorPage page, string email)
        {
            var md5Hasher = MD5.Create();
            var data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(email));
            var sBuilder = new StringBuilder();
            foreach (var t in data)
            {
                sBuilder.Append(t.ToString("x2"));
            }
            return sBuilder.ToString();
        }

        public static string StockMessage(this RazorPage razor, int quantity)
            => quantity > 0 ? $"Apenas {quantity} unidade(s) em estoque!" : "Produto esgotado!";

        public static string FormatCurrency(this RazorPage razor, decimal value)
            => value > 0 ? value.ToString("C2", Thread.CurrentThread.CurrentCulture) : "Gratuito";
    }
}