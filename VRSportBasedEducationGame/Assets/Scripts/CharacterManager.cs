using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public static CharacterManager Instance;

    [System.Serializable]
    public class CharacterSlot
    {
        public GameObject characterObject;   // Sahnedeki karakter objesi
        public Transform characterPoint;     // yemegi nerede tutacak
    }

    public List<CharacterSlot> characterSlots = new List<CharacterSlot>();

    public int currentIndex = 0;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        UpdateCharacters();
    }

    /// <summary>
    /// Listedeki karakterleri aktif/pasif yapar
    /// </summary>
    public void UpdateCharacters()
    {
        for (int i = 0; i < characterSlots.Count; i++)
        {
            if (characterSlots[i].characterObject != null)
                characterSlots[i].characterObject.SetActive(i == currentIndex);
        }
    }

    /// <summary>
    /// Sonraki karaktere gecer, sona gelirse basa doner
    /// </summary>
    public void NextChar()
    {
        currentIndex++;
        if (currentIndex >= characterSlots.Count)
            currentIndex = 0;

        UpdateCharacters();
    }

    /// <summary>
    /// Onceki karakter 
    /// </summary>
    public void PreviousChar()
    {
        currentIndex--;
        if (currentIndex < 0)
            currentIndex = characterSlots.Count - 1;

        UpdateCharacters();
    }
}
