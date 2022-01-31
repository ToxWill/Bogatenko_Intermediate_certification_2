using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ArcherTower : Tower
{
    [SerializeField] GameObject arrowPrefab;
    [SerializeField] Transform arrowSpawnPoint;

    public override void Start()
    {
        base.Start();
        StartCoroutine(Attack());
    }

    public override void Update()
    {
        base.Update();
    }

    IEnumerator Attack() 
    {
        while (true) 
        {
            if (enemiesInRange.Count != 0) 
            {
                
                if (enemiesInRange[0] != null) 
                {
                    attackTarget = enemiesInRange[0];
                    yield return new WaitForSeconds(1.4f);
                    GameObject spawnedArrow = Instantiate(arrowPrefab, arrowSpawnPoint);
                    spawnedArrow.GetComponent<Arrow>().SetTarget(attackTarget);

                    try 
                    {
                        if (attackTarget != null) 
                        {

                            if (attackTarget.GetComponent<Health>().WillDieFromDamage(25)) 
                            {
                                enemiesInRange.Remove(attackTarget);
                                //attackTarget.GetComponent<Health>().ChangeHP(-25);
                            }
                            else 
                            {
                                //attackTarget.GetComponent<Health>().ChangeHP(-25);
                            }
                        }
                        else
                        {
                            Destroy(spawnedArrow);
                            enemiesInRange.Remove(attackTarget);
                        }
                    }
                    catch (Exception e) 
                    {
                        print(e.Message);
                    }
                }
            }
            else 
            {
                anim.SetBool("Attacking", false);
                yield return new WaitUntil(() => enemiesInRange.Count > 0);
            }
        }
    }    
}
