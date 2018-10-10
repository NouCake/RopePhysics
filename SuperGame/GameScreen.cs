using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperGame {
    public class GameScreen : Screen {

        private GameMain game;
        private SpriteBatch batch;

        private Rope r;

        public GameScreen(GameMain game) : base(game) {
            this.game = getGame();

        }

        public override void Init() {
            base.Init();

            batch = new SpriteBatch(game.GraphicsDevice);
            r = new Rope(game, new Vector2(300, 50), 100, 20, 10);
        }

        public override void Update(GameTime gameTime) {
            base.Update(gameTime);

            r.Update(gameTime);
        }

        public override void Draw() {
            base.Draw();

            batch.Begin();
            r.Draw(batch);
            batch.End();
        }

    }
}
