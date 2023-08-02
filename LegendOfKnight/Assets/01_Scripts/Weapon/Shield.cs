using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public bool canParrying;
    public bool isParrying;

    public void ParryingReady(bool isStateShield)
    {
        canParrying = isStateShield;
    }

    public void Parrying()
    {
        if (canParrying)
        {
            Debug.Log("Parrying");
            canParrying = false;

            StartCoroutine(ParryngTimingCheck());
        }
    }

    IEnumerator ParryngTimingCheck()
    {
        isParrying = true;
        yield return new WaitForSeconds(0.5f);
        isParrying = false;
    }
}
