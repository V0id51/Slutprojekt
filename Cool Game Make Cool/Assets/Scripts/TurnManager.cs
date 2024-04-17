using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public enum TurnState {YourTurn, EnemyTurn}
public class TurnManager : MonoBehaviour
{
    public TurnState currentTurn;
    public GameObject turnBox;
    public Player player;
    public Opponent opponent;
    public TextMeshProUGUI actionText;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Attack()
    {
        int chance = Random.Range(0, 10);
        if (chance >= 7)
        {
            opponent.TakeDamage(player.atk * 2);
            actionText.text = "You landed a critical hit!";
        }
        else if(chance <= 1)
        {
            actionText.text = "You missed";
            //miss
        }
        else
        {
            opponent.TakeDamage(player.atk);
            actionText.text = "You landed a hit.";

        }
        currentTurn = TurnState.EnemyTurn;
    }

    public void Item()
    {

    }

    public void Run()
    {

    }

    
}
