using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCircle : MonoBehaviour
{
    public Transform PlayerPosition;

    private void Update()
    {
        transform.position = PlayerPosition.position;
    }


}
