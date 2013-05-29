namespace ByndyuSoft.Infrastructure.Domain.Commands
{
    /// <summary>
    ///     Интерфейс для команды.
    /// </summary>
    /// <typeparam name="TCommandContext">Контекст команды</typeparam>
    public interface ICommand<in TCommandContext> 
        where TCommandContext : ICommandContext
    {
        /// <summary>
        ///     Выполняет действия команды.
        /// </summary>
        /// <param name="commandContext">Контекст команды</param>
        void Execute(TCommandContext commandContext);
    }
}