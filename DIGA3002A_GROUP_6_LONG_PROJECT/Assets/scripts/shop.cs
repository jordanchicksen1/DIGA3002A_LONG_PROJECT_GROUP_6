using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shop : MonoBehaviour
{
    public credits credits;

    [Header("Heads UI")]
    public GameObject standardHeadUI;
    public bool boughtStandardHead = false;
    public GameObject speedHeadUI;
    public bool boughtSpeedHead = false;
    public GameObject defenseHeadUI;
    public bool boughtDefenseHead = false;

    [Header("Torsos UI")]
    public GameObject standardTorsoUI;
    public bool boughtStandardTorso = false;
    public GameObject speedTorsoUI;
    public bool boughtSpeedTorso = false;
    public GameObject defenseTorsoUI;
    public bool boughtDefenseTorso = false;

    [Header("Legs UI")]
    public GameObject standardLegsUI;
    public bool boughtStandardLegs = false;
    public GameObject speedLegsUI;
    public bool boughtSpeedLegs = false;
    public GameObject defenseLegsUI;
    public bool boughtDefenseLegs = false;

    [Header("Weapons")]
    public GameObject machineLeftUI;
    public bool boughtMachineLeft = false;
    public GameObject machineRightUI;
    public bool boughtMachineRight = false;
    public GameObject assaultLeftUI;
    public bool boughtAssaultLeft = false;
    public GameObject assaultRightUI;
    public bool boughtAssaultRight = false;
    public GameObject laserLeftUI;
    public bool boughtLaserLeft = false;
    public GameObject laserRightUI;
    public bool boughtLaserRight = false;

    [Header("Supers")]
    public GameObject laserSuperUI;
    public bool boughtLaserSuper = false;
    public GameObject orbitalSuperUI;
    public bool boughtOrbitalSuper = false;

    public GameObject notEnoughCredits;
    public GameObject newPartUnlocked;
    public GameObject partAlreadyBought;

    public bool hasPressed = false;
    
    //buying heads
    public void BuyStandardHead()
    {
        if(credits.credit >= 100 && boughtStandardHead == false && hasPressed == false)
        {
            StartCoroutine(NewPartAcquired());
            standardHeadUI.SetActive(true);
            boughtStandardHead = true;
            hasPressed = true;
            StartCoroutine(PressedButton());
            credits.Minus100();
        }

        if(credits.credit <= 100 &&  boughtStandardHead == false && hasPressed == false)
        {
            StartCoroutine(NotEnoughMoney());
            hasPressed = true;
            StartCoroutine(PressedButton());
        }

        if (boughtStandardHead == true && hasPressed == false)
        {
            StartCoroutine(AlreadyBoughtPart());
            hasPressed = true;
            StartCoroutine(PressedButton());
        }

    }

    public void BuySpeedHead()
    {
        if (credits.credit >= 200 && boughtSpeedHead == false && hasPressed == false)
        {
            StartCoroutine(NewPartAcquired());
            speedHeadUI.SetActive(true);
            boughtSpeedHead = true;
            hasPressed = true;
            StartCoroutine(PressedButton());
            credits.Minus200();
        }

        if (credits.credit <= 200 && boughtSpeedHead == false && hasPressed == false)
        {
            StartCoroutine(NotEnoughMoney());
            hasPressed = true;
            StartCoroutine(PressedButton());
        }

        if (boughtSpeedHead == true && hasPressed == false)
        {
            StartCoroutine(AlreadyBoughtPart());
            hasPressed = true;
            StartCoroutine(PressedButton());
        }
    }

    public void BuyDefenseHead() 
    {
        if (credits.credit >= 300 && boughtDefenseHead == false && hasPressed == false)
        {
            StartCoroutine(NewPartAcquired());
            defenseHeadUI.SetActive(true);
            boughtDefenseHead = true;
            hasPressed = true;
            StartCoroutine(PressedButton());
            credits.Minus300();
        }

        if (credits.credit <= 300 && boughtDefenseHead == false && hasPressed == false)
        {
            StartCoroutine(NotEnoughMoney());
            hasPressed = true;
            StartCoroutine(PressedButton());
        }

        if (boughtDefenseHead == true && hasPressed == false)
        {
            StartCoroutine(AlreadyBoughtPart());
            hasPressed = true;
            StartCoroutine(PressedButton());
        }
    }

    //buying torsos

    public void BuyStandardTorso()
    {
        if (credits.credit >= 100 && boughtStandardTorso == false && hasPressed == false)
        {
            StartCoroutine(NewPartAcquired());
            standardTorsoUI.SetActive(true);
            boughtStandardTorso = true;
            hasPressed = true;
            StartCoroutine(PressedButton());
            credits.Minus100();
        }

        if (credits.credit <= 100 && boughtStandardTorso == false && hasPressed == false)
        {
            StartCoroutine(NotEnoughMoney());
            hasPressed = true;
            StartCoroutine(PressedButton());
        }

        if (boughtStandardTorso == true && hasPressed == false)
        {
            StartCoroutine(AlreadyBoughtPart());
            hasPressed = true;
            StartCoroutine(PressedButton());
        }
    }

    public void BuySpeedTorso() 
    {
        if (credits.credit >= 200 && boughtSpeedTorso == false && hasPressed == false)
        {
            StartCoroutine(NewPartAcquired());
            speedTorsoUI.SetActive(true);
            boughtSpeedTorso = true;
            hasPressed = true;
            StartCoroutine(PressedButton());
            credits.Minus200() ;
        }

        if (credits.credit <= 200 && boughtSpeedTorso == false && hasPressed == false)
        {
            StartCoroutine(NotEnoughMoney());
            hasPressed = true;
            StartCoroutine(PressedButton());
        }

        if (boughtSpeedTorso == true && hasPressed == false)
        {
            StartCoroutine(AlreadyBoughtPart());
            hasPressed = true;
            StartCoroutine(PressedButton());
        }
    }

    public void BuyDefenseTorso()
    {
        if (credits.credit >= 300 && boughtDefenseTorso == false && hasPressed == false)
        {
            StartCoroutine(NewPartAcquired());
            defenseTorsoUI.SetActive(true);
            boughtDefenseTorso = true;
            hasPressed = true;
            StartCoroutine(PressedButton());
            credits.Minus300() ;
        }

        if (credits.credit <= 300 && boughtDefenseTorso == false && hasPressed == false)
        {
            StartCoroutine(NotEnoughMoney());
            hasPressed = true;
            StartCoroutine(PressedButton());
        }

        if (boughtDefenseTorso == true && hasPressed == false)
        {
            StartCoroutine(AlreadyBoughtPart());
            hasPressed = true;
            StartCoroutine(PressedButton());
        }
    }

    //buying legs

    public void BuyStandardLegs()
    {
        if (credits.credit >= 100 && boughtStandardLegs == false && hasPressed == false)
        {
            StartCoroutine(NewPartAcquired());
            standardLegsUI.SetActive(true);
            boughtStandardLegs = true;
            hasPressed = true;
            StartCoroutine(PressedButton());
            credits.Minus100() ;
        }

        if (credits.credit <= 100 && boughtStandardLegs == false && hasPressed == false)
        {
            StartCoroutine(NotEnoughMoney());
            hasPressed = true;
            StartCoroutine(PressedButton());
        }

        if (boughtStandardLegs == true && hasPressed == false)
        {
            StartCoroutine(AlreadyBoughtPart());
            hasPressed = true;
            StartCoroutine(PressedButton());
        }

    }

    public void BuySpeedLegs()
    {
        if (credits.credit >= 200 && boughtSpeedLegs == false && hasPressed == false)
        {
            StartCoroutine(NewPartAcquired());
            speedLegsUI.SetActive(true);
            boughtSpeedLegs = true;
            hasPressed = true;
            StartCoroutine(PressedButton());
            credits.Minus200();
        }

        if (credits.credit <= 200 && boughtSpeedLegs == false && hasPressed == false)
        {
            StartCoroutine(NotEnoughMoney());
            hasPressed = true;
            StartCoroutine(PressedButton());
        }

        if (boughtSpeedLegs == true && hasPressed == false)
        {
            StartCoroutine(AlreadyBoughtPart());
            hasPressed = true;
            StartCoroutine(PressedButton());
        }
    }

    public void BuyDefenseLegs()
    {
        if (credits.credit >= 300 && boughtDefenseLegs == false && hasPressed == false)
        {
            StartCoroutine(NewPartAcquired());
            defenseLegsUI.SetActive(true);
            boughtDefenseLegs = true;
            hasPressed = true;
            StartCoroutine(PressedButton());
            credits.Minus300();
        }

        if (credits.credit <= 300 && boughtDefenseLegs == false && hasPressed == false)
        {
            StartCoroutine(NotEnoughMoney());
            hasPressed = true;
            StartCoroutine(PressedButton());
        }

        if (boughtDefenseLegs == true && hasPressed == false)
        {
            StartCoroutine(AlreadyBoughtPart());
            hasPressed = true;
            StartCoroutine(PressedButton());
        }
    }

    //buying weapons

    public void BuyMachineLeft()
    {
        if (credits.credit >= 300 && boughtMachineLeft == false && hasPressed == false)
        {
            StartCoroutine(NewPartAcquired());
            machineLeftUI.SetActive(true);
            boughtMachineLeft = true;
            hasPressed = true;
            StartCoroutine(PressedButton());
            credits.Minus300();
        }

        if (credits.credit <= 300 && boughtMachineLeft == false && hasPressed == false)
        {
            StartCoroutine(NotEnoughMoney());
            hasPressed = true;
            StartCoroutine(PressedButton());
        }

        if (boughtMachineLeft == true && hasPressed == false)
        {
            StartCoroutine(AlreadyBoughtPart());
            hasPressed = true;
            StartCoroutine(PressedButton());
        }
    }
    public void BuyMachineRight() 
    {
        if (credits.credit >= 300 && boughtMachineRight == false && hasPressed == false)
        {
            StartCoroutine(NewPartAcquired());
            machineRightUI.SetActive(true);
            boughtMachineRight = true;
            hasPressed = true;
            StartCoroutine(PressedButton());
            credits.Minus300();
        }

        if (credits.credit <= 300 && boughtMachineRight == false && hasPressed == false)
        {
            StartCoroutine(NotEnoughMoney());
            hasPressed = true;
            StartCoroutine(PressedButton());
        }

        if (boughtMachineRight == true && hasPressed == false)
        {
            StartCoroutine(AlreadyBoughtPart());
            hasPressed = true;
            StartCoroutine(PressedButton());
        }
    }

    public void BuyAssaultLeft()
    {
        if (credits.credit >= 300 && boughtAssaultLeft == false && hasPressed == false)
        {
            StartCoroutine(NewPartAcquired());
            assaultLeftUI.SetActive(true);
            boughtAssaultLeft = true;
            hasPressed = true;
            StartCoroutine(PressedButton());
            credits.Minus300();
        }

        if (credits.credit <= 300 && boughtAssaultLeft == false && hasPressed == false)
        {
            StartCoroutine(NotEnoughMoney());
            hasPressed = true;
            StartCoroutine(PressedButton());
        }

        if (boughtAssaultLeft == true && hasPressed == false)
        {
            StartCoroutine(AlreadyBoughtPart());
            hasPressed = true;
            StartCoroutine(PressedButton());
        }
    }
    public void BuyAssaultRight() 
    {
        if (credits.credit >= 300 && boughtAssaultRight == false && hasPressed == false)
        {
            StartCoroutine(NewPartAcquired());
            assaultRightUI.SetActive(true);
            boughtAssaultRight = true;
            hasPressed = true;
            StartCoroutine(PressedButton());
            credits.Minus300();
        }

        if (credits.credit <= 300 && boughtAssaultRight == false && hasPressed == false)
        {
            StartCoroutine(NotEnoughMoney());
            hasPressed = true;
            StartCoroutine(PressedButton());
        }

        if (boughtAssaultRight == true && hasPressed == false)
        {
            StartCoroutine(AlreadyBoughtPart());
            hasPressed = true;
            StartCoroutine(PressedButton());
        }
    }

    public void BuyLaserLeft()
    {
        if (credits.credit >= 400 && boughtLaserLeft == false && hasPressed == false)
        {
            StartCoroutine(NewPartAcquired());
            laserLeftUI.SetActive(true);
            boughtLaserLeft = true;
            hasPressed = true;
            StartCoroutine(PressedButton());
            credits.Minus400();
        }

        if (credits.credit <= 400 && boughtLaserLeft == false && hasPressed == false)
        {
            StartCoroutine(NotEnoughMoney());
            hasPressed = true;
            StartCoroutine(PressedButton());
        }

        if (boughtLaserLeft == true && hasPressed == false)
        {
            StartCoroutine(AlreadyBoughtPart());
            hasPressed = true;
            StartCoroutine(PressedButton());
        }
    }

    public void BuyLaserRight() 
    {
        if (credits.credit >= 400 && boughtLaserRight == false && hasPressed == false)
        {
            StartCoroutine(NewPartAcquired());
            laserRightUI.SetActive(true);
            boughtLaserRight = true;
            hasPressed = true;
            StartCoroutine(PressedButton());
            credits.Minus400();
        }

        if (credits.credit <= 400 && boughtLaserRight == false && hasPressed == false)
        {
            StartCoroutine(NotEnoughMoney());
            hasPressed = true;
            StartCoroutine(PressedButton());
        }

        if (boughtLaserRight == true && hasPressed == false)
        {
            StartCoroutine(AlreadyBoughtPart());
            hasPressed = true;
            StartCoroutine(PressedButton());
        }
    }

    //buy supers 

    public void BuyLaserSuper()
    {
        if (credits.credit >= 400 && boughtLaserSuper == false && hasPressed == false)
        {
            StartCoroutine(NewPartAcquired());
            laserSuperUI.SetActive(true);
            boughtLaserSuper = true;
            hasPressed = true;
            StartCoroutine(PressedButton());
            credits.Minus400();
        }

        if (credits.credit <= 400 && boughtLaserSuper == false && hasPressed == false)
        {
            StartCoroutine(NotEnoughMoney());
            hasPressed = true;
            StartCoroutine(PressedButton());
        }

        if (boughtLaserSuper == true && hasPressed == false)
        {
            StartCoroutine(AlreadyBoughtPart());
            hasPressed = true;
            StartCoroutine(PressedButton());
        }
    }

    public void BuyOrbitalSuper()
    {
        if (credits.credit >= 300 && boughtOrbitalSuper == false && hasPressed == false)
        {
            StartCoroutine(NewPartAcquired());
            orbitalSuperUI.SetActive(true);
            boughtOrbitalSuper = true;
            hasPressed = true;
            StartCoroutine(PressedButton());
            credits.Minus300();
        }

        if (credits.credit <= 300 && boughtOrbitalSuper == false && hasPressed == false)
        {
            StartCoroutine(NotEnoughMoney());
            hasPressed = true;
            StartCoroutine(PressedButton());
        }

        if (boughtOrbitalSuper == true && hasPressed == false)
        {
            StartCoroutine(AlreadyBoughtPart());
            hasPressed = true;
            StartCoroutine(PressedButton());
        }
    }

    //coroutines

    public IEnumerator NewPartAcquired()
    {
        yield return new WaitForSeconds(0f);
        newPartUnlocked.SetActive(true);
        yield return new WaitForSeconds(2f);
        newPartUnlocked.SetActive(false);
    }

    public IEnumerator NotEnoughMoney()
    {
        yield return new WaitForSeconds(0f);
        notEnoughCredits.SetActive(true);
        yield return new WaitForSeconds(2f);
        notEnoughCredits.SetActive(false);
    }

    public IEnumerator AlreadyBoughtPart()
    {
        yield return new WaitForSeconds(0f);
        partAlreadyBought.SetActive(true);
        yield return new WaitForSeconds(2f);
        partAlreadyBought.SetActive(false);
    }

    public IEnumerator PressedButton()
    {
        yield return new WaitForSeconds(0.1f);
        hasPressed = false;
    }
}
