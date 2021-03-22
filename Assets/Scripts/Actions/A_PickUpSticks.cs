using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Pick Up Sticks", menuName = "Actions/Pick Up Sticks")]
public class A_PickUpSticks : Action
{
    GameObject[] sticks;
    int stickCount = 0;

    public override void Init(Planner p)
    {
        base.Init(p);
        sticks = GameObject.FindGameObjectsWithTag("Stick");
        //Preconditions = new string[] { "" };
    }

    public override void OnUpdate()
    {
        stickCount++;
        if (stickCount < sticks.Length)
        {
            p.Agent.SetDestination((Vector3)sticks[stickCount].transform.position);
        }
    }

    public override int GetCost()
    {
        return base.GetCost();
    }
}
