using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu]
public class Goal : ScriptableObject
{
    public int Priority = 10;
    public List<Action> CurrentPlan;
    [SerializeField] private string[] goalCompleteConditions;

    private Planner p;
    private Action currentAction;

    public void Init(Planner p)
    {
        this.p = p;
    }

    public void OnUpdate()
    {
        if (CurrentPlan == null)
            return;

        foreach(Action a in CurrentPlan)
        {
            a.OnUpdate();
        }
    }

    public List<Action> FindBestPlan()
    {
        List<Action> openList = new List<Action>();

        foreach(Action a in p.MyActions)
        {
            if (a.Effects.Intersect(goalCompleteConditions).Any())
            {
                openList.Add(a);
            }
        }

        List<List<Action>> Plans = new List<List<Action>>();
        while (openList.Count > 0)
        {   
            Action current = openList[0];
            List<Action> Plan = new List<Action>();
            Plan.Add(current);

            bool finishedPlan = false;
            while (!finishedPlan)
            {
                foreach (Action a in p.MyActions)
                {

                    if (current.Preconditions.Intersect(a.Effects).Any())
                    {
                        openList.Remove(current);
                        current = a;
                        openList.Add(current);
                        Plan.Add(a);
                        break;
                    }
                    else
                    {
                        openList.Remove(current);
                    }

                    if (a == p.MyActions.Last())
                        finishedPlan = true;
                }
            }

            Plan.Reverse();

            bool canAdd = true;

            if (canAdd)
                Plans.Add(Plan);
        }

        Plans = Plans.OrderBy(o => o.Sum(item => item.Cost)).ToList();

        foreach (List<Action> p in Plans)
        {
            //foreach(Action a in p)
            //{
            //    Debug.Log(a);
                
            //}
            //Debug.Log("------");
            if (p[0].PreconditionCheck())
            {
                return p;
            }
            continue;
        }
        return new List<Action>();
    }
}
