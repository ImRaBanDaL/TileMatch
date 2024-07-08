using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    [Header("Project Dependency")]
    [SerializeField] Tile tilePrefab; //Tile spawnlayabilmek i�in.

    [Header("Scene Dependency")]
    [SerializeField] Transform tileParent; //Tile'�n spawnlanaca�� parent'�.

    /*Tile instantiate yap�ld�ktan sonra tutulaca�� i�in bir array ol�turuyoruz. Daha sonra bu listeye ula�abilmek gerekecek. Bu y�zdne d��ar�dan okunabilir ama de�i�tirilemez olarak ayarlamam�z gerekiyor. 
     * Bunu get ve set ile yap�yoruz.*/

    public Tile[] Tiles { get; private set; }


    void PrepareTile()
    {
        var tileCount = 5;
        Tiles = new Tile[tileCount]; //TODO: Change with level tile amount

        for (int i = 0; i < tileCount; i++)
        {
            Tiles[i] = Instantiate(tilePrefab, tileParent);
        }
    }
    
}
