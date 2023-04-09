using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameState {

    public static int score_player1 = 0;
    public static int score_player2 = 0;

    public static int previous_winner = 0;

    // Call this when the new game starts
    public static void resetMatch(){
        Debug.Log("GAMESTATE: RESET MATCH");
        score_player1 = 0;
        score_player2 = 0;
    }

    //Call this when player one wins a round
    public static bool player1Point(){
        score_player1 += 1;
        Debug.Log("GAMESTATE: PLAYER1 +POINT! NOW HAS " + score_player1);
        if(score_player1 > 1){
            previous_winner = 1;
            return true;
        }
        return false;
    }

    //call this when player two wins a round
    public static bool player2Point(){
        score_player2 += 1;
        Debug.Log("GAMESTATE: PLAYER2 +POINT! NOW HAS " + score_player2);
        if(score_player2 > 1){
            previous_winner = 2;
            return true;
        }
        return false;
    }

    
}
