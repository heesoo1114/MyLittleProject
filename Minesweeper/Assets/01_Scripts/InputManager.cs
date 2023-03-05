using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    Camera cam;

    private void Awake()
    {
        cam = FindObjectOfType<Camera>();
    }

    private void Update()
    {
        LeftClickInput();
        RightClickInput();
    }

    public void LeftClickInput()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Vector2 pos = Input.mousePosition;
            RaycastHit2D hit = Physics2D.Raycast(pos, transform.forward, 15f);

            if (hit.collider != null)
            {
                Block _block = hit.collider.gameObject.GetComponent<Block>();

                if (_block.info == Info.Mine)
                {
                    GameManager.Instance.GameOver();
                    return;
                }

                _block.OpenBlock();
            }
        }
    }

    public void RightClickInput()
    {
        if (Input.GetMouseButtonUp(1))
        {
            Vector2 pos = Input.mousePosition;
            RaycastHit2D hit = Physics2D.Raycast(pos, transform.forward, 15f);

            if (hit.collider != null)
            {
                hit.collider.gameObject.GetComponent<Block>().MarkingBlock();
            }
        }
    }
}
