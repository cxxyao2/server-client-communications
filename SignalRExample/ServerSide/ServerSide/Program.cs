using ServerSide;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(co => 
{
    co.AddPolicy("AllowAnyOrigin", p => p
      .WithOrigins("null") // Origin of an html file opened in a browser 
      .AllowAnyHeader()
      .AllowCredentials());
});
builder.Services.AddSignalR();

var app = builder.Build();
app.UseCors("AllowAnyOrigin");

app.MapHub<ChatHub>("/chathub");

app.Run();
