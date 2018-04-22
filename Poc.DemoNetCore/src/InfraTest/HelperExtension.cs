using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace InfraTest
{
    public static class HelperExtension
    {
        public static void NotNull(this object obj)
        {
            Assert.NotNull(obj);
        }
        public static void Null(this object obj)
        {
            Assert.Null(obj);
        }
        public static void NotNull(this IEnumerable<object> obj)
        {

            Assert.False(obj == null, "Lista Vazia, Verifique o include");

            if (obj != null && !obj.Any())
            {
                Assert.Inconclusive($"Lista vazia, Tabela vazia");
            }
        }
        public static void True(this IEnumerable<object> obj)
        {

            Assert.False(obj == null,"Lista Vazia, Verifique o include");

            if (obj != null && !obj.Any())
            {
                Assert.Inconclusive($"Lista vazia, Tabela vazia");
            }
           
        }

    
    }
}
