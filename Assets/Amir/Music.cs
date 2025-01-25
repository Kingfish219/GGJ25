using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource backgroundAudioSource; // برای صدای بک‌گراند
    public AudioSource randomAudioSource; // برای صداهای تصادفی
    public AudioClip[] randomClips; // آرایه‌ای از صداهای تصادفی
    public float randomIntervalMin = 5f; // حداقل فاصله زمانی بین پخش صداها
    public float randomIntervalMax = 15f; // حداکثر فاصله زمانی بین پخش صداها

    private float timer;

    void Start()
    {
        // شروع پخش صدای بک‌گراند به صورت لوپ
        if (backgroundAudioSource != null)
        {
            backgroundAudioSource.loop = true;
            backgroundAudioSource.Play();
        }

        // تنظیم تایمر برای اولین پخش تصادفی
        ResetTimer();
    }

    void Update()
    {
        // شمارش زمان برای پخش صداهای تصادفی
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            PlayRandomSound();
            ResetTimer();
        }
    }

    void PlayRandomSound()
    {
        if (randomAudioSource != null && randomClips.Length > 0)
        {
            // انتخاب تصادفی یک کلیپ
            AudioClip clip = randomClips[Random.Range(0, randomClips.Length)];
            randomAudioSource.PlayOneShot(clip);
        }
    }

    void ResetTimer()
    {
        // تنظیم تایمر برای پخش بعدی
        timer = Random.Range(randomIntervalMin, randomIntervalMax);
    }
}
