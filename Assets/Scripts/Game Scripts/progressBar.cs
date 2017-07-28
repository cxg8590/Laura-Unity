using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class progressBar : MonoBehaviour
{

    public float add;
    float amount = 0;
    //public float length;
    public bool perSecond;

    // Use this for initialization
    void Start()
    {
        this.GetComponent<Image>().fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (perSecond)
        {
            PerSecond();
        }
    }

    public void PerSecond()
    {
        //amount = amount / 100;
        //Debug.Log("amount" + amount);
        amount += add / 10000;
        this.GetComponent<Image>().fillAmount = amount;
    }

    public void addAmount(float amt)
    {
        amount = amt;// / 10000;
        this.GetComponent<Image>().fillAmount = this.GetComponent<Image>().fillAmount + amount;
    }
    public void reset()
    {
        this.GetComponent<Image>().fillAmount = 0;
    }
}