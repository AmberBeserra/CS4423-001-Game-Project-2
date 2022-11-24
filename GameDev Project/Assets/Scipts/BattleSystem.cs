using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState { START, PLAYER, ENEMY, WIN, LOSE, ATTACKED }

public class BattleSystem : MonoBehaviour
{
    //public PlayerBehavior playerUnit;
    public GameObject enemyPrefab;
    public GameObject playerPrefab;
    
    bool blocking = false;
    bool dead = false;
    
    Unit enemyUnit;
    Unit playerUnit;

    public Text playerText;
    public Text enemyText;
    public Text turnText;

    public BattleState state;
    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;
        StartCoroutine(Setup());
        //enemyUnit.EnemyisDamaged(5);
    }
    IEnumerator Setup()
    {
        GameObject playerGO = Instantiate(playerPrefab);
        playerUnit = GameObject.Find("PlayerCharacter (1)").GetComponent<Unit>();
    
        GameObject enemyGO = Instantiate(enemyPrefab);
        enemyUnit = GameObject.Find("Enemy 2").GetComponent<Unit>();
        enemyUnit.unitHP.HPMaxDec(10);
        turnText.text = "The Battle Begins";

        playerText.text = "Player " + playerUnit.unitHP.Health + "/" + playerUnit.unitHP.HealthMax;

        enemyText.text = "Evil Slime " + enemyUnit.unitHP.Health + "/" + enemyUnit.unitHP.HealthMax;

        yield return new WaitForSeconds(2f);
        
        state = BattleState.PLAYER;
        PlayerTurn();
    }
    void PlayerTurn()
    {
        turnText.text = "Player's Turn";
    }
    //handles what happens when the attack button is clicked
    IEnumerator PlayerAttack()
    {
        state = BattleState.ATTACKED;
        bool dead = enemyUnit.Damaged(5);
        enemyText.text = "Evil Slime " + enemyUnit.unitHP.Health + "/" + enemyUnit.unitHP.HealthMax;
        turnText.text = "Player Attacks!";
        yield return new WaitForSeconds(2f);

        if(dead)
        {
            state = BattleState.WIN;
            turnText.text = "Enemy has Died.";
            EndBattle();
        }
        else
        {
            //enemy turn
            state = BattleState.ENEMY;
            StartCoroutine(enemyAttack());
        }
    }
    //handles the block button
    IEnumerator PlayerBlock()
    {
        state = BattleState.ATTACKED;
        turnText.text = "Player blocks!";
        blocking = true;
        yield return new WaitForSeconds(2f);

        state = BattleState.ENEMY;
        StartCoroutine(enemyAttack());
    }


    //handles enemy attack
    IEnumerator enemyAttack()
    {
        turnText.text = "The enemy attacks!";
        yield return new WaitForSeconds(2f);
        if(blocking)
        {
            turnText.text = "Attack Blocked!";
            yield return new WaitForSeconds(2f);
            blocking = false;
        }
        else{
            bool dead = playerUnit.Damaged(5);
        }
            
        playerText.text = "Player " + playerUnit.unitHP.Health + "/" + playerUnit.unitHP.HealthMax;

        if(dead)
        {
            state = BattleState.LOSE;
            turnText.text = "You have Died.";
            EndBattle();
        }
        else
        {
            //player turn
            state = BattleState.PLAYER;
            PlayerTurn();
        }
    }
    //handles the end of the battle 
    void EndBattle()
    {
        if(state == BattleState.WIN)
        {
            turnText.text = "You win!";
        }
        else if (state == BattleState.LOSE)
        {
            turnText.text = "You have Lost";
            //Put actions on game loss here
        }
    }
    public void OnAttackButton()
    {
        if (state != BattleState.PLAYER)
            return;

        StartCoroutine(PlayerAttack());
    }

    public void OnBlockButton()
    {
        if (state != BattleState.PLAYER)
            return;

        StartCoroutine(PlayerBlock());
    }
    
}
