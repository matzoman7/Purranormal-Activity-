using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    //BASIC FOR NOW I just want to see the movements better

    public Transform targetPlayer; //The player
    public Vector3 offset = new Vector3(1.5f, 3f, -3f);
    public float speed = 10f;

    private void Start()
    {
        //Lock cursor to center of the screen. For now idk if we want it 
        Cursor.lockState = CursorLockMode.Locked;
        //Hides the cursor
        Cursor.visible = false;
    }
    private void LateUpdate()
    {
        if (targetPlayer == null) return;

        //Camera Position
        Vector3 cameraPos = targetPlayer.position + targetPlayer.TransformDirection(offset);
        //Camera Movement
        transform.position = Vector3.Lerp(transform.position,cameraPos, speed * Time.deltaTime);
        //Looking at player. Here for now just want to always see the player
        transform.LookAt(targetPlayer.position + Vector3.up * 1.5f);
    }
}
