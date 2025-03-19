using UnityEngine;
using UnityEngine.UI;

public class SkinMenu : MonoBehaviour
{
    public SkinSelection skinSelection;

    public void SelectFrog()
    {
        skinSelection.playerSelection = SkinSelection.Player.Frog;
        skinSelection.UpdateSkin();
    }

    public void SelectVirtualGuy()
    {
        skinSelection.playerSelection = SkinSelection.Player.VirtualGuy;
        skinSelection.UpdateSkin();
    }

    public void SelectPinkMan()
    {
        skinSelection.playerSelection = SkinSelection.Player.PinkMan;
        skinSelection.UpdateSkin();
    }

    public void SelectMaskDude()
    {
        skinSelection.playerSelection = SkinSelection.Player.MaskDude;
        skinSelection.UpdateSkin();
    }
}
