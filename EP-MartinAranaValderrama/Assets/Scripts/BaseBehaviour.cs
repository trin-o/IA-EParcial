using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class BaseBehaviour : MonoBehaviour
{
    public TextMeshPro Text;
    public int Resources = 0;
    void Start()
    {
        UpdateText();
    }

    public void Give(NPCBehaviour npc)
    {
        Resources += 10;
        npc.StoredMinerals -= 10;
        UpdateText();
    }

    public void Heal(NPCBehaviour npc)
    {
        npc.Energy += 10;
    }

    void UpdateText()
    {
        Text.text = "[B] BASE" + "\n" + "Minerales: " + Resources + " kg";
    }
}
