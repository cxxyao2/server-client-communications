# Server-Client communication approaches

## Implemented using Csharp and Typescript

- 1, publish-subscribe:
  - webhook : http post. a message broker
- 2, request-response
  - gRPC (on top of http)
- 3, server sent events (client initiate, server send message , one-way approach)
- 4, signalR （ server push data to client )
- 5, websocket ( real-time, full-duplex communication)
- 6,RabbitMQ: message exchange. sender, consumer, topic.

## Todo:

- long polling ( not real real-time.)
