using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEncounter : MonoBehaviour
{
    public const int MinChance = 0;
    public const int MaxChance = 100;
    public const int HitChance = 50;
    public const int GetHitChance = 50;
    
    public Dictionary<string, List<LimbEffects>> limbs { get; set; }
    public List<MindEffects> activeEffects { get; set; }
    public PlayerEncounter enemy { get; set; }
    
    
    // Start is called before the first frame update
    private void Start()
    {
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

    public void TakeDamage()
    {
        var randomVal = Random.Range(MinChance, MaxChance + 1);

        if (randomVal >= HitChance)
        {
            if (activeEffects.Contains(MindEffects.Unconscious))
            {
                Die();
            }
            else
            {
                activeEffects.Add(MindEffects.Unconscious);
            }
        }
    }
    
    private void Attack()
    {
        var randomVal = Random.Range(MinChance, MaxChance + 1);

        if (randomVal >= GetHitChance)
        {
            enemy.TakeDamage();
        }
    }

    private void Talk()
    {
        
    }

    private void Die()
    {
        
    }
    
}
