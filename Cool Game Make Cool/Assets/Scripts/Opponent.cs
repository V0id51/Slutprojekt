using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditorInternal;

public class Opponent : MonoBehaviour
{
    public int hp, atk;
    int chance;
    public TurnManager turnManager;
    public Slider hpBar;
    public TextMeshProUGUI hpText;
    int maxhp;
    // Start is called before the first frame update
    void Start()
    {
         maxhp = hp;
        turnManager = GameObject.FindGameObjectWithTag("TurnManager").GetComponent<TurnManager>();
        hpBar.maxValue = hp;
        hpText.text = hp.ToString() + "/" + maxhp;
    }

    // Update is called once per frame
    void Update()
    {
        if (turnManager.currentTurn == TurnState.EnemyTurn)
        {

            StartCoroutine(AttackC());
            turnManager.currentTurn = TurnState.YourTurn;
        }

        hpBar.value = hp;
        hpText.text = hp.ToString() + "/" + maxhp;

    }

    public void Attack()
    {
        chance = Random.Range(0, 3);
        if (chance == 0)
        {
            //miss
            turnManager.actionText.text = "The opponent missed";

        }
        else
        {
            turnManager.player.TakeDamage(atk);
            turnManager.actionText.text = "The opponent hit you.";

        }



    }

    public void TakeDamage(int dmg)
    {
        hp -= dmg;
    }

    IEnumerator AttackC()
    {
            turnManager.turnBox.SetActive(false);
        turnManager.actionText.gameObject.SetActive(true);
        bool ca = false;
        yield return new WaitForSeconds(1.5f);
        ca = true;
        if (ca)
        {
            Attack();
            ca = false; 

        }
        yield return new WaitForSeconds(1.5f);

        turnManager.turnBox.SetActive(true);
        turnManager.actionText.gameObject.SetActive(false);
    }
}


