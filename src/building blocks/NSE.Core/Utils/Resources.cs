using System;

namespace NSE.Core.Utils
{
    public static class Resources
    {
        public static string ProductsIdsDontMatch => "Id's dos produtos não correspondem";

        public static string ProductNotFound(Guid productId) => $"O produto com o id {productId} não foi encontrado";

        public static string ProductInvalidQuantity(string productName, int stockQuantity)
            => $"O produto {productName} possui apenas {stockQuantity} unidades em estoque";
    }
}