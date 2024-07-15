using Microsoft.AspNetCore.Components;
using System.Reactive;
using System.Reactive.Linq;

namespace N8WasmMudLab.Models;

/// <summary>
/// for debug indicator
/// </summary>
internal class MyObserver<T> : IObserver<T>
{
  string name;
  public Queue<string> MsgQueue { get; private set; } = new Queue<string>(10);
  public int NextCnt { get; private set; } = 0;

  /// <summary>
  /// 通告外部有新訊息
  /// </summary>
  public Action<T>? OnNextReceived = null;

  public MyObserver(string name)
  {
    this.name = name; 
  }

  void IObserver<T>.OnNext(T value)
  {
    NextCnt++;
    string msg = $"{name}: {value} at {DateTime.Now:mmss.fff}";

    //# 只保留最後10筆訊息。
    if(MsgQueue.Count >= 10) MsgQueue.Dequeue();
    MsgQueue.Enqueue(msg);
    //Console.WriteLine(msg);

    //# 通告外部有新訊息。
    OnNextReceived?.Invoke(value);
  }

  void IObserver<T>.OnCompleted()
  {
    //Console.WriteLine($"{name}.OnCompleted");
  }

  void IObserver<T>.OnError(Exception ex)
  {
    //Console.WriteLine($"{name}.OnError! " + ex.Message);
  }
}
