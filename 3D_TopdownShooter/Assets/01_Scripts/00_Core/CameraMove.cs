using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private void Update()
    {
        Vector3 cameraPos = new Vector3(GameManager.Instance.player.transform.position.x, GameManager.Instance.player.transform.position.y + 10f, GameManager.Instance.player.transform.position.z);
        gameObject.transform.position = cameraPos;
    }
}
