using System;

namespace SKV.ML.Metadata
{
    public enum ParameterSource
    {
        String,
        Resource
    }

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class TitleAttribute : Attribute
    {
        public ParameterSource Source { get; set; }

        public string Title { get; set; } = default(string);
    }

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class IconAttribute : Attribute
    {
        public string IconClass { get; set; }
    }
}
