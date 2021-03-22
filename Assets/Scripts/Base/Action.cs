using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu]
public class Action : ScriptableObject
{
    protected Planner p;
    public int Cost = 0;
    public string[] Preconditions;
    public string[] Effects;

    public bool ActionComplete = false;

    public virtual void Init(Planner p)
    {
        this.p = p;
        foreach (string s in Effects) 
        {
            if(!p.State.ContainsKey(s))
                p.State.Add(s, false);
        }

        foreach (string s in Preconditions)
        {
            if (!p.State.ContainsKey(s))
                p.State.Add(s, false);
        }
    }

    public virtual bool PreconditionCheck()
    {
        foreach(string s in Preconditions)
        {
            if (!(bool)p.State[s])
                return false;
        }
        return true;
    }

    public virtual int GetCost() => Cost;

    public virtual void OnUpdate() 
    {
        if (ActionComplete)
            return;
    }

    public virtual void SetEffects()
    {
        foreach (string s in Effects)
        {
            p.State[s] = true;
        }
    }

    public virtual void OnActionEnter()
    {

    }
}
