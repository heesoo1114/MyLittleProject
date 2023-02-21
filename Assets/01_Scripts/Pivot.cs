using UnityEngine;

public class Pivot : MonoBehaviour
{
    public void Roatate()
    {
        transform.rotation = Quaternion.Euler(0, 0, transform.rotation.z + 60);
    }
}