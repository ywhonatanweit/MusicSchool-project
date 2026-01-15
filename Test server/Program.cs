using Model;
using Service;
using System.Threading.Tasks;

namespace Test_server
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            ApiService api=new ApiService();   
            ArtistList artists =await api.SelectAllArtists(); 
            Console.WriteLine(artists.Count);
        }
    }
}
