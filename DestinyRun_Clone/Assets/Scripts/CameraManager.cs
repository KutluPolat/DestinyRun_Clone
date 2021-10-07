using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Transform characters; // The object that holds other caracter models.
    public float cameraHeight = 12f, distanceBetweenCharactersAndCamera = 5f, cameraSpeed = 1f;

    private void FixedUpdate()
    {
        var targetPosition = new Vector3(characters.position.x, cameraHeight, characters.position.z - distanceBetweenCharactersAndCamera);
        transform.position = Vector3.Lerp(transform.position, targetPosition, Mathf.Abs(cameraSpeed) * Time.deltaTime);
    }
}
