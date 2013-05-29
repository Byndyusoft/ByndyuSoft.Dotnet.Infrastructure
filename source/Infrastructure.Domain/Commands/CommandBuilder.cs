namespace ByndyuSoft.Infrastructure.Domain.Commands
{
    /// <summary>
    ///     Стандартная реализация интерефейса <see cref="ICommandBuilder" />
    /// </summary>
    public class CommandBuilder : ICommandBuilder
    {
        private readonly ICommandFactory _commandFactory;

        /// <summary>
        ///     Конструктор.
        /// </summary>
        /// <param name="commandFactory"></param>
        public CommandBuilder(ICommandFactory commandFactory)
        {
            _commandFactory = commandFactory;
        }

        public void Execute<TCommandContext>(TCommandContext commandContext)
            where TCommandContext : ICommandContext
        {
            _commandFactory.Create<TCommandContext>().Execute(commandContext);
        }
    }
}