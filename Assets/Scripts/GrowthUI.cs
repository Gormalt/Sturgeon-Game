using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GrowthUI : MonoBehaviour
{
    public Sprite[] icons;

    public Image evolutionImage;
    public TextMeshProUGUI score;
    public TextMeshProUGUI stage;

    public void growTo(int num)
    {
        if (num < icons.Length)
        {
            evolutionImage.sprite = icons[num];

        }
    }

    public void levelTo(int level)
    {
        score.text = level.ToString();

        if (level == 0)
        {
            stage.text = "Stage: Juvenile";
        }
        else if (level == 1)
        {
            stage.text = "Stage: Young Adult";
        }
        else
        {
            stage.text = "Stage: Adult";
        }
    }
}
