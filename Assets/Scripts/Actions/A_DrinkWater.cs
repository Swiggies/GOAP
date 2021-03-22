using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Drink Water", menuName = "Actions/Drink Water")]
public class A_DrinkWater : Action
{

    public override void Init(Planner p)
    {
        base.Init(p);
    }

    public override void OnUpdate()
    {
        p.Agent.SetDestination((Vector3)p.DataContainer["waterPosition"]);
        if (Vector3.Distance(p.transform.position, (Vector3)p.DataContainer["waterPosition"]) < 3)
        {
            p.Thirst = 30;
            p.ChangeState("isThirsty", false);
            ActionComplete = true;
            Debug.Log("Yo");
        }
    }

    public override int GetCost()
    {
        return base.GetCost();
    }
}
