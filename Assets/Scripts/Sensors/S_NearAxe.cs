using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "Near Axe", menuName = "States/Near Axe")]

public class S_NearAxe : Sensor
{
    public bool NearAxe;

    private Vector3 axePos;

    public override void Init(Planner p)
    {
        base.Init(p);
        p.DataContainer.Add("nearAxe", false);
        p.DataContainer.Add("axePosition", axePos);
    }

    public override void OnUpdate()
    {
        axePos = GameObject.FindGameObjectWithTag("Axe").transform.position;
        
        if (Vector3.Distance(axePos, p.transform.position) > 10)
        {
            p.State["nearAxe"] = false;
        }
        else
        {
            p.State["nearAxe"] = true;
            p.DataContainer["axePosition"] = axePos;
        }
    }
}
