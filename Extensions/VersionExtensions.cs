using System;

namespace Extensio
{
    public static class VersionExtensions
    {
        /// <summary>
        /// Convert Version string (0.0.0.0) to Version Object
        /// </summary>
        /// <param name="versionString"></param>
        /// <returns></returns>
        public static Version ToVersion(this string versionString)
        {
            if (!string.IsNullOrWhiteSpace(versionString))
            {
                Version toReturn = null;
                if (Version.TryParse(versionString, out toReturn))
                {
                    if (toReturn != null)
                    {
                        return toReturn;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Are the two versions equal
        /// </summary>
        /// <param name="version"></param>
        /// <param name="toCompare"></param>
        /// <returns></returns>
        public static bool IsVersionEqual(this Version version, Version toCompare)
        {
            if (version != null && toCompare != null)
            {
                return version.Equals(toCompare);
            }
            return false;
        }

        /// <summary>
        /// Is the Right hand Version Higher than the Left hand Version?
        /// </summary>
        /// <param name="version"></param>
        /// <param name="isHigher"></param>
        /// <returns></returns>
        public static bool IsVersionHigher(this Version version, Version isHigher)
        {
            if (version != null && isHigher != null)
            {
                return isHigher.CompareTo(version) > 0;
            }
            return false;
        }

        /// <summary>
        /// Is the Right hand Version Lower than the Left hand Version?
        /// </summary>
        /// <param name="version"></param>
        /// <param name="isLower"></param>
        /// <returns></returns>
        public static bool IsVersionLower(this Version version, Version isLower)
        {
            if (version != null && isLower != null)
            {
                return isLower.CompareTo(version) < 0;
            }
            return false;
        }
    }
}
