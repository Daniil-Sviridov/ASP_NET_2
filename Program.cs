using Lesson1;
using System.Text.Json;

async Task<Post> GetPost(HttpClient client, int id)
{

    var response = await client.GetAsync($"https://jsonplaceholder.typicode.com/posts/{id}");

    if (response.IsSuccessStatusCode)
    {
        await using var responseStream = await response.Content.ReadAsStreamAsync();
        var options = new JsonSerializerOptions(JsonSerializerDefaults.Web);

        if (await JsonSerializer.DeserializeAsync<Post>(responseStream, options) is Post post)
            return post;
        else
            throw new Exception($"Error content");
    }
    else
    {
        throw new Exception($"Error code {response.StatusCode}");
    }
}
// See https://aka.ms/new-console-template for more information

using HttpClient client = new();
{
    client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com");

    var tasks = new List<Task<Post>>();
    for (int i = 4; i <= 13; i++) tasks.Add(GetPost(client, i));

    Task.WaitAll(tasks.ToArray());

    using (var sw = new StreamWriter(File.Create("result.txt")))
    {
        foreach (var task in tasks)
            if (task.IsCompleted && task.Exception == null)
                sw.WriteLine(task.Result);
    }

}
