using System;
using System.Runtime.Serialization;

namespace OOP_ICT.Tools;

public class FirstNullException : ArgumentNullException
{
    public string AdditionalInfo { get; private set; }

    public FirstNullException(string paramName, string additionalInfo) 
        : base(paramName)
    {
        AdditionalInfo = additionalInfo;
    }

    public override string Message => $"Argument '{ParamName}' is null. Additional information: {AdditionalInfo}";

}