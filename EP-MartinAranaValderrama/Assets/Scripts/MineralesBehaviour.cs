using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class MineralesBehaviour : MonoBehaviour
{
    public TextMeshPro Text;
    public int Resources = 1000;
    public int GainAmount = 100;
    public float GainCoolDown = 2f;
    void Start()
    {
        UpdateText();
        StartCoroutine(GainResources());
    }
    IEnumerator GainResources()
    {
        while (true)
        {
            yield return new WaitForSeconds(GainCoolDown);
            Resources += GainAmount;
            UpdateText();
        }
    }
    public void Gather(NPCBehaviour npc)
    {
        if (Resources > 0)
        {
            Resources -= 10;
            npc.StoredMinerals += 10;
            npc.Energy -= 5;
        }
        else
        {
            Resources = 0;
        }
        UpdateText();
    }

    void UpdateText()
    {
        Text.text = "[R] MINERALES" + "\n" + "Peso: " + Resources + " kg";
    }
}
