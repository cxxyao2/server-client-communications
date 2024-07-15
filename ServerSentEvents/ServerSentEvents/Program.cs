using System.Text.Json;
using ServerSentEvents;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<ItemService>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAnyOrigin", p => p
        .AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod());
});

var app = builder.Build();
app.UseCors("AllowAnyOrigin");

app.MapGet("/", async (HttpContext ctx, ItemService service, CancellationToken ct) =>
{
    ctx.Response.Headers.Append("Content-Type", "text/event-stream");

    int index = 0;
    while (!ct.IsCancellationRequested)
    {
        var item = await service.WaitForNewItem();
        await ctx.Response.WriteAsync($"data: {index} ");
        await JsonSerializer.SerializeAsync(ctx.Response.Body, item);
        await ctx.Response.WriteAsync($"\n\n");
        await ctx.Response.Body.FlushAsync();

        service.Reset();
        index++;
    }
});

app.Run();
