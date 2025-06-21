using System;

namespace Tiled2Unity
{
    [AttributeUsage(AttributeTargets.Class)]
    public class CustomTiledImporterAttribute : Attribute
    {
        public int Order { get; set; }
    }
}
