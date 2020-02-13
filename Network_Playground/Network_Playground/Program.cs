using System;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace Network_Playground
{
    public interface ICatsApi
    {
        [Get("/v1/images/search?breed_id=[id]")]
        Task<Cats> GetCats(string myId);

    }
    public class Cats
    {
        //[JsonProperty(PropertyName = "id")]
        public string id { get; set; }

        //[JsonProperty(PropertyName = "width")]
        public int width { get; set; }

        //[JsonProperty(PropertyName = "height")]
        public int height { get; set; }

        //[JsonProperty(PropertyName = "breeds")]
        //public B breeds { get; set; }

        //[JsonProperty(PropertyName = "url")]
        public string url { get; set; }
    }

    class Program
    {
        public static async Task Main(string[] args)
        {
            var catsApi = RestService.For<ICatsApi>("https://api.thecatapi.com");
            var cats = await catsApi.GetCats("beng");
            Console.WriteLine(cats);
            //Console.WriteLine($" id:{cats.id}, name:{cats.height}, origin:{cats.width}");
        }
    }
}
