using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBossHealthBar : MonoBehaviour
{

    public static UIBossHealthBar instance { get; private set; }
    public Image mask;
    public GameObject BossHealthbar;
    float maskSize;

    private void Awake()
    {
        instance = this;
    }
    // sets the mask size when called
    public void SetMaskSize()
    {
        maskSize = mask.rectTransform.rect.width;
    }

    //changes the health bar to represent the current amount of health
    public void SetBossHealth(float value)
    {
        mask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, maskSize * value);
    }
}