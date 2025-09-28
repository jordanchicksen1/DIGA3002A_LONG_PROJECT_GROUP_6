using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class equipment : MonoBehaviour
{
    [Header("Scripts")]
    public playerHealth playerHealth;
    public PlayerController playerEdited;

    [Header("Bools")]
    public bool basicHeadEquipped = true;
    public bool basicTorsoEquipped = true;
    public bool basicLegsEquipped = true;
    public bool standardHeadEquipped = false;
    public bool standardTorsoEquipped = false;
    public bool standardLegsEquipped = false;
    public bool speedHeadEquipped = false;
    public bool speedTorsoEquipped = false;
    public bool speedLegsEquipped = false;
    public bool defenceHeadEquipped = false;
    public bool defenceTorsoEquipped = false;
    public bool defenceLegsEquipped = false;
    //bools for weapons and supermoves are on the player script

    [Header("Props")]
    public GameObject basicHead;
    public GameObject basicTorso;
    public GameObject basicLegs;
    public GameObject standardHead;
    public GameObject standardTorso;
    public GameObject standardLegs;
    public GameObject speedHead;
    public GameObject speedTorso;
    public GameObject speedLegs;
    public GameObject defenceHead;
    public GameObject defenceTorso;
    public GameObject defenceLegs;
    public GameObject basicGunLeft;
    public GameObject basicGunRight;
    public GameObject machineGunLeft;
    public GameObject machineGunRight;
    public GameObject assaultGunLeft;
    public GameObject assaultGunRight;
    public GameObject laserGunLeft;
    public GameObject laserGunRight;



    //weapon equipping

    [ContextMenu("Basic Gun Left")]
    public void EquipBasicGunLeft()
    {
        playerEdited.leftBasicEquipped = true;
        playerEdited.leftMachineEquipped = false;
        playerEdited.leftAssaultEquipped = false;
        playerEdited.leftLaserEquipped = false;

        basicGunLeft.SetActive(true);
        machineGunLeft.SetActive(false);
        assaultGunLeft.SetActive(false);
        laserGunLeft.SetActive(false);
    }

    [ContextMenu("Basic Gun Right")]
    public void EquipBasicGunRight()
    {
        playerEdited.rightBasicEquipped = true;
        playerEdited.rightMachineEquipped = false;
        playerEdited.rightAssaultEquipped = false;
        playerEdited.rightLaserEquipped = false;

        basicGunRight.SetActive(true);
        machineGunRight.SetActive(false);
        assaultGunRight.SetActive(false);
        laserGunRight.SetActive(false);
    }

    [ContextMenu("Machine Gun Left")]
    public void EquipMachineGunLeft()
    {
        playerEdited.leftBasicEquipped = false;
        playerEdited.leftMachineEquipped = true;
        playerEdited.leftAssaultEquipped = false;
        playerEdited.leftLaserEquipped = false;

        basicGunLeft.SetActive(false);
        machineGunLeft.SetActive(true);
        assaultGunLeft.SetActive(false);
        laserGunLeft.SetActive(false);
    }

    [ContextMenu("Machine Gun Right")]
    public void EquipMachineGunRight()
    {
        playerEdited.rightBasicEquipped = false;
        playerEdited.rightMachineEquipped = true;
        playerEdited.rightAssaultEquipped = false;
        playerEdited.rightLaserEquipped = false;

        basicGunRight.SetActive(false);
        machineGunRight.SetActive(true);
        assaultGunRight.SetActive(false);
        laserGunRight.SetActive(false);
    }

    [ContextMenu("Assault Gun Left")]
    public void EquipAssaultGunLeft()
    {
        playerEdited.leftBasicEquipped = false;
        playerEdited.leftMachineEquipped = false;
        playerEdited.leftAssaultEquipped = true;
        playerEdited.leftLaserEquipped = false;

        basicGunLeft.SetActive(false);
        machineGunLeft.SetActive(false);
        assaultGunLeft.SetActive(true);
        laserGunLeft.SetActive(false);
    }

    [ContextMenu("Assault Gun Right")]
    public void EquipAssaultGunRight()
    {
        playerEdited.rightBasicEquipped = false;
        playerEdited.rightMachineEquipped = false;
        playerEdited.rightAssaultEquipped = true;
        playerEdited.rightLaserEquipped = false;

        basicGunRight.SetActive(false);
        machineGunRight.SetActive(false);
        assaultGunRight.SetActive(true);
        laserGunRight.SetActive(false);
    }

    [ContextMenu("Laser Gun Left")]
    public void EquipLaserGunLeft()
    {
        playerEdited.leftBasicEquipped = false;
        playerEdited.leftMachineEquipped = false;
        playerEdited.leftAssaultEquipped = false;
        playerEdited.leftLaserEquipped = true;

        basicGunLeft.SetActive(false);
        machineGunLeft.SetActive(false);
        assaultGunLeft.SetActive(false);
        laserGunLeft.SetActive(true);
    }

    [ContextMenu("Laser Gun Right")]
    public void EquipLaserGunRight()
    {
        playerEdited.rightBasicEquipped = false;
        playerEdited.rightMachineEquipped = false;
        playerEdited.rightAssaultEquipped = false;
        playerEdited.rightLaserEquipped = true;

        basicGunRight.SetActive(false);
        machineGunRight.SetActive(false);
        assaultGunRight.SetActive(false);
        laserGunRight.SetActive(true);
    }

    //super move equipping
    [ContextMenu("Basic Super")]
    public void EquipBasicSuper()
    {
        playerEdited.basicSuperEquipped = true;
        playerEdited.laserSuperEquipped = false;
        playerEdited.orbitalSuperEquipped = false;
    }

    [ContextMenu("Laser Super")]
    public void EquipLaserSuper()
    {
        playerEdited.basicSuperEquipped = false;
        playerEdited.laserSuperEquipped = true;
        playerEdited.orbitalSuperEquipped = false;
    }

    [ContextMenu("Orbital Super")]
    public void EquipOrbitalSuper()
    {
        playerEdited.basicSuperEquipped = false;
        playerEdited.laserSuperEquipped = false;
        playerEdited.orbitalSuperEquipped = true;
    }

    //euipping robo parts
    [ContextMenu("Basic Head")]
    public void EquipBasicHead()
    {
        if (speedHeadEquipped == true)
        {
            StartCoroutine(SpeedHeadToBasicHead());
        }

        if (standardHeadEquipped == true)
        {
            StartCoroutine(StandardHeadToBasicHead());
        }

        if (defenceHeadEquipped == true)
        {
            StartCoroutine(DefenceHeadToBasicHead());
        }

    }

    public IEnumerator SpeedHeadToBasicHead()
    {
        yield return new WaitForSeconds(0f);
        //de-equip speed head
        playerEdited.moveSpeed = playerEdited.moveSpeed - 3f;
        playerEdited.originalSpeed = playerEdited.originalSpeed - 3f;
        playerHealth.maxHealth = playerHealth.maxHealth - 25f;
        playerHealth.updateHealthBar();
        speedHead.SetActive(false);
        speedHeadEquipped = false;
        yield return new WaitForSeconds(0.5f);
        //equip basic head
        playerEdited.moveSpeed = playerEdited.moveSpeed + 1.67f;
        playerEdited.originalSpeed = playerEdited.originalSpeed + 1.67f;
        playerHealth.maxHealth = playerHealth.maxHealth + 33.3f;
        playerHealth.updateHealthBar();
        playerHealth.currentHealth = playerHealth.maxHealth;
        basicHeadEquipped = true;
        basicHead.SetActive(true);

    }

    public IEnumerator StandardHeadToBasicHead()
    {
        yield return new WaitForSeconds(0f);
        //de-equip standard head
        playerEdited.moveSpeed = playerEdited.moveSpeed - 2f;
        playerEdited.originalSpeed = playerEdited.originalSpeed - 2f;
        playerHealth.maxHealth = playerHealth.maxHealth - 50f;
        playerHealth.updateHealthBar();
        standardHead.SetActive(false);
        standardHeadEquipped = false;
        yield return new WaitForSeconds(0.5f);
        //equip basic head
        playerEdited.moveSpeed = playerEdited.moveSpeed + 1.67f;
        playerEdited.originalSpeed = playerEdited.originalSpeed + 1.67f;
        playerHealth.maxHealth = playerHealth.maxHealth + 33.3f;
        playerHealth.updateHealthBar();
        playerHealth.currentHealth = playerHealth.maxHealth;
        basicHeadEquipped = true;
        basicHead.SetActive(true);

    }

    public IEnumerator DefenceHeadToBasicHead()
    {
        yield return new WaitForSeconds(0f);
        //de-equip defence head
        playerEdited.moveSpeed = playerEdited.moveSpeed - 1.33f;
        playerEdited.originalSpeed = playerEdited.originalSpeed - 1.33f;
        playerHealth.maxHealth = playerHealth.maxHealth - 66.67f;
        playerHealth.updateHealthBar();
        defenceHeadEquipped = false;
        defenceHead.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        //equip basic head
        playerEdited.moveSpeed = playerEdited.moveSpeed + 1.67f;
        playerEdited.originalSpeed = playerEdited.originalSpeed + 1.67f;
        playerHealth.maxHealth = playerHealth.maxHealth + 33.3f;
        playerHealth.updateHealthBar();
        playerHealth.currentHealth = playerHealth.maxHealth;
        basicHeadEquipped = true;
        basicHead.SetActive(true);

    }

    [ContextMenu("Basic Torso")]
    public void EquipBasicTorso()
    {
        if (speedTorsoEquipped == true)
        {
            StartCoroutine(SpeedTorsoToBasicTorso());
        }

        if (standardTorsoEquipped == true)
        {
            StartCoroutine(StandardTorsoToBasicTorso());
        }

        if (defenceTorsoEquipped == true)
        {
            StartCoroutine(DefenceTorsoToBasicTorso());
        }

    }

    public IEnumerator SpeedTorsoToBasicTorso()
    {
        yield return new WaitForSeconds(0f);
        //de-equip speed torso
        playerEdited.moveSpeed = playerEdited.moveSpeed - 3f;
        playerEdited.originalSpeed = playerEdited.originalSpeed - 3f;
        playerHealth.maxHealth = playerHealth.maxHealth - 25f;
        playerHealth.updateHealthBar();
        speedTorsoEquipped = false;
        speedTorso.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        //equip basic torso
        playerEdited.moveSpeed = playerEdited.moveSpeed + 1.67f;
        playerEdited.originalSpeed = playerEdited.originalSpeed + 1.67f;
        playerHealth.maxHealth = playerHealth.maxHealth + 33.4f;
        playerHealth.updateHealthBar();
        playerHealth.currentHealth = playerHealth.maxHealth;
        basicTorsoEquipped = true;
        basicTorso.SetActive(true);

    }

    public IEnumerator StandardTorsoToBasicTorso()
    {
        yield return new WaitForSeconds(0f);
        //de-equip standard torso
        playerEdited.moveSpeed = playerEdited.moveSpeed - 2f;
        playerEdited.originalSpeed = playerEdited.originalSpeed - 2f;
        playerHealth.maxHealth = playerHealth.maxHealth - 50f;
        playerHealth.updateHealthBar();
        standardTorsoEquipped = false;
        standardTorso.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        //equip basic torso
        playerEdited.moveSpeed = playerEdited.moveSpeed + 1.67f;
        playerEdited.originalSpeed = playerEdited.originalSpeed + 1.67f;
        playerHealth.maxHealth = playerHealth.maxHealth + 33.4f;
        playerHealth.updateHealthBar();
        playerHealth.currentHealth = playerHealth.maxHealth;
        basicTorsoEquipped = true;
        basicTorso.SetActive(true);

    }

    public IEnumerator DefenceTorsoToBasicTorso()
    {
        yield return new WaitForSeconds(0f);
        //de-equip defence torso
        playerEdited.moveSpeed = playerEdited.moveSpeed - 1.33f;
        playerEdited.originalSpeed = playerEdited.originalSpeed - 1.33f;
        playerHealth.maxHealth = playerHealth.maxHealth - 66.67f;
        playerHealth.updateHealthBar();
        defenceTorsoEquipped = false;
        defenceTorso.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        //equip basic torso
        playerEdited.moveSpeed = playerEdited.moveSpeed + 1.67f;
        playerEdited.originalSpeed = playerEdited.originalSpeed + 1.67f;
        playerHealth.maxHealth = playerHealth.maxHealth + 33.4f;
        playerHealth.updateHealthBar();
        playerHealth.currentHealth = playerHealth.maxHealth;
        basicTorsoEquipped = true;
        basicTorso.SetActive(true);

    }

    [ContextMenu("Basic Legs")]
    public void EquipBasicLegs()
    {
        if (speedLegsEquipped == true)
        {
            StartCoroutine(SpeedLegsToBasicLegs());
        }

        if (standardLegsEquipped == true)
        {
            StartCoroutine(StandardLegsToBasicLegs());
        }

        if (defenceLegsEquipped == true)
        {
            StartCoroutine(DefenceLegsToBasicLegs());
        }

    }

    public IEnumerator SpeedLegsToBasicLegs()
    {
        yield return new WaitForSeconds(0f);
        //de-equip speed legs
        playerEdited.moveSpeed = playerEdited.moveSpeed - 3f;
        playerEdited.originalSpeed = playerEdited.originalSpeed - 3f;
        playerHealth.maxHealth = playerHealth.maxHealth - 25f;
        playerHealth.updateHealthBar();
        speedLegsEquipped = false;
        speedLegs.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        //equip basic legs
        playerEdited.moveSpeed = playerEdited.moveSpeed + 1.67f;
        playerEdited.originalSpeed = playerEdited.originalSpeed + 1.67f;
        playerHealth.maxHealth = playerHealth.maxHealth + 33.3f;
        playerHealth.updateHealthBar();
        playerHealth.currentHealth = playerHealth.maxHealth;
        basicLegsEquipped = true;
        basicLegs.SetActive(true);

    }

    public IEnumerator StandardLegsToBasicLegs()
    {
        yield return new WaitForSeconds(0f);
        //de-equip standard legs
        playerEdited.moveSpeed = playerEdited.moveSpeed - 2f;
        playerEdited.originalSpeed = playerEdited.originalSpeed - 2f;
        playerHealth.maxHealth = playerHealth.maxHealth - 50f;
        playerHealth.updateHealthBar();
        standardLegsEquipped = false;
        standardLegs.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        //equip basic legs
        playerEdited.moveSpeed = playerEdited.moveSpeed + 1.67f;
        playerEdited.originalSpeed = playerEdited.originalSpeed + 1.67f;
        playerHealth.maxHealth = playerHealth.maxHealth + 33.3f;
        playerHealth.updateHealthBar();
        playerHealth.currentHealth = playerHealth.maxHealth;
        basicLegsEquipped = true;
        basicLegs.SetActive(true);

    }

    public IEnumerator DefenceLegsToBasicLegs()
    {
        yield return new WaitForSeconds(0f);
        //de-equip defence legs
        playerEdited.moveSpeed = playerEdited.moveSpeed - 1.34f;
        playerEdited.originalSpeed = playerEdited.originalSpeed - 1.34f;
        playerHealth.maxHealth = playerHealth.maxHealth - 66.67f;
        playerHealth.updateHealthBar();
        defenceLegsEquipped = false;
        defenceLegs.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        //equip basic legs
        playerEdited.moveSpeed = playerEdited.moveSpeed + 1.67f;
        playerEdited.originalSpeed = playerEdited.originalSpeed + 1.67f;
        playerHealth.maxHealth = playerHealth.maxHealth + 33.3f;
        playerHealth.currentHealth = playerHealth.maxHealth;
        playerHealth.updateHealthBar();
        basicLegsEquipped = true;
        basicLegs.SetActive(true);

    }

    [ContextMenu("Standard Head")]
    public void EquipStandardHead()
    {
        if (speedHeadEquipped == true)
        {

        }

        if (defenceHeadEquipped == true)
        {

        }

        if(basicHeadEquipped == true)
        {

        }

    } 
}


