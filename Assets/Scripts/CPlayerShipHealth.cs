using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CPlayerShipHealth : CShipHealth
{
    public Image hpBar = null;
    public Text remainHp = null;
    public CPlayerLifeManager lifeManager = null;
    public CPlayerGenerator playerGenerator = null;

    private void OnEnable()
    {
        hp = maxHp;
        hpBar.fillAmount = 1.0f;
    }

    private void Update()
    {
        remainHp.text = hp.ToString();
    }

    public override int HpDown(float damage)
    {
        hpBar.fillAmount -= (damage / maxHp);
        remainHp.text = base.HpDown(damage).ToString();
        return hp;
    }

    public override int HpUp(float heal)
    {
        hpBar.fillAmount += (heal / maxHp);
        remainHp.text = base.HpUp(heal).ToString();
        return hp;
    }

    public override void DoDestroy()
    {
        lifeManager.LifeDown();
        Debug.Log("플레이어 쉽 파괴");
        gameObject.SetActive(false);

        playerGenerator.InitPlayerShip();
    }

    private void OnDisable()
    {
        NewShipGenerate();
    }

    void NewShipGenerate()
    {
        
    }
}
