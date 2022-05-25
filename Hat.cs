using System;

namespace Quest
{
    public class Hat
    {
        public int ShininessLevel { get; set; }

        public string ShininessDescription()
        {
            string description = "";
            if (ShininessLevel < 2)
            {
                description = "dull";
            }
            else if (ShininessLevel >= 2 && ShininessLevel <= 5)
            {
                description = "noticeable";
            }
            else if (ShininessLevel >= 6 && ShininessLevel <= 9)
            {
                description = "bright";
            }
            else if (ShininessLevel > 9)
            {
                description = "blinding";
            }
            return description;
        }
    }
}