using KnightBus.Messages;

namespace KnightBus.PostgreSql.Messages;

public interface IPostgresCommand : ICommand;

public interface IPostgresEvent : IEvent;
