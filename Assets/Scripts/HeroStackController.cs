using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroStackController : MonoBehaviour
{
    public AudioSource Ding;
    public List<GameObject> blocklist = new List<GameObject>();
    private GameObject lastBlockObject;
    public HeroMovementController Player;
    public Score scoreCount;
    private void Start()
    {
        UpdateLastBlockObject();
    }

    public void IncreaseNewBlock(GameObject _gameObject)
    {
        transform.position =new Vector3(transform.position.x,transform.position.y+0.0497f,transform.position.z);
        _gameObject.transform.position = new Vector3(transform.position.x,lastBlockObject.transform.position.y-0.0497f,transform.position.z);
        _gameObject.transform.SetParent(transform);
        blocklist.Add(_gameObject);
        UpdateLastBlockObject();
        Ding.Play();
    }

    public void DecreaseBlock(GameObject _gameObject)
    {
        if(blocklist.Count==1)
        {
        Player.SetSpeed(0);
        }
        _gameObject.transform.parent = null;
        blocklist.Remove(_gameObject);
        UpdateLastBlockObject();
        Destroy(_gameObject,1.5f);

    }

    public void UpdateLastBlockObject()
    {
        lastBlockObject = blocklist[blocklist.Count-1];

    }

    public void SuccessPlayer()
    {
        Player.flag=false;
    }
    public void Score2x()
    {
        scoreCount.SetMultiplier(2);
    }

    public void Score5x()
    {
        scoreCount.SetMultiplier(5);
    }

    public void Score10x()
    {
        scoreCount.SetMultiplier(10);
    }

    public void FinalScore()
    {
        scoreCount.SetScore(blocklist.Count-1);
        SuccessPlayer();
    }

}