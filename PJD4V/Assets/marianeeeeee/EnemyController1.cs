using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController1 : MonoBehaviour
{
    [SerializeField] private float changeDirectionTime;
    private Vector2 walkDirection;
    private float _currentChangeTime;
    private Animator enemyAI;

    public void SetWalkDirection (Vector2 direction){


        walkDirection = direction;
    }
    public void MoveDirection(){

        transform.Translate(walkDirection * Time.deltaTime); 
    }

    void Start(){

        enemyAI = GetComponent<Animator>();
    }
  
    void Update(){

        MoveDirection();
        CountTime();

    }

    public void CountTime(){

        if (_currentChangeTime <= changeDirectionTime){

            _currentChangeTime += Time.deltaTime;
      
        }
        else {
            _currentChangeTime = 0; //mudar a direcao de andar
            enemyAI.SetTrigger("Change Direction");
        }
    }
}
