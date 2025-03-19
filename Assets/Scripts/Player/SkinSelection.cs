using UnityEngine;

public class SkinSelection : MonoBehaviour
{
    public enum Player { Frog, VirtualGuy, PinkMan, MaskDude };

    public Player playerSelection;

    public Animator animator;
    public SpriteRenderer spriteRenderer;

    public RuntimeAnimatorController[] playersController;
    public Sprite[] playersRenderer;

    private void Start()
    {
        // Load the selected skin from PlayerPrefs
        string selectedSkin = PlayerPrefs.GetString("SelectedSkin", "Frog");
        playerSelection = (Player)System.Enum.Parse(typeof(Player), selectedSkin);
        UpdateSkin();
    }

    public void UpdateSkin()
    {
        // Save the selected skin to PlayerPrefs
        PlayerPrefs.SetString("SelectedSkin", playerSelection.ToString());

        switch (playerSelection)
        {
            case Player.Frog:
                animator.runtimeAnimatorController = playersController[0];
                spriteRenderer.sprite = playersRenderer[0];
                break;

            case Player.VirtualGuy:
                animator.runtimeAnimatorController = playersController[1];
                spriteRenderer.sprite = playersRenderer[1];
                break;

            case Player.PinkMan:
                animator.runtimeAnimatorController = playersController[2];
                spriteRenderer.sprite = playersRenderer[2];
                break;

            case Player.MaskDude:
                animator.runtimeAnimatorController = playersController[3];
                spriteRenderer.sprite = playersRenderer[3];
                break;
        }
    }
}
