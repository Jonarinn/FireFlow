using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils
{
    public static T[,] Create2DArray<T>(int rows, int cols, Func<int, int, T> initializer)
    {
        T[,] array = new T[rows, cols];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                array[i, j] = initializer(i, j);
            }
        }
        return array;
    }
}
