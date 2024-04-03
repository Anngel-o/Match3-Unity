using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public int width;
    public int height;
    public GameObject tileObject;
    public float cameraSizeOffset; //agregar un número al tamano ortográfico de la cámara
    public float cameraVerticalOffset; //agregar un valor a la posición en vertical
    public GameObject[] availablePieces; //piezas disponibles en la cuadrícula

    // Start is called before the first frame update
    void Start()
    {
        SetupBoard();
        PositionCamera();
        SetupPieces();
    }
    

    private void SetupPieces()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                var selectedPiece = availablePieces[UnityEngine.Random.Range(0, availablePieces.Length)];
                //crear el tablero instanciando objetos de cuadricula(sprite de cuadro vaciío de los objectos que harán match) en la posición (i, j, -5)
                var o = Instantiate(selectedPiece, new Vector3(x, y, -5), Quaternion.identity);
                //Quaternion.identity se utiliza para especificar que no se aplicará ninguna rotación al objeto.
                o.transform.parent = transform;
                //establece el objeto recién creado (o) como un hijo del objeto que contiene este script (transform). Esto significa que, en la jerarquía de la escena, el objeto o estará bajo el objeto que contiene este script. Como resultado, todos los objetos instanciados por esta función SetupBoard estarán agrupados bajo el mismo objeto en la jerarquía de la escena.
                o.GetComponent<Piece>()?.Setup(x, y, this);
            }
        }
    }

    private void PositionCamera()
    {
        //Ajustando y posicionando la cámara a un tamano ortográfico correcto
        float newPosX = (float) width / 2;
        float newPosY = (float) height / 2;

        //se resta -0.5 debido a la diferencia que Unity acomoda las unidades
        Camera.main.transform.position = new Vector3(newPosX - 0.5f, newPosY - 0.5f + cameraVerticalOffset, -10f);

        float horizontal = width + 1;
        float vertical = (height/2) + 1;
        //si el valor de horizontal es mayor que el de vertical se empleará el valor de horizontal, sino el de vertical, operación ternaria
        Camera.main.orthographicSize = horizontal > vertical ? horizontal + cameraSizeOffset: vertical + cameraSizeOffset;
    }

    private void SetupBoard()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                //crear el tablero instanciando objetos de cuadricula(sprite de cuadro vaciío de los objectos que harán match) en la posición (i, j, -5)
                var o = Instantiate(tileObject, new Vector3(x, y, -5), Quaternion.identity);
                //Quaternion.identity se utiliza para especificar que no se aplicará ninguna rotación al objeto.
                o.transform.parent = transform;
                //establece el objeto recién creado (o) como un hijo del objeto que contiene este script (transform). Esto significa que, en la jerarquía de la escena, el objeto o estará bajo el objeto que contiene este script. Como resultado, todos los objetos instanciados por esta función SetupBoard estarán agrupados bajo el mismo objeto en la jerarquía de la escena.
                o.GetComponent<Tile>()?.Setup(x, y, this);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
