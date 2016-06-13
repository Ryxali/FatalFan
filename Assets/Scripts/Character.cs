using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class Character : MonoBehaviour {

    private Rigidbody2D rBody;
    [SerializeField]
    private Transform body;

    [SerializeField]
    private ArmController armLeft;
    [SerializeField]
    private ArmController armRight;

    public string player = "P1";
    public bool useKeyboard = false;

    struct JoyInput
    {
        public Vector3 stick_L { get; set; }
        public Vector3 stick_R { get; set; }
    }
    private JoyInput input = new JoyInput
    {
        stick_L = Vector3.zero,
        stick_R = Vector3.zero
    };

	// Use this for initialization
	void Start () {
        rBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        UpdateInput();
        //TODO update tilt

        //TODO update arms
        if(input.stick_L != Vector3.zero)
            armLeft.UpdateWithInput(input.stick_L);
        if (input.stick_R != Vector3.zero)
            armRight.UpdateWithInput(input.stick_R);
        //TODO update physics
        
	}

    public void AddForce(Vector2 force)
    {
        rBody.AddForce(force, ForceMode2D.Force);
    }

    private void UpdateInput()
    {
        if(useKeyboard)
        {
            input.stick_L = new Vector2
            {
                x = Input.GetAxis("L_Horizontal"),
                y = Input.GetAxis("L_Vertical")
            }.normalized;
            input.stick_R = new Vector2
            {
                x = Input.GetAxis("R_Horizontal"),
                y = Input.GetAxis("R_Vertical")
            }.normalized;
        } else
        {
            input.stick_L = new Vector2
            {
                x = Input.GetAxis(player + "_L_Horizontal"),
                y = Input.GetAxis(player + "_L_Vertical")
            }.normalized;
            input.stick_R = new Vector2
            {
                x = Input.GetAxis(player + "_R_Horizontal"),
                y = Input.GetAxis(player + "_R_Vertical")
            }.normalized;
        }
        
    }
}
