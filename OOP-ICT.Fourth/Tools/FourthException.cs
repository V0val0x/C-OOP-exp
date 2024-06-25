using System;
using System.Runtime.Serialization;

namespace OOP_ICT.Fourth.Tools;

public class FourthException : Exception
{

    public FourthException(string message)
        : base(message)
    {
    }

    public FourthException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    protected FourthException(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
    }
}