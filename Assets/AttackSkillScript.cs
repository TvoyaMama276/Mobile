using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackSkillScript : MonoBehaviour
{
    private bool attackOrSpell = false;
    public GameObject attackButtons;
    public GameObject skillButtons;
    public GameObject skillButtons2;
    public Image changeb;
    public Sprite toSkill;
    public Sprite toAttack;
    // Start is called before the first frame update
    void Start()
    {
        skillButtons.SetActive(false);
        attackButtons.SetActive(true);
    }
    public void ChangeSkillAttack()
    {
        if (!attackOrSpell)
        {
            attackButtons.SetActive(false);
            if (BattleSystem.state == BattleState.PLAYER1TURN)
            {
                skillButtons.SetActive(true);
                skillButtons2.SetActive(false);
            }
            else if (BattleSystem.state == BattleState.PLAYER2TURN)
            {
                skillButtons.SetActive(false);
                skillButtons2.SetActive(true);
            }
            changeb.sprite = toAttack;
            attackOrSpell = true;
        }
        else
        {
            attackButtons.SetActive(true);
            skillButtons.SetActive(false);
            skillButtons2.SetActive(false);
            changeb.sprite = toSkill;
            attackOrSpell = false;
        }
    }
}
