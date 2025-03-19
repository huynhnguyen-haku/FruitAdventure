using UnityEngine;
using UnityEngine.UI;

public class SkinMenu : MonoBehaviour
{
    public SkinSelection skinSelection;

    public void SelectFrog()
    {
        skinSelection.playerSelection = SkinSelection.Player.Frog;
        PlayerPrefs.SetString("SelectedSkin", "Frog");
        skinSelection.UpdateSkin();
    }

    public void SelectVirtualGuy()
    {
        skinSelection.playerSelection = SkinSelection.Player.VirtualGuy;
        PlayerPrefs.SetString("SelectedSkin", "VirtualGuy");
        skinSelection.UpdateSkin();
    }

    public void SelectPinkMan()
    {
        skinSelection.playerSelection = SkinSelection.Player.PinkMan;
        PlayerPrefs.SetString("SelectedSkin", "PinkMan");
        skinSelection.UpdateSkin();
    }

    public void SelectMaskDude()
    {
        skinSelection.playerSelection = SkinSelection.Player.MaskDude;
        PlayerPrefs.SetString("SelectedSkin", "MaskDude");
        skinSelection.UpdateSkin();
    }
}
