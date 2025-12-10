using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public class Light_enemy : Enemis
{
    [SerializeField] bool ThereIsPLayer;
    Vector2 StartPosition; //mi da la posizione iniziale dove è posizionato L'enemy
    Vector2[] WayPoints; // è un Array di punti di destinazione, calcolati in base alla posizione iniziale e non trasform, altrimenti andrebbero tutti nello stesso punto di mappa
    int CurrentPosition=1; // indica Verso a quale WayPoint devo andare, settato a uno (1) per indicargli la prima destinazione

    private void Awake()
    {
        StartPosition = transform.position;

        //qui creo l'array di waypoint e gli stesso le sue destinazioni
        WayPoints = new Vector2[4];
        WayPoints[0] = StartPosition;
        //qui sto creando un pattern quadrato
        WayPoints[1] = StartPosition + Vector2.right * 3f; //qui gli sto passando tramite Right; StarPosition+ 1*3f,0; cosi gli dico resta sullo stesso asse delle Y, mentre la X deve essere di 3 in più verso destra
        WayPoints[2] = StartPosition +new Vector2(3f, -3f); //al posto di usare Vector2.up * -3; o direttamente Vector3.down per andare verso il basso; creo un nuovo vettore, dove nella X ci sta la posizione di x Aggiornata
                                                            // mentre in Y quella nuova, se avvessi lasciato Up o Down avvrebbe fatto una diagonale, perchè la x indica 0
        WayPoints[3] = StartPosition + Vector2.down * 3f; //qui essendo che down di base è 0,-1 e non 1; basta fargli *3 anfiche si trasformi in *-3; poi lo posso usare siccome qua in realta gli sto dicendo
                                                          // resta a y -3 e vai verso x 0, se avessi messo un left sarebbe andato oltre lo x 0, ma ad x -3; inoltre avvrebbe fatto una diagonale siccome la y sarebbe stata 0;


    }
    public override void LogicMove()
    {
        transform.position = Vector2.MoveTowards(transform.position, WayPoints[CurrentPosition], Speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, WayPoints[CurrentPosition]) < 0.05f)
        {
            CurrentPosition++;
            if (CurrentPosition >= WayPoints.Length)
            {
                CurrentPosition = 0;
            }
        }

   
    }
    private void Update()
    {
        if (ThereIsPLayer)
        {
            base.LogicMove();
        }
        else
        {
            LogicMove();
        }

    }
}

//bool waypoint;
//bool waypoint2;
//bool waypoint3;


//Vector3 pos1 = new Vector3(0, 0, 0);
//Vector3 pos2 = new Vector3(5, 0, 0);
//Vector3 pos3 = new Vector3(0, 5, 0);
//Vector3 pos4 = new Vector3(-5, 0, 0);


//public override void LogicMove()
//{
//    if (transform.position == pos1)
//    {
//        waypoint = true;
//    }
//    else if (transform.position == pos2)
//    {
//        waypoint= false;
//        waypoint2 = true;
//    }
//    else if(transform.position == pos3) 
//    {
//        waypoint2= false;
//        waypoint3= true;
//    }else if(transform.position == pos4)
//    {
//        waypoint3= false;
//    }

//    if (waypoint)
//    {
//        transform.position = Vector2.MoveTowards(transform.position, pos2, Speed * Time.deltaTime);
//    }
//    else if (waypoint2)
//    {
//        transform.position = Vector2.MoveTowards(transform.position, pos3, Speed * Time.deltaTime);
//    }
//    else if (waypoint3)
//    {
//        transform.position = Vector2.MoveTowards(transform.position, pos4, Speed * Time.deltaTime);
//    }
//    else
//    {
//        transform.position = Vector2.MoveTowards(transform.position, pos1, Speed * Time.deltaTime);
//    }

//}