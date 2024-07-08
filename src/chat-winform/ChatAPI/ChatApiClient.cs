using chat_models;
using System.Net.Http;
using System.Net.Http.Json;

namespace chat_winform;

public class ChatApiClient(HttpClient httpClient)
{
    public async Task<Response> CallApiChat(Question question, CancellationToken cancellationToken = default)
    {

        var responseLocal = new Response();
        var httpResponse = await httpClient.PostAsJsonAsync("api/chat", question, cancellationToken: cancellationToken);
        if (httpResponse.IsSuccessStatusCode)
        {
            responseLocal = await httpResponse.Content.ReadFromJsonAsync<Response>(cancellationToken: cancellationToken);
        }
        return responseLocal;
    }

    public string BaseAddress => httpClient.BaseAddress.ToString();

    public HttpClient HttpClient => httpClient;
}