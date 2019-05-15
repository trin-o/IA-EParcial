using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentSpawner : MonoBehaviour
{
    public GameObject AgentPrefab;
    public Bounds Boundaries;
    public float Radius;

    public void AddAgentInBoundaries()
    {
        Vector3 rPos = new Vector3(
            Random.Range(
                -Boundaries.extents.x + Boundaries.center.x,
                 Boundaries.extents.x + Boundaries.center.x),
            Random.Range(
                -Boundaries.extents.y + Boundaries.center.y,
                 Boundaries.extents.y + Boundaries.center.y),
            Random.Range(
                -Boundaries.extents.z + Boundaries.center.z,
                 Boundaries.extents.z + Boundaries.center.z)
        );
        GameObject a = Instantiate(AgentPrefab, rPos, Quaternion.identity, transform);
    }

    public void AddAgentInSphere()
    {
        Vector3 rPos = Random.insideUnitSphere * Radius;
        GameObject a = Instantiate(AgentPrefab, rPos, Quaternion.identity, transform);
    }

    public void AddAgentInCircle()
    {
        Vector3 rPos = Random.insideUnitCircle * Radius;
        GameObject a = Instantiate(AgentPrefab, rPos, Quaternion.identity, transform);
    }
}
