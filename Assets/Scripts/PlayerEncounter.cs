using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LimbEffects
{
    Crippled,
    Cut,
    DeepCut,
    Burned,
    Numb
}

public enum MindEffects
{
    Dazed,
    Unconscious,
    Drunk,
    Shocked
}

public class PlayerEncounter : MonoBehaviour
{
    public GameObject[] encounterUI;
    
    public const int MinChance = 0;
    public const int MaxChance = 100;
    public const int HitChance = 50;
    public Dictionary<string, List<LimbEffects>> limbs { get; set; }
    public List<MindEffects> activeEffects { get; set; }
    public EnemyEncounter enemy { get; set; }
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        //git test
        foreach (var encounterUIElement in encounterUI)
        {
            encounterUIElement.SetActive(true);
        }

        limbs = new Dictionary<string, List<LimbEffects>>();
        activeEffects = new List<MindEffects>();

        limbs["Head"] = null;
        limbs["Torso"] = null;
        limbs["LeftLeg"] = null;
        limbs["RightLeg"] = null;
        limbs["LeftArm"] = null;
        limbs["RightArm"] = null;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Attack()
    {
        var randomVal = Random.Range(MinChance, MaxChance + 1);

        if (randomVal >= HitChance)
        {
            enemy.TakeDamage();
        }
    }

    public void Talk()
    {
        
    }

    public void TakeDamage()
    {
        
    }
}
