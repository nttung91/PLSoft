using System;
using System.Collections.Generic;
using System.Drawing;

namespace Windows.Core.Forms.Navigator.Interfaces
{
    public interface ITreeNodeIconBuilder
    {
        Dictionary<Type, Bitmap> BuildTreeIcons();
    }
}