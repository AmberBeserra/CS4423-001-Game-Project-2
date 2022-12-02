using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum BattleState { START, PLAYER, ENEMY, WIN, LOSE, ATTACKED }

public class BattleSystem : MonoBehaviour
{
    private GameManager gameManager;
    bool blocking = false;
    bool charging = false;
    bool dead = false;

    public Animator myAnim;


    int turn = 1;

    Unit enemyUnit;
    Unit playerUnit;

    public Text playerText;
    public Text enemyText;
    public Text potion1;
    public Text potion2;
    public Text turnText;
    public Slider slider;
    public GameObject attackButton;
    public GameObject blockButton;
    public GameObject inventory;
    public GameObject inventoryButton;
    //public GameObject useWeak;
    //public GameObject useStrong;



    public int scene;

    public BattleState state;
    // Start is called before the first frame update
    void Start()
    {
        inventory.SetActive(false);
        myAnim = GetComponent<Animator>();

        state = BattleState.START;
        StartCoroutine(Setup());
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    IEnumerator Setup()
    {
        potion1.text = "" + FindObjectOfType<GameManager>().GetPotions();
        potion2.text = "" + FindObjectOfType<GameManager>().GetPotions2();

        playerUnit = GameObject.Find("PCfacingright").GetComponent<Unit>();
        enemyUnit = GameObject.Find("slime").GetComponent<Unit>();

        //set unit damage and max health
        playerUnit.setStats(2, 20);
        enemyUnit.setStats(2, 10);

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
        attackButton.SetActive(true);
        blockButton.SetActive(true);
        inventoryButton.SetActive(true);
    }
    //handles what happens when the attack button is clicked
    IEnumerator PlayerAttack()
    {

        state = BattleState.ATTACKED;

        bool dead = enemyUnit.Damaged(playerUnit.getDamage());

        enemyText.text = "Evil Slime " + enemyUnit.unitHP.Health + "/" + enemyUnit.unitHP.HealthMax;
        turnText.text = "Player Attacks!";
        attackButton.SetActive(false);
        blockButton.SetActive(false);
        inventoryButton.SetActive(false);
        inventory.SetActive(false);
        yield return new WaitForSeconds(2f);

        if (dead)
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

        myAnim.Play("PCBlock");

        turnText.text = "Player blocks!";
        blocking = true;
        attackButton.SetActive(false);
        blockButton.SetActive(false);
        inventoryButton.SetActive(false);
        inventory.SetActive(false);
        yield return new WaitForSeconds(2f);
        state = BattleState.ENEMY;
        StartCoroutine(enemyAttack());
    }


    //handles enemy attack
    IEnumerator enemyAttack()
    {
        inventory.SetActive(false);
        attackButton.SetActive(false);
        blockButton.SetActive(false);
        inventoryButton.SetActive(false);
        yield return new WaitForSeconds(2f);
        
        //checks if attack is already charged


        if (charging)
        {
            turnText.text = "The enemy releases the charged attack!";
            yield return new WaitForSeconds(2f);
            //checks if the player is blocking
            if (!blocking)
            {
                bool dead = playerUnit.Damaged(enemyUnit.getDamage() * 2);
                slider.value = playerUnit.unitHP.Health;
                playerText.text = "Player " + playerUnit.unitHP.Health + "/" + playerUnit.unitHP.HealthMax;
            }
            else
            {
                turnText.text = "Attack Blocked";
            }
            charging = false;
        }
        //starts charging attack every third attack
        else if ((turn % 3) == 0)
        {
            turnText.text = "The enemy begins charging an attack";
            charging = true;
        }
        //does normal attack if no attack is being charged 
        else
        {
            myAnim.SetTrigger("FinalSlimeAttack");
            turnText.text = "The enemy attacks!";


            myAnim.SetTrigger("FinalSlimeAttack");

            yield return new WaitForSeconds(2f);
            //checks if normal attack is blocked
            if (!blocking)
            {
                bool dead = playerUnit.Damaged(enemyUnit.getDamage());
                slider.value = playerUnit.unitHP.Health;
                playerText.text = "Player " + playerUnit.unitHP.Health + "/" + playerUnit.unitHP.HealthMax;
            }
            else
            {
                turnText.text = "Attack Blocked";
            }
        }
        yield return new WaitForSeconds(2f);
        turn++;
        //ends player block stance after blocking an attack
        if (blocking)
        {
            blocking = false;
        }
        //checks if player dies from the enemy attack
        if (dead)
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
        scene = SceneManager.GetActiveScene().buildIndex;
        //put actions on game win or loss here
        if (state == BattleState.WIN)
        {
            turnText.text = "You win!";
            gameManager.ScoreAfterMonsterDie();
            //SceneManager.LoadScene(3); //move to scene 3
            SceneManager.LoadScene(scene + 1);
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

        myAnim.SetTrigger("Attack");

        StartCoroutine(PlayerAttack());
    }

    public void OnBlockButton()
    {
        if (state != BattleState.PLAYER)
            return;

        myAnim.SetTrigger("Block");
        StartCoroutine(PlayerBlock());
    }
    public void useWeakButton()
    {
        if(FindObjectOfType<GameManager>().GetPotions() > 0){
            playerUnit.heal(10);
            slider.value = playerUnit.unitHP.Health;
            playerText.text = "Player " + playerUnit.unitHP.Health + "/" + playerUnit.unitHP.HealthMax;
            FindObjectOfType<GameManager>().useWeakPotion();
            potion1.text = "" + FindObjectOfType<GameManager>().GetPotions();
            turnText.text = "Used Potion";
            inventory.SetActive(false);
            state = BattleState.ENEMY;
            StartCoroutine(enemyAttack());
        }
        else{
            Debug.Log("You have no Weak Potions!");
        }
    }
    public void useStrongButton()
    {
        if(FindObjectOfType<GameManager>().GetPotions2() > 0){
            playerUnit.heal(20);
            slider.value = playerUnit.unitHP.Health;
            playerText.text = "Player " + playerUnit.unitHP.Health + "/" + playerUnit.unitHP.HealthMax;
            FindObjectOfType<GameManager>().useStrongPotion();
            potion2.text = "" + FindObjectOfType<GameManager>().GetPotions2();
            inventory.SetActive(false);
            turnText.text = "Used Potion";
            state = BattleState.ENEMY;
            StartCoroutine(enemyAttack());
        }
        else{
            Debug.Log("You have no Strong Potions!");
        }
    }


}