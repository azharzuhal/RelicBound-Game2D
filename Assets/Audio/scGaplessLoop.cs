using UnityEngine;

public class scGaplessLoop : MonoBehaviour
{
    [Header("Hubungkan ke AudioGameplay")]
    public AudioSource sumberAudioUtama; // Tarik object AudioGameplay ke sini

    [Header("File Lagu")]
    public AudioClip musicClip;

    private AudioSource[] sources;
    private int currentSource = 0;
    private double nextEventTime;

    void Start()
    {
        sources = new AudioSource[2];
        for (int i = 0; i < 2; i++)
        {
            sources[i] = gameObject.AddComponent<AudioSource>();
            sources[i].clip = musicClip;
            sources[i].playOnAwake = false;
        }

        // Mulai
        nextEventTime = AudioSettings.dspTime + 0.1;
        sources[currentSource].PlayScheduled(nextEventTime);

        double clipDuration = (double)musicClip.samples / musicClip.frequency;
        nextEventTime += clipDuration;
        sources[1 - currentSource].PlayScheduled(nextEventTime);
    }

    void Update()
    {
        // --- INI PERUBAHANNYA ---
        // Script akan selalu menyamakan volume dengan AudioGameplay
        if (sumberAudioUtama != null)
        {
            float volumeTarget = sumberAudioUtama.volume;
            sources[0].volume = volumeTarget;
            sources[1].volume = volumeTarget;
        }
        // ------------------------

        if (AudioSettings.dspTime > nextEventTime - 1.0)
        {
            currentSource = 1 - currentSource;
            double clipDuration = (double)musicClip.samples / musicClip.frequency;
            sources[currentSource].PlayScheduled(nextEventTime);
            nextEventTime += clipDuration;
        }
    }
}