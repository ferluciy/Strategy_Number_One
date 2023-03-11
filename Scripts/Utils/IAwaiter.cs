using System.Runtime.CompilerServices;
namespace UtilsStrategy
{
    public interface IAwaiter<TAwaited> : INotifyCompletion
{
    bool IsCompleted { get; }
    TAwaited GetResult();
}
}