using UnityEngine;
using AI;

public class EnemyBehaviour : BaseAgent
{

    void Start()
    {
        Vector3 rand = Random.insideUnitSphere;
        rand.Scale(new Vector3(1, 0, 1));
        addSeek(rand * 5);
    }

    void Update()
    {
        if (transform.position.magnitude > 15)
        {
            addSeek(Vector3.zero, 1);
        }

        addFlee(AgentManager.AM.Minerals.transform.position, AgentManager.AM.Minerals.radius);
        addFlee(AgentManager.AM.Base.transform.position, AgentManager.AM.Base.radius);
        addFlee(AgentManager.AM.EnemyBase.transform.position, AgentManager.AM.EnemyBase.radius);
        addSeparate(AgentManager.AM.Agents, 2, 1);
        addWander(10, 200, Mathf.PI, Mathf.PI * 2, .5f);

        transform.forward = velocity;
    }
}
