using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperGame {
    public class MenuScreen : Screen {

        private GameMain game;
        private SpriteBatch batch;

        private Texture2D bg;
        private Texture2D btnGo;

        private Vector2 bgPos;
        private Vector2 btnGoPos;

        public MenuScreen(GameMain game) : base(game){
            this.game = getGame();

            batch = new SpriteBatch(game.GraphicsDevice);
        }

        override public void Init() {
            base.Init();//does nothing

            btnGo = game.Content.Load<Texture2D>("go");
            bg = game.Content.Load<Texture2D>("greet_gem");
            bgPos = new Vector2(game.GraphicsDevice.Viewport.Width*0.5f - bg.Width*0.5f, game.GraphicsDevice.Viewport.Height*0.35f - bg.Height*0.5f);
            btnGoPos = new Vector2(game.GraphicsDevice.Viewport.Width * 0.5f - btnGo.Width * 0.5f, game.GraphicsDevice.Viewport.Height * 0.6f - btnGo.Height * 0.5f);

        }

        override public void Update(GameTime gameTime) {

            if (Keyboard.GetState().IsKeyDown(Keys.Enter)) {
                game.LoadScreen(game.gameScreen);
            }

        }

        override public void Draw() {
            base.Draw();//does nothing

            batch.Begin();
            batch.Draw(bg, position: bgPos);
            batch.Draw(btnGo, position: btnGoPos);
            batch.End();
            
        }

    }
}
