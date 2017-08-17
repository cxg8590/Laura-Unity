using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TelescopeManager : MonoBehaviour {

    public GameObject[] level;
    public GameObject[] unfound;
    public GameObject[] objects;
    public GameObject[] extras;

    private int lv;

    // Use this for initialization
    void Start () {
        lv = 0;

        level[lv].SetActive(true);
        unfound[lv].SetActive(true);
        extras[lv].SetActive(true);

        objects = new GameObject[level[lv].transform.childCount];
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i] = level[lv].transform.GetChild(i).gameObject;
        }

    }

    // Update is called once per frame
    void Update () {
        if (check() == true) Win();
	}

    bool check()
    {
        bool win = true;
        for(int i = 0; i < objects.Length; i++)
        {
            if(objects[i].GetComponent<TelescopeClick>().correct == false)
            {
                win = false;
            }
        }

        return win;
    }

    void Win()
    {
        Debug.Log("lv: " + lv);
        level[lv].SetActive(false);
        unfound[lv].SetActive(false);
        extras[lv].SetActive(true);

        if (lv < unfound.Length)
        {
            lv++;
            level[lv].SetActive(true);
            unfound[lv].SetActive(true);
            extras[lv].SetActive(true);

            objects = new GameObject[level[lv].transform.childCount];
            for (int i = 0; i < objects.Length; i++)
            {
                objects[i] = level[lv].transform.GetChild(i).gameObject;
                Debug.Log("Object Names: "+objects[i].name);
            }

        }
        else
        {
            Debug.Log("You Win");
        }
    }
}
