using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public AudioMixerGroup mixerGroup;

    public Sound[] sounds;

    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.loop = s.loop;

            s.source.outputAudioMixerGroup = mixerGroup;
        }

        PlayBackgroundMusic();
    }

    public void Play(string sound)
    {
        Sound s = Array.Find(sounds, item => item.name == sound);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + sound + " not found! Cannot play!");
            return;
        }

        s.source.volume = s.volume * (1f + UnityEngine.Random.Range(-s.volumeVariance / 2f, s.volumeVariance / 2f));
        s.source.pitch = s.pitch * (1f + UnityEngine.Random.Range(-s.pitchVariance / 2f, s.pitchVariance / 2f));

        s.source.Play();
    }

    public void Stop(string sound)
    {
        Sound s = Array.Find(sounds, item => item.name == sound);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + sound + " not found! Cannot stop!");
            return;
        }
        s.source.Stop();
    }

    public void Pause(string sound)
    {
        Sound s = Array.Find(sounds, item => item.name == sound);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + sound + " not found! Cannot pause!");
            return;
        }
        s.source.Pause();
    }

    public void PlayBackgroundMusic()
    {
        Play(GetBackgroundMusicName());
    }

    public void StopBackgroundMusic()
    {
        Stop(GetBackgroundMusicName());
    }

    public void PauseBackgroundMusic()
    {
        Pause(GetBackgroundMusicName());
    }

    private string GetBackgroundMusicName()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        Debug.Log("SceneName=" + sceneName);

        if (sceneName.StartsWith("Level"))
        {
            int levelId = int.Parse(sceneName.Substring(6)); // Substring Level_<level_number>

            return "Level_" + levelId + "Background";
        }

        return "MainMenuBackground";
    }
}
