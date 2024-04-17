using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int hp, atk;
    public Slider hpSlider;
    public TextMeshProUGUI hpText;
    int maxhp;
    // Start is called before the first frame update
    void Start()
    {
        maxhp = hp;
        hpSlider.maxValue = hp;
        hpText.text = hp.ToString() + "/" + maxhp;

    }

    // Update is called once per frame
    void Update()
    {
        hpSlider.value = hp;
        hpText.text = hp.ToString() + "/" + maxhp;
    }

    public void TakeDamage(int dmg)
    {
        hp -= dmg;
    }
}
