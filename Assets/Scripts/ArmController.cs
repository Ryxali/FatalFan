using UnityEngine;
using System.Collections;

public class ArmController : MonoBehaviour {

    [SerializeField]
    private float armLength = 3.0f;
    [SerializeField]
    private bool calculateArmLengthFromScene = false;

    [SerializeField]
    private float fanStrength = 1.0f;

    private Character parent;

    void Start()
    {
        if (calculateArmLengthFromScene) armLength = transform.localPosition.magnitude;
        parent = GetComponentInParent<Character>();
    }

    public void UpdateWithInput(Vector3 stick)
    {
        transform.rotation = Quaternion.LookRotation(stick, Vector3.Cross(stick, Vector3.forward));
        transform.localPosition = transform.forward * armLength;
        parent.AddForce(
            -new Vector2
            {
                x = stick.x,
                y = stick.y
            }.normalized
            * fanStrength);
        
    }
}
