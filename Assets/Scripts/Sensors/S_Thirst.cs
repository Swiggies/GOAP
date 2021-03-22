using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "Thirsty", menuName = "States/Thirsty")]

public class S_Thirst : Sensor
{
    public bool NearAxe;

    private Vector3 axePos;

    public override void Init(Planner p)
    {
        base.Init(p);
        p.DataContainer.Add("isThirsty", false);
        p.DataContainer.Add("waterPosition", new Vector3(-10, 0, 10));
    }

    public override void OnUpdate()
    {
        if (p.Thirst <= 0)
            p.ChangeState("isThirsty", true);
    }
}
