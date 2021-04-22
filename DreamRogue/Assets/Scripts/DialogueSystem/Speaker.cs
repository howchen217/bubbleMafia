using UnityEngine;

[CreateAssetMenu(fileName = "New Speaker", menuName = "Dialogue/New Speaker")] //this makes it pop up on asset menu
public class Speaker : ScriptableObject
{
    [System.Serializable]
    private class MoodAndSprite {
        public Mood mood;
        public Sprite sprite;
    }
    [SerializeField] private MoodAndSprite[] moodSprites = new MoodAndSprite[Mood.GetValues(typeof(Mood)).Length];
    [SerializeField] private string speakerName;
    [SerializeField] private SoundBundle speakerVoice;
    [SerializeField] private float speakerPitch;

    public enum Mood {
        Default,
        Curious,
        Suprised,
        Happy,
        Angry,
        Scared
    }

    public string GetName() {
        return speakerName;
    }

    public SoundBundle GetSpeakerVoice() {
        return speakerVoice;
    }

    public float GetSpeakerPitch() {
        return speakerPitch;
    }

    public Sprite GetSprite(Mood mood) {
        //to avoid weird index, we always want 
        if (moodSprites.Length == Mood.GetValues(typeof(Mood)).Length)
        {
            if (moodSprites[(int)mood].sprite != null)
            {
                return moodSprites[(int)mood].sprite;
            }
            else 
            {
                throw new System.Exception("the sprite for this mood is null!");
            }
        }
        else {
            throw new System.Exception("MoodAndSprite array's length does not match the enum's length, indexing issue!");
        }
    }
}
