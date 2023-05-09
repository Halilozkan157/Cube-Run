using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    [SerializeField] private HeroStackController heroStackController;
    private Vector3 direction = Vector3.back;
    private bool isStack = false;
    private RaycastHit hit;
    private void Start()
    {
        heroStackController = GameObject.FindObjectOfType<HeroStackController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        switch(other.gameObject.tag)
        {case "GreenCube":
            if(!isStack)
            {
                isStack = !isStack;
                heroStackController.IncreaseNewBlock(gameObject);
                SetDirection();
            }
        break;
        case "Obstacle":
            heroStackController.DecreaseBlock(gameObject);
        break;
        case "FinishLine":
            heroStackController.FinalScore();
        break;
        case "2x":
        if(heroStackController.blocklist.Count>1)
            heroStackController.DecreaseBlock(gameObject);

        heroStackController.Score2x();
        break;
        case "5x":
        if(heroStackController.blocklist.Count>1)
            heroStackController.DecreaseBlock(gameObject);

        heroStackController.Score5x();
        break;
        case "10x":
        if(heroStackController.blocklist.Count>1)
            heroStackController.DecreaseBlock(gameObject);

        heroStackController.Score10x();
        break;
        }

    }

    private void SetDirection()
    {
        direction = Vector3.forward;
    }

}
