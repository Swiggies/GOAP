using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Planner : MonoBehaviour
{
    [SerializeField] private float timeToUpdate = 0.1f;
    public Goal[] MyGoals;
    public Action[] MyActions;
    public Sensor[] MySensors;


    public float Thirst = 100;
    public Dictionary<string, object> DataContainer = new Dictionary<string, object>();
    public Dictionary<string, bool> State = new Dictionary<string, bool>();

    private float timer;
    public NavMeshAgent Agent;


    private void Start()
    { 

        for (int i = 0; i < MySensors.Length; i++)
        {
            MySensors[i] = Instantiate(MySensors[i]);
            MySensors[i].Init(this);
            MySensors[i].OnUpdate();
        }

        foreach (Action a in MyActions)
        {
            a.Init(this);
        }

        foreach (Goal g in MyGoals)
        {
            g.Init(this);
            g.CurrentPlan = g.FindBestPlan();
        }
    }

    // Update is called once per frame
    void Update()
    {
        Thirst -= Time.deltaTime;

        if (timeToUpdate <= 0)
            return;

        timer += Time.deltaTime;
        if (timer >= timeToUpdate)
        { 
            foreach (Sensor s in MySensors)
            {
                s.OnUpdate();
            }

            foreach(Goal g in MyGoals)
            {
                g.CurrentPlan = g.FindBestPlan();
                g.OnUpdate();
            }

            timer = 0;
        }
    }

    public void ChangeState(string stateName, bool state)
    {
        State[stateName] = state;

        foreach (Goal g in MyGoals)
        {
            g.CurrentPlan = g.FindBestPlan();
        }
    }

    private void OnGUI()
    {
        if (GUILayout.Button("Quit"))
        {
            Application.Quit();
        }
        GUILayout.Width(200);
        GUILayout.Space(Screen.height / 2);
        GUILayout.Label("Thirst: " + Thirst.ToString("f1"));
        GUILayout.Label("Update Rate: " + timeToUpdate.ToString("f1"));
        timeToUpdate = GUILayout.HorizontalSlider(timeToUpdate, 0.1f, 5);
        GUILayout.Label("Current Plans:");

        foreach (Goal g in MyGoals)
        {
            foreach(Action a in g.CurrentPlan)
            {
                GUILayout.Label(a.name);
            }
        }
    }
}
