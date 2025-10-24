using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSystem2 : Spells
{
    private void ChangeBattleState()
    {
        if (royal == true)
        {
            AntiRoyalOrder();
            royal = false;
        }
        if (state == BattleState.PLAYER1TURN && counter == 5)
        {
            state = BattleState.PLAYER2TURN;
            counter = 0;
            for (int i = 0; i < 5; i++)
                icon[i].sprite = sprite[3];
            arrowRotation.localScale = new Vector3(-1, 1, 1);
        }
        else if (state == BattleState.PLAYER2TURN && counter == 5)
        {
            state = BattleState.RESULT;
            counter = 0;
            for (int i = 0; i < 5; i++)
                icon[i].sprite = sprite[3];
            arrowRotation.localScale = new Vector3(1, 1, 1);
            CalculateResult();
        }
    }
    private void GameEnded(int whowon)
    {
        gameOverScreen.SetActive(true);
        if (whowon == 0)
            gameOverText.text = "ÏÎÁÅÄÈËÀ ÀÑÒÀÐÈß";
        else gameOverText.text = "ÏÎÁÅÄÈË ËÅÎÍ";
    }
    private void CalculateResult()
    {
        Vicious();
        Sadist();
        Dodge();
        WillToWin();
        for (int i = 0; i < 5; i++)
        {
            combo1 = 0;
            combo2 = 0;
            switch (player1attackType[i])
            {
                case AttackType.LIGHT:
                    {
                        switch (player2attackType[i])
                        {
                            case AttackType.LIGHT:
                                {
                                    combo1 = 0;
                                    combo2 = 0;
                                    break;
                                }
                            case AttackType.STRONG:
                                {
                                    player2Unit.currentHP -= player1Unit.damagelight;
                                    player2HUD.SetHP(player2Unit.currentHP);
                                    combo1++;
                                    combo2 = 0;
                                    break;
                                }
                            case AttackType.PARRY:
                                {
                                    player1Unit.currentHP -= player2Unit.damageparry;
                                    player1HUD.SetHP(player1Unit.currentHP);
                                    combo2++;
                                    combo1 = 0;
                                    break;
                                }
                            case AttackType.SPELL:
                                {
                                    switch (abillity2[i])
                                    {
                                        case 1:
                                            {
                                                Poisoning();
                                                player2Unit.currentHP -= player1Unit.damagelight;
                                                player2HUD.SetHP(player2Unit.currentHP);
                                                combo2 = 0;
                                                combo1++;
                                                break;
                                            }
                                        case 2:
                                            {
                                                ThrowKnife();
                                                combo2 = 0;
                                                combo1 = 0;
                                                break;
                                            }
                                        case 3:
                                            {
                                                Stubbornness();
                                                player2Unit.currentHP -= player1Unit.damagelight;
                                                player2HUD.SetHP(player2Unit.currentHP);
                                                combo2 = 0;
                                                combo1++;
                                                break;
                                            }
                                        case 4:
                                            {
                                                Hallucinogen();
                                                player2Unit.currentHP -= player1Unit.damagelight;
                                                player2HUD.SetHP(player2Unit.currentHP);
                                                combo2 = 0;
                                                combo1++;
                                                break;
                                            }
                                    }
                                    break;
                                }
                            case AttackType.ULTIMATE:
                                {
                                    Explosion();
                                    combo2 = 0;
                                    combo1 = 0;
                                    break;
                                }
                        }
                        break;
                    }
                case AttackType.STRONG:
                    {
                        switch (player2attackType[i])
                        {
                            case AttackType.LIGHT:
                                {
                                    player1Unit.currentHP -= player2Unit.damagelight;
                                    player1HUD.SetHP(player1Unit.currentHP);
                                    combo2++;
                                    combo1 = 0;
                                    break;
                                }
                            case AttackType.STRONG:
                                {
                                    player1Unit.currentHP -= (player2Unit.damagestrong / 2);
                                    player1HUD.SetHP(player1Unit.currentHP);
                                    player2Unit.currentHP -= (player1Unit.damagestrong / 2);
                                    player2HUD.SetHP(player2Unit.currentHP);
                                    combo1 = 0;
                                    combo2 = 0;
                                    break;
                                }
                            case AttackType.PARRY:
                                {
                                    player2Unit.currentHP -= player1Unit.damagestrong;
                                    player2HUD.SetHP(player2Unit.currentHP);
                                    combo1++;
                                    combo2 = 0;
                                    break;
                                }
                            case AttackType.SPELL:
                                {
                                    switch (abillity2[i])
                                    {
                                        case 1:
                                            {
                                                Poisoning();
                                                player2Unit.currentHP -= player1Unit.damagestrong;
                                                player2HUD.SetHP(player2Unit.currentHP);
                                                combo2 = 0;
                                                combo1++;
                                                break;
                                            }
                                        case 2:
                                            {
                                                ThrowKnife();
                                                combo2 = 0;
                                                combo1 = 0;
                                                break;
                                            }
                                        case 3:
                                            {
                                                Stubbornness();
                                                player2Unit.currentHP -= player1Unit.damagestrong;
                                                player2HUD.SetHP(player2Unit.currentHP);
                                                combo2 = 0;
                                                combo1++;
                                                break;
                                            }
                                        case 4:
                                            {
                                                Hallucinogen();
                                                player2Unit.currentHP -= player1Unit.damagestrong;
                                                player2HUD.SetHP(player2Unit.currentHP);
                                                combo2 = 0;
                                                combo1++;
                                                break;
                                            }
                                    }
                                    break;
                                }
                            case AttackType.ULTIMATE:
                                {
                                    Explosion();
                                    combo2 = 0;
                                    combo1 = 0;
                                    break;
                                }
                        }
                        break;
                    }
                case AttackType.PARRY:
                    {
                        switch (player2attackType[i])
                        {
                            case AttackType.LIGHT:
                                {
                                    player2Unit.currentHP -= player1Unit.damageparry;
                                    player2HUD.SetHP(player2Unit.currentHP);
                                    combo1++;
                                    combo2 = 0;
                                    break;
                                }
                            case AttackType.STRONG:
                                {
                                    player1Unit.currentHP -= player2Unit.damagestrong;
                                    player1HUD.SetHP(player1Unit.currentHP);
                                    combo1 = 0;
                                    combo2++;
                                    break;
                                }
                            case AttackType.PARRY:
                                {
                                    combo1 = 0;
                                    combo2 = 0;
                                    break;
                                }
                            case AttackType.SPELL:
                                {
                                    switch (abillity2[i])
                                    {
                                        case 1:
                                            {
                                                damage = player1Unit.currentHP;
                                                Poisoning();
                                                damage -= player1Unit.currentHP;
                                                player1Unit.currentHP += damage / 2;
                                                player1HUD.SetHP(player1Unit.currentHP);
                                                combo2 = 0;
                                                combo1 = 0;
                                                break;
                                            }
                                        case 2:
                                            {
                                                damage = player1Unit.currentHP;
                                                ThrowKnife();
                                                damage -= player1Unit.currentHP;
                                                player1Unit.currentHP += damage / 2;
                                                player1HUD.SetHP(player1Unit.currentHP);
                                                combo2 = 0;
                                                combo1 = 0;
                                                break;
                                            }
                                        case 3:
                                            {
                                                Stubbornness();
                                                combo2 = 0;
                                                combo1 = 0;
                                                break;
                                            }
                                        case 4:
                                            {
                                                damage = player1Unit.currentHP;
                                                Hallucinogen();
                                                damage -= player1Unit.currentHP;
                                                player1Unit.currentHP += damage / 2;
                                                player1HUD.SetHP(player1Unit.currentHP);
                                                combo2 = 0;
                                                combo1 = 0;
                                                break;
                                            }
                                    }
                                    break;
                                }
                            case AttackType.ULTIMATE:
                                {
                                    Explosion();
                                    combo2 = 0;
                                    combo1 = 0;
                                    break;
                                }
                        }
                        break;
                    }
                case AttackType.SPELL:
                    {
                        switch (player2attackType[i])
                        {
                            case AttackType.LIGHT:
                                {
                                    switch (abillity1[i])
                                    {
                                        case 1:
                                            {
                                                HiddenDagger();
                                                player1Unit.currentHP -= player2Unit.damagelight;
                                                player1HUD.SetHP(player1Unit.currentHP);
                                                combo1 = 0;
                                                combo2++;
                                                break;
                                            }
                                        case 2:
                                            {
                                                Heal();
                                                player1Unit.currentHP -= player2Unit.damagelight;
                                                player1HUD.SetHP(player1Unit.currentHP);
                                                combo1 = 0;
                                                combo2++;
                                                break;
                                            }
                                        case 3:
                                            {
                                                RoyalLight();
                                                combo2 = 0;
                                                combo1 = 0;
                                                break;
                                            }
                                        case 4:
                                            {
                                                player1Unit.currentHP -= player2Unit.damagelight;
                                                player1HUD.SetHP(player1Unit.currentHP);
                                                combo2++;
                                                combo1 = 0;
                                                break;
                                            }
                                    }
                                    break;
                                }
                            case AttackType.STRONG:
                                {
                                    switch (abillity1[i])
                                    {
                                        case 1:
                                            {
                                                HiddenDagger();
                                                player1Unit.currentHP -= player2Unit.damagestrong;
                                                player1HUD.SetHP(player1Unit.currentHP);
                                                combo1 = 0;
                                                combo2++;
                                                break;
                                            }
                                        case 2:
                                            {
                                                Heal();
                                                player1Unit.currentHP -= player2Unit.damagestrong;
                                                player1HUD.SetHP(player1Unit.currentHP);
                                                combo1 = 0;
                                                combo2++;
                                                break;
                                            }
                                        case 3:
                                            {
                                                RoyalLight();
                                                combo2 = 0;
                                                combo1 = 0;
                                                break;
                                            }
                                        case 4:
                                            {
                                                RoyalPunishment();
                                                combo2 = 0;
                                                combo1 = 0;
                                                break;
                                            }
                                    }
                                    break;
                                }
                            case AttackType.PARRY:
                                {
                                    switch (abillity1[i])
                                    {
                                        case 1:
                                            {
                                                HiddenDagger();
                                                combo1 = 0;
                                                combo2 = 0;
                                                break;
                                            }
                                        case 2:
                                            {
                                                Heal();
                                                combo1 = 0;
                                                combo2 = 0;
                                                break;
                                            }
                                        case 3:
                                            {
                                                combo2 = 0;
                                                combo1 = 0;
                                                break;
                                            }
                                        case 4:
                                            {
                                                RoyalPunishment();
                                                combo2 = 0;
                                                combo1 = 0;
                                                break;
                                            }
                                    }
                                    break;
                                }
                            case AttackType.SPELL:
                                {
                                    switch (abillity1[i])
                                    {
                                        case 1:
                                            {
                                                switch (abillity2[i])
                                                {
                                                    case 1:
                                                        {
                                                            Poisoning();
                                                            HiddenDagger();
                                                            combo2 = 0;
                                                            combo1 = 0;
                                                            break;
                                                        }
                                                    case 2:
                                                        {
                                                            ThrowKnife();
                                                            combo2 = 0;
                                                            combo1 = 0;
                                                            break;
                                                        }
                                                    case 3:
                                                        {
                                                            Stubbornness();
                                                            HiddenDagger();
                                                            combo2 = 0;
                                                            combo1 = 0;
                                                            break;
                                                        }
                                                    case 4:
                                                        {
                                                            Hallucinogen();
                                                            HiddenDagger();
                                                            combo2 = 0;
                                                            combo1 = 0;
                                                            break;
                                                        }
                                                }
                                                break;
                                            }
                                        case 2:
                                            {
                                                switch (abillity2[i])
                                                {
                                                    case 1:
                                                        {
                                                            Poisoning();
                                                            Heal();
                                                            combo2 = 0;
                                                            combo1 = 0;
                                                            break;
                                                        }
                                                    case 2:
                                                        {
                                                            ThrowKnife();
                                                            combo2 = 0;
                                                            combo1 = 0;
                                                            break;
                                                        }
                                                    case 3:
                                                        {
                                                            Stubbornness();
                                                            Heal();
                                                            combo2 = 0;
                                                            combo1 = 0;
                                                            break;
                                                        }
                                                    case 4:
                                                        {
                                                            Hallucinogen();
                                                            Heal();
                                                            combo2 = 0;
                                                            combo1 = 0;
                                                            break;
                                                        }
                                                }
                                                break;
                                            }
                                        case 3:
                                            {
                                                switch (abillity2[i])
                                                {
                                                    case 1:
                                                        {
                                                            Poisoning();
                                                            RoyalLight();
                                                            combo2 = 0;
                                                            combo1 = 0;
                                                            break;
                                                        }
                                                    case 2:
                                                        {
                                                            ThrowKnife();
                                                            combo2 = 0;
                                                            combo1 = 0;
                                                            break;
                                                        }
                                                    case 3:
                                                        {
                                                            Stubbornness();
                                                            RoyalLight();
                                                            combo2 = 0;
                                                            combo1 = 0;
                                                            break;
                                                        }
                                                    case 4:
                                                        {
                                                            Hallucinogen();
                                                            combo2 = 0;
                                                            combo1 = 0;
                                                            break;
                                                        }
                                                }
                                                break;
                                            }
                                        case 4:
                                            {
                                                switch (abillity2[i])
                                                {
                                                    case 1:
                                                        {
                                                            Poisoning();
                                                            RoyalPunishment();
                                                            combo2 = 0;
                                                            combo1 = 0;
                                                            break;
                                                        }
                                                    case 2:
                                                        {
                                                            ThrowKnife();
                                                            combo2 = 0;
                                                            combo1 = 0;
                                                            break;
                                                        }
                                                    case 3:
                                                        {
                                                            Stubbornness();
                                                            RoyalPunishment();
                                                            combo2 = 0;
                                                            combo1 = 0;
                                                            break;
                                                        }
                                                    case 4:
                                                        {
                                                            Hallucinogen();
                                                            RoyalPunishment();
                                                            combo2 = 0;
                                                            combo1 = 0;
                                                            break;
                                                        }
                                                }
                                                break;
                                            }
                                            break;
                                    }
                                    break;
                                }
                            case AttackType.ULTIMATE:
                                {
                                    Explosion();
                                    combo2 = 0;
                                    combo1 = 0;
                                    break;
                                }
                        }
                        break;
                    }
                case AttackType.ULTIMATE:
                    {
                        switch (player2attackType[i])
                        {
                            case AttackType.LIGHT:
                                {
                                    combo1 = 0;
                                    combo2 = 0;
                                    break;
                                }
                            case AttackType.STRONG:
                                {
                                    combo1 = 0;
                                    combo2 = 0;
                                    break;
                                }
                            case AttackType.PARRY:
                                {
                                    combo1 = 0;
                                    combo2 = 0;
                                    break;
                                }
                            case AttackType.SPELL:
                                {
                                    combo1 = 0;
                                    combo2 = 0;
                                    break;
                                }
                            case AttackType.ULTIMATE:
                                {
                                    combo1 = 0;
                                    combo2 = 0;
                                    Explosion();
                                    break;
                                }
                        }
                    }
                    break;
            }
            if (combo1 == 3)
            {
                player2Unit.currentHP -= player1Unit.extra;
                player2HUD.SetHP(player2Unit.currentHP);
            }
            if (combo2 == 3)
            {
                player1Unit.currentHP -= player2Unit.extra;
                player1HUD.SetHP(player1Unit.currentHP);
            }
            Antivicious();
            Antidodge();
        }
        Normal();
        player1Unit.currentHP -= poison * 35;
        player1HUD.SetHP(player1Unit.currentHP);
        poison = poison - 2;
        if (poison < 0)
            poison = 0;
        if ((player1Unit.currentHP <= 0) && (resurection == 1))
        {
            player2Unit.currentHP = player2Unit.maxHP * 3 / 20;
            player2HUD.SetHP(player2Unit.currentHP);
            resurection = 0;
        }
        if (player2Unit.currentHP <= 0)
        {
            state = BattleState.WON;
            GameEnded(0);
        }
        else if (player1Unit.currentHP <= 0)
        {
            state = BattleState.LOST;
            GameEnded(1);
        }
        else state = BattleState.PLAYER1TURN;
        roundCount++;
        ShowRound();
    }
    private void Normal()
    {
        player1Unit.damagelight = player1Unit.originaldamagelight;
        player1Unit.damagestrong = player1Unit.originaldamagestrong;
        player1Unit.damageparry = player1Unit.originaldamageparry;
        player1Unit.extra = player1Unit.originalextra;
        player2Unit.damagelight = player2Unit.originaldamagelight;
        player2Unit.damagestrong = player2Unit.originaldamagestrong;
        player2Unit.damageparry = player2Unit.originaldamageparry;
        player2Unit.extra = player2Unit.originalextra;
    }
    private void Start()
    {
        state = BattleState.START;
        SetupBattle();
        ShowRound();
    }
    private void SetupBattle() 
    {
        GameObject player1GO = Instantiate(player1Prefab, player1BattleStation);
        player1Unit = player1GO.GetComponent<Unit>();

        GameObject player2GO = Instantiate(player2Prefab, player2BattleStation);
        player2Unit = player2GO.GetComponent<Unit>();

        player1HUD.SetHUD(player1Unit);
        player2HUD.SetHUD(player2Unit);

        state = BattleState.PLAYER1TURN;
    }
    private void ShowRound()
    {
        switch (roundCount)
        {
            case 1:
                roundText.text = "I";
                break;
            case 2:
                roundText.text = "II";
                break;
            case 3:
                roundText.text = "III";
                break;
            case 4:
                roundText.text = "IV";
                break;
            case 5:
                roundText.text = "V";
                break;
            case 6:
                roundText.text = "VI";
                break;
            case 7:
                roundText.text = "VII";
                break;
            case 8:
                roundText.text = "VII";
                break;
            case 9:
                roundText.text = "IX";
                break;
            case 10:
                roundText.text = "X";
                break;
        }
    }
}
