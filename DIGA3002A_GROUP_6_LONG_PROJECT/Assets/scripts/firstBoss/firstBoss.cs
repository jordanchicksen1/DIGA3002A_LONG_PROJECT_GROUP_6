using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firstBoss : MonoBehaviour
{
    [Header("Player")]
    public Transform player;

    [Header("Stats and Phases")]
    public float moveSpeed = 5f;
    public float moveSpeedPhaseOne = 5f;
    public float moveSpeedPhaseTwo = 6f;
    public float moveSpeedPhaseThree = 7.5f;
    public bool Phase1 = true;
    public bool Phase2 = false;
    public bool Phase3 = false;

    [Header("Move Points and Bools")]
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

    [Header("Attack Stuff")]
    public Transform shootPoint1;
    public Transform shootPoint2;
    public Transform shootPoint3;
    public GameObject smallProjectile;
    public float smallProjectileSpeed = 10f;
    public GameObject mediumProjectiles;
    public float mediumProjectileSpeed = 12.5f;

    public void Start()
    {
        
    }

    public void Update()
    {
        this.gameObject.transform.LookAt(player);

        if(Phase1 == true)
        {
            if(atPointA == false && atPointB == false && atPointC == false && atPointD == false  && atPointE == false)
            {
                Debug.Log("starting phase 1");
                transform.position = Vector3.MoveTowards(transform.position, pointA.transform.position, moveSpeed * Time.deltaTime);
            }

            if(atPointA == true)
            {
                Debug.Log("Moving to point B");
                transform.position = Vector3.MoveTowards(transform.position, pointB.transform.position, moveSpeed * Time.deltaTime);
            }

            if (atPointB == true)
            {
                Debug.Log("Moving to point C");
                transform.position = Vector3.MoveTowards(transform.position, pointC.transform.position, moveSpeed * Time.deltaTime);
            }

            if (atPointC == true)
            {
                Debug.Log("Moving to point D");
                transform.position = Vector3.MoveTowards(transform.position, pointD.transform.position, moveSpeed * Time.deltaTime);
            }

            if (atPointD == true)
            {
                Debug.Log("Moving to point E");
                transform.position = Vector3.MoveTowards(transform.position, pointE.transform.position, moveSpeed * Time.deltaTime);
            }

            if (atPointE == true)
            {
                Debug.Log("Moving to point A");
                transform.position = Vector3.MoveTowards(transform.position, pointA .transform.position, moveSpeed * Time.deltaTime);
            }
        }

        if (Phase2 == true) 
        {
            if (atPointF == false && atPointG == false && atPointH == false && atPointI == false && atPointJ == false && atPointK == false && atPointL == false && atPointM == false)
            {
                Debug.Log("starting phase 2");
                transform.position = Vector3.MoveTowards(transform.position, pointF.transform.position, moveSpeed * Time.deltaTime);
            }

            if (atPointF == true)
            {
                Debug.Log("Moving to point G");
                transform.position = Vector3.MoveTowards(transform.position, pointG.transform.position, moveSpeed * Time.deltaTime);
            }

            if (atPointG == true)
            {
                Debug.Log("Moving to point H");
                transform.position = Vector3.MoveTowards(transform.position, pointH.transform.position, moveSpeed * Time.deltaTime);
            }

            if (atPointH == true)
            {
                Debug.Log("Moving to point I");
                transform.position = Vector3.MoveTowards(transform.position, pointI.transform.position, moveSpeed * Time.deltaTime);
            }

            if (atPointI == true)
            {
                Debug.Log("Moving to point J");
                transform.position = Vector3.MoveTowards(transform.position, pointJ.transform.position, moveSpeed * Time.deltaTime);
            }

            if (atPointJ == true)
            {
                Debug.Log("Moving to point K");
                transform.position = Vector3.MoveTowards(transform.position, pointK.transform.position, moveSpeed * Time.deltaTime);
            }

            if (atPointK == true)
            {
                Debug.Log("Moving to point L");
                transform.position = Vector3.MoveTowards(transform.position, pointL.transform.position, moveSpeed * Time.deltaTime);
            }

            if (atPointL == true)
            {
                Debug.Log("Moving to point M");
                transform.position = Vector3.MoveTowards(transform.position, pointM.transform.position, moveSpeed * Time.deltaTime);
            }

            if (atPointM == true)
            {
                Debug.Log("Moving to point M");
                transform.position = Vector3.MoveTowards(transform.position, pointF.transform.position, moveSpeed * Time.deltaTime);
            }
        }

        if(Phase3 == true)
        {
            if (atPointN == false && atPointO == false && atPointP == false && atPointQ == false && atPointR == false && atPointS == false)
            {
                Debug.Log("starting phase 3");
                transform.position = Vector3.MoveTowards(transform.position, pointN.transform.position, moveSpeed * Time.deltaTime);
            }

            if (atPointN == true)
            {
                Debug.Log("Moving to point O");
                transform.position = Vector3.MoveTowards(transform.position, pointO.transform.position, moveSpeed * Time.deltaTime);
            }

            if (atPointO == true)
            {
                Debug.Log("Moving to point P");
                transform.position = Vector3.MoveTowards(transform.position, pointP.transform.position, moveSpeed * Time.deltaTime);
            }

            if (atPointP == true)
            {
                Debug.Log("Moving to point Q");
                transform.position = Vector3.MoveTowards(transform.position, pointQ.transform.position, moveSpeed * Time.deltaTime);
            }

            if (atPointQ == true)
            {
                Debug.Log("Moving to point R");
                transform.position = Vector3.MoveTowards(transform.position, pointR.transform.position, moveSpeed * Time.deltaTime);
            }

            if (atPointR == true)
            {
                Debug.Log("Moving to point S");
                transform.position = Vector3.MoveTowards(transform.position, pointS.transform.position, moveSpeed * Time.deltaTime);
            }

            if (atPointS == true)
            {
                Debug.Log("Moving to point N");
                transform.position = Vector3.MoveTowards(transform.position, pointN.transform.position, moveSpeed * Time.deltaTime);
            }
        }

    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "PointA")
        {
            atPointA = true;
            atPointB = false;
            atPointC = false;
            atPointD = false;
            atPointE = false;
            atPointF = false;
            atPointG = false;
            atPointH = false;
            atPointI = false;
            atPointJ = false;
            atPointK = false;
            atPointL = false;
            atPointM = false;
            atPointN = false;
            atPointO = false;
            atPointP = false;
            atPointQ = false;
            atPointR = false;
            atPointS = false;
            StartCoroutine(ConsecutiveShotPhase1());
        }

        if (other.tag == "PointB")
        {
            atPointA = false;
            atPointB = true;
            atPointC = false;
            atPointD = false;
            atPointE = false;
            atPointF = false;
            atPointG = false;
            atPointH = false;
            atPointI = false;
            atPointJ = false;
            atPointK = false;
            atPointL = false;
            atPointM = false;
            atPointN = false;
            atPointO = false;
            atPointP = false;
            atPointQ = false;
            atPointR = false;
            atPointS = false;
            StartCoroutine(SpreadshotPhase1());
        }

        if (other.tag == "PointC")
        {
            atPointA = false;
            atPointB = false;
            atPointC = true;
            atPointD = false;
            atPointE = false;
            atPointF = false;
            atPointG = false;
            atPointH = false;
            atPointI = false;
            atPointJ = false;
            atPointK = false;
            atPointL = false;
            atPointM = false;
            atPointN = false;
            atPointO = false;
            atPointP = false;
            atPointQ = false;
            atPointR = false;
            atPointS = false;
            StartCoroutine(ConsecutiveShotPhase1());
        }

        if (other.tag == "PointD")
        {
            atPointA = false;
            atPointB = false;
            atPointC = false;
            atPointD = true;
            atPointE = false;
            atPointF = false;
            atPointG = false;
            atPointH = false;
            atPointI = false;
            atPointJ = false;
            atPointK = false;
            atPointL = false;
            atPointM = false;
            atPointN = false;
            atPointO = false;
            atPointP = false;
            atPointQ = false;
            atPointR = false;
            atPointS = false;
            StartCoroutine(SpreadshotPhase1());
        }

        if (other.tag == "PointE")
        {
            atPointA = false;
            atPointB = false;
            atPointC = false;
            atPointD = false;
            atPointE = true;
            atPointF = false;
            atPointG = false;
            atPointH = false;
            atPointI = false;
            atPointJ = false;
            atPointK = false;
            atPointL = false;
            atPointM = false;
            atPointN = false;
            atPointO = false;
            atPointP = false;
            atPointQ = false;
            atPointR = false;
            atPointS = false;
            StartCoroutine(ConsecutiveShotPhase1());
        }

        if (other.tag == "PointF")
        {
            atPointA = false;
            atPointB = false;
            atPointC = false;
            atPointD = false;
            atPointE = false;
            atPointF = true;
            atPointG = false;
            atPointH = false;
            atPointI = false;
            atPointJ = false;
            atPointK = false;
            atPointL = false;
            atPointM = false;
            atPointN = false;
            atPointO = false;
            atPointP = false;
            atPointQ = false;
            atPointR = false;
            atPointS = false;
        }

        if (other.tag == "PointG")
        {
            atPointA = false;
            atPointB = false;
            atPointC = false;
            atPointD = false;
            atPointE = false;
            atPointF = false;
            atPointG = true;
            atPointH = false;
            atPointI = false;
            atPointJ = false;
            atPointK = false;
            atPointL = false;
            atPointM = false;
            atPointN = false;
            atPointO = false;
            atPointP = false;
            atPointQ = false;
            atPointR = false;
            atPointS = false;
        }

        if (other.tag == "PointH")
        {
            atPointA = false;
            atPointB = false;
            atPointC = false;
            atPointD = false;
            atPointE = false;
            atPointF = false;
            atPointG = false;
            atPointH = true;
            atPointI = false;
            atPointJ = false;
            atPointK = false;
            atPointL = false;
            atPointM = false;
            atPointN = false;
            atPointO = false;
            atPointP = false;
            atPointQ = false;
            atPointR = false;
            atPointS = false;
        }

        if (other.tag == "PointI")
        {
            atPointA = false;
            atPointB = false;
            atPointC = false;
            atPointD = false;
            atPointE = false;
            atPointF = false;
            atPointG = false;
            atPointH = false;
            atPointI = true;
            atPointJ = false;
            atPointK = false;
            atPointL = false;
            atPointM = false;
            atPointN = false;
            atPointO = false;
            atPointP = false;
            atPointQ = false;
            atPointR = false;
            atPointS = false;
        }

        if (other.tag == "PointJ")
        {
            atPointA = false;
            atPointB = false;
            atPointC = false;
            atPointD = false;
            atPointE = false;
            atPointF = false;
            atPointG = false;
            atPointH = false;
            atPointI = false;
            atPointJ = true;
            atPointK = false;
            atPointL = false;
            atPointM = false;
            atPointN = false;
            atPointO = false;
            atPointP = false;
            atPointQ = false;
            atPointR = false;
            atPointS = false;
        }

        if (other.tag == "PointK")
        {
            atPointA = false;
            atPointB = false;
            atPointC = false;
            atPointD = false;
            atPointE = false;
            atPointF = false;
            atPointG = false;
            atPointH = false;
            atPointI = false;
            atPointJ = false;
            atPointK = true;
            atPointL = false;
            atPointM = false;
            atPointN = false;
            atPointO = false;
            atPointP = false;
            atPointQ = false;
            atPointR = false;
            atPointS = false;
            Debug.Log("hit point k");
        }

        if (other.tag == "PointL")
        {
            atPointA = false;
            atPointB = false;
            atPointC = false;
            atPointD = false;
            atPointE = false;
            atPointF = false;
            atPointG = false;
            atPointH = false;
            atPointI = false;
            atPointJ = false;
            atPointK = false;
            atPointL = true;
            atPointM = false;
            atPointN = false;
            atPointO = false;
            atPointP = false;
            atPointQ = false;
            atPointR = false;
            atPointS = false;
        }

        if (other.tag == "PointM")
        {
            atPointA = false;
            atPointB = false;
            atPointC = false;
            atPointD = false;
            atPointE = false;
            atPointF = false;
            atPointG = false;
            atPointH = false;
            atPointI = false;
            atPointJ = false;
            atPointK = false;
            atPointL = false;
            atPointM = true;
            atPointN = false;
            atPointO = false;
            atPointP = false;
            atPointQ = false;
            atPointR = false;
            atPointS = false;
        }

        if (other.tag == "PointN")
        {
            atPointA = false;
            atPointB = false;
            atPointC = false;
            atPointD = false;
            atPointE = false;
            atPointF = false;
            atPointG = false;
            atPointH = false;
            atPointI = false;
            atPointJ = false;
            atPointK = false;
            atPointL = false;
            atPointM = false;
            atPointN = true;
            atPointO = false;
            atPointP = false;
            atPointQ = false;
            atPointR = false;
            atPointS = false;
        }

        if (other.tag == "PointO")
        {
            atPointA = false;
            atPointB = false;
            atPointC = false;
            atPointD = false;
            atPointE = false;
            atPointF = false;
            atPointG = false;
            atPointH = false;
            atPointI = false;
            atPointJ = false;
            atPointK = false;
            atPointL = false;
            atPointM = false;
            atPointN = false;
            atPointO = true;
            atPointP = false;
            atPointQ = false;
            atPointR = false;
            atPointS = false;
        }

        if (other.tag == "PointP")
        {
            atPointA = false;
            atPointB = false;
            atPointC = false;
            atPointD = false;
            atPointE = false;
            atPointF = false;
            atPointG = false;
            atPointH = false;
            atPointI = false;
            atPointJ = false;
            atPointK = false;
            atPointL = false;
            atPointM = false;
            atPointN = false;
            atPointO = false;
            atPointP = true;
            atPointQ = false;
            atPointR = false;
            atPointS = false;
        }

        if (other.tag == "PointQ")
        {
            atPointA = false;
            atPointB = false;
            atPointC = false;
            atPointD = false;
            atPointE = false;
            atPointF = false;
            atPointG = false;
            atPointH = false;
            atPointI = false;
            atPointJ = false;
            atPointK = false;
            atPointL = false;
            atPointM = false;
            atPointN = false;
            atPointO = false;
            atPointP = false;
            atPointQ = true;
            atPointR = false;
            atPointS = false;
        }

        if (other.tag == "PointR")
        {
            atPointA = false;
            atPointB = false;
            atPointC = false;
            atPointD = false;
            atPointE = false;
            atPointF = false;
            atPointG = false;
            atPointH = false;
            atPointI = false;
            atPointJ = false;
            atPointK = false;
            atPointL = false;
            atPointM = false;
            atPointN = false;
            atPointO = false;
            atPointP = false;
            atPointQ = false;
            atPointR = true;
            atPointS = false;
        }

        if (other.tag == "PointS")
        {
            atPointA = false;
            atPointB = false;
            atPointC = false;
            atPointD = false;
            atPointE = false;
            atPointF = false;
            atPointG = false;
            atPointH = false;
            atPointI = false;
            atPointJ = false;
            atPointK = false;
            atPointL = false;
            atPointM = false;
            atPointN = false;
            atPointO = false;
            atPointP = false;
            atPointQ = false;
            atPointR = false;
            atPointS = true;
        }
    }

    public IEnumerator SpreadshotPhase1()
    {
        yield return new WaitForSeconds(0f);
        yield return new WaitForSeconds(0f);
        moveSpeed = 0f;
        var projectile = Instantiate(smallProjectile, shootPoint1.position, shootPoint1.rotation);
        var rb = projectile.GetComponent<Rigidbody>();
        rb.velocity = shootPoint1.forward * smallProjectileSpeed;
        Destroy(projectile, 1.5f);
        var projectile2 = Instantiate(smallProjectile, shootPoint2.position, shootPoint2.rotation);
        var rb2 = projectile2.GetComponent<Rigidbody>();
        rb2.velocity = shootPoint2.forward * smallProjectileSpeed;
        Destroy(projectile2, 1.5f);
        var projectile3 = Instantiate(smallProjectile, shootPoint3.position, shootPoint3.rotation);
        var rb3 = projectile3.GetComponent<Rigidbody>();
        rb3.velocity = shootPoint3.forward * smallProjectileSpeed;
        Destroy(projectile3, 1.5f);
        yield return new WaitForSeconds(1.5f);
        moveSpeed = moveSpeedPhaseOne;
    }

    public IEnumerator SpreadshotPhase2()
    {
        yield return new WaitForSeconds(0f);
    }

    public IEnumerator SpreadshotPhase3()
    {
        yield return new WaitForSeconds(0f);
    }

    public IEnumerator ConsecutiveShotPhase1()
    {
        yield return new WaitForSeconds(0f);
        moveSpeed = 0f;
        var projectile = Instantiate(smallProjectile, shootPoint1.position, shootPoint1.rotation);
        var rb = projectile.GetComponent<Rigidbody>();
        rb.velocity = shootPoint1.forward * smallProjectileSpeed;
        Destroy(projectile, 1.5f);
        yield return new WaitForSeconds(0.5f);
        var projectile2 = Instantiate(smallProjectile, shootPoint1.position, shootPoint1.rotation);
        var rb2 = projectile2.GetComponent<Rigidbody>();
        rb2.velocity = shootPoint1.forward * smallProjectileSpeed;
        Destroy(projectile2, 1.5f);
        yield return new WaitForSeconds(0.5f);
        var projectile3 = Instantiate(smallProjectile, shootPoint1.position, shootPoint1.rotation);
        var rb3 = projectile3.GetComponent<Rigidbody>();
        rb3.velocity = shootPoint1.forward * smallProjectileSpeed;
        Destroy(projectile3, 1.5f);
        yield return new WaitForSeconds(0.5f);
        moveSpeed = moveSpeedPhaseOne;
    }

    public IEnumerator ConsecutiveShotPhase2()
    {
        yield return new WaitForSeconds(0f);

    }

    public IEnumerator ConsecutiveShotPhase3()
    {
        yield return new WaitForSeconds(0f);
    }
}
