using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HashCodeChecker : MonoBehaviour
{
    public TMP_InputField inputField; 
    public GameObject[] imagenezzzz;       
    public int[] tags;                

    
    public void OnInputChanged()
    {
        string input = inputField.text;
        int hashCode = CalculateHash(input);

        Debug.Log("Input: " + input + ", HashCode: " + hashCode); 

        
        for (int i = 0; i < imagenezzzz.Length; i++)
        {
            if (tags[i] == hashCode)
            {
                imagenezzzz[i].SetActive(true);
                Debug.Log("Activando: " + tags[i]);
            }
            else
            {
                imagenezzzz[i].SetActive(false);
                Debug.Log("Desactivando: " + tags[i]);
            }
        }
    }

   
    public int CalculateHash(string input)
    {
        int hashCode = 0;
        for (int i = 0; i < input.Length; i++)
        {
            hashCode += (int)input[i];
        }
        Debug.Log("Hash Calculado para " + input + ": " + hashCode); 
        return hashCode;
    }
}
