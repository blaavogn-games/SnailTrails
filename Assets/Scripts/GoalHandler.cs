using UnityEngine;
using System.Collections;

public class GoalHandler : MonoBehaviour {
    public AudioClip goal;
    int whiteFlowers = 0, blackFlowers = 0;
    bool whiteInGoal = false, blackInGoal = false;
    public Goal goal_white, goal_black;

    private bool won = false;
    private float wonTimer = 1.2f;

    void Update() {
      //  Debug.Log(Application.loadedLevel);
        if (won) {
            wonTimer -= Time.deltaTime;
            if (wonTimer < 0) {

                if (Application.loadedLevel < 13) { 
                    Application.LoadLevel(Application.loadedLevel + 1);
                } else {
                    Application.LoadLevel(0);
                }
            }

        }

    }

    public void inGoal(bool white) {
        if (white) {
            whiteInGoal = true;
        }else{
            blackInGoal = true;
        }

        checkWin();
    }
    
    public void notInGoal(bool white) {
        if (white) {
            whiteInGoal = false;
        } else {
            blackInGoal = false;
        }
    }

    public void addFlower(bool white) {
        if (white) {
            whiteFlowers++;
            goal_white.setSolid(false);
        } else {
            blackFlowers++;
            goal_black.setSolid(false);
        }
    }
    
    public void removeFlower(bool white) {
        if (white) {
            whiteFlowers--;
            if(whiteFlowers == 0){
                goal_white.setSolid(true);
                checkWin();
            }
        } else {
            blackFlowers--;
            if(blackFlowers == 0){
                goal_black.setSolid(true);
                checkWin();
            }
        }
    }

    private void checkWin() {
        if (whiteInGoal && blackInGoal && blackFlowers == 0 && whiteFlowers == 0) {
            audio.PlayOneShot(goal);
            won = true;
            
        }
    }
}
