using UnityEngine;


public class FigureId : MonoBehaviour
{
    public enum Figure
    {
        Cube,
        Sphere,
        Capsule
    }

    [SerializeField] public Figure figure;
}
