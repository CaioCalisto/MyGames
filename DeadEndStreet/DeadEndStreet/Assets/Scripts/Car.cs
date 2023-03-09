using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class Car : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity = new Vector3(0, -1.0F, 0);
    }

    // Update is called once per frame
    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        MoveForward(verticalInput);
    }

    public void MoveForward(float verticalInput)
    {
        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * 5);
    }
}
