using System;
using System.Collections.Generic;
using System.Text;

namespace Dalilacademy_.Core.Exciptions
{
    public class NotFoundException(string message) : Exception(message);
    public class ConflictException(string message) : Exception(message);
    
}
