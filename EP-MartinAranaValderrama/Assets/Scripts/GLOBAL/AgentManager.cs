using System.Collections.Generic;
using UnityEngine;
using AI;

public class AgentManager : MonoBehaviour
{
    static public AgentManager AM;
    public int SelectedNPC = 0;
    public NPCBehaviour currentNPC = null;
    public NPCState SelectedState = NPCState.Hold;

    public Place Base;
    public Place EnemyBase;
    public Place Minerals;

    public Material NormalMat;
    public Material SelectedMat;

    public List<BaseAgent> Agents = new List<BaseAgent>();
    float cc;

    void Awake()
    {
        AM = this;
    }
    void Start()
    {
        CheckChildren();
    }

    void Update()
    {
        GetNPC();
        GetAction();
    }

    void CheckChildren()
    {
        cc = transform.childCount;
        Agents = new List<BaseAgent>();
        for (int i = 0; i < cc; i++)
        {
            Agents.Add(transform.GetChild(i).GetComponent<BaseAgent>());
        }
        Debug.Log(Agents.Count);
    }

    void GetNPC()
    {
        if (Input.GetKeyDown(KeyCode.Keypad1)) SelectedNPC = 1;
        else
                if (Input.GetKeyDown(KeyCode.Keypad2)) SelectedNPC = 2;
        else
                if (Input.GetKeyDown(KeyCode.Keypad3)) SelectedNPC = 3;
        else
                if (Input.GetKeyDown(KeyCode.Keypad4)) SelectedNPC = 4;
        else
            return;

        if (currentNPC)
        {
            currentNPC.rend.sharedMaterial = NormalMat;
        }

        for (int i = 0; i < Agents.Count; i++)
        {
            NPCBehaviour npc = Agents[i].GetComponent<NPCBehaviour>();
            if (npc)
            {
                if (npc.ID == SelectedNPC)
                {
                    currentNPC = npc;
                    npc.rend.sharedMaterial = SelectedMat;
                    return;
                }
            }
        }
    }

    void GetAction()
    {
        if (Input.GetKeyDown(KeyCode.R)) SelectedState = NPCState.Gather;
        else
                if (Input.GetKeyDown(KeyCode.A)) SelectedState = NPCState.Attack;
        else
                if (Input.GetKeyDown(KeyCode.B)) SelectedState = NPCState.Rest;
        else
            return;

        if (currentNPC)
        {
            currentNPC.State = SelectedState;
        }
    }

}

[System.Serializable]
public class Place
{
    public Transform transform;
    public float radius;
}