﻿using Solution.ValidationLibrary;

namespace Solution.ValidationLibrary.ValidationRules;

public class MaxValueRule<T>(int maxValue) : IValidationRule<T>
{
    public string ValidationMessage { get; set; } = $"Length can't be more than {maxValue}.";

    public bool Check(T value)
    {
        if (!int.TryParse(value?.ToString(), out int data))
        {
            return false;
        }

        return data <= maxValue;
    }
}
