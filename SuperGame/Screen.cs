using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperGame {

    public class Screen {

        private GameMain game;

        public Screen(GameMain game) {
            this.game = game;
        }

        virtual public void Init() {

        }

        virtual public void Update(GameTime gameTime) {

        }

        virtual public void Draw() {

        }

        protected GameMain getGame() {
            return game;
        }

    }

}
