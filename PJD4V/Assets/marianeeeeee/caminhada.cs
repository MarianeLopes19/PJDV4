using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class caminhada : StateMachineBehaviour
{
    private EnemyController1 myEnemy;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex){

        myEnemy = animator.GetComponent<EnemyController1>();

        if(Random.value < 0.5f){

            myEnemy.SetWalkDirection(Vector2.left);
        }
        else{
            myEnemy.SetWalkDirection(Vector2.right);
        }



    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex){

        myEnemy.MoveDirection();
        myEnemy.CountTime();

    }
}
