using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class TweenScript : MonoBehaviour {
    [Range(0, 1000)]
    public int RotationSpeed;

    private int _someSpeed = 1;
    public int SomeSpeed => _someSpeed;

    // Start is called before the first frame update
    void Start()
    {
        transform.DORotate(Vector3.left * RotationSpeed, 10);
    }

    // Update is called once per frame
    void Update() {
    }
}
