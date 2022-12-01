using System;
using System.Collections.Generic;
using System.Linq;

namespace Kogane
{
    public static class LevenshteinDistance
    {
        public static string GetMostSimilarString( this IEnumerable<string> self, string source )
        {
            return self
                    .OrderByDescending( x => CalculateSimilarity( source, x ) )
                    .FirstOrDefault()
                ;
        }

        // https://social.technet.microsoft.com/wiki/contents/articles/26805.c-calculating-percentage-similarity-of-2-strings.aspx
        public static int ComputeLevenshteinDistance( string source, string target )
        {
            if ( ( source == null ) || ( target == null ) ) return 0;
            if ( ( source.Length == 0 ) || ( target.Length == 0 ) ) return 0;
            if ( source == target ) return source.Length;

            var sourceWordCount = source.Length;
            var targetWordCount = target.Length;

            if ( sourceWordCount == 0 ) return targetWordCount;
            if ( targetWordCount == 0 ) return sourceWordCount;

            var distance = new int[ sourceWordCount + 1, targetWordCount + 1 ];

            for ( var i = 0; i <= sourceWordCount; distance[ i, 0 ] = i++ )
            {
            }

            for ( var j = 0; j <= targetWordCount; distance[ 0, j ] = j++ )
            {
            }

            for ( var i = 1; i <= sourceWordCount; i++ )
            {
                for ( var j = 1; j <= targetWordCount; j++ )
                {
                    var cost = ( target[ j - 1 ] == source[ i - 1 ] ) ? 0 : 1;
                    distance[ i, j ] = Math.Min( Math.Min( distance[ i - 1, j ] + 1, distance[ i, j - 1 ] + 1 ), distance[ i - 1, j - 1 ] + cost );
                }
            }

            return distance[ sourceWordCount, targetWordCount ];
        }

        // https://social.technet.microsoft.com/wiki/contents/articles/26805.c-calculating-percentage-similarity-of-2-strings.aspx
        public static double CalculateSimilarity( string source, string target )
        {
            if ( ( source == null ) || ( target == null ) ) return 0.0;
            if ( ( source.Length == 0 ) || ( target.Length == 0 ) ) return 0.0;
            if ( source == target ) return 1.0;

            var stepsToSame = ComputeLevenshteinDistance( source, target );
            return ( 1.0 - ( stepsToSame / ( double )Math.Max( source.Length, target.Length ) ) );
        }
    }
}