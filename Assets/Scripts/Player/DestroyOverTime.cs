using UnityEngine;
using System.Collections;

public class DestroyOverTime : MonoBehaviour
{
    public float time;
    private float timer;

    // Update is called once per frame
    void LateUpdate()
    {
        timer += Time.deltaTime;

        if (timer > time)
        {
            Destroy(this.gameObject);
        }
    }
}
