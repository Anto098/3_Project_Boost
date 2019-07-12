using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Oscillator : MonoBehaviour
{
    [SerializeField] Vector3 movementVector = new Vector3(10f,10f,10f);
    [Range(0.1f,100f)][SerializeField] float period = 2f;

    // todo remove inspector later
    float movementFactor; // 0 for not moved and 1 for fully moved

    Vector3 startingPos;
    // Start is called before the first frame update
    void Start()
    {
        startingPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float cycles = Time.time / period; // grows continuously through time
        const float tau = 2f * Mathf.PI; // about 6,28
        float rawSinWave = Mathf.Sin(cycles * tau);


        movementFactor = (rawSinWave +1) /2;
        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPos + offset;
    }
}
