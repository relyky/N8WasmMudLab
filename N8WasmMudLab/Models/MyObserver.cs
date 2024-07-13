using System.Reactive;
using System.Reactive.Linq;

namespace N8WasmMudLab.Models;

internal class MyObserver<T> : IObserver<T>
{
  public MyObserver()
  {
    
  }

  void IObserver<T>.OnNext(T value)
  {
    Console.WriteLine($"IObserver<{nameof(T)}>.OnNext => {value}");
  }

  void IObserver<T>.OnCompleted()
  {
    Console.WriteLine($"IObserver<{nameof(T)}>.OnCompleted");
  }

  void IObserver<T>.OnError(Exception ex)
  {
    Console.WriteLine($"IObserver<{nameof(T)}>.OnError! " + ex.Message);
  }
}
