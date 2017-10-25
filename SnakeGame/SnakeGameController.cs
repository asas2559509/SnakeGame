using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace SnakeGame
{
    public class SnakeGameController : Controller
    {
        Timer timer;
        public static int direction2 = 3;

        public SnakeGameController()
        {
            // update the board every one second;
            timer = new Timer(SnakeGameModel.TIME_BASE / SnakeGameModel.Speed);
            timer.Enabled = false;
            timer.Elapsed += this.OnTimedEvent;
        }


        public void KeyUpHandled(KeyboardState ks)
        {
            int play = 1;
            int direction = -1;
            
            Keys[] keys = ks.GetPressedKeys();

            if (keys.Contains(Keys.Up))
            {
                if(direction2 == SnakeGameModel.MOVE_DOWN) { }
                else
                {
                    direction = SnakeGameModel.MOVE_UP;
                    direction2 = SnakeGameModel.MOVE_UP;

                }                
            }
            else if (keys.Contains(Keys.Down))
            {
                if (direction2 == SnakeGameModel.MOVE_UP) { }
                else
                {
                    direction = SnakeGameModel.MOVE_DOWN;
                    direction2 = SnakeGameModel.MOVE_DOWN;

                }
            }
            else if (keys.Contains(Keys.Left))
            {
                if (direction2 == SnakeGameModel.MOVE_RIGHT) { }
                else
                {
                    direction = SnakeGameModel.MOVE_LEFT;
                    direction2 = SnakeGameModel.MOVE_LEFT;

                }
            }
            else if (keys.Contains(Keys.Right))
            {
                if (direction2 == SnakeGameModel.MOVE_LEFT) { }
                else
                {
                    direction = SnakeGameModel.MOVE_RIGHT;
                    direction2 = SnakeGameModel.MOVE_RIGHT;

                }
            }
            else if (keys.Contains(Keys.Space))
            {
                if(timer.Enabled == true)
                {
                    timer.Enabled = false;
                    
                }else
                {
                    timer.Enabled = true;
                    
                }                
            }
            // Find all snakeboard model we know
            if (direction == -1) return;
            foreach (Model m in mList)
            {
                if (m is SnakeGameModel)
                {
                    // Tell the model to update
                    SnakeGameModel sbm = (SnakeGameModel)m;
                    sbm.SetDirection(direction);
                }
            }
        }

        public void Start()
        {
            timer.Enabled = true; 
        }

        public void Stop()
        {
            // Stop the game
            timer.Enabled = false;
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            Snake.Debug("TE");
            foreach (Model m in mList)
            {
                if (m is SnakeGameModel)
                {
                    SnakeGameModel sbm = (SnakeGameModel)m;
                    sbm.Move();
                    sbm.Update();
                }
            }
            timer.Interval = SnakeGameModel.TIME_BASE / SnakeGameModel.Speed;
        }

    }
}
