﻿using KnightBus.Core;
using Npgsql;

namespace KnightBus.PostgreSql;

public class PostgresTransport : ITransport
{
    public PostgresTransport(IPostgresConfiguration postgresConfiguration, NpgsqlDataSource npgsqlDataSource)
    {
        TransportChannelFactories = [
            new PostgresChannelFactory(npgsqlDataSource, postgresConfiguration),
            new PostgresSubscriptionChannelFactory(npgsqlDataSource, postgresConfiguration)
        ];
    }

    public ITransportChannelFactory[] TransportChannelFactories { get; }

    public ITransport ConfigureChannels(ITransportConfiguration configuration)
    {
        foreach (var channelFactory in TransportChannelFactories)
        {
            channelFactory.Configuration = configuration;
        }

        return this;
    }
}
