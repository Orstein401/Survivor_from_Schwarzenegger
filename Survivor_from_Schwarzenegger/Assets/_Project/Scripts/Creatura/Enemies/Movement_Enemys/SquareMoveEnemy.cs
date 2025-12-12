using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareMoveEnemy : MoveEnemy
{

    private Vector2[] WayPoints; // è un Array di punti di destinazione, calcolati in base alla posizione iniziale e non trasform, altrimenti andrebbero tutti nello stesso punto di mappa
    private int CurrentPosition = 1; // indica Verso a quale WayPoint devo andare, settato a uno (1) per indicargli la prima destinazione

    protected override void Awake()
    {
        base.Awake();

    }
    public override void SetUpPattern()
    {
        //qui creo l'array di waypoint e gli stesso le sue destinazioni
        WayPoints = new Vector2[4];
        WayPoints[0] = StartPosition;
        //qui sto creando un pattern quadrato
        WayPoints[1] = StartPosition + Vector2.right * LenghtPattern; //qui gli sto passando tramite Right; StarPosition+ 1*3f,0; cosi gli dico resta sullo stesso asse delle Y, mentre la X deve essere di 3 in più verso destra
        WayPoints[2] = StartPosition + new Vector2(LenghtPattern, -LenghtPattern); //al posto di usare Vector2.up * -3; o direttamente Vector3.down per andare verso il basso; creo un nuovo vettore, dove nella X ci sta la posizione di x Aggiornata
                                                                                   // mentre in Y quella nuova, se avvessi lasciato Up o Down avvrebbe fatto una diagonale, perchè la x indica 0
        WayPoints[3] = StartPosition + Vector2.down * LenghtPattern; //qui essendo che down di base è 0,-1 e non 1; basta fargli *3 anfiche si trasformi in *-3; poi lo posso usare siccome qua in realta gli sto dicendo
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
}
