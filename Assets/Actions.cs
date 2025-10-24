using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actions : BattleSystem
{
    public void OnLightAttackButton()
    {
        icon[counter].sprite = sprite[0];
        if (state == BattleState.PLAYER1TURN)
        {
            player1attackType[counter] = AttackType.LIGHT;
            if (counter < 5)
                counter++;
        }
        else if (state == BattleState.PLAYER2TURN)
        {
            player2attackType[counter] = AttackType.LIGHT;
            if (counter < 5)
                counter++;
        }
        else return;
    }
    public void OnStrongAttackButton()
    {
        icon[counter].sprite = sprite[1];
        if (state == BattleState.PLAYER1TURN)
        {
            player1attackType[counter] = AttackType.STRONG;
            if (counter < 5)
                counter++;
        }
        else if (state == BattleState.PLAYER2TURN)
        {
            player2attackType[counter] = AttackType.STRONG;
            if (counter < 5)
                counter++;
        }
        else return;
    }
    public void OnParryAttackButton()
    {
        icon[counter].sprite = sprite[2];
        if (state == BattleState.PLAYER1TURN)
        {
            player1attackType[counter] = AttackType.PARRY;
            if (counter < 5)
                counter++;
        }
        else if (state == BattleState.PLAYER2TURN)
        {
            player2attackType[counter] = AttackType.PARRY;
            if (counter < 5)
                counter++;
        }
        else return;
    }
    public void OnSpell1()
    {
        icon[counter].sprite = sprite[4];
        if (state == BattleState.PLAYER1TURN)
        {
            player1attackType[counter] = AttackType.SPELL;
            abillity1[counter] = 1;
            if (counter < 5)
                counter++;
        }
        else if (state == BattleState.PLAYER2TURN)
        {
            player2attackType[counter] = AttackType.SPELL;
            abillity2[counter] = 1;
            if (counter < 5)
                counter++;
        }
        else return;
    }
    public void OnSpell2()
    {
        icon[counter].sprite = sprite[4];
        if (state == BattleState.PLAYER1TURN)
        {
            player1attackType[counter] = AttackType.SPELL;
            abillity1[counter] = 2;
            if (counter < 5)
                counter++;
        }
        else if (state == BattleState.PLAYER2TURN)
        {
            player2attackType[counter] = AttackType.SPELL;
            abillity2[counter] = 2;
            if (counter < 5)
                counter++;
        }
        else return;
    }
    public void OnSpell3()
    {
        icon[counter].sprite = sprite[4];
        if (state == BattleState.PLAYER1TURN)
        {
            player1attackType[counter] = AttackType.SPELL;
            abillity1[counter] = 3;
            if (counter < 5)
                counter++;
        }
        else if (state == BattleState.PLAYER2TURN)
        {
            player2attackType[counter] = AttackType.SPELL;
            abillity2[counter] = 3;
            if (counter < 5)
                counter++;
        }
        else return;
    }
    public void OnSpell4()
    {
        icon[counter].sprite = sprite[4];
        if (state == BattleState.PLAYER1TURN)
        {
            player1attackType[counter] = AttackType.SPELL;
            abillity1[counter] = 4;
            if (counter < 5)
                counter++;
        }
        else if (state == BattleState.PLAYER2TURN)
        {
            player2attackType[counter] = AttackType.SPELL;
            abillity2[counter] = 4;
            if (counter < 5)
                counter++;
        }
        else return;
    }
    public void OnUltimate()
    {
        if (state == BattleState.PLAYER1TURN)
        {
            if (Ult1 == true)
            {
                icon[counter].sprite = sprite[4];
                RoyalOrder();
                player1attackType[counter] = AttackType.ULTIMATE;
                if (counter < 5)
                    counter++;
                royal = true;
                Ult1 = false;
            }
            else return;
        }
        else if (state == BattleState.PLAYER2TURN)
        {
            if (Ult2 == true)
            {
                icon[counter].sprite = sprite[4];
                player2attackType[counter] = AttackType.ULTIMATE;
                if (counter < 5)
                    counter++;
                Ult2 = false;
            }
            else return;
        }
        else return;
    }
    public void RoyalOrder()
    {
        order = Random.Range(1, 3);
        switch (order)
        {
            case 1:
                {
                    lightattack.gameObject.SetActive(false);
                    break;
                }
            case 2:
                {
                    heavyattack.gameObject.SetActive(false);
                    break;
                }
            case 3:
                {
                    parry.gameObject.SetActive(false);
                    break;
                }
        }
    }
    public void AntiRoyalOrder()
    {
        switch (order)
        {
            case 1:
                {
                    lightattack.gameObject.SetActive(true);
                    player2Unit.damagelight = 0;
                    break;
                }
            case 2:
                {
                    heavyattack.gameObject.SetActive(true);
                    player2Unit.damagestrong = 0;
                    break;
                }
            case 3:
                {
                    parry.gameObject.SetActive(true);
                    player1Unit.damageparry = 0;
                    break;
                }
        }
    }
}
