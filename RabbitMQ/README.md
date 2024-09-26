RabbitMQ is an open-source message broker software that facilitates the efficient exchange of messages between distributed systems. It implements the Advanced Message Queuing Protocol (AMQP) and provides robust messaging for applications, ensuring that messages are delivered safely and efficiently between producers (senders) and consumers (receivers).

### Key Features of RabbitMQ:

1. **Message Queuing**: Messages are placed in queues, where they wait to be processed by consumers.
2. **Reliability**: Supports message persistence, delivery acknowledgments, and publisher confirms to ensure messages are not lost.
3. **Flexible Routing**: Messages can be routed through various exchange types (direct, topic, headers, and fanout) based on routing rules.
4. **Clustering**: RabbitMQ can be deployed in a cluster configuration for high availability and scalability.
5. **Federation and Shovel**: Allows for the federation of queues across different RabbitMQ instances and data centers.
6. **Plugins**: Extensible via a plugin architecture, supporting features like management plugins, monitoring, and various authentication mechanisms.
7. **Interoperability**: Supports multiple messaging protocols like AMQP, MQTT, STOMP, and more, enabling interoperability between different systems and languages.
8. **Management UI**: Provides a web-based user interface for managing and monitoring RabbitMQ servers.

### Core Concepts in RabbitMQ:

1. **Producer**: An application that sends messages.
2. **Consumer**: An application that receives messages.
3. **Queue**: A buffer that stores messages. Consumers receive messages from queues.
4. **Exchange**: Routes messages to queues based on routing keys. There are different types of exchanges:

   - **Direct Exchange**: Routes messages to queues based on an exact match between the routing key and the queue binding key.
   - **Topic Exchange**: Routes messages to queues based on pattern matching between the routing key and the queue binding pattern.
   - **Fanout Exchange**: Routes messages to all bound queues without considering routing keys.
   - **Headers Exchange**: Routes messages based on message header values instead of the routing key.

5. **Binding**: A link between a queue and an exchange that tells the exchange how to route messages to the queue.
6. **Message**: The data sent between producers and consumers, which can include a payload and metadata.

### Example Use Case:

1. **Producer**: An application (e.g., a web service) generates a message when a user performs an action (e.g., placing an order).
2. **Exchange**: The producer sends the message to an exchange. The exchange uses routing rules to determine which queue(s) should receive the message.
3. **Queue**: The message is placed in a queue, waiting to be processed by a consumer.
4. **Consumer**: A worker application retrieves the message from the queue and processes it (e.g., updating inventory, sending a confirmation email).

### Why Use RabbitMQ?

- **Decoupling**: Producers and consumers are decoupled, allowing them to operate independently and scale separately.
- **Load Balancing**: Distributes work among multiple consumers to balance the load.
- **Asynchronous Processing**: Enables asynchronous communication, allowing producers to continue working without waiting for consumers to process messages.
- **Reliability**: Ensures messages are reliably delivered and processed, even in case of failures.

### Installing RabbitMQ:

RabbitMQ can be installed on various platforms, including Windows, macOS, and Linux. Here's a brief guide to installing RabbitMQ on a Linux system:

1. **Install Erlang** (a dependency for RabbitMQ):

   ```bash
   sudo apt-get update
   sudo apt-get install erlang
   ```

2. **Install RabbitMQ**:

   ```bash
   sudo apt-get install rabbitmq-server
   ```

3. **Start RabbitMQ Server**:

   ```bash
   sudo systemctl start rabbitmq-server
   sudo systemctl enable rabbitmq-server
   ```

4. **Enable the Management Plugin** (optional):
   ```bash
   sudo rabbitmq-plugins enable rabbitmq_management
   ```
   You can then access the management UI at `http://localhost:15672` with the default credentials `guest/guest`.

RabbitMQ provides a reliable and flexible messaging system, suitable for various use cases requiring robust and efficient message handling.

### Other References

- `https://www.rabbitmq.com`
- Delete c:\users\jenni\appdata\roaming\nuget folder before run `dotnet add package RabbitMQ.Client`
- prerequisites: `docker run -it --rm --name rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq:3.13-management` locally or connect to a remote RabbitMQ server
- run sender : `cd\send\dotnet run`
- run receiver: `cd\receiver\dotnet run`
