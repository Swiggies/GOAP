using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "Near Chainsaw", menuName = "States/Near Chainsaw")]

public class S_NearChainsaw : Sensor
{
    public bool NearAxe;

    private Vector3 axePos;

    public override void Init(Planner p)
    {
        base.Init(p);
        p.DataContainer.Add("nearChainsaw", false);
        p.DataContainer.Add("chainsawPosition", axePos);
    }

    public override void OnUpdate()
    {
        axePos = GameObject.FindGameObjectWithTag("Chainsaw").transform.position;
        
        if (Vector3.Distance(axePos, p.transform.position) > 10)
        {
            p.State["nearChainsaw"] = false;
        }
        else
        {
            p.State["nearChainsaw"] = true;
            p.DataContainer["chainsawPosition"] = axePos;
        }
    }
}
