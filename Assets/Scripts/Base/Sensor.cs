using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

[CreateAssetMenu]
public class Sensor : ScriptableObject
{
    protected Planner p;

    public virtual void Init(Planner p)
    {
        this.p = p;
    }

    public virtual void OnUpdate() { }
}
