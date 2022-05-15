using ArticleBZ.Shared.DTOs;
using ArticleBZ.Shared.Models;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace ArticleBZ.Client.Services
{
    public static class JSRuntimeOperation
    {

        public static ValueTask<object> SetItem(this IJSRuntime js,string key, string value)
        {
          return  js.InvokeAsync<object>("localStorage.setItem", key, value);
        }
        public static ValueTask<LoginVM> SetUser(this IJSRuntime js, string key, LoginVM vm)
        {
            
            return js.InvokeAsync<LoginVM>("localStorage.setItem",key, vm);
        }
        
        public static ValueTask<string> GetItem(this IJSRuntime js, string key)
        {
            return js.InvokeAsync<string>("localStorage.getItem", key);
        }
        public static ValueTask<LoginVM> GetUser(this IJSRuntime js, string key)
        {
            return js.InvokeAsync<LoginVM>("localStorage.getItem", key);
        }
        public static ValueTask<object> RemoveItem(this IJSRuntime js, string key)
        {
            return js.InvokeAsync<object>("localStorage.removeItem", key);
        }
        
    }
}
