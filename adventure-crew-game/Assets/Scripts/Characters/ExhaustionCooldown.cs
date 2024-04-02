using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ExhaustionCooldown : MonoBehaviour
{
    private float timeLeft;
    private float currentTimeInterval;

    [SerializeField]
    private TextMeshProUGUI timerText;

    private float mostExhaustion;

    // Start is called before the first frame update
    void Start()
    {
        mostExhaustion = 0f;
        foreach(Adventurer adv in AdventurerList.Adventurers)
        {
            if (adv.Exhaustion > mostExhaustion)
                mostExhaustion = adv.Exhaustion;
        }

        timeLeft = mostExhaustion;
        currentTimeInterval = timeLeft;
        if(mostExhaustion == 0)
        {
            timerText.gameObject.SetActive(false);
        }
        else
        {
            timerText.gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            UpdateExhaustion(timeLeft);
        }
        else
        {
            timeLeft = 0;
        }
    }

    private void UpdateExhaustion(float currentTime)
    {
        if(currentTime <= currentTimeInterval - 1)
        {
            for(int i = 0; i < AdventurerList.Adventurers.Count; i++)
            {
                if (AdventurerList.Adventurers[i].Exhaustion > 0)
                {
                    Adventurer curAdv = AdventurerList.Adventurers[i];
                    curAdv.Exhaustion -= 1;
                    if (curAdv.GetStats().HP < curAdv.GetStats().MaxHP)
                    {
                        Stats healing = new Stats(curAdv.GetStats().HP + curAdv.HealInterval, curAdv.GetStats().MaxHP,
                            curAdv.GetStats().Damage, curAdv.GetStats().Agility, curAdv.GetStats().Range);
                        AdventurerList.Adventurers[i].SetStats(healing);
                    }
                    if (curAdv.GetStats().HP > curAdv.GetStats().MaxHP)
                    {
                        Stats healing = new Stats(curAdv.GetStats().MaxHP, curAdv.GetStats().MaxHP,
                            curAdv.GetStats().Damage, curAdv.GetStats().Agility, curAdv.GetStats().Range);
                        AdventurerList.Adventurers[i].SetStats(healing);
                    }
                }
            }
            currentTimeInterval -= 1;
        }

        //Found this method in a video: https://www.youtube.com/watch?v=hxpUk0qiRGs
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        timerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }
}
