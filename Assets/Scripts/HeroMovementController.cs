using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.CodeDom;

public class HeroMovementController : MonoBehaviour
{
    [SerializeField] private float forwardMovementSpeed;
    [SerializeField] private float horizontalMovementSpeed;
    [SerializeField] private float leftBound;
    [SerializeField] private float rightBound;
    public bool flag=true;
    public GameManager gameManager;
    private float horizontalValue;
    private float newPositionX;

    void FixedUpdate()
    {
        if(!GameManager.instance.IsSessionPlaying)
        return;
        if(forwardMovementSpeed==0&&horizontalMovementSpeed==0)
        {
            StartCoroutine(WaitAndRestart(0.75f));

        }
        if(flag==false)
        {
            StartCoroutine(WaitSuccess(0.75f));
        }
        HandleHorizontalInput();
        SetHeroForwardMovement();
        SetHeroHorizontalMovement();
    }

    public void SetSpeed(int _speed)
    {
        forwardMovementSpeed=_speed;
        horizontalMovementSpeed=_speed;
    }

    private void HandleHorizontalInput()
    {
        if(Input.GetMouseButton(0))
        {
            horizontalValue = Input.GetAxis("Mouse X");
        }
        else
        {
            horizontalValue=0;
        }
    }

    private void SetHeroForwardMovement()
    {
        transform.Translate(Vector3.forward*forwardMovementSpeed*Time.deltaTime);
    }

    private void SetHeroHorizontalMovement()
    {
        newPositionX = transform.position.x+horizontalValue*horizontalMovementSpeed*Time.deltaTime;
        newPositionX = Mathf.Clamp(newPositionX,leftBound,rightBound);
        transform.position = new Vector3 (newPositionX,transform.position.y,transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Obstacle"||other.gameObject.tag=="FinishLine")
        {
            Invoke("rest",1f);
        }
    }

    void rest()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    

    void StopGame ()
    {
        Time.timeScale = 0;
    }

    public IEnumerator WaitAndRestart(float waitTime)
    {   
    yield return new WaitForSeconds(waitTime);
    gameManager.GameOver();   
    StopGame();
    }

    public IEnumerator WaitSuccess(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        gameManager.Success();
        StopGame();
    }
}

