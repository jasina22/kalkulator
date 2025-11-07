using UnityEngine;
using TMPro;

public class Calculator : MonoBehaviour
{
    public TMP_InputField display;

    private string currentInput = "";
    private float firstNumber;
    private string operation;
    private bool isSecondNumber = false;

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
}
