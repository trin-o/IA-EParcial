using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class EnemyBaseBehaviour : MonoBehaviour
{
    public TextMeshPro Text;
    public int Health = 100;
    public int GainAmount = 1;
    public float GainCoolDown = 0.1f;
    void Start()
    {
        UpdateText();
        StartCoroutine(GainHP());
    }
    IEnumerator GainHP()
    {
        while (true)
        {
            yield return new WaitForSeconds(GainCoolDown);
            Health += GainAmount;
            if (Health > 100) Health = 100;
            UpdateText();
        }
    }
    public void Damage(NPCBehaviour npc)
    {
        if (Health > 0)
        {
            Health -= 5;
            npc.Energy -= 10;
        }
        UpdateText();
    }

    void UpdateText()
    {
        Health = Mathf.Clamp(Health, 0, 100);
        Text.text = "[A] BASE ENEMIGA" + "\n" + "Vida: " + Health + '%';
    }
}
