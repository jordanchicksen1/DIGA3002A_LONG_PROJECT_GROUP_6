using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class credits : MonoBehaviour
{
    public int credit = 0;
    public TextMeshProUGUI creditText;



    public void AddTutOneCredits()
    {
        credit = credit + 720;
        creditText.text = credit.ToString();
    }

    public void AddTutTwoCredits()
    {
        credit = credit + 720;
        creditText.text = credit.ToString();
    }

    public void AddTutThreeCredits()
    {
        credit = credit + 720;
        creditText.text = credit.ToString();
    }

    public void AddMissionOneCredits()
    {
        credit = credit + 1000;
        creditText.text = credit.ToString();
    }

    public void AddBossOneCredits()
    {
        credit = credit + 1000;
        creditText.text = credit.ToString();
    }

    public void WalkerKill()
    {
        credit = credit + 100;
        creditText.text = credit.ToString();
    }

    public void TankerKill()
    {
        credit = credit = credit + 200;
        creditText.text = credit.ToString();
    }

    public void JetKill()
    {
        credit = credit + 150;
        creditText.text = credit.ToString();
    }
}
