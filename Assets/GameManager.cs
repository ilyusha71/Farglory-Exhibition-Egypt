using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Target")]
    public Transform target;
    private Button[] targetButton;

    //public bool[] hasCollected;

    [Header("Progress")]
    //public Image[] imageProgress;

    [Header("Mission")]
    public Transform mission;
    private Button[] btnMission;
    private TextMeshProUGUI[] textProgress;
    private int[] valueProgress = new int[3];

    [Header("Cheat")]
    public Transform cheat;
    private Button[] btnCheat;
    private int countCheat;
    private int valueCheat;

    [Header("Tips")]
    public Button btnTips;
    public GameObject[] animationTips;
    //public Sprite[] spriteTips;
    //public Image imageTips;
    [Header("SFX")]
    public AudioClip[] bgm;
    private AudioSource sfx;

    private void Awake()
    {
        targetButton = target.GetComponentsInChildren<Button>();
        btnMission = mission.GetComponentsInChildren<Button>();
        btnCheat = cheat.GetComponentsInChildren<Button>();
        countCheat = btnCheat.Length;
        //imageTips = btnTips.GetComponent<Image>();

        textProgress = new TextMeshProUGUI[3];
        for (int i = 0; i < 3; i++)
        {
            textProgress[i] = btnMission[i].GetComponentInChildren<TextMeshProUGUI>();
        }

        sfx = GetComponent<AudioSource>();
    }

    void Start ()
    {
        for (int i = 0; i < targetButton.Length; i++)
        {
            int index = i;
            targetButton[index].onClick.AddListener(() =>
            {
                targetButton[index].interactable = false;
                if (index < 9)
                {
                    textProgress[0].text = ++valueProgress[0] + "<size=37>/9";
                    if (valueProgress[0] == 9)
                    {
                        textProgress[0].text = "<size=37>↓提示</size>";
                        btnMission[0].interactable = true;
                        sfx.clip = bgm[2];
                        sfx.Play();
                    }
                    else if (valueProgress[0] > 9)
                        textProgress[0].text = "<size=37>↓提示</size>";
                }
                else if (index < 18)
                {
                    textProgress[1].text = ++valueProgress[1] + "<size=37>/9";
                    if (valueProgress[1] == 9)
                    {
                        textProgress[1].text = "<size=37>↓提示</size>";
                        btnMission[1].interactable = true;
                        sfx.clip = bgm[1];
                        sfx.Play();
                    }
                    else if (valueProgress[1] > 9)
                        textProgress[1].text = "<size=37>↓提示</size>";
                }
                else if (index < 27)
                {
                    textProgress[2].text = ++valueProgress[2] + "<size=37>/9";
                    if (valueProgress[2] == 9)
                    {
                        textProgress[2].text = "<size=37>↓提示</size>";
                        btnMission[2].interactable = true;
                        sfx.clip = bgm[1];
                        sfx.Play();
                    }
                    else if (valueProgress[2] > 9)
                        textProgress[2].text = "<size=37>↓提示</size>";
                }
                sfx.PlayOneShot(bgm[0], 3.0f);
            });
        }

        for (int i = 0; i < 3; i++)
        {
            int index = i;
            btnMission[index].interactable = false;
            textProgress[index].text = "0<size=37>/9";
            btnMission[index].onClick.AddListener(() =>
            {
                if (btnTips.gameObject.activeSelf) return;
                btnTips.gameObject.SetActive(true);
                animationTips[index].SetActive(true);
                sfx.PlayOneShot(bgm[3], 1.0f);
            });
            btnTips.onClick.AddListener(() =>
            {
                btnTips.gameObject.SetActive(false);
                animationTips[0].SetActive(false);
                animationTips[1].SetActive(false);
                animationTips[2].SetActive(false);

            });
        }

        for (int i = 0; i < countCheat; i++)
        {
            int index = i;
            btnCheat[index].onClick.AddListener(() =>
            {
                valueCheat *= 10;
                valueCheat += index + 1;
                valueCheat %= 10000;
                if (valueCheat == 1243)
                {
                    valueProgress[0] = 9;
                    textProgress[0].text = "<size=37>↓提示</size>";
                    btnMission[0].interactable = true;
                    sfx.clip = bgm[2];
                    sfx.Play();
                }
                else if (valueCheat == 2143)
                {
                    valueProgress[1] = 9;
                    textProgress[1].text = "<size=37>↓提示</size>";
                    btnMission[1].interactable = true;
                    sfx.clip = bgm[1];
                    sfx.Play();
                }
                else if (valueCheat == 3421)
                {
                    valueProgress[2] = 9;
                    textProgress[2].text = "<size=37>↓提示</size>";
                    btnMission[2].interactable = true;
                    sfx.clip = bgm[2];
                    sfx.Play();
                }

            });
        }
    }
}
