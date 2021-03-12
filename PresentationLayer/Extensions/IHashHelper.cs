using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace PresentationLayer.Extensions
{
    interface IHashHelper
    {
         string GetHash(HashAlgorithm hashAlgorithm, string input);

    }
}
