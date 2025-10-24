using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState { START, PLAYER1TURN, PLAYER2TURN, RESULT, WON, LOST }
public abstract class BattleSystem : MonoBehaviour
{
    public int roundCount = 1;
    public Text roundText;
    public GameObject player1Prefab;
    public GameObject player2Prefab;
    public GameObject lightattack;
    public GameObject heavyattack;
    public GameObject parry;
    public Transform player1BattleStation;
    public Transform player2BattleStation;
    public Unit player1Unit;
    public Unit player2Unit;
    public BattleHUD player1HUD;
    public BattleHUD player2HUD;
    public Transform arrowRotation;
    public Image[] icon = new Image[5];
    public Sprite[] sprite = new Sprite[5];
    public int[] abillity1 = new int[5];
    public int[] abillity2 = new int[5];
    public bool royal;
    public bool Ult1 = true;
    public bool Ult2 = true;
    public int damage;
    public int resurection = 0;
    public int counter = 0;
    public int chance;
    public int order;
    public int agility;
    public int poison = 0;
    public int trigger = 0;
    public int combo1;
    public int combo2;
    public GameObject gameOverScreen;
    public Text gameOverText;
    public enum AttackType { LIGHT, STRONG, PARRY, SPELL, ULTIMATE };
    public AttackType[] player1attackType = new AttackType[5];
    public AttackType[] player2attackType = new AttackType[5];
    private bool ready;
    public static BattleState state;
}
