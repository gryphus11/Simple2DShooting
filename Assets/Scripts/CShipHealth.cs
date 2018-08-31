using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CShipHealth : MonoBehaviour
{
    public int maxHp = 0;
    public int hp = 0;
    
    // Use this for initialization
    protected virtual void Start()
    {
        hp = maxHp;
    }

    public virtual int HpDown(float damage)
    {
        hp -= (int)damage;

        if (hp < 0)
            hp = 0;
        return hp;
    }

    public virtual int HpUp(float heal)
    {
        hp += (int)heal;
        if (hp > maxHp)
            hp = maxHp;
        return hp;
    }

    public virtual void DoDestroy()
    {
        Destroy(gameObject);
        
    }

    public void ManualDestroy()
    {
        GetComponent<CShipDamage>().ShowHitEffect(transform.position);
        DoDestroy();
    }

}
