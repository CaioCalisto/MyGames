using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;

public class OnNpcDialogTriggered : MonoBehaviour
{
    [SerializeField] private GameObject mainCamera;
    [SerializeField] private GameObject chatGptDialog;
    [SerializeField] private Transform standingPoint;

    private Transform avatar;
    
    private async void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            avatar = other.transform;

            // disable player input
            avatar.GetComponent<PlayerInput>().enabled = false;

            await Task.Delay(50);
            
            // teleport the avatar to StandingPoint
            avatar.position = standingPoint.position;
            avatar.rotation = standingPoint.rotation;
            
            // disable main camera, enable dialog camera
            mainCamera.SetActive(false);
            chatGptDialog.SetActive(true);
            
            // display cursor
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void Recover()
    {
        avatar.GetComponent<PlayerInput>().enabled = true;

        mainCamera.SetActive(true);
        chatGptDialog.SetActive(false);
            
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
