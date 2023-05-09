using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int score = 10;
    public int multiplier=10;
    public Text ScoreText;
 
   void Update()
   {
    ScoreText.text = score.ToString();
   }

   public void SetScore(int x)
   {
    score=x;
    CalculateScore();
   }

   public void SetMultiplier(int x)
   {
    multiplier=x;
   }

   private void CalculateScore()
   {
    score*=multiplier;
   }
}
