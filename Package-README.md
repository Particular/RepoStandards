**Build, version, and monitor better microservices with the most powerful service platform for .NET**

> This README is included with all NServiceBus NuGet packages. Click the **Project website** link in the NuGet sidebar to access specific documentation for this package.

## NServiceBus

NServiceBus is the industry-leading platform for building and monitoring message-driven or event-driven applications on .NET including:

- Encapsulate business logic in message handlers
- Orchestrate long-running business processes with sagas
- Run on-premises, in the cloud, or serverless
- Monitor and respond to failures using included platform tooling
- Observe system performance using Open Telemetry integration
- Support for Azure Service Bus, Azure Storage Queues, Amazon SQS/SNS, RabbitMQ, and using Microsoft SQL Server tables as queues
- Support for storing data in multiple flavors of SQL, Azure Cosmos DB, Azure Table Storage, Amazon DynamoDB, MongoDB, and RavenDB
- 24x7 commercial support from a team of dedicated support engineers located around the world

## Getting started

- Visit the [NServiceBus Quick Start](https://docs.particular.net/tutorials/quickstart/) to learn how NServiceBus will help you build better software systems.
- Visit the [NServiceBus step-by-step tutorial](https://docs.particular.net/tutorials/nservicebus-step-by-step/) to learn how to build NServiceBus systems, including how to send commands, manage multiple message endpoints, publish events, and retry errors.
- Install the [ParticularTemplates NuGet package](https://www.nuget.org/packages/ParticularTemplates) to get NServiceBus templates you can use to bootstrap projects using either `dotnet new` or within Visual Studio.
- Check out our other [tutorials](https://docs.particular.net/tutorials/) and [samples](https://docs.particular.net/samples/).
- Get [help with a proof-of-concept](https://particular.net/proof-of-concept).

## Support

- Browse our [documentation](https://docs.particular.net).
- Reach out to the [ParticularDiscussion](https://discuss.particular.net/) community.
- [Contact us](https://particular.net/support) to discuss your support requirements.

## Packages

- [NServiceBus](https://www.nuget.org/packages/NServiceBus)
- [NServiceBus.Testing](https://www.nuget.org/packages/NServiceBus.Testing)

### Transports

- [NServiceBus.Transport.AzureServiceBus](https://www.nuget.org/packages/NServiceBus.Transport.AzureServiceBus)
- [NServiceBus.Transport.AzureStorageQueues](https://www.nuget.org/packages/NServiceBus.Transport.AzureStorageQueues)
- [NServiceBus.AmazonSQS](https://www.nuget.org/packages/NServiceBus.AmazonSQS)
- [NServiceBus.RabbitMQ](https://www.nuget.org/packages/NServiceBus.RabbitMQ)
- [NServiceBus.Transport.SqlServer](https://www.nuget.org/packages/NServiceBus.Transport.SqlServer)
- [NServiceBus.Transport.Msmq](https://www.nuget.org/packages/NServiceBus.Transport.Msmq)

### Persistence

- [NServiceBus.Persistence.Sql](https://www.nuget.org/packages/NServiceBus.Persistence.Sql)
- [NServiceBus.Persistence.CosmosDB](https://www.nuget.org/packages/NServiceBus.Persistence.CosmosDB)
- [NServiceBus.Persistence.DynamoDB](https://www.nuget.org/packages/NServiceBus.Persistence.DynamoDB)
- [NServiceBus.Persistence.AzureTable](https://www.nuget.org/packages/NServiceBus.Persistence.AzureTable)
- [NServiceBus.Storage.MongoDB](https://www.nuget.org/packages/NServiceBus.Storage.MongoDB)
- [NServiceBus.RavenDB](https://www.nuget.org/packages/NServiceBus.RavenDB)
- [NServiceBus.Persistence.ServiceFabric](https://www.nuget.org/packages/NServiceBus.Persistence.ServiceFabric)
- [NServiceBus.NHibernate](https://www.nuget.org/packages/NServiceBus.NHibernate)
- [NServiceBus.Persistence.NonDurable](https://www.nuget.org/packages/NServiceBus.Persistence.NonDurable)

### Hosting

- [NServiceBus.Extensions.Hosting](https://www.nuget.org/packages/NServiceBus.Extensions.Hosting)
- [NServiceBus.AzureFunctions.InProcess.ServiceBus](https://www.nuget.org/packages/NServiceBus.AzureFunctions.InProcess.ServiceBus)
- [NServiceBus.AzureFunctions.Worker.ServiceBus](https://www.nuget.org/packages/NServiceBus.AzureFunctions.Worker.ServiceBus)
- [NServiceBus.AwsLambda.Sqs](https://www.nuget.org/packages/NServiceBus.AwsLambda.Sqs)

### Serialization

- [NServiceBus.Newtonsoft.Json](https://www.nuget.org/packages/NServiceBus.Newtonsoft.Json)

### Monitoring

- [NServiceBus.Metrics](https://www.nuget.org/packages/NServiceBus.Metrics)
- [NServiceBus.Metrics.ServiceControl](https://www.nuget.org/packages/NServiceBus.Metrics.ServiceControl)
- [NServiceBus.Metrics.ServiceControl.Msmq](https://www.nuget.org/packages/NServiceBus.Metrics.ServiceControl.Msmq)
- [NServiceBus.Metrics.PerformanceCounters](https://www.nuget.org/packages/NServiceBus.Metrics.PerformanceCounters)
- [NServiceBus.CustomChecks](https://www.nuget.org/packages/NServiceBus.CustomChecks)
- [NServiceBus.Heartbeat](https://www.nuget.org/packages/NServiceBus.Heartbeat)
- [NServiceBus.SagaAudit](https://www.nuget.org/packages/NServiceBus.SagaAudit)
- [NServiceBus.ServicePlatform.Connector](https://www.nuget.org/packages/NServiceBus.ServicePlatform.Connector)

### Interoperability

- [NServiceBus.Transport.Bridge](https://www.nuget.org/packages/NServiceBus.Transport.Bridge)
- [NServiceBus.Gateway](https://www.nuget.org/packages/NServiceBus.Gateway)
- [NServiceBus.Gateway.Sql](https://www.nuget.org/packages/NServiceBus.Gateway.Sql)
- [NServiceBus.Gateway.RavenDB](https://www.nuget.org/packages/NServiceBus.Gateway.RavenDB)

### Other

- [NServiceBus.Encryption.MessageProperty](https://www.nuget.org/packages/NServiceBus.Encryption.MessageProperty)
- [NServiceBus.TransactionalSession](https://www.nuget.org/packages/NServiceBus.TransactionalSession)
- [NServiceBus.Callbacks](https://www.nuget.org/packages/NServiceBus.Callbacks)
- [NServiceBus.DataBus.AzureBlobStorage](https://www.nuget.org/packages/NServiceBus.DataBus.AzureBlobStorage)
- [NServiceBus.DataBus.BinarySerializer](https://www.nuget.org/packages/NServiceBus.DataBus.BinarySerializer)
- [NServiceBus.UniformSession](https://www.nuget.org/packages/NServiceBus.UniformSession)
- [NServiceBus.Wcf](https://www.nuget.org/packages/NServiceBus.Wcf)