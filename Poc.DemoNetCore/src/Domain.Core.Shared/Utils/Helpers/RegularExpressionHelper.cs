using System;
using System.Collections.Generic;
using System.Text;

namespace Poc.DemoNetCore.Domain.Shared.Utils.Helpers
{
    public static class RegularExpressionHelper
    {
        // referência https://stackoverflow.com/questions/3518504/regular-expression-for-matching-latitude-longitude-coordinates

        public const string Latitude = @"^(\\+|-)?(?:90(?:(?:\\.0{1,6})?)|(?:[0-9]|[1-8][0-9])(?:(?:\\.[0-9]{1,6})?))$";
        public const string Longitude = @"^(\\+|-)?(?:180(?:(?:\\.0{1,6})?)|(?:[0-9]|[1-9][0-9]|1[0-7][0-9])(?:(?:\\.[0-9]{1,6})?))$";
    }
}
