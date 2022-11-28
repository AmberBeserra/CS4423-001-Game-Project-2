using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState { START, PLAYER, ENEMY, WIN, LOSE, ATTACKED }

public class BattleSystem : MonoBehaviour
{  
    
    bool blocking = false;
    bool charging = false;
    bool dead = false;

    int turn = 1;
    
    Unit enemyUnit;
    Unit playerUnit;

    public Text playerText;
    public Text enemyText;
    public Text turnText;
    public Slider slider;

    public BattleState state;
    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;
        StartCoroutine(Setup());
    }
    IEnumerator Setup()
    {
        playerUnit = GameObject.Find("PCfacingright").GetComponent<Unit>();
        enemyUnit = GameObject.Find("slime").GetComponent<Unit>();

        //set unit damage and max health
        playerUnit.setStats(2,20);
        enemyUnit.setStats(2,10);

        turnText.text = "The Battle Begins";
        
        playerText.text = "Player " + playerUnit.unitHP.Health + "/" + playerUnit.unitHP.HealthMax;
        slider.maxValue = playerUnit.unitHP.HealthMax;
        slider.value = playerUnit.unitHP.Health;

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
        bool dead = enemyUnit.Damaged(playerUnit.getDamage());
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
        //checks if attack is already charged
        if(charging){
            turnText.text = "The enemy releases the charged attack!";
            yield return new WaitForSeconds(2f);
            //checks if the player is blocking
            if(!blocking){
                bool dead = playerUnit.Damaged(enemyUnit.getDamage() * 2);
                slider.value = playerUnit.unitHP.Health;
                playerText.text = "Player " + playerUnit.unitHP.Health + "/" + playerUnit.unitHP.HealthMax;
            }
            else{
                turnText.text = "Attack Blocked";
            }
            charging = false;
        }
        //starts charging attack every third attack
        else if((turn % 3) == 0){
            turnText.text = "The enemy begins charging an attack";
            charging = true;
        }
        //does normal attack if no attack is being charged 
        else {
            turnText.text = "The enemy attacks!";
            yield return new WaitForSeconds(2f);
            //checks if normal attack is blocked
            if(!blocking){
                bool dead = playerUnit.Damaged(enemyUnit.getDamage());
                slider.value = playerUnit.unitHP.Health;
                playerText.text = "Player " + playerUnit.unitHP.Health + "/" + playerUnit.unitHP.HealthMax;
            }
            else{
                turnText.text = "Attack Blocked";
            }            
        }
        yield return new WaitForSeconds(2f);
        turn++;
        //ends player block stance after blocking an attack
        if(blocking)
        {            
            blocking = false;
        }     
        //checks if player dies from the enemy attack
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
        //put actions on game win or loss here
        if(state == BattleState.WIN)
        {
            turnText.text = "You win!";

        }
        else if (state == BattleState.LOSE)
        {
            turnText.text = "You have Lost";

        }
    }
    //what happens on each button click
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