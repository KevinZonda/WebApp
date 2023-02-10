var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

Queue<string> queue = new();

app.MapGet("/hello", () => "Hello");

app.MapGet("/getQueue", () => queue);

app.MapPost("/pushQueue", (PushQueueModel<string> pm) =>
{
    if (pm == null) return Results.BadRequest();
    if (queue.Contains(pm.Content)) Results.Conflict("duplicated");
    queue.Enqueue(pm.Content);
    return Results.Ok();
});

app.Run();

class PushQueueModel<T>
{
    public T Content { get; set; }
}