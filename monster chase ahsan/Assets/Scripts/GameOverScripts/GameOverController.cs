using TMPro;
using UnityEngine;

public class GameOverController : MonoBehaviour
{
    public TMP_Text scores_tmp;

    void Start()
    {
        scores_tmp.SetText("Scores: {0}", ScoreStatic.score);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
