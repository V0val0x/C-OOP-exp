using System;
using System.Runtime.Serialization;

namespace OOP_ICT.Second.Tools;

public class SecondException : Exception
{

    public SecondException(string message)
        : base(message)
    {
    }

    public SecondException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    protected SecondException(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
    }
}