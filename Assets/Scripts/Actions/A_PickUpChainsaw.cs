using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Pick Up Chainsaw", menuName = "Actions/Pick Up Chainsaw")]
public class A_PickUpChainsaw : Action
{
    public override void Init(Planner p)
    {
        base.Init(p);
        DoEffect();
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        p.Agent.SetDestination((Vector3)p.DataContainer["chainsawPosition"]);
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
