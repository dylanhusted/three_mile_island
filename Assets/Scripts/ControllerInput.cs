using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerInput : MonoBehaviour {

    public AudioClip clip;
    public AudioSource audioSource;
    public Transform gunBarrelTransform;
    public static int userPoints = 0;

    // Use this for initialization
    void Start () {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = clip;
	}
	
	// Update is called once per frame
	void Update () {
		if (OVRInput.Get(OVRInput.Button.SecondaryHandTrigger)) {
            audioSource.Play();
            RaycastGun();
        }
        TextMesh pointsText = GameObject.Find("pointsTextMesh").GetComponent<TextMesh>();
        pointsText.text = "Points: " + System.Environment.NewLine + userPoints;
    }

    private void RaycastGun() {
        RaycastHit hit;
        if (Physics.Raycast(gunBarrelTransform.position, gunBarrelTransform.forward, out hit)) {
            if (hit.collider.gameObject.CompareTag("Snake")) {
                Destroy(hit.collider.gameObject);
                userPoints += 25;
            }
        }
    }
}
