using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A state machine that can be used to manage states in any object.
/// Can be used for a game manager, player physics controller, etc.
/// Override the `Update()` method to add custom logic. Don't forget to call `base.Update()`!
/// </summary>
public class StateMachine<T> where T : State
{
    public T State { get; private set; }
    public static event Action<T, T> OnBeforeStateChanged;
    public static event Action<T, T> OnAfterStateChanged;

    public void SetState(T State)
    {
        OnBeforeStateChanged?.Invoke(this.State, State);

        this.State?.Exit();
        this.State = State;
        this.State?.Enter();

        OnAfterStateChanged?.Invoke(this.State, State);
    }

    public virtual void Update()
    {
        State?.Update();
    }
}

/// <summary>
/// A state that can be used in a state machine.
/// </summary>
public class State
{
    public virtual void Enter() { }
    public virtual void Update() { }
    public virtual void Exit() { }
}