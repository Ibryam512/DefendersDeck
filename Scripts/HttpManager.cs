using System.Collections.Generic;
using System.Net.Http.Json;
using Godot;

public class HttpManager
{
    private string _token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJhdWQiOiJhY2NvdW50IiwiaXNzIjoiZGVmZW5kZXJzZGVjayIsImV4cCI6MTc2ODUwMzI4OCwic3ViIjoiNCIsInByZWZlcnJlZF91c2VybmFtZSI6IklicnlhbTEiLCJpYXQiOjE3MzY5NjcyODgsIm5iZiI6MTczNjk2NzI4OH0.WFEPB8DlCXnjHs8JWjfC4bF-Y9db_5ssuYCFqAJQRtU";
    private string _url = "https://defendersdeckapi-cyfmddgsgfgdhtbq.germanywestcentral-01.azurewebsites.net/api";

    // знам, че това не е коректен начин за имплементация :)
    public List<Card> GetDeck()
    {
        GD.Print("GetDeckAsync");
        using (System.Net.Http.HttpClient client = new())
        {
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {_token}");
            var result = client.GetAsync($"{_url}/cards/deck").Result;

            if (!result.IsSuccessStatusCode)
            {
                return new List<Card>();  
            }

            var content = result.Content.ReadFromJsonAsync<BaseResponse<List<Card>>>().Result;
            return content.Data;
        }
    }
}