using NSE.WebApp.Mvc.Extensions.Exceptions;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace NSE.WebApp.Mvc.Services
{
    public abstract class Service
    {
        protected StringContent GetContent(object data)
            => new StringContent(JsonSerializer.Serialize(data), Encoding.UTF8, "application/json");

        protected async Task<T> DeserializeObjectResponse<T>(HttpResponseMessage response)
        {
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            return JsonSerializer.Deserialize<T>(await response.Content.ReadAsStringAsync(), options);
        }

        protected bool HasResponseErrors(HttpResponseMessage response)
        {
            switch (response.StatusCode)
            {
                case System.Net.HttpStatusCode.Unauthorized:
                case System.Net.HttpStatusCode.Forbidden:
                case System.Net.HttpStatusCode.NotFound:
                case System.Net.HttpStatusCode.InternalServerError:
                    throw new CustomHttpResponseException(response.StatusCode);
                case System.Net.HttpStatusCode.BadRequest:
                    return true;
            }

            response.EnsureSuccessStatusCode();
            return false;
        }
    }
}