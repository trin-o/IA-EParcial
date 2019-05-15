using UnityEngine;
using AI;
using TMPro;

public enum NPCState
{
    Hold, Rest, Gather, Attack
}

public class NPCBehaviour : BaseAgent
{

    [Header("NPC")]
    public int ID;
    public float StoredMinerals = 0;
    public float Energy = 100;
    float CoolDown = .5f;
    float Timer = 0;
    public NPCState State = NPCState.Hold;
    public TextMeshPro Text;
    public Renderer rend;


    void Start()
    {
        Vector3 rand = Random.insideUnitSphere;
        rand.Scale(new Vector3(1, 0, 1));
        addSeek(rand * 5);
    }

    void Update()
    {
        switch (State)
        {
            case NPCState.Rest:
                addSeek(AgentManager.AM.Base.transform.position, AgentManager.AM.Base.radius);
                if (Vector3.Distance(transform.position, AgentManager.AM.Base.transform.position) < AgentManager.AM.Base.radius * 2)
                {
                    Timer += Time.deltaTime;
                    if (Timer > CoolDown)
                    {
                        if (StoredMinerals > 0)
                        {
                            Timer = 0;
                            AgentManager.AM.Base.transform.SendMessage("Give", this);
                        }
                        if (Energy < 100)
                        {
                            AgentManager.AM.Base.transform.SendMessage("Heal", this);
                        }
                    }
                }
                break;

            case NPCState.Gather:
                addSeek(AgentManager.AM.Minerals.transform.position, AgentManager.AM.Minerals.radius);
                if (Vector3.Distance(transform.position, AgentManager.AM.Minerals.transform.position) < AgentManager.AM.Minerals.radius * 2)
                {
                    Timer += Time.deltaTime;
                    if (Timer > CoolDown)
                    {
                        Timer = 0;
                        if (Energy > 0)
                            AgentManager.AM.Minerals.transform.SendMessage("Gather", this);
                    }
                }
                break;

            case NPCState.Attack:
                addSeek(AgentManager.AM.EnemyBase.transform.position, AgentManager.AM.EnemyBase.radius);
                if (Vector3.Distance(transform.position, AgentManager.AM.EnemyBase.transform.position) < AgentManager.AM.EnemyBase.radius * 2)
                {
                    Timer += Time.deltaTime;
                    if (Timer > CoolDown)
                    {
                        Timer = 0;
                        if (Energy > 0)
                            AgentManager.AM.EnemyBase.transform.SendMessage("Damage", this);
                    }
                }
                break;

            case NPCState.Hold:
                if (transform.position.magnitude > 10)
                {
                    addSeek(Vector3.zero, 1);
                }
                break;
        }


        addFlee(AgentManager.AM.Minerals.transform.position, AgentManager.AM.Minerals.radius);
        addFlee(AgentManager.AM.Base.transform.position, AgentManager.AM.Base.radius);
        addFlee(AgentManager.AM.EnemyBase.transform.position, AgentManager.AM.EnemyBase.radius);
        addSeparate(AgentManager.AM.Agents, 2, 1);
        addWander(10, 200, Mathf.PI, Mathf.PI * 2, .5f);


        transform.forward = velocity;
        UpdateText();
    }

    void UpdateText()
    {
        Text.text = "[" + ID + "]" + "\n" + "Energia: " + Energy + '%' + "\n" + "Minerales: " + StoredMinerals + " kg";
        Text.transform.forward = Camera.main.transform.forward;
    }
}
