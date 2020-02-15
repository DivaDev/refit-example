using System;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace Network_Playground
{
    /*
     * [
	{
      "breeds":
		[ list of attributes ],
	 "id":"LSaDk6OjY",
      "url":"https://cdn2.thecatapi.com/images/LSaDk6OjY.jpg",
      "width":1080,
      "height":1080
     }
        ]
     */
    public interface ICatsApi
    {
        [Get("/v1/images/search?breed_id={id}")]
        Task<List<Cat>> GetCats(string id);

    }

    public class Cat
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

    public class Herd
    {
        public List<Cat> breeds { get; set;}
    }

    class Program
    {
        public static async Task Main(string[] args)
        {
            var catsApi = RestService.For<ICatsApi>("https://api.thecatapi.com");
            var cats = await catsApi.GetCats("beng");
           // Console.WriteLine(cats);
            Console.WriteLine($" id:{cats[0].id}, name:{cats[0].height}, origin:{cats[0].width}");
        }
    }
}
