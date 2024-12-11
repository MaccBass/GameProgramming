using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum CookerStatus {
    AVAILABLE,
    PREPARING,
    COOKING,
    COMPLETED
}

public class Cooker : MonoBehaviour
{
    public ToolType toolType;
    public CookerStatus status;
    public Slider cookingSlider;
    private float cookingTimer = 0;


    public Recipe targetRecipe;
    public Recipe resultRecipe;
    public Sprite trashSprite;

    public float fSoundDuration = 1.0f;

    public AudioClip cookingCompleteSound;
    public AudioClip potSound;
    public AudioClip fryerAndPanSound;
    public AudioClip cuttingboardSound;

    public AudioSource CompleteAudioSource;
    public AudioSource audioSource;

    private void Awake() {
        cookingSlider = GetComponentInChildren<Slider>(true);
        cookingSlider.gameObject.SetActive(false);
        status = CookerStatus.AVAILABLE;
        if (gameObject.name == "Fryer") toolType = ToolType.Fryer;
        else if (gameObject.name == "FryingPan") toolType = ToolType.Grill;
        else if (gameObject.name == "Pot") toolType = ToolType.Pot;
        else if (gameObject.name == "CuttingBoard") toolType = ToolType.Board;

        audioSource = GetComponent<AudioSource>();
        if(audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        if(CompleteAudioSource == null)
        {
            CompleteAudioSource = gameObject.AddComponent<AudioSource>();
        }
        audioSource.playOnAwake = false;
        CompleteAudioSource.playOnAwake = false;
    }

    public void Update() {
        if (status == CookerStatus.COOKING) {
            cookingTimer += Time.deltaTime;
            cookingSlider.value = cookingTimer / targetRecipe.cookingTime;
            if (cookingTimer >= targetRecipe.cookingTime) {
                cookingTimer = 0;
                status = CookerStatus.COMPLETED;

                Debug.Log("Cooking completed on " + toolType);
                completeFood();
            }
        }
        
        if (status == CookerStatus.COMPLETED && Input.GetKeyDown(KeyCode.X)) {
            HoldFood();
        }
    }

    public void prepareCooking() {
        if (status != CookerStatus.AVAILABLE) return;
        Debug.Log(toolType + " is preparing");
        status = CookerStatus.PREPARING;

        CookerManager.Instance.showPopup(this);
    }

    public void startCooking(Recipe recipe) {
        targetRecipe = recipe;

        status = CookerStatus.COOKING;
        cookingTimer += Time.deltaTime;
        cookingSlider.gameObject.SetActive(true);

        //사운드 재생
        PlayCookingSound();
    }

    public void completeFood() {
        resultRecipe = new Recipe(targetRecipe);
        if (targetRecipe.toolType != this.toolType) 
        {
            resultRecipe.isTrash = true;
            resultRecipe.icon = trashSprite;
            Debug.Log("TRASH!!!!!!!!!!!!!!!!!!!!!!!!");
        }
        if(cookingCompleteSound != null)
        {
            audioSource.clip = cookingCompleteSound;
            audioSource.Play();
            Invoke("StopCompleteMusic", fSoundDuration);
        }
    }

    public void HoldFood() {
        status = CookerStatus.AVAILABLE;
        cookingTimer = 0;
        cookingSlider.gameObject.SetActive(false);
        Debug.Log(resultRecipe.itemName);
        HeldItemsManager.Instance.HoldItem(resultRecipe);
        resultRecipe = null;
    }
    private void PlayCookingSound()
    {
        switch(toolType)
        {
            case ToolType.Pot:
                PlaySound(potSound);
                break;
            case ToolType.Fryer:
            case ToolType.Grill:
                PlaySound(fryerAndPanSound);
                break;
            case ToolType.Board:
                PlaySound(cuttingboardSound);
                break;
        }
    }

    private void PlaySound(AudioClip clip)
    {
        if(clip != null)
        {
            audioSource.clip = clip;
            audioSource.Play();
            Invoke("StopSound", 2f);
        }
    }
    private void StopSound()
    {
        audioSource.Stop();
    }
    private void StopCompleteMusic()
    {
        CompleteAudioSource.Stop();
    }
}
