using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperGame {
    class Rope {

        private RopeSegment ropeStart;
        private RopeSegment ropeEnd;

        private GameMain game;

        private Texture2D baseTexture;
        private int BASE_LENGTH = 100;
        private int BASE_WIDTH = 5;


        public Rope(GameMain game, Vector2 pos, int length, float strength, float weight) {
            this.game = game;
            createSegments(pos, length, length/8, strength, weight);
            createBaseTexture();

            ropeStart.setFixed(true);
        }

        private void createSegments(Vector2 pos, int targetLength, int segments, float strength, float weight) {
            RopeSegment tmp = null;
            float weightPerSegment = targetLength / 100f * weight / segments;
            for (int i = 0; i < segments; i++) {
                RopeSegment seg = new RopeSegment(this, new Vector2(pos.X + (targetLength / segments - 1) * i, pos.Y), (targetLength / segments - 1), strength, weightPerSegment);
                if (ropeStart == null) {
                    ropeStart = seg;
                }
                if (tmp != null) {
                    tmp.setNext(seg);
                }
                seg.setLast(tmp);
                tmp = seg;
            }
            ropeEnd = tmp;
        }

        private void createBaseTexture() {
            baseTexture = new Texture2D(game.GraphicsDevice, BASE_LENGTH, BASE_WIDTH);
            Color[] data = new Color[baseTexture.Width * baseTexture.Height];
            for (int i = 0; i < data.Length; i++) {
                data[i] = Color.Chocolate;
            }
            baseTexture.SetData(data);
        }

        public void Update(GameTime gameTime) {
            MouseState mouse = Mouse.GetState();
            if(mouse.LeftButton == ButtonState.Pressed) {
                //ropeEnd.addForce(new Vector2(mouse.X, mouse.Y) - ropeEnd.getPos());
                //ropeEnd.setPos(new Vector2(mouse.X, mouse.Y));

                ropeEnd.addForce(new Vector2(100 * gameTime.ElapsedGameTime.Milliseconds / 1000f, 0));
            }

            if (mouse.RightButton == ButtonState.Pressed) {
                ropeEnd.addForce(new Vector2(-100 * gameTime.ElapsedGameTime.Milliseconds / 1000f, 0));
            }

            ropeEnd.addForce(new Vector2(0, 100 * 9.81f * ));

            //ropeEnd.addForce(new Vector2(0, 1000*  9.81f * gameTime.ElapsedGameTime.Milliseconds/1000f));

            updateForce(gameTime);
            updatePhysics(gameTime);
        }

        private void updatePhysics(GameTime gameTime) {
            RopeSegment current = ropeStart;

            while (current != null) {
                current.updatePhysics(gameTime);
                current = current.getNext();
            }
        }
        
        private void updateForce(GameTime gameTime) {
            RopeSegment current = ropeStart;

            while(current != null) {
                current.updateForce(gameTime);
                current = current.getNext();
            }
        }

        public void Draw(SpriteBatch batch) {
            RopeSegment current = ropeStart;

            while(current.getNext() != null) {
                drawBetweenSegments(current, current.getNext(), batch);
                current = current.getNext();
            }
        }

        private void drawBetweenSegments(RopeSegment one, RopeSegment two, SpriteBatch batch) {
            Vector2 dist = two.getPos() - one.getPos();
            float rotation = (float)Math.Atan2(dist.Y, dist.X);
            Vector2 scale = new Vector2(dist.Length() / BASE_LENGTH, 1);
            float sc = (one.targetLength / dist.Length());
            if (sc < 0) sc = 0;
            Color color = new Color(1-sc, sc, 0);
            batch.Draw(baseTexture, position: one.getPos(), scale: scale, rotation: rotation, color: color, origin: new Vector2(0, 2.5f));
            //batch.Draw(baseTexture, position: one.getPos(), scale: new Vector2(5/100f, 1));
        }

        public void setEnd(Vector2 pos) {
            ropeEnd.setPos(pos);
        }


    }
}
