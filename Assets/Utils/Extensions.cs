using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extensions
{
    public static void Let<T>(this T? obj, Action<T> action) where T : struct
    {
        if (obj.HasValue)
        {
            action(obj.Value);
        }
    }
}
