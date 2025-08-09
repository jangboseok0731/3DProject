using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Heals : MonoBehaviour
{
    public float curValue;
    public float maxValue;
    public float startValue;
    public float passiveValue;
    public Image uiImage;

    private void Start()
    {
        curValue = startValue;
        Subtract(20f);
    }
    private void Update()
    {
        uiImage.fillAmount = GetPercentage();
        PassiveHeal();
    }
    public void Add(float amount)
    {
        curValue = Mathf.Min(curValue, amount, maxValue);
    }

    public void Subtract(float amount)
    {
        curValue = Mathf.Max(curValue - amount, 0.0f);
        Debug.Log($"지금 {amount} 만큼 데미지를 입었어");
    }
    public float GetPercentage()
    {
        return curValue / maxValue;
    }
    public float PassiveHeal()
    {
        return curValue += passiveValue * Time.deltaTime;
    }
}
