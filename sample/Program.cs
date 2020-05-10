using System;
using System.Collections.Generic;
using restClient;
namespace sample
{
    class Program
    {
        class Foo{
            public DateTime Date{get;set;} 
            public  int TemperatureC{get;set;} 
        }
         static void Main(string[] args)
        {
            var singletone=new  HttpClientFactory();
            Client<List<Foo>> client=new restClient.Client<List<Foo>>(singletone,new Uri("http://127.0.0.1:5010"));
            var x= client.Get("WeatherForecast");
            foreach(var y in x.Result){
                //Console.WriteLine("{0} \t {1}",y.Date,y.TemperatureC);
            }

            Client<Foo> client2=new restClient.Client<Foo>(singletone,new Uri("http://127.0.0.1:5010"));
            var yy= client2.Post("WeatherForecast",new Foo(){TemperatureC=1000}).Result;
            Console.WriteLine("{0} \t {1}",yy.Date,yy.TemperatureC);
            // var httpclient=singletone.GetOrCreate(new Uri("http://127.0.0.1:5010"));
            // var x= httpclient.GetAsync("WeatherForecast");
            // var responseContent =  x.Result.Content.ReadAsStringAsync();
            // Console.WriteLine( responseContent.Result.ToString());
        }
    }
}
