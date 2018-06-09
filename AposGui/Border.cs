﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using MonoGame.Extended.BitmapFonts;

namespace AposGameCheatSheet.AposGui
{
    /// <summary>
    /// Goal: A text component.
    /// </summary>
    class Border : Component
    {
        public Border() : this(new Component()) {
        }
        public Border(Component iC) : this(iC, 0, 0, 0, 0) {
        }
        public Border(Component iC, int iMarginLeft, int iMarginTop, int iMarginRight, int iMarginBottom) {
            Item = iC;
            Item.Parent = this;
            MarginLeft = iMarginLeft;
            MarginTop = iMarginTop;
            MarginRight = iMarginRight;
            MarginBottom = iMarginBottom;
        }
        Component Item;
        public override Point Position {
            get => base.Position;
            set {
                base.Position = value;
                if (Item != null) {
                    Item.Position = base.Position + new Point(MarginLeft, MarginTop);
                }
            }
        }
        public override int Width {
            get => base.Width;
            set {
                base.Width = value;
                if (Item != null) {
                    Item.Width = base.Width - MarginLeft - MarginRight;
                }
            }
        }
        public override int Height {
            get => base.Height;
            set {
                base.Height = value;
                if (Item != null) {
                    Item.Height = base.Height - MarginTop - MarginBottom;
                }
            }
        }
        public virtual int MarginLeft {
            get; set;
        }
        public virtual int MarginTop {
            get; set;
        }
        public virtual int MarginRight {
            get; set;
        }
        public virtual int MarginBottom {
            get; set;
        }
        public override Component GetFinal() {
            if (Item != null) {
                return Item;
            }
            return this;
        }
        public override bool UpdateInput() {
            return Item.UpdateInput();
        }
        public override void Update() {
            Item.Update();
        }
        public override void Draw(SpriteBatch s, Rectangle clipRect) {
            clipRect = ClipRectangle(clipRect);
            Item.Draw(s, clipRect);
        }
        public override int PrefWidth => Item.PrefWidth + MarginLeft + MarginRight;
        public override int PrefHeight => Item.PrefHeight + MarginTop + MarginBottom;
    }
}
