using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firstBoss : MonoBehaviour
{
    //player
    public Transform player;

    //move points and bools
    public Transform pointA;
    public bool atPointA = false;
    public Transform pointB;
    public bool atPointB = false;
    public Transform pointC;
    public bool atPointC = false;
    public Transform pointD;
    public bool atPointD = false;
    public Transform pointE;
    public bool atPointE = false;
    public Transform pointF;
    public bool atPointF = false;
    public Transform pointG;
    public bool atPointG = false;
    public Transform pointH;
    public bool atPointH = false;
    public Transform pointI;
    public bool atPointI = false;
    public Transform pointJ;
    public bool atPointJ = false;
    public Transform pointK;
    public bool atPointK = false;
    public Transform pointL;
    public bool atPointL = false;
    public Transform pointM;
    public bool atPointM = false;
    public Transform pointN;
    public bool atPointN = false;
    public Transform pointO;
    public bool atPointO = false;
    public Transform pointP;
    public bool atPointP = false;
    public Transform pointQ;
    public bool atPointQ = false;
    public Transform pointR;
    public bool atPointR = false;
    public Transform pointS;
    public bool atPointS = false;

    public void Start()
    {
        
    }

    public void Update()
    {

        this.gameObject.transform.LookAt(player);


    }
}
