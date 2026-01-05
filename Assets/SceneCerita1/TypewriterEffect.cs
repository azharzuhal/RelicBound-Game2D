using System.Collections;
using UnityEngine;
using UnityEngine.UI; // PENTING: Pakai UI biasa, bukan TMPro

public class TypewriterEffect : MonoBehaviour
{
    // Kecepatan ketik (0.05 detik per huruf)
    [SerializeField] private float delayPerChar = 0.05f;

    // Perhatikan tipe datanya sekarang 'Text', bukan 'TMP_Text'
    public IEnumerator Run(string textToType, Text textLabel)
    {
        textLabel.text = ""; // Hapus teks lama

        // Loop huruf per huruf
        foreach (char c in textToType)
        {
            textLabel.text += c;
            yield return new WaitForSeconds(delayPerChar);
        }
    }
}