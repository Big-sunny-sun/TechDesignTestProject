using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] tiles; // Массив плиток
    private int emptyTileIndex; // Индекс пустой плитки

    void Start()
    {
        // Инициализация пустой плитки (например, последняя плитка)
        emptyTileIndex = tiles.Length - 1;
    }

    public void OnTileClick(int index)
    {
        // Проверяем, можно ли поменять местами плитки
        if (CanSwap(index))
        {
            SwapTiles(index, emptyTileIndex);
            emptyTileIndex = index; // Обновляем индекс пустой плитки
        }
    }

    private bool CanSwap(int index)
    {
        // Проверяем, находится ли плитка рядом с пустой плиткой
        int row = index / 4;
        int col = index % 4;
        int emptyRow = emptyTileIndex / 4;
        int emptyCol = emptyTileIndex % 4;

        return (Mathf.Abs(row - emptyRow) == 1 && col == emptyCol) || (Mathf.Abs(col - emptyCol) == 1 && row == emptyRow);
    }

    private void SwapTiles(int index1, int index2)
    {
        // Меняем местами плитки
        Vector3 tempPosition = tiles[index1].transform.position;
        tiles[index1].transform.position = tiles[index2].transform.position;
        tiles[index2].transform.position = tempPosition;

        // Меняем местами элементы в массиве
        GameObject tempTile = tiles[index1];
        tiles[index1] = tiles[index2];
        tiles[index2] = tempTile;
    }
}
