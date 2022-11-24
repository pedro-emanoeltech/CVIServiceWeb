using Blazored.SessionStorage;
using System.Text;
using System.Text.Json;

namespace CVIServiceWebApp.Settings
{
    public static class SessionStorageSerivce
    {
        public static async Task SalvarItemCriptSessaoAsync<T>(this ISessionStorageService sessionStorageSerivce,string key ,T item)
        {
            var itemJson = JsonSerializer.Serialize(item);
            var itemJsonBytes = Encoding.UTF8.GetBytes(itemJson);
            var base64Json = Convert.ToBase64String(itemJsonBytes);
            await sessionStorageSerivce.SetItemAsync(key, base64Json);
        }
        public static async  Task<T> LerItemCriptSessaoAsync<T>(this ISessionStorageService sessionStorageSerivce, string key)
        {
            var base64Json = await sessionStorageSerivce.GetItemAsync<string>(key);
            var itemJsonByte = Convert.FromBase64String(base64Json);
            var itemJson = Encoding.UTF8.GetString(itemJsonByte);
            var item = JsonSerializer.Deserialize<T>(itemJson);
            return item!;
        }
    }
}
