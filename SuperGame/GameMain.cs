using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SuperGame {

    public class GameMain : Game {
        GraphicsDeviceManager graphics;
        Screen currentScreen;

        public MenuScreen menuScreen;
        public GameScreen gameScreen;

        public GameMain() {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

        }

        protected override void Initialize() {
            base.Initialize();

            menuScreen = new MenuScreen(this);
            gameScreen = new GameScreen(this);

            LoadScreen(menuScreen);
        }

        protected override void LoadContent() {
        }

        protected override void UnloadContent() {


        }

        protected override void Update(GameTime gameTime) {
            currentScreen.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            currentScreen.Draw();

            base.Draw(gameTime);
        }

        public void LoadScreen(Screen sc) {
            currentScreen = sc;
            currentScreen.Init();
        }

    }

}
