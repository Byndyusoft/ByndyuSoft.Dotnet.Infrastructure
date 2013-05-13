namespace ByndyuSoft.Infrastructure.Domain.Commands
{
    /// <summary>
    /// Интерфейс фабрики, создающей команду для определенного контекста.
    /// </summary>
    public interface ICommandFactory
    {
        /// <summary>
        /// Создает команду по контексту команды.
        /// </summary>
        /// <typeparam name="TCommandContext">Контекст команды</typeparam>
        /// <returns>Экземпляр <see cref="ICommand"/> c заданным контекстом. /></returns>
        ICommand<TCommandContext> Create<TCommandContext>() where TCommandContext : ICommandContext;
    }
}