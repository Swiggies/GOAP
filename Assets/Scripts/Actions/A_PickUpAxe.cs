using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Pick Up Axe", menuName = "Actions/Pick Up Axe")]
public class A_PickUpAxe : Action
{
    public override void Init(Planner p)
    {
        base.Init(p);
        DoEffect();
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        p.Agent.SetDestination((Vector3)p.DataContainer["axePosition"]);
        ActionComplete = true;
    }

    [ContextMenu("Effect")]
    public void DoEffect()
    {
        foreach(string e in Effects)
        {
            p.State[e] = true;
        }
    }

    public override int GetCost()
    {
        return base.GetCost();
    }
}
