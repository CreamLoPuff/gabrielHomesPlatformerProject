using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour
{
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Camera();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
        else if (Input.GetKey(KeyCode.R))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(1);
            Time.timeScale = 1;
        }
    }

    public void Camera()
    {  
        transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, -10);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }
}
