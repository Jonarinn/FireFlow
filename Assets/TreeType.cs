

using UnityEngine;

public class TreeType : MonoBehaviour
{

    public void ChangeTreeType()
    {
        TreeGamemode gamemode = GridRenderer.treeGamemode;
        switch (gamemode)
        {
            case TreeGamemode.Normal:
                {
                    GridRenderer.treeGamemode = TreeGamemode.Jungle;
                    break;
                }
            case TreeGamemode.Jungle:
                {
                    GridRenderer.treeGamemode = TreeGamemode.Normal;
                    break;
                }

        }
    }
}