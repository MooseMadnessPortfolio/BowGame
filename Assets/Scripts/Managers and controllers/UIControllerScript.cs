using UnityEngine;
using UnityEngine.UI;

public class UIControllerScript : MonoBehaviour
{
    public Text scoreText;

    public void SetScore(int score)
    {
        scoreText.text = "Левки: " + score;
    } 
}