using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceCombatDemo.InputLogic
{
    public static class Input
    {
        public static KeyboardState KeyboardState { get; private set; }

        public static KeyboardState OldKeyboardState { get; private set; }

        public static MouseState MouseState { get; private set; }

        public static MouseState OldMouseState { get; private set; }

        public static Vector2 MousePosition { get; private set; }

        internal static void Update(Game game)
        {
            OldKeyboardState = KeyboardState;
            KeyboardState = Keyboard.GetState();

            MouseState currentMouseState = Mouse.GetState(game.Window);
            if (currentMouseState.X != MouseState.X || currentMouseState.Y != MouseState.Y)
                MousePosition = new Vector2(currentMouseState.X, currentMouseState.Y);

            OldMouseState = MouseState;
            MouseState = currentMouseState;
        }

        public static bool IsKeyDown(Keys key) => KeyboardState.IsKeyDown(key);

        public static bool IsOldKeyDown(Keys key) => OldKeyboardState.IsKeyDown(key);

        public static bool PostClick(Keys key) => !IsKeyDown(key) && IsOldKeyDown(key);

        public static bool OnClick(Keys key) => IsKeyDown(key) && !IsOldKeyDown(key);
    }
}
