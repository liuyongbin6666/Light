using GMVC.Core;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ModelBase
{
    protected void SendEvent(string eventName, params object[] args) => Game.SendEvent(eventName, args);
    public void Log(string message, [CallerMemberName] object methodName = null) => Debug.Log($"{GetType().Name} {methodName}: {message}");
    public void Log([CallerMemberName] object methodName = null) => Log("Invoke()", methodName?.ToString());
}
