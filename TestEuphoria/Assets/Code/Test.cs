using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class Test : MonoBehaviour
{
    
    public enum Figure
    {
        Cube,
        Sphere,
        Capsule
    }

    [SerializeField] public Figure figure;
}
