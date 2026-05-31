using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] audioClips; // Array untuk menyimpan berbagai klip audio
    AudioSource audioSource; // Komponen AudioSource untuk memutar suara
    public static AudioManager singleton; // Singleton instance untuk akses global


    void Awake()
    {
        audioSource = GetComponent<AudioSource>(); // Ambil komponen AudioSource dari GameObject ini
        singleton = this; // Set singleton instance
    }

    public void PlayAudio(int index)
    {
        audioSource.PlayOneShot(audioClips[index]); // Putar klip audio berdasarkan indeks yang diberikan
        // bisa juga memakai audioSource.Play(); 
    }
}
