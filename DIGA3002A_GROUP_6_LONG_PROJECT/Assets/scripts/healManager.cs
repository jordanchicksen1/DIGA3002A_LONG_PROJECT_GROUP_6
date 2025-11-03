using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class healManager : MonoBehaviour
{
    public int heal;
    public int maxHeal = 3;
    public TextMeshProUGUI healText;

    public void Start()
    {
        heal = maxHeal;
        healText.text = heal.ToString();
    }
    public void UseHeal()
    {
        heal = heal - 1;
        healText.text = heal.ToString();
    }

    public void AddHeal()
    {
        heal = heal + 1;
        healText.text = heal.ToString();
    }
    public void RestoreHeal()
    {
        heal = maxHeal;
        healText.text = heal.ToString();
    }
}
