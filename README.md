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

## About code quality Analysis tool

### Sonarqube vs codeql

Take the below factors into account:

- Easy of setup and integration
- Analytical capabilities and accuracy
- Language support and compatibility
- Rule customization and configurability
- Community support and additonal resources
- Performance and scalability

Benefits:

- identiy and fix critical security flaws in codebase, ensuring a robust and secure product

Stages:

- firstly, use Sonarqube as tool to analyze the codebase, to find the vulnerablities. CodeQL is a paid tool.
