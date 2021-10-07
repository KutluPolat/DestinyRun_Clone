using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static Player player = new Player();

    public GameObject[] models;
    public Animator[] _animatorsOfCharacters;

    public float characterSpeed = 4f, swipeSpeed = 5f;

    private bool _isGameStarted, _isCharacterTouchingRightWall, _isCharacterTouchingLeftWall;
    private string _oldJob;
    

    private void Start() => SetModelAccordingToJob(); // Set starting job to new graduate (Because entrepreneurialPersonality is 0 at the beginning).

    void FixedUpdate()
    {
        ConsoleProDebug.Watch("Personality: ", player.entrepreneurialPersonality.ToString());
        ControlsForUnityEditor();
        ControlsForAndroid();

        if (_isGameStarted) // if game started, start to move character forward.
            Move(0f, characterSpeed * Time.deltaTime);
    }

    private void ControlsForUnityEditor()
    {
#if UNITY_EDITOR
        if (Input.GetKey(KeyCode.A))
            Move(-swipeSpeed * Time.deltaTime);

        else if (Input.GetKey(KeyCode.D))
            Move(swipeSpeed * Time.deltaTime);
#endif
    }
    private void ControlsForAndroid()
    {
#if PLATFORM_ANDROID
        if (Input.touchCount > 0)
            Move(Input.touches[0].deltaPosition.x * Time.deltaTime);
#endif
    }

    /// <param name="directionX">Negative values moves the character to the left while positive ones to the right.<br/>The absolute of the value affects the speed.</param>
    /// <param name="directionZ">Negative values moves the character backward while positive ones moves the character forward.<br/>The absolute of the value affects the speed.</param>
    private void Move(float directionX, float directionZ = 0f)
    {
        _isGameStarted = true; // When any input detected, set _isGameStarted true.

        // If the character is trying to go left while she's already at the left edge, return.
        if (_isCharacterTouchingLeftWall && directionX < 0)
            return;

        // If the character is trying to go right while she's already at the right edge, return.
        if (_isCharacterTouchingRightWall && directionX > 0)
            return;

        transform.position = new Vector3(
                transform.position.x + directionX,
                transform.position.y,
                transform.position.z + directionZ);

        if (directionZ != 0)
            foreach (Animator animator in _animatorsOfCharacters)
                animator.SetTrigger("FastRun");

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hamburger")
        {
            other.GetComponent<HamburgerObject>().hamburger.Eat();
            Destroy(other.gameObject);
            SetModelAccordingToJob();
        }
        else if (other.tag == "Doughnut")
        {
            other.GetComponent<DoughnutObject>().doughnut.Eat();
            Destroy(other.gameObject);
            SetModelAccordingToJob();
        }

        if(other.tag == "Chooser")
        {
            foreach (GameObject chooser in GameObject.FindGameObjectsWithTag("Chooser"))
                Destroy(chooser.GetComponent<BoxCollider>()); // Destroying box colliders to block triggering with two choosers.

            bool _isChooserWantToBeAnOfficer;

            if (other.name.Contains("Police"))
                _isChooserWantToBeAnOfficer = true;
            else
                _isChooserWantToBeAnOfficer = false;

            foreach (FoodObject food in FindObjectsOfType<FoodObject>())
                food.ReArrangeFoodsAccordingToTargetJob(_isChooserWantToBeAnOfficer);

        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "InvisibleWallRight")
            _isCharacterTouchingRightWall = true;

        if (other.tag == "InvisibleWallLeft")
            _isCharacterTouchingLeftWall = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "InvisibleWallRight")
            _isCharacterTouchingRightWall = false;

        if (other.tag == "InvisibleWallLeft")
            _isCharacterTouchingLeftWall = false;
    }

    private void SetModelAccordingToJob()
    {
        var currentJob = player.GetCurrentJob();

        if (_oldJob == currentJob) // If job isn't changed after eating food, return.
            return;
        else
            _oldJob = currentJob;  // Else, change old job to the new one.

        foreach (GameObject model in models)
            model.SetActive(false); // Deactivate every 3D models.

        ConsoleProDebug.LogToFilter(currentJob, "Job");
        switch (currentJob)
        {
            case "Detective":
                ConsoleProDebug.LogToFilter("Detective", "Job");
                models[0].transform.rotation = Quaternion.identity;
                models[0].SetActive(true);  // Set active only Detective model.
                break;

            case "Officer":
                ConsoleProDebug.LogToFilter("Officer", "Job");
                models[1].transform.rotation = Quaternion.identity;
                models[1].SetActive(true);  // Set active only Police model.
                break;

            case "NewGraduate":
                ConsoleProDebug.LogToFilter("NewGraduate", "Job");
                models[2].transform.rotation = Quaternion.identity;
                models[2].SetActive(true);  // Set active only NewGraduated model.
                break;

            case "Entrepreneur":
                ConsoleProDebug.LogToFilter("Entrepreneur", "Job");
                models[3].transform.rotation = Quaternion.identity;
                models[3].SetActive(true);  // Set active only Entrepreneur model.
                break;

            case "BusinessWoman":
                ConsoleProDebug.LogToFilter("BusinessWoman", "Job");
                models[4].transform.rotation = Quaternion.identity;
                models[4].SetActive(true);  // Set active only BusinessWoman model.
                break;
        }
    }
}
