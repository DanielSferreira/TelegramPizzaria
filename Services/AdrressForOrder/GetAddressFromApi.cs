using RestSharp;
using Newtonsoft.Json;

namespace TelegramPizzaria.Services.AdrressForOrder
{
    public class GetAddressFromApi
    {
        
        private RestClient clt;
        
        public GetAddressFromApi(string address)
            => clt = new RestClient(address);
        
        public Localizacao Location(
            string sgl, 
            string city, 
            string rua
        ) {
            var req = new RestRequest("address")
                .AddHeader("Authorization", "Token token=e715441276928dba38f999dc19d28666")
                .AddParameter("estado", sgl)
                .AddParameter("cidade", city)
                .AddParameter("logradouro", rua);

            var res = clt.Get(req);
            var a = JsonConvert.DeserializeObject<Localizacao>(res.Content);

            return a;
        }


    }
    public class Cidade {
        public int ddd { get; set; } 
        public string ibge { get; set; } 
        public string nome { get; set; } 
    }
    public class Estado {
        public string sigla { get; set; } 
    }
    public class Localizacao {
        public double altitude { get; set; } 
        public string cep { get; set; } 
        public string latitude { get; set; } 
        public string longitude { get; set; } 
        public Cidade cidade { get; set; } 
        public Estado estado { get; set; } 
    }
}