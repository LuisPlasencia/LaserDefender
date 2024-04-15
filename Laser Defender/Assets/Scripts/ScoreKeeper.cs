using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    int score = 0;
    static ScoreKeeper instance;


    void Awake()
    {
        ManageSingleton();
    }

    void ManageSingleton()
    {

  //      2 maneras de crear un singleton: la primera buscando en la scene y la segunda a través de variable static
  //      la segunda manera nos ahorra tener que buscar en el scene (findobjects..) 
  //      int instanceCount = FindObjectsOfType(GetType()).Length;
  //      if(instanceCount > 1)
  
        if(instance != null){
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else 
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public int GetScore()
    {
        return score;
    }

    public void ModifyScore(int value)
    {
        score += value;
        Mathf.Clamp(score, 0, int.MaxValue);
        Debug.Log(score);
    }

    public void ResetScore()
    {
        score = 0;
    }
}
