using System;
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

    [Header("Basic Part Stats")]
    public float basicHeadHP = 33.3f;
    public float basicHeadSpeed = 1.67f;
    public float basicTorsoHP = 33.4f;
    public float basicTorsoSpeed = 1.67f;
    public float basicLegsHP = 33.3f;
    public float basicLegsSpeed = 1.67f;

    [Header("Standard Part Stats")]
    public float standardHeadHP = 50f;
    public float standardHeadSpeed = 2f;
    public float standardTorsoHP = 50f;
    public float standardTorsoSpeed = 2f;
    public float standardLegsHP = 50f;
    public float standardLegsSpeed = 2f;

    [Header("Speed Part Stats")]
    public float speedHeadHP = 25f;
    public float speedHeadSpeed = 3f;
    public float speedTorsoHP = 25f;
    public float speedTorsoSpeed = 3f;
    public float speedLegsHP = 25f;
    public float speedLegsSpeed = 3f;

    [Header("Defence Part Stats")]
    public float defenceHeadHP = 66.67f;
    public float defenceHeadSpeed = 1.33f;
    public float defenceTorsoHP = 66.67f;
    public float defenceTorsoSpeed = 1.34f;
    public float defenceLegsHP = 66.67f;
    public float defenceLegsSpeed = 1.33f;

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

    [Header("UI Equipped Images")]
    public GameObject equippedBasicHead;
    public GameObject equippedBasicTorso;
    public GameObject equippedBasicLegs;
    public GameObject equippedStandardHead;
    public GameObject equippedStandardTorso;
    public GameObject equippedStandardLegs;
    public GameObject equippedSpeedHead;
    public GameObject equippedSpeedTorso;
    public GameObject equippedSpeedLegs;
    public GameObject equippedDefenceHead;
    public GameObject equippedDefenceTorso;
    public GameObject equippedDefenceLegs;
    public GameObject equippedBasicGunLeft;
    public GameObject equippedBasicGunRight;
    public GameObject equippedAssaultGunLeft;
    public GameObject equippedAssaultGunRight;
    public GameObject equippedMachineGunLeft;
    public GameObject equippedMachineGunRight;
    public GameObject equippedLaserGunLeft;
    public GameObject equippedLaserGunRight;
    public GameObject equippedShieldSuper;
    public GameObject equippedLaserSuper;
    public GameObject equippedOrbitalSuper;

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

        equippedBasicGunLeft.SetActive(true);
        equippedAssaultGunLeft.SetActive(false);
        equippedMachineGunLeft.SetActive(false);
        equippedLaserGunLeft.SetActive(false);
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

        equippedBasicGunRight.SetActive(true);
        equippedAssaultGunRight.SetActive(false);
        equippedMachineGunRight.SetActive(false);
        equippedLaserGunRight.SetActive(false);
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

        equippedBasicGunLeft.SetActive(false);
        equippedAssaultGunLeft.SetActive(false);
        equippedMachineGunLeft.SetActive(true);
        equippedLaserGunLeft.SetActive(false);
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

        equippedBasicGunRight.SetActive(false);
        equippedAssaultGunRight.SetActive(false);
        equippedMachineGunRight.SetActive(true);
        equippedLaserGunRight.SetActive(false);
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

        equippedBasicGunLeft.SetActive(false);
        equippedAssaultGunLeft.SetActive(true);
        equippedMachineGunLeft.SetActive(false);
        equippedLaserGunLeft.SetActive(false);
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

        equippedBasicGunRight.SetActive(false);
        equippedAssaultGunRight.SetActive(true);
        equippedMachineGunRight.SetActive(false);
        equippedLaserGunRight.SetActive(false);
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

        equippedBasicGunLeft.SetActive(false);
        equippedAssaultGunLeft.SetActive(false);
        equippedMachineGunLeft.SetActive(false);
        equippedLaserGunLeft.SetActive(true);
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

        equippedBasicGunRight.SetActive(false);
        equippedAssaultGunRight.SetActive(false);
        equippedMachineGunRight.SetActive(false);
        equippedLaserGunRight.SetActive(true);
    }

    //super move equipping
    [ContextMenu("Basic Super")]
    public void EquipBasicSuper()
    {
        playerEdited.basicSuperEquipped = true;
        playerEdited.laserSuperEquipped = false;
        playerEdited.orbitalSuperEquipped = false;

        equippedShieldSuper.SetActive(true);
        equippedLaserSuper.SetActive(false);
        equippedOrbitalSuper.SetActive(false);
    }

    [ContextMenu("Laser Super")]
    public void EquipLaserSuper()
    {
        playerEdited.basicSuperEquipped = false;
        playerEdited.laserSuperEquipped = true;
        playerEdited.orbitalSuperEquipped = false;

        equippedShieldSuper.SetActive(false);
        equippedLaserSuper.SetActive(true);
        equippedOrbitalSuper.SetActive(false);
    }

    [ContextMenu("Orbital Super")]
    public void EquipOrbitalSuper()
    {
        playerEdited.basicSuperEquipped = false;
        playerEdited.laserSuperEquipped = false;
        playerEdited.orbitalSuperEquipped = true;

        equippedShieldSuper.SetActive(false);
        equippedLaserSuper.SetActive(false);
        equippedOrbitalSuper.SetActive(true);
    }

    //euipping robo parts
    [ContextMenu("Basic Head")]
    public void EquipBasicHead()
    {
        if (speedHeadEquipped == true)
        {
            StartCoroutine(SpeedHeadToBasicHead());
            equippedSpeedHead.SetActive(false);
            equippedBasicHead.SetActive(true);
        }

        if (standardHeadEquipped == true)
        {
            StartCoroutine(StandardHeadToBasicHead());
            equippedStandardHead.SetActive(false);
            equippedBasicHead.SetActive(true);
        }

        if (defenceHeadEquipped == true)
        {
            StartCoroutine(DefenceHeadToBasicHead());
            equippedDefenceHead.SetActive(false);
            equippedBasicHead.SetActive(true);
        }

    }

    public IEnumerator SpeedHeadToBasicHead()
    {
        yield return new WaitForSeconds(0f);
        //de-equip speed head
        playerEdited.moveSpeed = playerEdited.moveSpeed - speedHeadSpeed;
        playerEdited.originalSpeed = playerEdited.originalSpeed - speedHeadSpeed;
        playerHealth.maxHealth = playerHealth.maxHealth - speedHeadHP;
        playerHealth.updateHealthBar();
        speedHead.SetActive(false);
        speedHeadEquipped = false;
        yield return new WaitForSeconds(0.1f);
        //equip basic head
        playerEdited.moveSpeed = playerEdited.moveSpeed + basicHeadSpeed;
        playerEdited.originalSpeed = playerEdited.originalSpeed + basicHeadSpeed;
        playerHealth.maxHealth = playerHealth.maxHealth + basicHeadHP;
        playerHealth.updateHealthBar();
        playerHealth.currentHealth = playerHealth.maxHealth;
        basicHeadEquipped = true;
        basicHead.SetActive(true);

    }

    public IEnumerator StandardHeadToBasicHead()
    {
        yield return new WaitForSeconds(0f);
        //de-equip standard head
        playerEdited.moveSpeed = playerEdited.moveSpeed - standardHeadSpeed;
        playerEdited.originalSpeed = playerEdited.originalSpeed - standardHeadSpeed;
        playerHealth.maxHealth = playerHealth.maxHealth - standardHeadHP;
        playerHealth.updateHealthBar();
        standardHead.SetActive(false);
        standardHeadEquipped = false;
        yield return new WaitForSeconds(0.1f);
        //equip basic head
        playerEdited.moveSpeed = playerEdited.moveSpeed + basicHeadSpeed;
        playerEdited.originalSpeed = playerEdited.originalSpeed + basicHeadSpeed;
        playerHealth.maxHealth = playerHealth.maxHealth + basicHeadHP;
        playerHealth.updateHealthBar();
        playerHealth.currentHealth = playerHealth.maxHealth;
        basicHeadEquipped = true;
        basicHead.SetActive(true);

    }

    public IEnumerator DefenceHeadToBasicHead()
    {
        yield return new WaitForSeconds(0f);
        //de-equip defence head
        playerEdited.moveSpeed = playerEdited.moveSpeed - defenceHeadSpeed;
        playerEdited.originalSpeed = playerEdited.originalSpeed - defenceHeadSpeed;
        playerHealth.maxHealth = playerHealth.maxHealth - defenceHeadHP;
        playerHealth.updateHealthBar();
        defenceHeadEquipped = false;
        defenceHead.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        //equip basic head
        playerEdited.moveSpeed = playerEdited.moveSpeed + basicHeadSpeed;
        playerEdited.originalSpeed = playerEdited.originalSpeed + basicHeadSpeed;
        playerHealth.maxHealth = playerHealth.maxHealth + basicHeadHP;
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
            equippedSpeedTorso.SetActive(false);
            equippedBasicTorso.SetActive(true);
        }

        if (standardTorsoEquipped == true)
        {
            StartCoroutine(StandardTorsoToBasicTorso());
            equippedStandardLegs.SetActive(false);
            equippedBasicTorso.SetActive(true);
        }

        if (defenceTorsoEquipped == true)
        {
            StartCoroutine(DefenceTorsoToBasicTorso());
            equippedDefenceTorso.SetActive(false);
            equippedBasicTorso.SetActive(true);
        }

    }

    public IEnumerator SpeedTorsoToBasicTorso()
    {
        yield return new WaitForSeconds(0f);
        //de-equip speed torso
        playerEdited.moveSpeed = playerEdited.moveSpeed - speedTorsoSpeed;
        playerEdited.originalSpeed = playerEdited.originalSpeed - speedTorsoSpeed;
        playerHealth.maxHealth = playerHealth.maxHealth - speedTorsoHP;
        playerHealth.updateHealthBar();
        speedTorsoEquipped = false;
        speedTorso.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        //equip basic torso
        playerEdited.moveSpeed = playerEdited.moveSpeed + basicTorsoSpeed;
        playerEdited.originalSpeed = playerEdited.originalSpeed + basicTorsoSpeed;
        playerHealth.maxHealth = playerHealth.maxHealth + basicTorsoHP;
        playerHealth.updateHealthBar();
        playerHealth.currentHealth = playerHealth.maxHealth;
        basicTorsoEquipped = true;
        basicTorso.SetActive(true);

    }

    public IEnumerator StandardTorsoToBasicTorso()
    {
        yield return new WaitForSeconds(0f);
        //de-equip standard torso
        playerEdited.moveSpeed = playerEdited.moveSpeed - standardTorsoSpeed;
        playerEdited.originalSpeed = playerEdited.originalSpeed - standardTorsoSpeed;
        playerHealth.maxHealth = playerHealth.maxHealth - standardTorsoHP;
        playerHealth.updateHealthBar();
        standardTorsoEquipped = false;
        standardTorso.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        //equip basic torso
        playerEdited.moveSpeed = playerEdited.moveSpeed + basicTorsoSpeed;
        playerEdited.originalSpeed = playerEdited.originalSpeed + basicTorsoSpeed;
        playerHealth.maxHealth = playerHealth.maxHealth + basicTorsoHP;
        playerHealth.updateHealthBar();
        playerHealth.currentHealth = playerHealth.maxHealth;
        basicTorsoEquipped = true;
        basicTorso.SetActive(true);

    }

    public IEnumerator DefenceTorsoToBasicTorso()
    {
        yield return new WaitForSeconds(0f);
        //de-equip defence torso
        playerEdited.moveSpeed = playerEdited.moveSpeed - defenceTorsoSpeed;
        playerEdited.originalSpeed = playerEdited.originalSpeed - defenceTorsoSpeed;
        playerHealth.maxHealth = playerHealth.maxHealth - defenceTorsoHP;
        playerHealth.updateHealthBar();
        defenceTorsoEquipped = false;
        defenceTorso.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        //equip basic torso
        playerEdited.moveSpeed = playerEdited.moveSpeed + basicTorsoSpeed;
        playerEdited.originalSpeed = playerEdited.originalSpeed + basicTorsoSpeed;
        playerHealth.maxHealth = playerHealth.maxHealth + basicTorsoHP;
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
            equippedSpeedLegs.SetActive(false);
            equippedBasicLegs.SetActive(true);
        }

        if (standardLegsEquipped == true)
        {
            StartCoroutine(StandardLegsToBasicLegs());
            equippedStandardLegs.SetActive(false);
            equippedBasicLegs.SetActive(true);
        }

        if (defenceLegsEquipped == true)
        {
            StartCoroutine(DefenceLegsToBasicLegs());
            equippedDefenceLegs.SetActive(false);
            equippedBasicLegs.SetActive(true);
        }

    }

    public IEnumerator SpeedLegsToBasicLegs()
    {
        yield return new WaitForSeconds(0f);
        //de-equip speed legs
        playerEdited.moveSpeed = playerEdited.moveSpeed - speedLegsSpeed;
        playerEdited.originalSpeed = playerEdited.originalSpeed - speedLegsSpeed;
        playerHealth.maxHealth = playerHealth.maxHealth - speedLegsHP;
        playerHealth.updateHealthBar();
        speedLegsEquipped = false;
        speedLegs.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        //equip basic legs
        playerEdited.moveSpeed = playerEdited.moveSpeed + basicLegsSpeed;
        playerEdited.originalSpeed = playerEdited.originalSpeed + basicLegsSpeed;
        playerHealth.maxHealth = playerHealth.maxHealth + basicLegsHP;
        playerHealth.updateHealthBar();
        playerHealth.currentHealth = playerHealth.maxHealth;
        basicLegsEquipped = true;
        basicLegs.SetActive(true);

    }

    public IEnumerator StandardLegsToBasicLegs()
    {
        yield return new WaitForSeconds(0f);
        //de-equip standard legs
        playerEdited.moveSpeed = playerEdited.moveSpeed - standardLegsSpeed;
        playerEdited.originalSpeed = playerEdited.originalSpeed - standardLegsSpeed;
        playerHealth.maxHealth = playerHealth.maxHealth - standardLegsHP;
        playerHealth.updateHealthBar();
        standardLegsEquipped = false;
        standardLegs.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        //equip basic legs
        playerEdited.moveSpeed = playerEdited.moveSpeed + basicLegsSpeed;
        playerEdited.originalSpeed = playerEdited.originalSpeed + basicLegsSpeed;
        playerHealth.maxHealth = playerHealth.maxHealth + basicLegsHP;
        playerHealth.updateHealthBar();
        playerHealth.currentHealth = playerHealth.maxHealth;
        basicLegsEquipped = true;
        basicLegs.SetActive(true);

    }

    public IEnumerator DefenceLegsToBasicLegs()
    {
        yield return new WaitForSeconds(0f);
        //de-equip defence legs
        playerEdited.moveSpeed = playerEdited.moveSpeed - defenceLegsSpeed;
        playerEdited.originalSpeed = playerEdited.originalSpeed - defenceLegsSpeed;
        playerHealth.maxHealth = playerHealth.maxHealth - defenceLegsHP;
        playerHealth.updateHealthBar();
        defenceLegsEquipped = false;
        defenceLegs.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        //equip basic legs
        playerEdited.moveSpeed = playerEdited.moveSpeed + basicLegsSpeed;
        playerEdited.originalSpeed = playerEdited.originalSpeed + basicLegsSpeed;
        playerHealth.maxHealth = playerHealth.maxHealth + basicLegsHP;
        playerHealth.updateHealthBar();
        playerHealth.currentHealth = playerHealth.maxHealth;
        basicLegsEquipped = true;
        basicLegs.SetActive(true);

    }

    [ContextMenu("Standard Head")]
    public void EquipStandardHead()
    {
        if (speedHeadEquipped == true)
        {
            StartCoroutine(SpeedHeadToStandardHead());
            equippedSpeedHead.SetActive(false);
            equippedStandardHead.SetActive(true);
        }

        if (defenceHeadEquipped == true)
        {
            StartCoroutine(DefenceHeadToStandardHead());
            equippedDefenceHead.SetActive(false);
            equippedStandardHead.SetActive(true);
        }

        if(basicHeadEquipped == true)
        {
            StartCoroutine(BasicHeadToStandardHead());
            equippedBasicHead.SetActive(false);
            equippedStandardHead.SetActive(true);
        }

    }

    public IEnumerator SpeedHeadToStandardHead()
    {
        yield return new WaitForSeconds(0f);
        //de-equip speed head
        playerEdited.moveSpeed = playerEdited.moveSpeed - speedHeadSpeed;
        playerEdited.originalSpeed = playerEdited.originalSpeed - speedHeadSpeed;
        playerHealth.maxHealth = playerHealth.maxHealth - speedHeadHP;
        playerHealth.updateHealthBar();
        speedHead.SetActive(false);
        speedHeadEquipped = false;
        yield return new WaitForSeconds(0.1f);
        //equip standard head
        playerEdited.moveSpeed = playerEdited.moveSpeed + standardHeadSpeed;
        playerEdited.originalSpeed = playerEdited.originalSpeed + standardHeadSpeed;
        playerHealth.maxHealth = playerHealth.maxHealth + standardHeadHP;
        playerHealth.updateHealthBar();
        playerHealth.currentHealth = playerHealth.maxHealth;
        standardHeadEquipped = true;
        standardHead.SetActive(true);

    }

    public IEnumerator DefenceHeadToStandardHead()
    {
        yield return new WaitForSeconds(0f);
        //de-equip defence head
        playerEdited.moveSpeed = playerEdited.moveSpeed - defenceHeadSpeed;
        playerEdited.originalSpeed = playerEdited.originalSpeed - defenceHeadSpeed;
        playerHealth.maxHealth = playerHealth.maxHealth - defenceHeadHP;
        playerHealth.updateHealthBar();
        defenceHead.SetActive(false);
        defenceHeadEquipped = false;
        yield return new WaitForSeconds(0.1f);
        //equip standard head
        playerEdited.moveSpeed = playerEdited.moveSpeed + standardHeadSpeed;
        playerEdited.originalSpeed = playerEdited.originalSpeed + standardHeadSpeed;
        playerHealth.maxHealth = playerHealth.maxHealth + standardHeadHP;
        playerHealth.updateHealthBar();
        playerHealth.currentHealth = playerHealth.maxHealth;
        standardHeadEquipped = true;
        standardHead.SetActive(true);

    }

    public IEnumerator BasicHeadToStandardHead()
    {
        yield return new WaitForSeconds(0f);
        //de-equip basic head
        playerEdited.moveSpeed = playerEdited.moveSpeed - basicHeadSpeed;
        playerEdited.originalSpeed = playerEdited.originalSpeed - basicHeadSpeed;
        playerHealth.maxHealth = playerHealth.maxHealth - basicHeadHP;
        playerHealth.updateHealthBar();
        basicHead.SetActive(false);
        basicHeadEquipped = false;
        yield return new WaitForSeconds(0.1f);
        //equip standard head
        playerEdited.moveSpeed = playerEdited.moveSpeed + standardHeadSpeed;
        playerEdited.originalSpeed = playerEdited.originalSpeed + standardHeadSpeed;
        playerHealth.maxHealth = playerHealth.maxHealth + standardHeadHP;
        playerHealth.updateHealthBar();
        playerHealth.currentHealth = playerHealth.maxHealth;
        standardHeadEquipped = true;
        standardHead.SetActive(true);

    }

    [ContextMenu("Standard Torso")]
    public void EquipStandardTorso()
    {
        if (speedTorsoEquipped == true)
        {
            StartCoroutine(SpeedTorsoToStandardTorso());
            equippedSpeedTorso.SetActive(false);
            equippedStandardTorso.SetActive(true);
        }

        if (defenceTorsoEquipped == true)
        {
            StartCoroutine(DefenceTorsoToStandardTorso());
            equippedDefenceTorso.SetActive(false);
            equippedStandardTorso.SetActive(true);
        }

        if (basicTorsoEquipped == true)
        {
            StartCoroutine(BasicTorsoToStandardTorso());
            equippedBasicTorso.SetActive(false);
            equippedStandardTorso.SetActive(true);
        }

    }

    public IEnumerator SpeedTorsoToStandardTorso()
    {
        yield return new WaitForSeconds(0f);
        //de-equip speed torso
        playerEdited.moveSpeed = playerEdited.moveSpeed - speedTorsoSpeed;
        playerEdited.originalSpeed = playerEdited.originalSpeed - speedTorsoSpeed;
        playerHealth.maxHealth = playerHealth.maxHealth - speedTorsoHP;
        playerHealth.updateHealthBar();
        speedTorso.SetActive(false);
        speedTorsoEquipped = false;
        yield return new WaitForSeconds(0.1f);
        //equip standard torso
        playerEdited.moveSpeed = playerEdited.moveSpeed + standardTorsoSpeed;
        playerEdited.originalSpeed = playerEdited.originalSpeed + standardTorsoSpeed;
        playerHealth.maxHealth = playerHealth.maxHealth + standardTorsoHP;
        playerHealth.updateHealthBar();
        playerHealth.currentHealth = playerHealth.maxHealth;
        standardTorsoEquipped = true;
        standardTorso.SetActive(true);

    }

    public IEnumerator DefenceTorsoToStandardTorso()
    {
        yield return new WaitForSeconds(0f);
        //de-equip defence torso
        playerEdited.moveSpeed = playerEdited.moveSpeed - defenceTorsoSpeed;
        playerEdited.originalSpeed = playerEdited.originalSpeed - defenceTorsoSpeed;
        playerHealth.maxHealth = playerHealth.maxHealth - defenceTorsoHP;
        playerHealth.updateHealthBar();
        defenceTorso.SetActive(false);
        defenceTorsoEquipped = false;
        yield return new WaitForSeconds(0.1f);
        //equip standard torso
        playerEdited.moveSpeed = playerEdited.moveSpeed + standardTorsoSpeed;
        playerEdited.originalSpeed = playerEdited.originalSpeed + standardTorsoSpeed;
        playerHealth.maxHealth = playerHealth.maxHealth + standardTorsoHP;
        playerHealth.updateHealthBar();
        playerHealth.currentHealth = playerHealth.maxHealth;
        standardTorsoEquipped = true;
        standardTorso.SetActive(true);

    }

    public IEnumerator BasicTorsoToStandardTorso()
    {
        yield return new WaitForSeconds(0f);
        //de-equip basic torso
        playerEdited.moveSpeed = playerEdited.moveSpeed - basicTorsoSpeed;
        playerEdited.originalSpeed = playerEdited.originalSpeed - basicTorsoSpeed;
        playerHealth.maxHealth = playerHealth.maxHealth - basicTorsoHP;
        playerHealth.updateHealthBar();
        basicTorso.SetActive(false);
        basicTorsoEquipped = false;
        yield return new WaitForSeconds(0.1f);
        //equip standard torso
        playerEdited.moveSpeed = playerEdited.moveSpeed + standardTorsoSpeed;
        playerEdited.originalSpeed = playerEdited.originalSpeed + standardTorsoSpeed;
        playerHealth.maxHealth = playerHealth.maxHealth + standardTorsoHP;
        playerHealth.updateHealthBar();
        playerHealth.currentHealth = playerHealth.maxHealth;
        standardTorsoEquipped = true;
        standardTorso.SetActive(true);

    }

    [ContextMenu("Standard Legs")]
    public void EquipStandardLegs()
    {
        if (speedLegsEquipped == true)
        {
            StartCoroutine(SpeedLegsToStandardLegs());
            equippedSpeedLegs.SetActive(false);
            equippedStandardLegs.SetActive(true);
        }

        if (defenceLegsEquipped == true)
        {
            StartCoroutine(DefenceLegsToStandardLegs());
            equippedDefenceLegs.SetActive(false);
            equippedStandardLegs.SetActive(true);
        }

        if (basicLegsEquipped == true)
        {
            StartCoroutine(BasicLegsToStandardLegs());
            equippedBasicLegs.SetActive(false);
            equippedStandardLegs.SetActive(true);
        }

    }

    public IEnumerator SpeedLegsToStandardLegs()
    {
        yield return new WaitForSeconds(0f);
        //de-equip speed legs
        playerEdited.moveSpeed = playerEdited.moveSpeed - speedLegsSpeed;
        playerEdited.originalSpeed = playerEdited.originalSpeed - speedLegsSpeed;
        playerHealth.maxHealth = playerHealth.maxHealth - speedLegsHP;
        playerHealth.updateHealthBar();
        speedLegs.SetActive(false);
        speedLegsEquipped = false;
        yield return new WaitForSeconds(0.1f);
        //equip standard legs
        playerEdited.moveSpeed = playerEdited.moveSpeed + standardLegsSpeed;
        playerEdited.originalSpeed = playerEdited.originalSpeed + standardLegsSpeed;
        playerHealth.maxHealth = playerHealth.maxHealth + standardLegsHP;
        playerHealth.updateHealthBar();
        playerHealth.currentHealth = playerHealth.maxHealth;
        standardLegsEquipped = true;
        standardLegs.SetActive(true);

    }

    public IEnumerator DefenceLegsToStandardLegs()
    {
        yield return new WaitForSeconds(0f);
        //de-equip defence legs
        playerEdited.moveSpeed = playerEdited.moveSpeed - defenceLegsSpeed;
        playerEdited.originalSpeed = playerEdited.originalSpeed - defenceLegsSpeed;
        playerHealth.maxHealth = playerHealth.maxHealth - defenceLegsHP;
        playerHealth.updateHealthBar();
        defenceLegs.SetActive(false);
        defenceLegsEquipped = false;
        yield return new WaitForSeconds(0.1f);
        //equip standard legs
        playerEdited.moveSpeed = playerEdited.moveSpeed + standardLegsSpeed;
        playerEdited.originalSpeed = playerEdited.originalSpeed + standardLegsSpeed;
        playerHealth.maxHealth = playerHealth.maxHealth + standardLegsHP;
        playerHealth.updateHealthBar();
        playerHealth.currentHealth = playerHealth.maxHealth;
        standardLegsEquipped = true;
        standardLegs.SetActive(true);

    }

    public IEnumerator BasicLegsToStandardLegs()
    {
        yield return new WaitForSeconds(0f);
        //de-equip basic legs
        playerEdited.moveSpeed = playerEdited.moveSpeed - basicLegsSpeed;
        playerEdited.originalSpeed = playerEdited.originalSpeed - basicLegsSpeed;
        playerHealth.maxHealth = playerHealth.maxHealth - basicLegsHP;
        playerHealth.updateHealthBar();
        basicLegs.SetActive(false);
        basicLegsEquipped = false;
        yield return new WaitForSeconds(0.1f);
        //equip standard legs
        playerEdited.moveSpeed = playerEdited.moveSpeed + standardLegsSpeed;
        playerEdited.originalSpeed = playerEdited.originalSpeed + standardLegsSpeed;
        playerHealth.maxHealth = playerHealth.maxHealth + standardTorsoHP;
        playerHealth.updateHealthBar();
        playerHealth.currentHealth = playerHealth.maxHealth;
        standardLegsEquipped = true;
        standardLegs.SetActive(true);

    }

    [ContextMenu("Speed Head")]
    public void EquipSpeedHead()
    {
        if (standardHeadEquipped == true)
        {
            StartCoroutine(StandardHeadToSpeedHead());
            equippedStandardHead.SetActive(false);
            equippedSpeedHead.SetActive(true);
        }

        if (defenceHeadEquipped == true)
        {
            StartCoroutine(DefenceHeadToSpeedHead());
            equippedDefenceHead.SetActive(false);
            equippedSpeedHead.SetActive(true);
        }

        if (basicHeadEquipped == true)
        {
            StartCoroutine(BasicHeadToSpeedHead());
            equippedBasicHead.SetActive(false);
            equippedSpeedHead.SetActive(true);
        }

    }

    public IEnumerator StandardHeadToSpeedHead()
    {
        yield return new WaitForSeconds(0f);
        //de-equip standard head
        playerEdited.moveSpeed = playerEdited.moveSpeed - standardHeadSpeed;
        playerEdited.originalSpeed = playerEdited.originalSpeed - standardHeadSpeed;
        playerHealth.maxHealth = playerHealth.maxHealth - standardHeadHP;
        playerHealth.updateHealthBar();
        standardHead.SetActive(false);
        standardHeadEquipped = false;
        yield return new WaitForSeconds(0.1f);
        //equip speed head
        playerEdited.moveSpeed = playerEdited.moveSpeed + speedHeadSpeed;
        playerEdited.originalSpeed = playerEdited.originalSpeed + speedHeadSpeed;
        playerHealth.maxHealth = playerHealth.maxHealth + speedHeadHP;
        playerHealth.updateHealthBar();
        playerHealth.currentHealth = playerHealth.maxHealth;
        speedHeadEquipped = true;
        speedHead.SetActive(true);

    }

    public IEnumerator DefenceHeadToSpeedHead()
    {
        yield return new WaitForSeconds(0f);
        //de-equip defence head
        playerEdited.moveSpeed = playerEdited.moveSpeed - defenceHeadSpeed;
        playerEdited.originalSpeed = playerEdited.originalSpeed - defenceHeadSpeed;
        playerHealth.maxHealth = playerHealth.maxHealth - defenceHeadHP;
        playerHealth.updateHealthBar();
        defenceHead.SetActive(false);
        defenceHeadEquipped = false;
        yield return new WaitForSeconds(0.1f);
        //equip speed head
        playerEdited.moveSpeed = playerEdited.moveSpeed + speedHeadSpeed;
        playerEdited.originalSpeed = playerEdited.originalSpeed + speedHeadSpeed;
        playerHealth.maxHealth = playerHealth.maxHealth + speedHeadHP;
        playerHealth.updateHealthBar();
        playerHealth.currentHealth = playerHealth.maxHealth;
        speedHeadEquipped = true;
        speedHead.SetActive(true);

    }

    public IEnumerator BasicHeadToSpeedHead()
    {
        yield return new WaitForSeconds(0f);
        //de-equip basic head
        playerEdited.moveSpeed = playerEdited.moveSpeed - basicHeadSpeed;
        playerEdited.originalSpeed = playerEdited.originalSpeed - basicHeadSpeed;
        playerHealth.maxHealth = playerHealth.maxHealth - basicHeadHP;
        playerHealth.updateHealthBar();
        basicHead.SetActive(false);
        basicHeadEquipped = false;
        yield return new WaitForSeconds(0.1f);
        //equip speed head
        playerEdited.moveSpeed = playerEdited.moveSpeed + speedHeadSpeed;
        playerEdited.originalSpeed = playerEdited.originalSpeed + speedHeadSpeed;
        playerHealth.maxHealth = playerHealth.maxHealth + speedHeadHP;
        playerHealth.updateHealthBar();
        playerHealth.currentHealth = playerHealth.maxHealth;
        speedHeadEquipped = true;
        speedHead.SetActive(true);

    }

    [ContextMenu("Speed Torso")]
    public void EquipSpeedTorso()
    {
        if (standardTorsoEquipped == true)
        {
            StartCoroutine(StandardTorsoToSpeedTorso());
            equippedStandardTorso.SetActive(false);
            equippedSpeedTorso.SetActive(true);
        }

        if (defenceTorsoEquipped == true)
        {
            StartCoroutine(DefenceTorsoToSpeedTorso());
            equippedDefenceTorso.SetActive(false);
            equippedSpeedTorso.SetActive(true);
        }

        if (basicTorsoEquipped == true)
        {
            StartCoroutine(BasicTorsoToSpeedTorso());
            equippedBasicTorso.SetActive(false);
            equippedSpeedTorso.SetActive(true);
        }

    }

    public IEnumerator StandardTorsoToSpeedTorso()
    {
        yield return new WaitForSeconds(0f);
        //de-equip standard torso
        playerEdited.moveSpeed = playerEdited.moveSpeed - standardTorsoSpeed;
        playerEdited.originalSpeed = playerEdited.originalSpeed - standardTorsoSpeed;
        playerHealth.maxHealth = playerHealth.maxHealth - standardTorsoHP;
        playerHealth.updateHealthBar();
        standardTorso.SetActive(false);
        standardTorsoEquipped = false;
        yield return new WaitForSeconds(0.1f);
        //equip speed torso
        playerEdited.moveSpeed = playerEdited.moveSpeed + speedTorsoSpeed;
        playerEdited.originalSpeed = playerEdited.originalSpeed + speedTorsoSpeed;
        playerHealth.maxHealth = playerHealth.maxHealth + speedTorsoHP;
        playerHealth.updateHealthBar();
        playerHealth.currentHealth = playerHealth.maxHealth;
        speedTorsoEquipped = true;
        speedTorso.SetActive(true);

    }

    public IEnumerator DefenceTorsoToSpeedTorso()
    {
        yield return new WaitForSeconds(0f);
        //de-equip defence torso
        playerEdited.moveSpeed = playerEdited.moveSpeed - defenceTorsoSpeed;
        playerEdited.originalSpeed = playerEdited.originalSpeed - defenceTorsoSpeed;
        playerHealth.maxHealth = playerHealth.maxHealth - defenceTorsoHP;
        playerHealth.updateHealthBar();
        defenceTorso.SetActive(false);
        defenceTorsoEquipped = false;
        yield return new WaitForSeconds(0.1f);
        //equip speed torso
        playerEdited.moveSpeed = playerEdited.moveSpeed + speedTorsoSpeed;
        playerEdited.originalSpeed = playerEdited.originalSpeed + speedTorsoSpeed;
        playerHealth.maxHealth = playerHealth.maxHealth + speedTorsoHP;
        playerHealth.updateHealthBar();
        playerHealth.currentHealth = playerHealth.maxHealth;
        speedTorsoEquipped = true;
        speedTorso.SetActive(true);

    }

    public IEnumerator BasicTorsoToSpeedTorso()
    {
        yield return new WaitForSeconds(0f);
        //de-equip basic torso
        playerEdited.moveSpeed = playerEdited.moveSpeed - basicTorsoSpeed;
        playerEdited.originalSpeed = playerEdited.originalSpeed - basicTorsoSpeed;
        playerHealth.maxHealth = playerHealth.maxHealth - basicTorsoHP;
        playerHealth.updateHealthBar();
        basicTorso.SetActive(false);
        basicTorsoEquipped = false;
        yield return new WaitForSeconds(0.1f);
        //equip speed torso
        playerEdited.moveSpeed = playerEdited.moveSpeed + speedTorsoSpeed;
        playerEdited.originalSpeed = playerEdited.originalSpeed + speedTorsoSpeed;
        playerHealth.maxHealth = playerHealth.maxHealth + speedTorsoHP;
        playerHealth.updateHealthBar();
        playerHealth.currentHealth = playerHealth.maxHealth;
        speedTorsoEquipped = true;
        speedTorso.SetActive(true);

    }

    [ContextMenu("Speed Legs")]
    public void EquipSpeedLegs()
    {
        if (standardLegsEquipped == true)
        {
            StartCoroutine(StandardLegsToSpeedLegs());
            equippedStandardLegs.SetActive(false);
            equippedSpeedLegs.SetActive(true);
        }

        if (defenceLegsEquipped == true)
        {
            StartCoroutine(DefenceLegsToSpeedLegs());
            equippedDefenceLegs.SetActive(false);
            equippedSpeedLegs.SetActive(true);
        }

        if (basicLegsEquipped == true)
        {
            StartCoroutine(BasicLegsToSpeedLegs());
            equippedBasicLegs.SetActive(false);
            equippedSpeedLegs.SetActive(true);
        }

    }

    public IEnumerator StandardLegsToSpeedLegs()
    {
        yield return new WaitForSeconds(0f);
        //de-equip standard legs
        playerEdited.moveSpeed = playerEdited.moveSpeed - standardLegsSpeed;
        playerEdited.originalSpeed = playerEdited.originalSpeed - standardLegsSpeed;
        playerHealth.maxHealth = playerHealth.maxHealth - standardLegsHP;
        playerHealth.updateHealthBar();
        standardLegs.SetActive(false);
        standardLegsEquipped = false;
        yield return new WaitForSeconds(0.1f);
        //equip speed legs
        playerEdited.moveSpeed = playerEdited.moveSpeed + speedLegsSpeed;
        playerEdited.originalSpeed = playerEdited.originalSpeed + speedLegsSpeed;
        playerHealth.maxHealth = playerHealth.maxHealth + speedLegsHP;
        playerHealth.updateHealthBar();
        playerHealth.currentHealth = playerHealth.maxHealth;
        speedLegsEquipped = true;
        speedLegs.SetActive(true);

    }

    public IEnumerator DefenceLegsToSpeedLegs()
    {
        yield return new WaitForSeconds(0f);
        //de-equip defence legs
        playerEdited.moveSpeed = playerEdited.moveSpeed - defenceLegsSpeed;
        playerEdited.originalSpeed = playerEdited.originalSpeed - defenceLegsSpeed;
        playerHealth.maxHealth = playerHealth.maxHealth - defenceLegsHP;
        playerHealth.updateHealthBar();
        defenceLegs.SetActive(false);
        defenceLegsEquipped = false;
        yield return new WaitForSeconds(0.1f);
        //equip speed legs
        playerEdited.moveSpeed = playerEdited.moveSpeed + speedLegsSpeed;
        playerEdited.originalSpeed = playerEdited.originalSpeed + speedLegsSpeed;
        playerHealth.maxHealth = playerHealth.maxHealth + speedLegsHP;
        playerHealth.updateHealthBar();
        playerHealth.currentHealth = playerHealth.maxHealth;
        speedLegsEquipped = true;
        speedLegs.SetActive(true);

    }

    public IEnumerator BasicLegsToSpeedLegs()
    {
        yield return new WaitForSeconds(0f);
        //de-equip basic legs
        playerEdited.moveSpeed = playerEdited.moveSpeed - basicLegsSpeed;
        playerEdited.originalSpeed = playerEdited.originalSpeed - basicLegsSpeed;
        playerHealth.maxHealth = playerHealth.maxHealth - basicLegsHP;
        playerHealth.updateHealthBar();
        basicLegs.SetActive(false);
        basicLegsEquipped = false;
        yield return new WaitForSeconds(0.1f);
        //equip speed legs
        playerEdited.moveSpeed = playerEdited.moveSpeed + speedLegsSpeed;
        playerEdited.originalSpeed = playerEdited.originalSpeed + speedLegsSpeed;
        playerHealth.maxHealth = playerHealth.maxHealth + speedLegsHP;
        playerHealth.updateHealthBar();
        playerHealth.currentHealth = playerHealth.maxHealth;
        speedLegsEquipped = true;
        speedLegs.SetActive(true);

    }

    [ContextMenu("Defence Head")]
    public void EquipDefenceHead()
    {
        if (standardHeadEquipped == true)
        {
            StartCoroutine(StandardHeadToDefenceHead());
            equippedStandardHead.SetActive(false);
            equippedDefenceHead.SetActive(true);
        }

        if (speedHeadEquipped == true)
        {
            StartCoroutine(SpeedHeadToDefenceHead());
            equippedSpeedHead.SetActive(false);
            equippedDefenceHead.SetActive(true);
        }

        if (basicHeadEquipped == true)
        {
            StartCoroutine(BasicHeadToDefenceHead());
            equippedBasicHead.SetActive(false);
            equippedDefenceHead.SetActive(true);
        }

    }

    public IEnumerator StandardHeadToDefenceHead()
    {
        yield return new WaitForSeconds(0f);
        //de-equip standard head
        playerEdited.moveSpeed = playerEdited.moveSpeed - standardHeadSpeed;
        playerEdited.originalSpeed = playerEdited.originalSpeed - standardHeadSpeed;
        playerHealth.maxHealth = playerHealth.maxHealth - standardHeadHP;
        playerHealth.updateHealthBar();
        standardHead.SetActive(false);
        standardHeadEquipped = false;
        yield return new WaitForSeconds(0.1f);
        //equip defence head
        playerEdited.moveSpeed = playerEdited.moveSpeed + defenceHeadSpeed;
        playerEdited.originalSpeed = playerEdited.originalSpeed + defenceHeadSpeed;
        playerHealth.maxHealth = playerHealth.maxHealth + defenceHeadHP;
        playerHealth.updateHealthBar();
        playerHealth.currentHealth = playerHealth.maxHealth;
        defenceHeadEquipped = true;
        defenceHead.SetActive(true);

    }

    public IEnumerator SpeedHeadToDefenceHead()
    {
        yield return new WaitForSeconds(0f);
        //de-equip defence head
        playerEdited.moveSpeed = playerEdited.moveSpeed - speedHeadSpeed;
        playerEdited.originalSpeed = playerEdited.originalSpeed - speedHeadSpeed;
        playerHealth.maxHealth = playerHealth.maxHealth - speedHeadHP;
        playerHealth.updateHealthBar();
        speedHead.SetActive(false);
        speedHeadEquipped = false;
        yield return new WaitForSeconds(0.1f);
        //equip defence head
        playerEdited.moveSpeed = playerEdited.moveSpeed + defenceHeadSpeed;
        playerEdited.originalSpeed = playerEdited.originalSpeed + defenceHeadSpeed;
        playerHealth.maxHealth = playerHealth.maxHealth + defenceHeadHP;
        playerHealth.updateHealthBar();
        playerHealth.currentHealth = playerHealth.maxHealth;
        defenceHeadEquipped = true;
        defenceHead.SetActive(true);

    }

    public IEnumerator BasicHeadToDefenceHead()
    {
        yield return new WaitForSeconds(0f);
        //de-equip basic head
        playerEdited.moveSpeed = playerEdited.moveSpeed - basicHeadSpeed;
        playerEdited.originalSpeed = playerEdited.originalSpeed - basicHeadSpeed;
        playerHealth.maxHealth = playerHealth.maxHealth - basicHeadHP;
        playerHealth.updateHealthBar();
        basicHead.SetActive(false);
        basicHeadEquipped = false;
        yield return new WaitForSeconds(0.1f);
        //equip defence head
        playerEdited.moveSpeed = playerEdited.moveSpeed + defenceHeadSpeed;
        playerEdited.originalSpeed = playerEdited.originalSpeed + defenceHeadSpeed;
        playerHealth.maxHealth = playerHealth.maxHealth + defenceHeadHP;
        playerHealth.updateHealthBar();
        playerHealth.currentHealth = playerHealth.maxHealth;
        defenceHeadEquipped = true;
        defenceHead.SetActive(true);

    }

    [ContextMenu("Defence Torso")]
    public void EquipDefenceTorso()
    {
        if (standardTorsoEquipped == true)
        {
            StartCoroutine(StandardTorsoToDefenceTorso());
            equippedStandardTorso.SetActive(false);
            equippedDefenceTorso.SetActive(true);
        }

        if (speedTorsoEquipped == true)
        {
            StartCoroutine(SpeedTorsoToDefenceTorso());
            equippedSpeedTorso.SetActive(false);
            equippedDefenceTorso.SetActive(true);
        }

        if (basicTorsoEquipped == true)
        {
            StartCoroutine(BasicTorsoToDefenceTorso());
            equippedBasicTorso.SetActive(false);
            equippedDefenceTorso.SetActive(true);
        }

    }

    public IEnumerator StandardTorsoToDefenceTorso()
    {
        yield return new WaitForSeconds(0f);
        //de-equip standard torso
        playerEdited.moveSpeed = playerEdited.moveSpeed - standardTorsoSpeed;
        playerEdited.originalSpeed = playerEdited.originalSpeed - standardTorsoSpeed;
        playerHealth.maxHealth = playerHealth.maxHealth - standardTorsoHP;
        playerHealth.updateHealthBar();
        standardTorso.SetActive(false);
        standardTorsoEquipped = false;
        yield return new WaitForSeconds(0.1f);
        //equip defence torso
        playerEdited.moveSpeed = playerEdited.moveSpeed + defenceTorsoSpeed;
        playerEdited.originalSpeed = playerEdited.originalSpeed + defenceTorsoSpeed;
        playerHealth.maxHealth = playerHealth.maxHealth + defenceTorsoHP;
        playerHealth.updateHealthBar();
        playerHealth.currentHealth = playerHealth.maxHealth;
        defenceTorsoEquipped = true;
        defenceTorso.SetActive(true);

    }

    public IEnumerator SpeedTorsoToDefenceTorso()
    {
        yield return new WaitForSeconds(0f);
        //de-equip defence head
        playerEdited.moveSpeed = playerEdited.moveSpeed - speedTorsoSpeed;
        playerEdited.originalSpeed = playerEdited.originalSpeed - speedTorsoSpeed;
        playerHealth.maxHealth = playerHealth.maxHealth - speedTorsoHP;
        playerHealth.updateHealthBar();
        speedTorso.SetActive(false);
        speedTorsoEquipped = false;
        yield return new WaitForSeconds(0.1f);
        //equip defence torso
        playerEdited.moveSpeed = playerEdited.moveSpeed + defenceTorsoSpeed;
        playerEdited.originalSpeed = playerEdited.originalSpeed + defenceTorsoSpeed;
        playerHealth.maxHealth = playerHealth.maxHealth + defenceTorsoHP;
        playerHealth.updateHealthBar();
        playerHealth.currentHealth = playerHealth.maxHealth;
        defenceTorsoEquipped = true;
        defenceTorso.SetActive(true);

    }

    public IEnumerator BasicTorsoToDefenceTorso()
    {
        yield return new WaitForSeconds(0f);
        //de-equip basic head
        playerEdited.moveSpeed = playerEdited.moveSpeed - basicTorsoSpeed;
        playerEdited.originalSpeed = playerEdited.originalSpeed - basicTorsoSpeed;
        playerHealth.maxHealth = playerHealth.maxHealth - basicTorsoHP;
        playerHealth.updateHealthBar();
        basicTorso.SetActive(false);
        basicTorsoEquipped = false;
        yield return new WaitForSeconds(0.1f);
        //equip defence torso
        playerEdited.moveSpeed = playerEdited.moveSpeed + defenceTorsoSpeed;
        playerEdited.originalSpeed = playerEdited.originalSpeed + defenceTorsoSpeed;
        playerHealth.maxHealth = playerHealth.maxHealth + defenceTorsoHP;
        playerHealth.updateHealthBar();
        playerHealth.currentHealth = playerHealth.maxHealth;
        defenceTorsoEquipped = true;
        defenceTorso.SetActive(true);

    }

    [ContextMenu("Defence Legs")]
    public void EquipDefenceLegs()
    {
        if (standardLegsEquipped == true)
        {
            StartCoroutine(StandardLegsToDefenceLegs());
            equippedStandardLegs.SetActive(false);
            equippedDefenceLegs.SetActive(true);
        }

        if (speedLegsEquipped == true)
        {
            StartCoroutine(SpeedLegsToDefenceLegs());
            equippedSpeedLegs.SetActive(false);
            equippedDefenceLegs.SetActive(true);
        }

        if (basicLegsEquipped == true)
        {
            StartCoroutine(BasicLegsToDefenceLegs());
            equippedBasicLegs.SetActive(false);
            equippedDefenceLegs.SetActive(true);
        }

    }

    public IEnumerator StandardLegsToDefenceLegs()
    {
        yield return new WaitForSeconds(0f);
        //de-equip standard legs
        playerEdited.moveSpeed = playerEdited.moveSpeed - standardLegsSpeed;
        playerEdited.originalSpeed = playerEdited.originalSpeed - standardLegsSpeed;
        playerHealth.maxHealth = playerHealth.maxHealth - standardLegsHP;
        playerHealth.updateHealthBar();
        standardLegs.SetActive(false);
        standardLegsEquipped = false;
        yield return new WaitForSeconds(0.1f);
        //equip defence legs
        playerEdited.moveSpeed = playerEdited.moveSpeed + defenceLegsSpeed;
        playerEdited.originalSpeed = playerEdited.originalSpeed + defenceLegsSpeed;
        playerHealth.maxHealth = playerHealth.maxHealth + defenceLegsHP;
        playerHealth.updateHealthBar();
        playerHealth.currentHealth = playerHealth.maxHealth;
        defenceLegsEquipped = true;
        defenceLegs.SetActive(true);

    }

    public IEnumerator SpeedLegsToDefenceLegs()
    {
        yield return new WaitForSeconds(0f);
        //de-equip defence head
        playerEdited.moveSpeed = playerEdited.moveSpeed - speedLegsSpeed;
        playerEdited.originalSpeed = playerEdited.originalSpeed - speedLegsSpeed;
        playerHealth.maxHealth = playerHealth.maxHealth - speedLegsHP;
        playerHealth.updateHealthBar();
        speedLegs.SetActive(false);
        speedLegsEquipped = false;
        yield return new WaitForSeconds(0.1f);
        //equip defence legs
        playerEdited.moveSpeed = playerEdited.moveSpeed + defenceLegsSpeed;
        playerEdited.originalSpeed = playerEdited.originalSpeed + defenceLegsSpeed;
        playerHealth.maxHealth = playerHealth.maxHealth + defenceLegsHP;
        playerHealth.updateHealthBar();
        playerHealth.currentHealth = playerHealth.maxHealth;
        defenceLegsEquipped = true;
        defenceLegs.SetActive(true);

    }

    public IEnumerator BasicLegsToDefenceLegs()
    {
        yield return new WaitForSeconds(0f);
        //de-equip basic legs
        playerEdited.moveSpeed = playerEdited.moveSpeed - basicLegsSpeed;
        playerEdited.originalSpeed = playerEdited.originalSpeed - basicLegsSpeed;
        playerHealth.maxHealth = playerHealth.maxHealth - basicLegsHP;
        playerHealth.updateHealthBar();
        basicLegs.SetActive(false);
        basicLegsEquipped = false;
        yield return new WaitForSeconds(0.1f);
        //equip defence torso
        playerEdited.moveSpeed = playerEdited.moveSpeed + defenceTorsoSpeed;
        playerEdited.originalSpeed = playerEdited.originalSpeed + defenceTorsoSpeed;
        playerHealth.maxHealth = playerHealth.maxHealth + defenceTorsoHP;
        playerHealth.updateHealthBar();
        playerHealth.currentHealth = playerHealth.maxHealth;
        defenceLegsEquipped = true;
        defenceLegs.SetActive(true);

    }
}


