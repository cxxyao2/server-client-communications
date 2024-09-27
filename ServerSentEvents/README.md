Server-Sent Events (SSE) is a standard describing how servers can initiate data transmission towards browser clients once an initial client connection has been established. Unlike WebSockets, which allow for bidirectional communication, SSE is a <i>one-way</i> channel where data is sent from the server to the client. It is often used to send real-time updates to web applications, such as notifications, live scores, or other streaming data. Once connection is establed, server side is keeping alive, continously sending
info to the client side, e.g. DoorDash, ChatGPT, etc.
### Protocal

Server-Sent Events (SSE) are based on the HTTP protocol. SSE allows a server to push updates to the browser over a single long-lived HTTP connection. It is part of the HTML5 standard and uses a simple text-based format sent over HTTP, specifically using the text/event-stream MIME type.

### How Server-Sent Events Work

1. **Client Initiates Connection**: The client (usually a web browser) sends an HTTP request to the server to establish a connection.
2. **Server Keeps Connection Open**: The server keeps this connection open and sends events to the client as long as the connection is active.
3. **Events Sent in Plain Text**: Data is sent in plain text, typically in a specific format that includes the `data:` field. The server can send multiple messages over the same connection.
4. **Reconnection**: If the connection drops, the client can automatically reconnect, and the server can resume sending events from where it left off.

### SSE Example in C#

Here's a basic example of how to implement SSE in a C# backend using ASP.NET Core:

#### 1. Set Up the Controller

```csharp
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class EventsController : ControllerBase
{
    [HttpGet]
    public async Task Get()
    {
        Response.ContentType = "text/event-stream";

        for (int i = 0; i < 10; i++)
        {
            await Response.WriteAsync($"data: Server time is {DateTime.Now}\n\n");
            await Response.Body.FlushAsync();
            await Task.Delay(1000); // Wait for a second before sending the next event
        }
    }
}
```

#### 2. Set Up the Client (JavaScript)

```html
<!DOCTYPE html>
<html>
	<body>
		<div id="events"></div>
		<script>
			const eventSource = new EventSource('/api/events')
			eventSource.onmessage = function (event) {
				const newElement = document.createElement('div')
				newElement.textContent = 'New event: ' + event.data
				document.getElementById('events').appendChild(newElement)
			}
		</script>
	</body>
</html>
```

### Key Features of SSE

1. **Automatic Reconnection**: Clients automatically reconnect with the server if the connection is lost.
2. **Event IDs**: SSE supports event IDs which help the client to identify the last received event.
3. **Event Types**: You can specify different types of events and handle them differently on the client side.
4. **Text-Based**: SSE uses a simple text-based format which makes it easy to implement and debug.

### Use Cases

- **Live Updates**: Real-time updates for dashboards, stock tickers, or news feeds.
- **Notifications**: Sending notifications or alerts to web clients.
- **Monitoring**: Real-time monitoring of server or application status.

### Advantages

- **Simplicity**: Easier to implement compared to WebSockets for one-way communication.
- **Browser Support**: Widely supported in modern web browsers.
- **Lightweight**: Efficient for scenarios where only the server needs to push updates to the client.

### Limitations

- **One-Way Communication**: Only supports communication from server to client. For bidirectional communication, WebSockets would be more appropriate.
- **Less Control Over Connection**: Less control compared to WebSockets for managing the connection lifecycle.
- **Limited to HTTP/1.1**: SSE works over HTTP/1.1 and does not leverage newer HTTP/2 features.
