#region Copyright (C) 2007-2008 Team MediaPortal

/*
    Copyright (C) 2007-2008 Team MediaPortal
    http://www.team-mediaportal.com
 
    This file is part of MediaPortal II

    MediaPortal II is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    MediaPortal II is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with MediaPortal II.  If not, see <http://www.gnu.org/licenses/>.
*/
#endregion
using System;
using System.Collections.Generic;
using System.Text;
using MediaPortal.Presentation.Properties;
using SlimDX;
using SlimDX.Direct3D9;

namespace Presentation.SkinEngine.Controls.Animations
{
  public class PointKeyFrame : IKeyFrame, ICloneable
  {
    Property _keyTimeProperty;
    Property _keyValueProperty;

    #region ctor
    public PointKeyFrame()
    {
      Init();
    }

    public PointKeyFrame(PointKeyFrame k)
    {
      Init();
      KeyTime = k.KeyTime;
      Value = k.Value;
    }

    void Init()
    {
      _keyTimeProperty = new Property(new TimeSpan(0, 0, 0));
      _keyValueProperty = new Property(new Vector2(0, 0));
    }


    public virtual object Clone()
    {
      return new PointKeyFrame(this);
    }
    #endregion

    #region properties
    public Property KeyTimeProperty
    {
      get
      {
        return _keyTimeProperty;
      }
      set
      {
        _keyTimeProperty = value;
      }
    }

    public TimeSpan KeyTime
    {
      get
      {
        return (TimeSpan)_keyTimeProperty.GetValue();
      }
      set
      {
        _keyTimeProperty.SetValue(value);
      }
    }


    public Property ValueProperty
    {
      get
      {
        return _keyValueProperty;
      }
      set
      {
        _keyValueProperty = value;
      }
    }
    public Vector2 Value
    {
      get
      {
        return (Vector2)_keyValueProperty.GetValue();
      }
      set
      {
        _keyValueProperty.SetValue(value);
      }
    }

    object IKeyFrame.Value
    {
      get
      {
        return this.Value;
      }
      set
      {
        this.Value = (Vector2)value;
      }
    }

    public virtual Vector2 Interpolate(Vector2 start, double keyframe)
    {
      return start;
    }
    #endregion
  }
}
