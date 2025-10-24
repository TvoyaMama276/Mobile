using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spells : Actions
{
    //Способности Астарии
    public void HiddenDagger()
    {
        player1Unit.damagelight += 50;
        player1Unit.damagestrong += 50;
        player1Unit.damageparry += 50;
        player1Unit.extra += 50;
        player1Unit.currentMP -= 2;
        player1HUD.SetMP(player1Unit.currentMP);
    }
    public void Heal()
    {
        player1Unit.currentHP += 250;
        player1HUD.SetHP(player1Unit.currentHP);
        player1Unit.currentMP -= 2;
        player1HUD.SetMP(player1Unit.currentMP);
    }
    public void RoyalLight()
    {
        player2Unit.currentHP -= player1Unit.damageparry * 3 / 2;
        player2HUD.SetHP(player2Unit.currentHP);
        player1Unit.currentMP -= 3;
        player1HUD.SetMP(player1Unit.currentMP);
    }
    public void RoyalPunishment()
    {
        player2Unit.currentHP -= player1Unit.damagestrong * 3;
        player2HUD.SetHP(player2Unit.currentHP);
        player1Unit.currentMP -= 3;
        player1HUD.SetMP(player1Unit.currentMP);
    }
    public void Vicious()
    {
        chance = Random.Range(1, 10);
        if (chance == 1)
        {
            player1Unit.damagelight *= 2;
            player1Unit.damagestrong *= 2;
            player1Unit.damageparry *= 2;
            player1Unit.extra *= 2;
        }
    }
    public void Antivicious()
    {
        if (chance == 1)
        {
            player1Unit.damagelight /= 2;
            player1Unit.damagestrong /= 2;
            player1Unit.damageparry /= 2;
            player1Unit.extra /= 2;
        }
    }
    public void Sadist()
    {
        player1Unit.damagelight = player1Unit.damagelight + (((player2Unit.maxHP - player2Unit.currentHP) * 2 * player1Unit.damagelight) / (5 * player2Unit.maxHP));
        player1Unit.damagestrong = player1Unit.damagestrong + (((player2Unit.maxHP - player2Unit.currentHP) * 2 * player1Unit.damagestrong) / (5 * player2Unit.maxHP));
        player1Unit.damageparry = player1Unit.damageparry + (((player2Unit.maxHP - player2Unit.currentHP) * 2 * player1Unit.damageparry) / (5 * player2Unit.maxHP));
        player1Unit.extra = player1Unit.extra + (((player2Unit.maxHP - player2Unit.currentHP) * 2 * player1Unit.extra) / (5 * player2Unit.maxHP));
    }
    //Способности Леона
    public void Poisoning()
    {
        trigger++;
        player2Unit.currentMP -= 2;
        player2HUD.SetMP(player2Unit.currentMP);
    }
    public void ThrowKnife()
    {
        player1Unit.currentHP -= 75;
        player1HUD.SetHP(player1Unit.currentHP);
        poison++;
        player2Unit.currentMP -= 2;
        player2HUD.SetMP(player2Unit.currentMP);
    }
    public void Stubbornness()
    {
        resurection = 1;
        player2Unit.currentMP -= 3;
        player2HUD.SetMP(player2Unit.currentMP);
    }
    public void Hallucinogen()
    {
        player1Unit.currentHP -= 125;
        player1HUD.SetHP(player1Unit.currentHP);
        int trip = Random.Range(1, 3);
        switch (trip)
        {
            case 1:
                player1attackType[counter + 1] = AttackType.LIGHT;
                break;
            case 2:
                player1attackType[counter + 1] = AttackType.STRONG;
                break;
            case 3:
                player1attackType[counter + 1] = AttackType.PARRY;
                break;
        }
        player2Unit.currentMP -= 3;
        player2HUD.SetMP(player2Unit.currentMP);
    }
    public void Dodge()
    {
        agility = Random.Range(1, 10);
        if (agility == 1)
        {
            player1Unit.currentdamagelight = player1Unit.damagelight;
            player1Unit.currentdamagestrong = player1Unit.damagestrong;
            player1Unit.currentdamageparry = player1Unit.damageparry;
            player1Unit.damagelight = 0;
            player1Unit.damagestrong = 0;
            player1Unit.damageparry = 0;
        }
    }
    public void Antidodge()
    {
        if (agility == 1)
        {
            player1Unit.damagelight = player1Unit.currentdamagelight;
            player1Unit.damagestrong = player1Unit.currentdamagestrong;
            player1Unit.damageparry = player1Unit.currentdamageparry;
            combo1 = 0;
        }
    }
    public void WillToWin()
    {
        player2Unit.damagelight = player2Unit.damagelight + (((player2Unit.maxHP - player2Unit.currentHP) * 3 * player2Unit.damagelight) / (5 * player2Unit.maxHP));
        player2Unit.damagestrong = player2Unit.damagestrong + (((player2Unit.maxHP - player2Unit.currentHP) * 3 * player2Unit.damagestrong) / (5 * player2Unit.maxHP));
        player2Unit.damageparry = player2Unit.damageparry + (((player2Unit.maxHP - player2Unit.currentHP) * 3 * player2Unit.damageparry) / (5 * player2Unit.maxHP));
        player2Unit.extra = player2Unit.extra + (((player2Unit.maxHP - player2Unit.currentHP) * 3 * player2Unit.extra) / (5 * player2Unit.maxHP));
    }
    public void Explosion()
    {
        player1Unit.currentHP -= 100 * poison;
        poison = 0;
    }
}
