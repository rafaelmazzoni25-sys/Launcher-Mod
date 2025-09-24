using System;
using System.Collections.Generic;
using System.Drawing;
using LauncherSuite.Core.Design;

namespace Launcher.Design
{
    internal static class ThemeResources
    {
        private static readonly Dictionary<string, Image> Cache = new Dictionary<string, Image>(StringComparer.OrdinalIgnoreCase);
        private static readonly object SyncRoot = new object();

        public static Image Get(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                return null;
            }

            lock (SyncRoot)
            {
                Image source;
                if (!Cache.TryGetValue(key, out source) || source == null)
                {
                    source = ThemeResourceProvider.GetBuiltin(key);
                    Cache[key] = source;
                }

                if (source == null)
                {
                    return null;
                }

                return new Bitmap(source);
            }
        }

        public static void Set(string key, Image image)
        {
            if (string.IsNullOrEmpty(key) || image == null)
            {
                return;
            }

            lock (SyncRoot)
            {
                Image copy = new Bitmap(image);
                Image existing;
                if (Cache.TryGetValue(key, out existing) && existing != null)
                {
                    existing.Dispose();
                }

                Cache[key] = copy;
            }
        }

        public static void Reset()
        {
            lock (SyncRoot)
            {
                foreach (Image image in Cache.Values)
                {
                    if (image != null)
                    {
                        image.Dispose();
                    }
                }

                Cache.Clear();
            }
        }
    }
}
