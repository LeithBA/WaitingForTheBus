using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Gameloop : MonoBehaviour
{
    private float timer;
    private bool started;
    [SerializeField] private GameObject mainText, subText, busStatus, slider, button00, _button00, button01, _button01, button02, _button02 , button03;
    private int progress = 0;

    void Start()
    {
        button00.GetComponent<Button>().onClick.AddListener(button00Click);
        button01.GetComponent<Button>().onClick.AddListener(button01Click);
        button02.GetComponent<Button>().onClick.AddListener(button02Click);
        button03.GetComponent<Button>().onClick.AddListener(button03Click);
        subText.SetActive(false);
        button03.SetActive(false);
        Intro();
    }

    // Update is called once per frame
    void Update()
    {
        if (started == true)
        {
            timer += Time.deltaTime;
            slider.GetComponent<Slider>().value = timer;
        }

        if (timer >= 4)
        {
            UpdateText(busStatus, "You see the bus arrive.");
        }

        if (timer >= 6)
        {
            UpdateText(busStatus, "The bus is nearly here.");
        }

        if (timer >= 8)
        {
            UpdateText(busStatus, "The bus stops.");
        }

        if (timer >= 10)
        {
            subText.SetActive(true);
            if (progress == 0)
                UpdateText(subText, "You got on the bus and left.\nGood job.");
            else if (progress == 4)
                UpdateText(subText, "You littered and got in the bus with smoke in your mouth.\nThis is the worst possible outcome.\nYou're simply a jerk.");
            else if (progress == 5)
                UpdateText(subText, "Please don't litter in real life. Cigarette butts take up to 25 years to decompose.");
            else if (progress == 6)
                UpdateText(subText, "You know you could've started a fire by throwing your cigarette in the bin without killing it off.\nBut you did it anyway...");
            else if (progress == 7)
                UpdateText(subText, "You've done the responsible thing.\nNext step?\nStop smoking.");
            else
                UpdateText(subText, "The bus leaved without you...\n Too bad.");
            
            UpdateText(busStatus, "The bus leaves.");
            
            button03.SetActive(true);
        }
    }

    private void UpdateText(GameObject obj, string txt)
    {
        obj.GetComponent<Text>().text = txt;
    }

    void button00Click()
    {
        timer = 0;
        if (progress == 0 || progress == 4 || progress == 5 || progress == 6 || progress == 7)
        {
            progress = 1;
            subText.SetActive(false);
            button00.SetActive(false);
            button01.SetActive(true);
            button02.SetActive(true);
            started = true;
            UpdateText(mainText, "You light up a cigarette and start smoking.");
            UpdateText(_button00, "");
            UpdateText(_button01, "Smoke a couple more puffs");
            UpdateText(_button02, "Walk towards the trash bin");
        }
    }
    void button01Click()
    {
        if (progress == 1)
        {
            progress = 2;
            UpdateText(mainText, "You smoke a little bit more.");
            UpdateText(_button01, "Finish cigarette");
            UpdateText(_button02, "Throw cigarette away");
        }

        else if (progress == 2)
        {
            progress = 4;
            UpdateText(mainText, "You finish smoking your cigarette, quickly throw it on the ground and get in the bus with your mouth half full of smoke.");
            button01.SetActive(false);
            button02.SetActive(false);
        }

        else if (progress == 3)
        {
            progress = 6;
            UpdateText(mainText, "You throw your cigarette in the bin, hoping nothing will catch on fire and then walk back to get on the bus.");
            button01.SetActive(false);
            button02.SetActive(false);
        }

    }

    void button02Click()
    {
        if (progress == 1)
        {
            progress = 3;
            UpdateText(mainText, "You walk towards the trash bin.");
            UpdateText(_button01, "Throw the cigarette in the bin");
            UpdateText(_button02, "Kill the cigarette in the bins ashtray");
        }

        else if (progress == 2)
        {
            progress = 5;
            UpdateText(mainText, "You throw your cigarette on the ground, prepare your transport ticket to get on the bus.");
            button01.SetActive(false);
            button02.SetActive(false);
        }

        else if (progress == 3)
        {
            progress = 7;
            UpdateText(mainText, "You kill your cigarette before throwing it in the ashtray and then walk back to get on the bus.");
            button01.SetActive(false);
            button02.SetActive(false);
        }
    }
    
    void button03Click()
    {
        SceneManager.LoadScene(0);
    }

    private void Intro()
    {
        button01.SetActive(false);
        button02.SetActive(false);
        UpdateText(mainText, "You are waiting for you bus.");
        UpdateText(busStatus, "No sign of the bus yet.");
        UpdateText(_button00, "Light up a cigarette");
        UpdateText(_button01, "");
        UpdateText(_button02, "");
    }

}
