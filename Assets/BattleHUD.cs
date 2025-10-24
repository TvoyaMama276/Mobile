using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{
    public Text nameText;
    public Text currentHP;
    public Text currentMP;
    public Slider hpSlider;
    public Slider mpSlider;
    public void SetHUD(Unit unit)
    {
        nameText.text = unit.unitName;
        hpSlider.maxValue = unit.maxHP;
        hpSlider.value = unit.currentHP;
        currentHP.text = unit.currentHP.ToString();
        mpSlider.maxValue = unit.maxMP;
        mpSlider.value = unit.currentMP;
        currentMP.text = unit.currentMP.ToString();
    }

    public void SetHP(int hp)
    {
        hpSlider.value = hp;
        currentHP.text = hp.ToString();
    }
    public void SetMP(int mp)
    {
        mpSlider.value = mp;
        currentMP.text = mp.ToString();
    }
}
