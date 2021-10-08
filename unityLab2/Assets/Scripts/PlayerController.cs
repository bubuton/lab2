using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//unity input component
using UnityEngine.InputSystem;
//unity ui
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Vector2 moveValue;
    public float speed;
    public Text scoreText;
    public Text winText;

    private int count;
    private int numPickUps = 4;

    private void Start()
    {
        count = 0;
        winText.text = "";
        SetCountText();
    }

    void OnMove(InputValue value) {
        moveValue = value.Get<Vector2>();
    }

    void FixedUpdate() {
        Vector3 movement = new Vector3(moveValue.x, 0.0f, moveValue.y);

        GetComponent<Rigidbody>().AddForce(movement * speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "PickUp")
        {
            other.gameObject.SetActive(false);
            count += 1;
            SetCountText();
        }
    }

    private void SetCountText() {
        scoreText.text = "Score: " + count.ToString();
        if (count >= numPickUps) {
            scoreText.text = "";
            winText.text = "You win!";
        }
    }

}
