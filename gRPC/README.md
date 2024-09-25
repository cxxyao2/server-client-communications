## What is gRPC
 - A client application can directly call a method on a servce applciaton on a different machine  as if it were local objects, making it easier for you to create distributed applications and services as in many RPC systems.
 - gRPC is based around the idea of defining a service, specifying the methods that can be called remotely with their parameters and return types.
 -  google performance Remote Procedure Call

 ## The protocol underneath
 -  gRPC uses **HTTP/2** as the underlying protocol for communication between servers and clients. HTTP/2 offers several advantages, such as multiplexing (allowing multiple requests and responses to be in flight simultaneously), header compression, and bidirectional streaming, which makes it well-suited for gRPC's efficient, low-latency communication model.

 - In addition, gRPC uses **Protocol Buffers (protobuf)** as its interface definition language (IDL) to serialize and deserialize data efficiently between clients and servers.