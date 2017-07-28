using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TelegramManager : MonoBehaviour {
    public GameObject canvas;

    public GameObject Lincoln; //the progress bar for lincoln
    //public GameObject Douglas;
    public Button[] buttons; //list of all buttons
    public Image[] Lights; //the image element that displays the image sequence and what has just been tapped
    public Sprite[] dots; //the list of all images
    public Sprite[] off;

    public GameObject[] progress; //progress dots
    public Sprite[] progDots;

    public Image win;
    public Sprite correct;
    public Sprite wrong;

    //tutorial video
    public GameObject screen;
    private bool startGame;

    //public GameObject winLose;
    public GameObject goodJob;
    public GameObject tryAgain;

    int length; //length of arrays
    int current; //which button/sprite we are on right now
    bool playing; //are we in the game portion or the watch portion
    Button[] buttonOrder; //the order the buttons should be pressed in, should match up with spriteOrder
    Sprite[] spriteOrder;//the order the sprites appear in, should match up with buttonOrder
    Sprite[] offOrder;
    Image[] imgOrder;

    float level;

    public Image greyOut;

    // Use this for initialization
    void Start () {
        /*greyOut.raycastTarget = false;
        greyOut.color = new Color(0, 0, 0, 0);
        greyOut.enabled = false;*/
        startGame = false;
        //populate(); //populate the arrays
    }
	
	// Update is called once per frame
	void Update () {
        if (screen.GetComponent<ClickBool>().click == true && startGame == false)
        {
            startGame = true;
            playing = false; //player isnt playing
            length = 1; //list of buttons to press starts at 1
            level = 15;
            screen.gameObject.SetActive(false);
            populate();
        }

        for(int i = 0; i < 5; i++)
        {
            buttons[i].image.sprite = off[i];
        }
        
        if (playing)
        {
            if(current >= length)
            {
                //when you win a round, the progress bar goes up relative to how many where in the sequence
                StartCoroutine(WinLoose(true));
                playing = false;
                Lincoln.GetComponent<progressBar>().addAmount(length
                    /level);
                //it then increases the length and starts over
                length++;
                updateProgressDots();
                populate();
            }
        }
        if (Lincoln.GetComponent<Image>().fillAmount == 1.0f)
        {
            //you win
        }

        /*if(Douglas.GetComponent<Image>().fillAmount == 1.0f)
        {
            //you lose
        }*/
	}

    void populate()
    {
        int sprite; //which sprite and button combination are in this position
        buttonOrder = new Button[length];
        spriteOrder = new Sprite[length];
        offOrder = new Sprite[length];
        imgOrder = new Image[length];
        for (int i = 0; i < length; i++)
        {
            sprite = Random.Range(1, 6); //gets a number between 1 and 5
            //takes the above number and adds a button sprite combination to their respective lists
            if(sprite == 1)
            {
                buttonOrder[i] = buttons[0];
                spriteOrder[i] = dots[0];
                offOrder[i] = off[0];
                imgOrder[i] = Lights[0];
            }
            else if (sprite == 2)
            {
                buttonOrder[i] = buttons[1];
                spriteOrder[i] = dots[1];
                offOrder[i] = off[1];
                imgOrder[i] = Lights[1];
            }
            else if (sprite == 3)
            {
                buttonOrder[i] = buttons[2];
                spriteOrder[i] = dots[2];
                offOrder[i] = off[2];
                imgOrder[i] = Lights[2];
            }
            else if (sprite == 4)
            {
                buttonOrder[i] = buttons[3];
                spriteOrder[i] = dots[3];
                offOrder[i] = off[3];
                imgOrder[i] = Lights[3];
            }
            else if (sprite == 5)
            {
                buttonOrder[i] = buttons[4];
                spriteOrder[i] = dots[4];
                offOrder[i] = off[4];
                imgOrder[i] = Lights[4];
            }
        }

        StartCoroutine(playThrough()); //starts the coroutine to display the complete list of sprites
        
        current = 0; //starts the player at the zero element of the list
        //playThrough();
    }

    IEnumerator playThrough()
    {
        playing = false;
        for (int i = 0; i < Lights.Length; i++)
        {
            Lights[i].sprite = off[i];
        }
        greyOut.enabled = true;
        //play through the list of images
        for (int i = 0; i < length; i++)
        {
            imgOrder[i].sprite = spriteOrder[i]; //sets the image to the current sprite in the list
            //here we should put an animation to make sure players know when a new dot is here
            //wait 1 second
            yield return new WaitForSeconds(0.75f);//waits 1 second for the next one
            imgOrder[i].sprite = offOrder[i];
            yield return new WaitForSeconds(0.25f);
        }
        greyOut.enabled = false;
        playing = true; //ypu are now playing the game
    }

    public void checkClick(Button bt)
    {
        if (playing == true)
        {
            if (bt == buttonOrder[current])//if the button pressed is correct
            {
                color(.25f, current); //sets the image to the button you just pressed
                current++;//updates your position in the lists
            }
            else
            {
                StartCoroutine(WinLoose(false));
                length = 1;//sets your length back to one
                playing = false; //you are no longer playing
                updateProgressDots();
                populate();//starts the game over
            }
        }
    }

    IEnumerator color(float sec, int sprt)
    {
        imgOrder[sprt].sprite = spriteOrder[sprt];
        yield return new WaitForSeconds(sec);
    }

    IEnumerator WinLoose(bool cr)
    {
        if (cr)
        {
            //win.sprite = correct;
            Debug.Log("winLoose win");
            //winLose = goodJob;// Instantiate(goodJob, new Vector3(0, 0, 0), Quaternion.identity) as GameObject
            Instantiate(goodJob, new Vector3(0, -1, 0), Quaternion.identity);
            //GameObject gj = Instantiate(goodJob, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
            //gj.transform.SetParent(canvas.transform);
            yield return new WaitForSeconds(.25f);
            
        }
        else
        {
            //win.sprite = wrong;
            Debug.Log("winLoose lose");
            //winLose = tryAgain;
            Instantiate(tryAgain, new Vector3(0, -1, 0), Quaternion.identity);
            //GameObject ta = Instantiate(tryAgain, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
            //ta.transform.SetParent(canvas.transform);
            yield return new WaitForSeconds(.25f);
        }
    }

    void victory()
    {
        if (level < 25)
        {
            level += 5;
            Lincoln.GetComponent<progressBar>().reset();
            StartCoroutine(WinLoose(false));
            length = 1;//sets your length back to one
            playing = false; //you are no longer playing
            populate();//starts the game over
        }
        else
        {
            Debug.Log("You Win!");
        }
    }

    void updateProgressDots()
    {
        for(int i = 0; i < 5; i++)
        {
            if(i < length - 1)
            {
                progress[i].GetComponent<SpriteRenderer>().sprite = progDots[1];
            }
            else
            {
                progress[i].GetComponent<SpriteRenderer>().sprite = progDots[0];
            }
        }
        if(length >= 6)
        {
            Application.LoadLevel(1);
        }
        broadCast();
    }

    void broadCast()
    {
        Application.ExternalCall("unityBroadcast", length);
    }

    public bool getPlaying()
    {
        return playing;
    }

    /*IEnumerator wait(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
    }*/

}
/* IEnumerator playThrough()
    {
        for (int i = 0; i < length; i++)
        {
            image.sprite = spriteOrder[i];
            //wait 1 second
            yield return new WaitForSeconds(1);
            System.Threading.Thread.Sleep(1000);
            //StartCoroutine(wait(1.0f));
        }
        Debug.Log("spriteOrder" + spriteOrder);
        current = 0;
        playing = true;
    }
    
    
    IEnumerator playThrough()
    {
        int i = current;
        while (i < length)
        {
            image.sprite = spriteOrder[i];
        }
            //wait 1 second
        yield return new WaitForSeconds(1);
        current++;
    }*/
