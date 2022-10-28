using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchDetection : MonoBehaviour
{
    [SerializeField] private GameObject cube;
    [SerializeField] private Transform fingertip;
    private float distance;
    private float touch_threshold;
    private float distance_threshold = 0.5f;
    private bool isHit = false;
    private bool wasHit = false;
    private bool isEnter = false;
    private bool isExit = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        touch_threshold = distance_threshold + 0.5f*cube.transform.localScale.y;
        distance = DistanceCalculator(cube, fingertip);
        isHit = (distance < touch_threshold);
        isEnter = isHit && !wasHit;
        isExit = !isHit && wasHit;

        if (isExit) {
            ChangeColor(cube);
        }
        wasHit = isHit;
    }

    private void ChangeColor(GameObject cube) {
        var cubeRenderer = cube.GetComponent<Renderer>();
        Color newColor = new Color(Random.value, Random.value, Random.value, 0.0f);
        cubeRenderer.material.SetColor("_Color", newColor);
    }

    private float DistanceCalculator(GameObject target, Transform fingertip) {
        float dis = 0;
        dis = Vector3.Distance(target.transform.position, fingertip.position);
        return dis;
    }
}
