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
    //buying heads
    public void BuyStandardHead()
    {
        if(credits.credit >= 100 && boughtStandardHead == false)
        {
            StartCoroutine(NewPartAcquired());
            standardHeadUI.SetActive(true);
            boughtStandardHead = true;
        }

        if(credits.credit <= 100 &&  boughtStandardHead == false)
        {
            StartCoroutine(NotEnoughMoney());
        }

        if (boughtStandardHead == true)
        {
            StartCoroutine(AlreadyBoughtPart());
        }

    }

    public void BuySpeedHead()
    {
        if (credits.credit >= 200 && boughtSpeedHead == false)
        {
            StartCoroutine(NewPartAcquired());
            speedHeadUI.SetActive(true);
            boughtSpeedHead = true;
        }

        if (credits.credit <= 200 && boughtSpeedHead == false)
        {
            StartCoroutine(NotEnoughMoney());
        }

        if (boughtSpeedHead == true)
        {
            StartCoroutine(AlreadyBoughtPart());
        }
    }

    public void BuyDefenseHead() 
    {
        if (credits.credit >= 300 && boughtDefenseHead == false)
        {
            StartCoroutine(NewPartAcquired());
            defenseHeadUI.SetActive(true);
            boughtDefenseHead = true;
        }

        if (credits.credit <= 300 && boughtDefenseHead == false)
        {
            StartCoroutine(NotEnoughMoney());
        }

        if (boughtDefenseHead == true)
        {
            StartCoroutine(AlreadyBoughtPart());
        }
    }

    //buying torsos

    public void BuyStandardTorso()
    {
        if (credits.credit >= 100 && boughtStandardTorso == false)
        {
            StartCoroutine(NewPartAcquired());
            standardTorsoUI.SetActive(true);
            boughtStandardTorso = true;
        }

        if (credits.credit <= 100 && boughtStandardTorso == false)
        {
            StartCoroutine(NotEnoughMoney());
        }

        if (boughtStandardTorso == true)
        {
            StartCoroutine(AlreadyBoughtPart());
        }
    }

    public void BuySpeedTorso() 
    {
        if (credits.credit >= 200 && boughtSpeedTorso == false)
        {
            StartCoroutine(NewPartAcquired());
            speedTorsoUI.SetActive(true);
            boughtSpeedTorso = true;
        }

        if (credits.credit <= 200 && boughtSpeedTorso == false)
        {
            StartCoroutine(NotEnoughMoney());
        }

        if (boughtSpeedTorso == true)
        {
            StartCoroutine(AlreadyBoughtPart());
        }
    }

    public void BuyDefenseTorso()
    {
        if (credits.credit >= 300 && boughtDefenseTorso == false)
        {
            StartCoroutine(NewPartAcquired());
            defenseTorsoUI.SetActive(true);
            boughtDefenseTorso = true;
        }

        if (credits.credit <= 300 && boughtDefenseTorso == false)
        {
            StartCoroutine(NotEnoughMoney());
        }

        if (boughtDefenseTorso == true)
        {
            StartCoroutine(AlreadyBoughtPart());
        }
    }

    //buying legs

    public void BuyStandardLegs()
    {
        if (credits.credit >= 100 && boughtStandardLegs == false)
        {
            StartCoroutine(NewPartAcquired());
            standardLegsUI.SetActive(true);
            boughtStandardLegs = true;
        }

        if (credits.credit <= 100 && boughtStandardLegs == false)
        {
            StartCoroutine(NotEnoughMoney());
        }

        if (boughtStandardLegs == true)
        {
            StartCoroutine(AlreadyBoughtPart());
        }

    }

    public void BuySpeedLegs()
    {
        if (credits.credit >= 200 && boughtSpeedLegs == false)
        {
            StartCoroutine(NewPartAcquired());
            speedLegsUI.SetActive(true);
            boughtSpeedLegs = true;
        }

        if (credits.credit <= 200 && boughtSpeedLegs == false)
        {
            StartCoroutine(NotEnoughMoney());
        }

        if (boughtSpeedLegs == true)
        {
            StartCoroutine(AlreadyBoughtPart());
        }
    }

    public void BuyDefenseLegs()
    {
        if (credits.credit >= 300 && boughtDefenseLegs == false)
        {
            StartCoroutine(NewPartAcquired());
            defenseLegsUI.SetActive(true);
            boughtDefenseLegs = true;
        }

        if (credits.credit <= 300 && boughtDefenseLegs == false)
        {
            StartCoroutine(NotEnoughMoney());
        }

        if (boughtDefenseLegs == true)
        {
            StartCoroutine(AlreadyBoughtPart());
        }
    }

    //buying weapons

    public void BuyMachineLeft()
    {
        if (credits.credit >= 300 && boughtMachineLeft == false)
        {
            StartCoroutine(NewPartAcquired());
            machineLeftUI.SetActive(true);
            boughtMachineLeft = true;
        }

        if (credits.credit <= 300 && boughtMachineLeft == false)
        {
            StartCoroutine(NotEnoughMoney());
        }

        if (boughtMachineLeft == true)
        {
            StartCoroutine(AlreadyBoughtPart());
        }
    }
    public void BuyMachineRight() 
    {
        if (credits.credit >= 300 && boughtMachineRight == false)
        {
            StartCoroutine(NewPartAcquired());
            machineRightUI.SetActive(true);
            boughtMachineRight = true;
        }

        if (credits.credit <= 300 && boughtMachineRight == false)
        {
            StartCoroutine(NotEnoughMoney());
        }

        if (boughtMachineRight == true)
        {
            StartCoroutine(AlreadyBoughtPart());
        }
    }

    public void BuyAssaultLeft()
    {
        if (credits.credit >= 300 && boughtAssaultLeft == false)
        {
            StartCoroutine(NewPartAcquired());
            assaultLeftUI.SetActive(true);
            boughtAssaultLeft = true;
        }

        if (credits.credit <= 300 && boughtAssaultLeft == false)
        {
            StartCoroutine(NotEnoughMoney());
        }

        if (boughtAssaultLeft == true)
        {
            StartCoroutine(AlreadyBoughtPart());
        }
    }
    public void BuyAssaultRight() 
    {
        if (credits.credit >= 300 && boughtAssaultRight == false)
        {
            StartCoroutine(NewPartAcquired());
            assaultRightUI.SetActive(true);
            boughtAssaultRight = true;
        }

        if (credits.credit <= 300 && boughtAssaultRight == false)
        {
            StartCoroutine(NotEnoughMoney());
        }

        if (boughtAssaultRight == true)
        {
            StartCoroutine(AlreadyBoughtPart());
        }
    }

    public void BuyLaserLeft()
    {
        if (credits.credit >= 400 && boughtLaserLeft == false)
        {
            StartCoroutine(NewPartAcquired());
            laserLeftUI.SetActive(true);
            boughtLaserLeft = true;
        }

        if (credits.credit <= 400 && boughtLaserLeft == false)
        {
            StartCoroutine(NotEnoughMoney());
        }

        if (boughtLaserLeft == true)
        {
            StartCoroutine(AlreadyBoughtPart());
        }
    }

    public void BuyLaserRight() 
    {
        if (credits.credit >= 400 && boughtLaserRight == false)
        {
            StartCoroutine(NewPartAcquired());
            laserRightUI.SetActive(true);
            boughtLaserRight = true;
        }

        if (credits.credit <= 400 && boughtLaserRight == false)
        {
            StartCoroutine(NotEnoughMoney());
        }

        if (boughtLaserRight == true)
        {
            StartCoroutine(AlreadyBoughtPart());
        }
    }

    //buy supers 

    public void BuyLaserSuper()
    {
        if (credits.credit >= 400 && boughtLaserSuper == false)
        {
            StartCoroutine(NewPartAcquired());
            laserSuperUI.SetActive(true);
            boughtLaserSuper = true;
        }

        if (credits.credit <= 400 && boughtLaserSuper == false)
        {
            StartCoroutine(NotEnoughMoney());
        }

        if (boughtLaserSuper == true)
        {
            StartCoroutine(AlreadyBoughtPart());
        }
    }

    public void BuyOrbitalSuper()
    {
        if (credits.credit >= 300 && boughtOrbitalSuper == false)
        {
            StartCoroutine(NewPartAcquired());
            orbitalSuperUI.SetActive(true);
            boughtOrbitalSuper = true;
        }

        if (credits.credit <= 300 && boughtOrbitalSuper == false)
        {
            StartCoroutine(NotEnoughMoney());
        }

        if (boughtOrbitalSuper == true)
        {
            StartCoroutine(AlreadyBoughtPart());
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
}
