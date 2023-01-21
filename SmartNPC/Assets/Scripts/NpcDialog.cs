using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;

public class NpcDialog : MonoBehaviour
{
    [SerializeField] private GameObject mainCamera;
    [SerializeField] private GameObject toActivate;
    [SerializeField] private Transform standingPoint;
    
    private async void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Transform avatar = other.transform;

            // disable player input
            avatar.GetComponent<PlayerInput>().enabled = false;

            await Task.Delay(50);
            
            // teleport the avatar to StandingPoint
            avatar.position = standingPoint.position;
            avatar.rotation = standingPoint.rotation;
            
            // disable main camera, enable dialog camera
            mainCamera.SetActive(false);
            toActivate.SetActive(true);
            
            // gpt chat ui
        }
    }
    
    // recover
}
