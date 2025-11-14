using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class Calculator : MonoBehaviour
{
    public TMP_InputField display;

    private string currentInput = "";
    private float firstNumber;
    private string operation;
    private bool isSecondNumber = false;

   
    private List<float> results = new List<float>();

    public void OnNumberClick(string number)
    {
        currentInput += number;
        display.text = currentInput;
    }

    public void OnOperationClick(string op)
    {
        if (float.TryParse(currentInput, out firstNumber))
        {
            operation = op;
            currentInput = "";
            isSecondNumber = true;
        }
    }

    public void OnEqualClick()
    {
        if (float.TryParse(currentInput, out float secondNumber))
        {
            float result = 0;

            switch (operation)
            {
                case "+": result = firstNumber + secondNumber; break;
                case "-": result = firstNumber - secondNumber; break;
                case "*": result = firstNumber * secondNumber; break;
                case "/":
                    result = secondNumber != 0 ? firstNumber / secondNumber : 0;
                    break;
            }

            
            display.text = result.ToString();

            
            results.Add(result);

            
            currentInput = result.ToString();
            isSecondNumber = false;
        }
    }

    public void OnClearClick()
    {
        currentInput = "";
        firstNumber = 0;
        operation = "";
        display.text = "";
    }

    
    public void OnShowMaxResultClick()
    {
        if (results.Count > 0)
        {
            float maxValue = Mathf.Max(results.ToArray());
            display.text = "Max: " + maxValue;
        }
        else
        {
            display.text = "Brak wyników";
        }
    }
}
